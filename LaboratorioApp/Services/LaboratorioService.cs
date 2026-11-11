using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LaboratorioApp.Data;
using LaboratorioApp.Models;

namespace LaboratorioApp.Services
{
    public class LaboratorioService
    {
        private readonly LaboratorioContext _context;

        public LaboratorioService()
        {
            _context = new LaboratorioContext();

            // Seed Data: Inicializa equipos base en la BD si la tabla está vacía
            if (!_context.Equipos.Any())
            {
                _context.Equipos.Add(new Equipo("EQ-01", "Osciloscopio Digital", 2));
                _context.Equipos.Add(new Equipo("EQ-02", "Multímetro", 3));
                _context.Equipos.Add(new Equipo("EQ-03", "Fuente de Poder", 1));
                _context.SaveChanges();
            }
        }

        public List<Equipo> ObtenerEquipos()
        {
            return _context.Equipos.ToList();
        }

        public List<Prestamo> ObtenerPrestamosActivos()
        {
            return _context.Prestamos
                .Where(p => p.Estado != EstadoPrestamo.Devuelto)
                .ToList();
        }

        public void RegistrarEstudiante(string id, string nombre)
        {
            var estudianteExistente = _context.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
            if (estudianteExistente == null)
            {
                _context.Estudiantes.Add(new Estudiante(id, nombre));
                _context.SaveChanges();
            }
        }

        public (bool Exito, string Mensaje) Prestar(string idEstudiante, string idEquipo, DateTime fechaInicio, int diasLimite = 7)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.IdEstudiante == idEstudiante);
            if (estudiante == null) return (false, "El estudiante no está registrado.");

            var equipo = _context.Equipos.FirstOrDefault(eq => eq.IdEquipo == idEquipo);
            if (equipo == null) return (false, "El equipo no existe en el inventario.");

            if (!equipo.EstaDisponible())
                return (false, $"No hay unidades disponibles de {equipo.Nombre}.");

            int prestamosActivosCount = _context.Prestamos
                .Count(p => p.IdEstudiante == idEstudiante && (p.Estado == EstadoPrestamo.Activo || p.Estado == EstadoPrestamo.Atrasado));

            if (prestamosActivosCount >= 3)
                return (false, "El estudiante superó el límite de 3 préstamos activos.");

            int totalPrestamos = _context.Prestamos.Count() + 1;
            var nuevoPrestamo = new Prestamo(
                $"P-{totalPrestamos:D3}",
                idEstudiante,
                idEquipo,
                fechaInicio,
                fechaInicio.AddDays(diasLimite)
            );

            equipo.CantidadPrestados++;
            _context.Prestamos.Add(nuevoPrestamo);
            _context.SaveChanges();

            return (true, $"Préstamo exitoso. ID: {nuevoPrestamo.IdPrestamo}. Fecha Límite: {nuevoPrestamo.FechaLimite:yyyy-MM-dd}");
        }

        public (bool Exito, string Mensaje) Devolver(string idPrestamo, DateTime fechaDevolucion)
        {
            var prestamo = _context.Prestamos.FirstOrDefault(p => p.IdPrestamo == idPrestamo);
            if (prestamo == null) return (false, "Préstamo no encontrado. Verifique el ID.");

            if (prestamo.Estado == EstadoPrestamo.Devuelto) return (false, "Este equipo ya fue devuelto previamente.");

            prestamo.FechaDev = fechaDevolucion;
            prestamo.Estado = EstadoPrestamo.Devuelto;

            var equipo = _context.Equipos.FirstOrDefault(e => e.IdEquipo == prestamo.IdEquipo);
            if (equipo != null && equipo.CantidadPrestados > 0)
            {
                equipo.CantidadPrestados--;
            }

            _context.SaveChanges();
            return (true, "Devolución registrada correctamente.");
        }

        public List<string> VerificarMora(DateTime fechaActual)
        {
            var alertas = new List<string>();
            var prestamosActivos = _context.Prestamos.Where(p => p.Estado != EstadoPrestamo.Devuelto).ToList();

            foreach (var prestamo in prestamosActivos)
            {
                if (prestamo.EvalAtrasado(fechaActual))
                {
                    prestamo.Estado = EstadoPrestamo.Atrasado;
                    alertas.Add($"El préstamo {prestamo.IdPrestamo} del estudiante {prestamo.IdEstudiante} está vencido.");
                }
            }
            _context.SaveChanges();
            return alertas;
        }
    }
}