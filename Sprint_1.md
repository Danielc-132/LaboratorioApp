# 🧪 LaboratorioApp - Sistema de Gestión de Préstamos

## 📌 Estado del Proyecto: Backend y Lógica de Negocio Completados (Sprint 1)

Este repositorio contiene la arquitectura base y la lógica de negocio para el sistema de gestión de inventario y préstamos de equipos de laboratorio. El proyecto está estructurado aplicando el principio de **Separación de Responsabilidades (Separation of Concerns)**, preparando el código para una futura integración con Windows Forms y Entity Framework Core (SQL Server).

### 🏗️ Arquitectura Actual

El código se divide en dos capas principales:

1. **Capa de Dominio (`/Models`)**: 
   - Contiene las entidades puras: `Equipo`, `Estudiante` y `Prestamo`.
   - Se implementaron las propiedades de navegación y llaves primarias (`[Key]`) requeridas para el futuro mapeo relacional (ORM).
   - `Prestamo.cs` incluye la regla de validación de políticas de negocio (límite de 3 préstamos por estudiante y disponibilidad de stock).

2. **Capa de Servicios (`/Services`)**:
   - `LaboratorioService.cs` actúa como el gestor central.
   - Maneja el estado temporal en memoria (listas privadas) simulando el comportamiento transaccional de una base de datos.
   - Retorna respuestas estructuradas (Tuplas `(bool Exito, string Mensaje)`) en lugar de interactuar directamente con la consola, permitiendo desacoplar la lógica de la interfaz de usuario.

### ✅ Funcionalidades Implementadas (Historias de Usuario)

- **[HU-01] Registro Automático de Estudiantes:** Creación de perfil de estudiante "al vuelo" si no existe en el sistema al intentar realizar un préstamo.
- **[HU-03] Asignación de Préstamo:** Vinculación transaccional entre `Estudiante` y `Equipo`, con cálculo automático de fechas de vencimiento y actualización de inventario.
- **[HU-04] Validación de Límites:** Bloqueo de préstamos si el equipo no tiene stock o si el estudiante posee 3 o más préstamos activos/atrasados.
- **[HU-05] Registro de Devolución:** Cierre del ciclo del préstamo, liberación de stock y actualización de estados (`Devuelto`).
- **[HU-06] Reporte de Inventario:** Generación de un reporte tabular en texto con las cantidades totales, prestadas y disponibles.
- **Control de Mora:** Evaluación iterativa de fechas de vencimiento para marcar transacciones como `Atrasado`.

### 🚀 Próximos Pasos (Siguientes Fases)

- **Fase UI:** Diseño e implementación de la interfaz gráfica utilizando Windows Forms (DataGrids, Formularios de entrada, Alertas).
- **Fase de Persistencia:** Reemplazo de las listas en memoria por persistencia real utilizando **Entity Framework Core** y **SQL Server**.
