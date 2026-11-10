using LaboratorioApp.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LaboratorioApp
{
    public partial class Form1 : Form
    {
        private LaboratorioService _servicio;

        public Form1()
        {
            InitializeComponent();
            _servicio = new LaboratorioService();
            ActualizarTablas();
        }

        private void ActualizarTablas()
        {
            dgvInventario.DataSource = null;
            dgvInventario.DataSource = _servicio.ObtenerEquipos();

            dgvPrestamosActivos.DataSource = null;
            dgvPrestamosActivos.DataSource = _servicio.ObtenerPrestamosActivos();
        }

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

        // Método auxiliar para redondear las esquinas de cualquier control
        private void RedondearControl(Control control, int radio)
        {
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();
            int diametro = radio * 2;

            path.AddArc(rect.X, rect.Y, diametro, diametro, 180, 90);
            path.AddArc(rect.Right - diametro, rect.Y, diametro, diametro, 270, 90);
            path.AddArc(rect.Right - diametro, rect.Bottom - diametro, diametro, diametro, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diametro, diametro, diametro, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }
    }
}
