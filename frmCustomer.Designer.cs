namespace expressLoan
{
    partial class frmCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVolver = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbDatosClientes = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNumeroCelular = new System.Windows.Forms.TextBox();
            this.gbFormaContacto = new System.Windows.Forms.GroupBox();
            this.cbNumeroCelular = new System.Windows.Forms.CheckBox();
            this.cbCorreoElectronico = new System.Windows.Forms.CheckBox();
            this.lblNumeroCelular = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.gbDatosClientes.SuspendLayout();
            this.gbFormaContacto.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVolver
            // 
            this.lblVolver.AutoSize = true;
            this.lblVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolver.Location = new System.Drawing.Point(0, 0);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(33, 31);
            this.lblVolver.TabIndex = 0;
            this.lblVolver.Text = "⪡";
            this.lblVolver.Click += new System.EventHandler(this.lblVolver_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(131, 42);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(132, 16);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Clientes Registrados";
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(134, 120);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(500, 300);
            this.dgvClientes.TabIndex = 0;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(380, 75);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(170, 13);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Busca Cliente por su ID o Nombre:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(383, 92);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(170, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(559, 90);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 22);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(134, 91);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(226, 91);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gbDatosClientes
            // 
            this.gbDatosClientes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbDatosClientes.Controls.Add(this.btnCancelar);
            this.gbDatosClientes.Controls.Add(this.btnAceptar);
            this.gbDatosClientes.Controls.Add(this.txtEmail);
            this.gbDatosClientes.Controls.Add(this.txtNombre);
            this.gbDatosClientes.Controls.Add(this.lblEmail);
            this.gbDatosClientes.Controls.Add(this.lblNombre);
            this.gbDatosClientes.Controls.Add(this.txtNumeroCelular);
            this.gbDatosClientes.Controls.Add(this.gbFormaContacto);
            this.gbDatosClientes.Controls.Add(this.lblNumeroCelular);
            this.gbDatosClientes.Location = new System.Drawing.Point(134, 120);
            this.gbDatosClientes.Name = "gbDatosClientes";
            this.gbDatosClientes.Size = new System.Drawing.Size(500, 300);
            this.gbDatosClientes.TabIndex = 35;
            this.gbDatosClientes.TabStop = false;
            this.gbDatosClientes.Text = "Datos del Cliente";
            this.gbDatosClientes.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(178, 229);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(178, 41);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(175, 213);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(97, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Correo Electronico:";
            this.lblEmail.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(175, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(99, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del Cliente:";
            // 
            // txtNumeroCelular
            // 
            this.txtNumeroCelular.Location = new System.Drawing.Point(178, 174);
            this.txtNumeroCelular.Name = "txtNumeroCelular";
            this.txtNumeroCelular.Size = new System.Drawing.Size(150, 20);
            this.txtNumeroCelular.TabIndex = 8;
            this.txtNumeroCelular.Visible = false;
            // 
            // gbFormaContacto
            // 
            this.gbFormaContacto.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbFormaContacto.Controls.Add(this.cbNumeroCelular);
            this.gbFormaContacto.Controls.Add(this.cbCorreoElectronico);
            this.gbFormaContacto.Location = new System.Drawing.Point(178, 67);
            this.gbFormaContacto.Name = "gbFormaContacto";
            this.gbFormaContacto.Size = new System.Drawing.Size(150, 77);
            this.gbFormaContacto.TabIndex = 33;
            this.gbFormaContacto.TabStop = false;
            this.gbFormaContacto.Text = "Forma de Contacto";
            // 
            // cbNumeroCelular
            // 
            this.cbNumeroCelular.AutoSize = true;
            this.cbNumeroCelular.Location = new System.Drawing.Point(9, 26);
            this.cbNumeroCelular.Name = "cbNumeroCelular";
            this.cbNumeroCelular.Size = new System.Drawing.Size(98, 17);
            this.cbNumeroCelular.TabIndex = 24;
            this.cbNumeroCelular.Text = "Numero Celular";
            this.cbNumeroCelular.UseVisualStyleBackColor = true;
            // 
            // cbCorreoElectronico
            // 
            this.cbCorreoElectronico.AutoSize = true;
            this.cbCorreoElectronico.Location = new System.Drawing.Point(9, 49);
            this.cbCorreoElectronico.Name = "cbCorreoElectronico";
            this.cbCorreoElectronico.Size = new System.Drawing.Size(113, 17);
            this.cbCorreoElectronico.TabIndex = 25;
            this.cbCorreoElectronico.Text = "Correo Electronico";
            this.cbCorreoElectronico.UseVisualStyleBackColor = true;
            // 
            // lblNumeroCelular
            // 
            this.lblNumeroCelular.AutoSize = true;
            this.lblNumeroCelular.Location = new System.Drawing.Point(175, 158);
            this.lblNumeroCelular.Name = "lblNumeroCelular";
            this.lblNumeroCelular.Size = new System.Drawing.Size(82, 13);
            this.lblNumeroCelular.TabIndex = 7;
            this.lblNumeroCelular.Text = "Numero Celular:";
            this.lblNumeroCelular.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(325, 271);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 34;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(103, 271);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 451);
            this.Controls.Add(this.gbDatosClientes);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblVolver);
            this.Controls.Add(this.lblBuscar);
            this.MaximumSize = new System.Drawing.Size(790, 490);
            this.MinimumSize = new System.Drawing.Size(790, 490);
            this.Name = "frmCustomer";
            this.Text = "Customer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomer_FormClosing);
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.gbDatosClientes.ResumeLayout(false);
            this.gbDatosClientes.PerformLayout();
            this.gbFormaContacto.ResumeLayout(false);
            this.gbFormaContacto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVolver;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gbDatosClientes;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNumeroCelular;
        private System.Windows.Forms.GroupBox gbFormaContacto;
        private System.Windows.Forms.CheckBox cbNumeroCelular;
        private System.Windows.Forms.CheckBox cbCorreoElectronico;
        private System.Windows.Forms.Label lblNumeroCelular;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}