using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static LaboratorioApp.Models.Estudiante;

namespace LaboratorioApp.Models
{
    public enum EstadoPrestamo
    {
        Activo,
        Devuelto,
        Atrasado,
    }

    public class Equipo
    {
        [Key] //indica la llave primaria para sql
        public string IdEquipo { get; set; }
        public string Nombre {  get; set; }
        public int CantidadTotal { get; set; }
        public int CantidadPrestados {  get; set; }

        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public Equipo() {  } //Constructor para sql
        
        public Equipo(string idEquipo, string nombre, int cantidadTotal)
        {
            IdEquipo = idEquipo;
            Nombre = nombre;
            CantidadTotal = cantidadTotal;
            CantidadPrestados = 0;
        }

        public bool EstaDisponible()
        {
            return CantidadPrestados < CantidadTotal;
        }

        public int UnidadesDisponibles()
        {
            return CantidadTotal - CantidadPrestados;
        }
    }

    public class Estudiante
    {
        [Key]
        public string IdEstudiante { get; set; }
        public string Nombre { get; set; }

        public List<Prestamo> HistorialPrestamos { get; set; } = new List<Prestamo>();

        public Estudiante () { } //constructor sql

        public Estudiante(string idEstudiante, string nombre)
        {
            IdEstudiante = idEstudiante;
            Nombre = nombre;
        }

        public List<Prestamo> ConsultarPrestamosActivos()
        {
            return HistorialPrestamos
                .Where(p => p.Estado == EstadoPrestamo.Activo || p.Estado == EstadoPrestamo.Atrasado)
                .ToList();
        }

        }

    public class Prestamo
    {
        [Key]
        public string IdPrestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaDev { get; set; }
        public EstadoPrestamo Estado { get; set; }

        //llaves foraneas
        public string IdEstudiante { get; set; }
        public string IdEquipo { get; set; }

        public Estudiante Estudiante { get; set; }
        public Equipo Equipo { get; set; }

        public Prestamo() { } //constructor sql

        public Prestamo(string idPrestamo, string idEstduiante, string idEquipo, DateTime fechaInicio, DateTime fechaLimite)
        {
            IdPrestamo = idPrestamo;
            IdEstudiante = idEstduiante;
            IdEquipo = idEquipo;
            FechaInicio = fechaInicio;
            FechaLimite = fechaLimite;
            FechaDev = null;
            Estado = EstadoPrestamo.Activo;
        }

        public (bool EsValido, String MensajeError) ValidarPolitica(Estudiante estudianteConDatos, Equipo equipoConDatos)
        {
            if (!equipoConDatos.EstaDisponible())
            {
                return (false, $"No hay unidades disponibles de {equipoConDatos.Nombre}.");
            }

            if (estudianteConDatos.ConsultarPrestamosActivos().Count >= 3)
            {
                return (false, $"{estudianteConDatos.Nombre} ya tiene 3 prestamos sin devolver");
            }

            return (true, string.Empty);
        }

        public bool EvalAtrasado(DateTime fechaActual)
        {
            return Estado == EstadoPrestamo.Activo && fechaActual > FechaLimite;
        }
    }
}