namespace LaboratorioApp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.dgvPrestamosActivos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.txtIdEstudiante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreEstudiante = new System.Windows.Forms.TextBox();
            this.txtIdEquipo = new System.Windows.Forms.TextBox();
            this.txtIdPrestamoDevolver = new System.Windows.Forms.TextBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnVerificarMora = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(12, 24);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(499, 177);
            this.dgvInventario.TabIndex = 0;
            // 
            // dgvPrestamosActivos
            // 
            this.dgvPrestamosActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamosActivos.Location = new System.Drawing.Point(12, 243);
            this.dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            this.dgvPrestamosActivos.Size = new System.Drawing.Size(499, 177);
            this.dgvPrestamosActivos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(553, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Estudiante";
            // 
            // btnPrestar
            // 
            this.btnPrestar.Location = new System.Drawing.Point(556, 193);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(118, 23);
            this.btnPrestar.TabIndex = 3;
            this.btnPrestar.Text = "Registrar Prestamo";
            this.btnPrestar.UseVisualStyleBackColor = true;
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click_1);
            // 
            // txtIdEstudiante
            // 
            this.txtIdEstudiante.Location = new System.Drawing.Point(556, 55);
            this.txtIdEstudiante.Name = "txtIdEstudiante";
            this.txtIdEstudiante.Size = new System.Drawing.Size(100, 20);
            this.txtIdEstudiante.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre Estudiante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID Equipo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Verificar Prestamos";
            // 
            // txtNombreEstudiante
            // 
            this.txtNombreEstudiante.Location = new System.Drawing.Point(556, 105);
            this.txtNombreEstudiante.Name = "txtNombreEstudiante";
            this.txtNombreEstudiante.Size = new System.Drawing.Size(100, 20);
            this.txtNombreEstudiante.TabIndex = 9;
            // 
            // txtIdEquipo
            // 
            this.txtIdEquipo.Location = new System.Drawing.Point(556, 155);
            this.txtIdEquipo.Name = "txtIdEquipo";
            this.txtIdEquipo.Size = new System.Drawing.Size(100, 20);
            this.txtIdEquipo.TabIndex = 10;
            // 
            // txtIdPrestamoDevolver
            // 
            this.txtIdPrestamoDevolver.Location = new System.Drawing.Point(556, 268);
            this.txtIdPrestamoDevolver.Name = "txtIdPrestamoDevolver";
            this.txtIdPrestamoDevolver.Size = new System.Drawing.Size(100, 20);
            this.txtIdPrestamoDevolver.TabIndex = 11;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(556, 303);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 23);
            this.btnDevolver.TabIndex = 13;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click_1);
            // 
            // btnVerificarMora
            // 
            this.btnVerificarMora.Location = new System.Drawing.Point(658, 303);
            this.btnVerificarMora.Name = "btnVerificarMora";
            this.btnVerificarMora.Size = new System.Drawing.Size(99, 23);
            this.btnVerificarMora.TabIndex = 14;
            this.btnVerificarMora.Text = "Verificar Mora";
            this.btnVerificarMora.UseVisualStyleBackColor = true;
            this.btnVerificarMora.Click += new System.EventHandler(this.btnVerificarMora_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerificarMora);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.txtIdPrestamoDevolver);
            this.Controls.Add(this.txtIdEquipo);
            this.Controls.Add(this.txtNombreEstudiante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdEstudiante);
            this.Controls.Add(this.btnPrestar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPrestamosActivos);
            this.Controls.Add(this.dgvInventario);
            this.Name = "Form1";
            this.Text = "LabApp";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

