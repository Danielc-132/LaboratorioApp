using System;
using System.Windows.Forms;
using LaboratorioApp.Services;

namespace LaboratorioApp
{
    public partial class Form1 : Form
    {
        private LaboratorioService _servicio;

        public Form1()
        {
            // Inicializa los componentes visuales definidos en el Diseñador
            InitializeComponent();

            // Instanciamos el servicio de negocio y cargamos los datos iniciales
            _servicio = new LaboratorioService();
            ActualizarTablas();
        }

        // Método para refrescar los DataGridView con la información actual
        private void ActualizarTablas()
        {
            dgvInventario.DataSource = null;
            dgvInventario.DataSource = _servicio.ObtenerEquipos();

            dgvPrestamosActivos.DataSource = null;
            dgvPrestamosActivos.DataSource = _servicio.ObtenerPrestamosActivos();
        }

        // Evento del botón para registrar un préstamo
        private void btnPrestar_Click(object sender, EventArgs e)
        {
            string idEstudiante = txtIdEstudiante.Text.Trim();
            string nombreEstudiante = txtNombreEstudiante.Text.Trim();
            string idEquipo = txtIdEquipo.Text.Trim();

            if (string.IsNullOrEmpty(idEstudiante) || string.IsNullOrEmpty(nombreEstudiante) || string.IsNullOrEmpty(idEquipo))
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registra al estudiante (si no existe) y procesa el préstamo
            
            _servicio.RegistrarEstudiante(idEstudiante, nombreEstudiante);
            var resultado = _servicio.Prestar(idEstudiante, idEquipo, DateTime.Now);

            if (resultado.Exito)
            {
                MessageBox.Show(resultado.Mensaje, "Préstamo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdEstudiante.Clear();
                txtNombreEstudiante.Clear();
                txtIdEquipo.Clear();
                ActualizarTablas();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, "No se pudo prestar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para registrar una devolución
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            string idPrestamo = txtIdPrestamoDevolver.Text.Trim();

            if (string.IsNullOrEmpty(idPrestamo))
            {
                MessageBox.Show("Ingrese el ID a devolver.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = _servicio.Devolver(idPrestamo, DateTime.Now);

            if (resultado.Exito)
            {
                MessageBox.Show(resultado.Mensaje, "Devolución Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdPrestamoDevolver.Clear();
                ActualizarTablas();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para verificar préstamos en mora
        private void btnVerificarMora_Click(object sender, EventArgs e)
        {
            var alertas = _servicio.VerificarMora(DateTime.Now);

            if (alertas.Count > 0)
            {
                string mensajeMora = string.Join("\n", alertas);
                MessageBox.Show(mensajeMora, "Alerta de Préstamos Atrasados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarTablas();
            }
            else
            {
                MessageBox.Show("No hay préstamos en mora en este momento.", "Verificación Limpia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void btnPrestar_Click_1(object sender, EventArgs e)
        {
            string idEstudiante = txtIdEstudiante.Text.Trim();
            string nombreEstudiante = txtNombreEstudiante.Text.Trim();
            string idEquipo = txtIdEquipo.Text.Trim();

            if (string.IsNullOrEmpty(idEstudiante) || string.IsNullOrEmpty(nombreEstudiante) || string.IsNullOrEmpty(idEquipo))
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registra al estudiante (si no existe) y procesa el préstamo
            _servicio.RegistrarEstudiante(idEstudiante, nombreEstudiante);
            var resultado = _servicio.Prestar(idEstudiante, idEquipo, DateTime.Now);

            if (resultado.Exito)
            {
                MessageBox.Show(resultado.Mensaje, "Préstamo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdEstudiante.Clear();
                txtNombreEstudiante.Clear();
                txtIdEquipo.Clear();
                ActualizarTablas();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, "No se pudo prestar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDevolver_Click_1(object sender, EventArgs e)
        {
            string idPrestamo = txtIdPrestamoDevolver.Text.Trim();

            if (string.IsNullOrEmpty(idPrestamo))
            {
                MessageBox.Show("Ingrese el ID a devolver.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = _servicio.Devolver(idPrestamo, DateTime.Now);

            if (resultado.Exito)
            {
                MessageBox.Show(resultado.Mensaje, "Devolución Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdPrestamoDevolver.Clear();
                ActualizarTablas();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerificarMora_Click_1(object sender, EventArgs e)
        {
            var alertas = _servicio.VerificarMora(DateTime.Now);

            if (alertas.Count > 0)
            {
                string mensajeMora = string.Join("\n", alertas);
                MessageBox.Show(mensajeMora, "Alerta de Préstamos Atrasados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarTablas();
            }
            else
            {
                MessageBox.Show("No hay préstamos en mora en este momento.", "Verificación Limpia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

//prueba de git
