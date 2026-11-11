-- ==========================================
-- SCRIPT COMPLETO DE BASE DE DATOS
-- Sistema de Gestión de Laboratorio
-- ==========================================

USE LaboratorioDb;
GO

-- 1. TABLAS E INTEGRIDAD DE DATOS
IF OBJECT_ID('dbo.Prestamos', 'U') IS NOT NULL DROP TABLE dbo.Prestamos;
IF OBJECT_ID('dbo.Equipos', 'U') IS NOT NULL DROP TABLE dbo.Equipos;
IF OBJECT_ID('dbo.Estudiantes', 'U') IS NOT NULL DROP TABLE dbo.Estudiantes;
GO

CREATE TABLE Equipos (
    IdEquipo VARCHAR(20) NOT NULL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CantidadTotal INT NOT NULL DEFAULT 0 CHECK (CantidadTotal >= 0),
    CantidadPrestados INT NOT NULL DEFAULT 0 CHECK (CantidadPrestados >= 0),
    CONSTRAINT CK_Equipos_Disponibles CHECK (CantidadPrestados <= CantidadTotal)
);

CREATE TABLE Estudiantes (
    IdEstudiante VARCHAR(20) NOT NULL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Prestamos (
    IdPrestamo VARCHAR(20) NOT NULL PRIMARY KEY,
    FechaInicio DATETIME NOT NULL,
    FechaLimite DATETIME NOT NULL,
    FechaDev DATETIME NULL,
    Estado INT NOT NULL DEFAULT 0 CHECK (Estado IN (0, 1, 2)),
    IdEstudiante VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Estudiantes(IdEstudiante),
    IdEquipo VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Equipos(IdEquipo),
    CONSTRAINT CK_Prestamos_Fechas CHECK (FechaLimite >= FechaInicio)
);
GO

-- 2. VISTAS (REPORTES Y CONSULTAS)
IF OBJECT_ID('dbo.vw_ReporteInventario', 'V') IS NOT NULL DROP VIEW dbo.vw_ReporteInventario;
GO
CREATE VIEW vw_ReporteInventario AS
SELECT e.IdEquipo, e.Nombre, e.CantidadTotal, e.CantidadPrestados,
       (e.CantidadTotal - e.CantidadPrestados) AS UnidadesDisponibles,
       CASE WHEN e.CantidadPrestados < e.CantidadTotal THEN 'Disponible' ELSE 'Sin Stock' END AS EstadoDisponibilidad
FROM Equipos e;
GO

IF OBJECT_ID('dbo.vw_PrestamosActivos', 'V') IS NOT NULL DROP VIEW dbo.vw_PrestamosActivos;
GO
CREATE VIEW vw_PrestamosActivos AS
SELECT p.IdPrestamo, est.IdEstudiante, est.Nombre AS NombreEstudiante,
       eq.IdEquipo, eq.Nombre AS NombreEquipo, p.FechaInicio, p.FechaLimite, p.Estado,
       CASE p.Estado WHEN 0 THEN 'Activo' WHEN 1 THEN 'Devuelto' WHEN 2 THEN 'Atrasado' END AS EstadoTexto,
       DATEDIFF(DAY, p.FechaLimite, GETDATE()) AS DiasDeRetraso
FROM Prestamos p
INNER JOIN Estudiantes est ON p.IdEstudiante = est.IdEstudiante
INNER JOIN Equipos eq ON p.IdEquipo = eq.IdEquipo
WHERE p.Estado != 1;
GO

-- 3. PROCEDIMIENTOS ALMACENADOS (LÓGICA DE NEGOCIO)
IF OBJECT_ID('dbo.sp_RegistrarPrestamo', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_RegistrarPrestamo;
GO
CREATE PROCEDURE sp_RegistrarPrestamo
    @p_IdPrestamo VARCHAR(20), @p_IdEstudiante VARCHAR(20), @p_IdEquipo VARCHAR(20),
    @p_FechaInicio DATETIME, @p_DiasLimite INT = 7,
    @p_Exito TINYINT OUTPUT, @p_Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF @p_DiasLimite IS NULL OR @p_DiasLimite = 0 SET @p_DiasLimite = 7;
    BEGIN TRANSACTION;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM Estudiantes WHERE IdEstudiante = @p_IdEstudiante)
        BEGIN SET @p_Exito = 0; SET @p_Mensaje = 'El estudiante no está registrado.'; ROLLBACK; RETURN; END

        DECLARE @v_NombreEquipo VARCHAR(100), @v_CantTotal INT, @v_CantPrest INT;
        SELECT @v_NombreEquipo = Nombre, @v_CantTotal = CantidadTotal, @v_CantPrest = CantidadPrestados
        FROM Equipos WHERE IdEquipo = @p_IdEquipo;

        IF @v_NombreEquipo IS NULL
        BEGIN SET @p_Exito = 0; SET @p_Mensaje = 'El equipo no existe en el inventario.'; ROLLBACK; RETURN; END
        IF @v_CantPrest >= @v_CantTotal
        BEGIN SET @p_Exito = 0; SET @p_Mensaje = CONCAT('No hay unidades disponibles de ', @v_NombreEquipo, '.'); ROLLBACK; RETURN; END

        DECLARE @v_PrestamosActivos INT;
        SELECT @v_PrestamosActivos = COUNT(*) FROM Prestamos WHERE IdEstudiante = @p_IdEstudiante AND Estado IN (0, 2);
        IF @v_PrestamosActivos >= 3
        BEGIN SET @p_Exito = 0; SET @p_Mensaje = 'El estudiante superó el límite de 3 préstamos activos.'; ROLLBACK; RETURN; END

        DECLARE @v_FechaLimite DATETIME = DATEADD(DAY, @p_DiasLimite, @p_FechaInicio);
        INSERT INTO Prestamos (IdPrestamo, FechaInicio, FechaLimite, Estado, IdEstudiante, IdEquipo)
        VALUES (@p_IdPrestamo, @p_FechaInicio, @v_FechaLimite, 0, @p_IdEstudiante, @p_IdEquipo);

        UPDATE Equipos SET CantidadPrestados = CantidadPrestados + 1 WHERE IdEquipo = @p_IdEquipo;

        SET @p_Exito = 1;
        SET @p_Mensaje = CONCAT('Préstamo exitoso. ID: ', @p_IdPrestamo, '. Fecha Límite: ', CONVERT(VARCHAR(10), @v_FechaLimite, 23));
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        SET @p_Exito = 0; SET @p_Mensaje = 'Error interno al registrar el préstamo.';
    END CATCH
END;
GO

IF OBJECT_ID('dbo.sp_RegistrarDevolucion', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_RegistrarDevolucion;
GO
CREATE PROCEDURE sp_RegistrarDevolucion
    @p_IdPrestamo VARCHAR(20), @p_FechaDevolucion DATETIME,
    @p_Exito TINYINT OUTPUT, @p_Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @v_IdEquipo VARCHAR(20), @v_EstadoActual INT;
        SELECT @v_IdEquipo = IdEquipo, @v_EstadoActual = Estado FROM Prestamos WHERE IdPrestamo = @p_IdPrestamo;

        IF @v_IdEquipo IS NULL
        BEGIN SET @p_Exito = 0; SET @p_Mensaje = 'Préstamo no encontrado. Verifique el ID.'; ROLLBACK; RETURN; END
        IF @v_EstadoActual = 1
        BEGIN SET @p_Exito = 0; SET @p_Mensaje = 'Este equipo ya fue devuelto previamente.'; ROLLBACK; RETURN; END

        UPDATE Prestamos SET FechaDev = @p_FechaDevolucion, Estado = 1 WHERE IdPrestamo = @p_IdPrestamo;
        UPDATE Equipos SET CantidadPrestados = CantidadPrestados - 1 WHERE IdEquipo = @v_IdEquipo AND CantidadPrestados > 0;

        SET @p_Exito = 1; SET @p_Mensaje = 'Devolución registrada correctamente.';
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        SET @p_Exito = 0; SET @p_Mensaje = 'Error interno al registrar la devolución.';
    END CATCH
END;
GO

IF OBJECT_ID('dbo.sp_VerificarMora', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_VerificarMora;
GO
CREATE PROCEDURE sp_VerificarMora
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Prestamos SET Estado = 2 WHERE Estado = 0 AND FechaLimite < GETDATE();
    SELECT p.IdPrestamo, p.IdEstudiante, est.Nombre AS NombreEstudiante, p.IdEquipo, eq.Nombre AS NombreEquipo,
           p.FechaLimite, DATEDIFF(DAY, p.FechaLimite, GETDATE()) AS DiasDeRetraso
    FROM Prestamos p
    INNER JOIN Estudiantes est ON p.IdEstudiante = est.IdEstudiante
    INNER JOIN Equipos eq ON p.IdEquipo = eq.IdEquipo
    WHERE p.Estado = 2;
END;
GO

-- 4. SEED DATA (DATOS SEMILLA)
INSERT INTO Equipos (IdEquipo, Nombre, CantidadTotal, CantidadPrestados)
VALUES ('EQ-01', 'Osciloscopio Digital', 2, 0),
       ('EQ-02', 'Multímetro', 3, 0),
       ('EQ-03', 'Fuente de Poder', 1, 0);
GO