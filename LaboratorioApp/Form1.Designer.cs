using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LaboratorioApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.dgvPrestamosActivos = new System.Windows.Forms.DataGridView();
            this.panelPrestamos = new System.Windows.Forms.Panel();
            this.lblTituloPrestamo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdEstudiante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreEstudiante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdEquipo = new System.Windows.Forms.TextBox();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.panelDevoluciones = new System.Windows.Forms.Panel();
            this.lblTituloDevolucion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdPrestamoDevolver = new System.Windows.Forms.TextBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnVerificarMora = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).BeginInit();
            this.panelPrestamos.SuspendLayout();
            this.panelDevoluciones.SuspendLayout();
            this.SuspendLayout();

            // 
            // Form1 - Ventana Principal Dark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42))))); // Dark Slate Background
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LabApp - Gestión de Laboratorio";

            // 
            // dgvInventario (Tabla Superior Oscura)
            // 
            this.dgvInventario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInventario.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvInventario.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInventario.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(20, 20);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(520, 220);
            this.dgvInventario.TabIndex = 0;

            // 
            // dgvPrestamosActivos (Tabla Inferior Oscura)
            // 
            this.dgvPrestamosActivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvPrestamosActivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrestamosActivos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvPrestamosActivos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPrestamosActivos.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvPrestamosActivos.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPrestamosActivos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvPrestamosActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamosActivos.Location = new System.Drawing.Point(20, 260);
            this.dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            this.dgvPrestamosActivos.ReadOnly = true;
            this.dgvPrestamosActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrestamosActivos.Size = new System.Drawing.Size(520, 220);
            this.dgvPrestamosActivos.TabIndex = 1;

            // 
            // panelPrestamos (Tarjeta Arriba)
            // 
            this.panelPrestamos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelPrestamos.Controls.Add(this.lblTituloPrestamo);
            this.panelPrestamos.Controls.Add(this.label1);
            this.panelPrestamos.Controls.Add(this.txtIdEstudiante);
            this.panelPrestamos.Controls.Add(this.label2);
            this.panelPrestamos.Controls.Add(this.txtNombreEstudiante);
            this.panelPrestamos.Controls.Add(this.label3);
            this.panelPrestamos.Controls.Add(this.txtIdEquipo);
            this.panelPrestamos.Controls.Add(this.btnPrestar);
            this.panelPrestamos.Location = new System.Drawing.Point(560, 20);
            this.panelPrestamos.Name = "panelPrestamos";
            this.panelPrestamos.Size = new System.Drawing.Size(315, 255);
            this.panelPrestamos.TabIndex = 2;

            // Título
            this.lblTituloPrestamo.AutoSize = true;
            this.lblTituloPrestamo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrestamo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248))))); // Azul Neón suave
            this.lblTituloPrestamo.Location = new System.Drawing.Point(15, 12);
            this.lblTituloPrestamo.Text = "REGISTRAR NUEVO PRÉSTAMO";

            // Labels en gris claro
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Text = "ID Estudiante";

            this.txtIdEstudiante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtIdEstudiante.ForeColor = System.Drawing.Color.White;
            this.txtIdEstudiante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdEstudiante.Location = new System.Drawing.Point(15, 60);
            this.txtIdEstudiante.Size = new System.Drawing.Size(280, 23);

            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Text = "Nombre Estudiante";

            this.txtNombreEstudiante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtNombreEstudiante.ForeColor = System.Drawing.Color.White;
            this.txtNombreEstudiante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreEstudiante.Location = new System.Drawing.Point(15, 111);
            this.txtNombreEstudiante.Size = new System.Drawing.Size(280, 23);

            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.label3.Location = new System.Drawing.Point(15, 144);
            this.label3.Text = "ID Equipo";

            this.txtIdEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtIdEquipo.ForeColor = System.Drawing.Color.White;
            this.txtIdEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdEquipo.Location = new System.Drawing.Point(15, 162);
            this.txtIdEquipo.Size = new System.Drawing.Size(280, 23);

            // Botón Azul Destacado
            this.btnPrestar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnPrestar.FlatAppearance.BorderSize = 0;
            this.btnPrestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrestar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrestar.ForeColor = System.Drawing.Color.White;
            this.btnPrestar.Location = new System.Drawing.Point(15, 202);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(280, 32);
            this.btnPrestar.Text = "Registrar Préstamo";
            this.btnPrestar.UseVisualStyleBackColor = false;
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);

            // 
            // panelDevoluciones (Tarjeta Abajo)
            // 
            this.panelDevoluciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelDevoluciones.Controls.Add(this.lblTituloDevolucion);
            this.panelDevoluciones.Controls.Add(this.label4);
            this.panelDevoluciones.Controls.Add(this.txtIdPrestamoDevolver);
            this.panelDevoluciones.Controls.Add(this.btnDevolver);
            this.panelDevoluciones.Controls.Add(this.btnVerificarMora);
            this.panelDevoluciones.Location = new System.Drawing.Point(560, 290);
            this.panelDevoluciones.Name = "panelDevoluciones";
            this.panelDevoluciones.Size = new System.Drawing.Size(315, 190);
            this.panelDevoluciones.TabIndex = 3;

            this.lblTituloDevolucion.AutoSize = true;
            this.lblTituloDevolucion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloDevolucion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblTituloDevolucion.Location = new System.Drawing.Point(15, 15);
            this.lblTituloDevolucion.Text = "GESTIÓN DE DEVOLUCIONES Y MORAS";

            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.label4.Location = new System.Drawing.Point(15, 48);
            this.label4.Text = "ID a devolver";

            this.txtIdPrestamoDevolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtIdPrestamoDevolver.ForeColor = System.Drawing.Color.White;
            this.txtIdPrestamoDevolver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdPrestamoDevolver.Location = new System.Drawing.Point(15, 68);
            this.txtIdPrestamoDevolver.Size = new System.Drawing.Size(280, 23);

            // Botones Secundarios Oscuros
            this.btnDevolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnDevolver.FlatAppearance.BorderSize = 0;
            this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolver.ForeColor = System.Drawing.Color.White;
            this.btnDevolver.Location = new System.Drawing.Point(15, 125);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(130, 32);
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = false;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);

            this.btnVerificarMora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnVerificarMora.FlatAppearance.BorderSize = 0;
            this.btnVerificarMora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarMora.ForeColor = System.Drawing.Color.White;
            this.btnVerificarMora.Location = new System.Drawing.Point(165, 125);
            this.btnVerificarMora.Name = "btnVerificarMora";
            this.btnVerificarMora.Size = new System.Drawing.Size(130, 32);
            this.btnVerificarMora.Text = "Verificar Mora";
            this.btnVerificarMora.UseVisualStyleBackColor = false;
            this.btnVerificarMora.Click += new System.EventHandler(this.btnVerificarMora_Click);

            // Controles al Formulario
            this.Controls.Add(this.panelDevoluciones);
            this.Controls.Add(this.panelPrestamos);
            this.Controls.Add(this.dgvPrestamosActivos);
            this.Controls.Add(this.dgvInventario);

            this.panelPrestamos.ResumeLayout(false);
            this.panelPrestamos.PerformLayout();
            this.panelDevoluciones.ResumeLayout(false);
            this.panelDevoluciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.DataGridView dgvPrestamosActivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.TextBox txtIdEstudiante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreEstudiante;
        private System.Windows.Forms.TextBox txtIdEquipo;
        private System.Windows.Forms.TextBox txtIdPrestamoDevolver;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnVerificarMora;

        private System.Windows.Forms.Panel panelPrestamos;
        private System.Windows.Forms.Panel panelDevoluciones;
        private System.Windows.Forms.Label lblTituloPrestamo;
        private System.Windows.Forms.Label lblTituloDevolucion;
    }
}