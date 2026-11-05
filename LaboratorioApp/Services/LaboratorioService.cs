using System;
using System.Collections.Generic;
using System.Linq;
using LaboratorioApp.Models;

namespace LaboratorioApp.Services
{
    public class LaboratorioService
    {
        private List<Equipo> _equiposFisicos;
        private List<Estudiante> _estudiantes;
        private List<Prestamo> _prestamos;
        private int _contadorPrestamos = 1;

        public LaboratorioService()
        {
            // Inicializamos usando constructor de Equipo
            _equiposFisicos = new List<Equipo>
            {
                new Equipo("EQ-01", "Osciloscopio Digital", 2),
                new Equipo("EQ-02", "Multímetro", 3),
                new Equipo("EQ-03", "Fuente de Poder", 1)
            };
            _estudiantes = new List<Estudiante>();
            _prestamos = new List<Prestamo>();
        }

        public List<Equipo> ObtenerEquipos() => _equiposFisicos;

        public List<Prestamo> ObtenerPrestamosActivos() => _prestamos.Where(p => p.Estado != EstadoPrestamo.Devuelto).ToList();

        public void RegistrarEstudiante(string id, string nombre)
        {
            if (!_estudiantes.Any(e => e.IdEstudiante.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                // Usamos tu constructor de Estudiante
                _estudiantes.Add(new Estudiante(id, nombre));
            }
        }

        public (bool Exito, string Mensaje) Prestar(string idEstudiante, string idEquipo, DateTime fechaInicio, int diasLimite = 7)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.IdEstudiante.Equals(idEstudiante, StringComparison.OrdinalIgnoreCase));
            if (estudiante == null) return (false, "El estudiante no está registrado.");

            var equipo = _equiposFisicos.FirstOrDefault(eq => eq.IdEquipo.Equals(idEquipo, StringComparison.OrdinalIgnoreCase));
            if (equipo == null) return (false, "El equipo no existe en el inventario.");

            // Aprovechamos tu método Existente en la clase Equipo
            if (!equipo.EstaDisponible())
                return (false, $"No hay unidades disponibles de {equipo.Nombre}.");

            // Aprovechamos tu método existente en la clase Estudiante
            if (estudiante.ConsultarPrestamosActivos().Count >= 3)
                return (false, "El estudiante superó el límite de 3 préstamos activos.");

            // Creamos el préstamo usando tu constructor
            var nuevoPrestamo = new Prestamo(
                $"P-{_contadorPrestamos++:D3}",
                idEstudiante,
                idEquipo,
                fechaInicio,
                fechaInicio.AddDays(diasLimite)
            );

            // Vinculamos las entidades y actualizamos contadores
            nuevoPrestamo.Estudiante = estudiante;
            nuevoPrestamo.Equipo = equipo;

            equipo.CantidadPrestados++;
            estudiante.HistorialPrestamos.Add(nuevoPrestamo);
            _prestamos.Add(nuevoPrestamo);

            return (true, $"Préstamo exitoso. ID: {nuevoPrestamo.IdPrestamo}. Fecha Límite: {nuevoPrestamo.FechaLimite:yyyy-MM-dd}");
        }

        public (bool Exito, string Mensaje) Devolver(string idPrestamo, DateTime fechaDevolucion)
        {
            var prestamo = _prestamos.FirstOrDefault(p => p.IdPrestamo.Equals(idPrestamo, StringComparison.OrdinalIgnoreCase));
            if (prestamo == null) return (false, "Préstamo no encontrado. Verifique el ID.");

            if (prestamo.Estado == EstadoPrestamo.Devuelto) return (false, "Este equipo ya fue devuelto previamente.");

            prestamo.FechaDev = fechaDevolucion; // Usando tu propiedad FechaDev
            prestamo.Estado = EstadoPrestamo.Devuelto;

            // Liberamos el equipo disminuyendo los prestados
            var equipo = _equiposFisicos.FirstOrDefault(e => e.IdEquipo.Equals(prestamo.IdEquipo, StringComparison.OrdinalIgnoreCase));
            if (equipo != null && equipo.CantidadPrestados > 0)
            {
                equipo.CantidadPrestados--;
            }

            return (true, "Devolución registrada correctamente.");
        }

        public List<string> VerificarMora(DateTime fechaActual)
        {
            var alertas = new List<string>();
            foreach (var prestamo in _prestamos.Where(p => p.Estado != EstadoPrestamo.Devuelto))
            {
                // Aprovechamos tu método EvalAtrasado de la clase Prestamo
                if (prestamo.EvalAtrasado(fechaActual))
                {
                    prestamo.Estado = EstadoPrestamo.Atrasado;
                    alertas.Add($"El préstamo {prestamo.IdPrestamo} del estudiante {prestamo.IdEstudiante} está vencido.");
                }
            }
            return alertas;
        }
    }
}