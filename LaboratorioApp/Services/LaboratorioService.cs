using System;
using System.Collections.Generic;
using System.Linq;
using LaboratorioApp.Models;

namespace LaboratorioApp.Services
{
    public class LaboratorioService
    {
        //se usan listas privadas para simular la bd por el momento
        private List<Equipo> _equiposFisicos;
        private List<Estudiante> _estudiantesResgistrados;
        private List<Prestamo> _prestamosActivos;
        private int _contadorPrestamos;

        public LaboratorioService()
        {
            _equiposFisicos = new List<Equipo>();
            _estudiantesResgistrados = new List<Estudiante>();
            _prestamosActivos = new List<Prestamo>();
            _contadorPrestamos = 0;

            CargarInventarioInicial();
        }

        private void CargarInventarioInicial()
        {
            _equiposFisicos.Add(new Equipo("EQ-01", "Osciloscopio Digital", 2));
            _equiposFisicos.Add(new Equipo("EQ-02", "Multímetro", 3));
            _equiposFisicos.Add(new Equipo("EQ-03", "Fuente de Poder", 1));
        }

        //metodos para poder visualizar en la parte grafica
        public List<Equipo> ObtenerEquipos() => _equiposFisicos.ToList();
        public List<Prestamo> ObtenerPrestamosActivos() => _prestamosActivos.ToList();

        public Estudiante BuscarEstudiante(string idEstudiante)
        {
            return _estudiantesResgistrados.FirstOrDefault(e => e.IdEstudiante.Equals(idEstudiante, StringComparison.OrdinalIgnoreCase));
        }

        public Estudiante RegistrarEstudiante(string idEstudiante, string nombre)
        {
            //verifica si ya existe para evitar duplicados
            var existente = BuscarEstudiante(idEstudiante);
            if(existente != null) return existente;

            var nuevoEstudiante = new Estudiante(idEstudiante, nombre);
            _estudiantesResgistrados.Add(nuevoEstudiante);
            return nuevoEstudiante;
        }

        public(bool Exito, string Mensaje) Prestar(string idEstudiante, idEquipo, DateTime fechaInicio, int diasLimite = 7)
        {
            var estudiante = BuscarEstudiante(idEstudiante);
            var equipo = _equiposFisicos.FirstOrDefault(eq => eq.IdEquipo.Equals(idEquipo, StringComparison.OrdinalIgnoreCase));

            if (estudiante == null) return (false, "El estudiante no está registrado. ");
            if (equipo == null) return (false, "El equipo no existe. ");

            var PrestamoTemp = new Prestamo();
            var validacion = PrestamoTemp.ValidarPolitica(estudiante, equipo);
        }

    }
}