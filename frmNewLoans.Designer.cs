namespace expressLoan
{
    partial class frmNewLoans
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
            this.components = new System.ComponentModel.Container();
            this.lblVolver = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.rbPrestamoFijo = new System.Windows.Forms.RadioButton();
            this.rbPrestamoInteres = new System.Windows.Forms.RadioButton();
            this.lblNumeroCelular = new System.Windows.Forms.Label();
            this.txtNumeroCelular = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblSaldoNum = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.gbDinero = new System.Windows.Forms.GroupBox();
            this.cbNumeroCelular = new System.Windows.Forms.CheckBox();
            this.cbCorreoElectronico = new System.Windows.Forms.CheckBox();
            this.lblPrestamoFijo = new System.Windows.Forms.Label();
            this.txtPrestamoFijo = new System.Windows.Forms.TextBox();
            this.txtPrestamoInteres = new System.Windows.Forms.TextBox();
            this.lblPrestamoInteres = new System.Windows.Forms.Label();
            this.btnRegistrarPrestamo = new System.Windows.Forms.Button();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.gbFormaContacto = new System.Windows.Forms.GroupBox();
            this.gbTipoPrestamo = new System.Windows.Forms.GroupBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.gbDatosPrestamos = new System.Windows.Forms.GroupBox();
            this.gbDatosClientes = new System.Windows.Forms.GroupBox();
            this.epRegistroPrestamo = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.gbDinero.SuspendLayout();
            this.gbFormaContacto.SuspendLayout();
            this.gbTipoPrestamo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.gbDatosPrestamos.SuspendLayout();
            this.gbDatosClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRegistroPrestamo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVolver
            // 
            this.lblVolver.AutoSize = true;
            this.lblVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolver.Location = new System.Drawing.Point(0, 0);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(33, 31);
            this.lblVolver.TabIndex = 0;
            this.lblVolver.Text = "⪡";
            this.lblVolver.Click += new System.EventHandler(this.lblVolver_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(17, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(99, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del Cliente:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(20, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // rbPrestamoFijo
            // 
            this.rbPrestamoFijo.AutoSize = true;
            this.rbPrestamoFijo.Location = new System.Drawing.Point(6, 26);
            this.rbPrestamoFijo.Name = "rbPrestamoFijo";
            this.rbPrestamoFijo.Size = new System.Drawing.Size(88, 17);
            this.rbPrestamoFijo.TabIndex = 3;
            this.rbPrestamoFijo.TabStop = true;
            this.rbPrestamoFijo.Text = "Prestamo Fijo";
            this.rbPrestamoFijo.UseVisualStyleBackColor = true;
            this.rbPrestamoFijo.CheckedChanged += new System.EventHandler(this.rbPrestamoFijo_CheckedChanged);
            // 
            // rbPrestamoInteres
            // 
            this.rbPrestamoInteres.AutoSize = true;
            this.rbPrestamoInteres.Location = new System.Drawing.Point(6, 48);
            this.rbPrestamoInteres.Name = "rbPrestamoInteres";
            this.rbPrestamoInteres.Size = new System.Drawing.Size(125, 17);
            this.rbPrestamoInteres.TabIndex = 4;
            this.rbPrestamoInteres.TabStop = true;
            this.rbPrestamoInteres.Text = "Prestamo con Interes";
            this.rbPrestamoInteres.UseVisualStyleBackColor = true;
            this.rbPrestamoInteres.CheckedChanged += new System.EventHandler(this.rbPrestamoInteres_CheckedChanged);
            // 
            // lblNumeroCelular
            // 
            this.lblNumeroCelular.AutoSize = true;
            this.lblNumeroCelular.Location = new System.Drawing.Point(17, 192);
            this.lblNumeroCelular.Name = "lblNumeroCelular";
            this.lblNumeroCelular.Size = new System.Drawing.Size(82, 13);
            this.lblNumeroCelular.TabIndex = 7;
            this.lblNumeroCelular.Text = "Numero Celular:";
            this.lblNumeroCelular.Visible = false;
            // 
            // txtNumeroCelular
            // 
            this.txtNumeroCelular.Location = new System.Drawing.Point(20, 208);
            this.txtNumeroCelular.Name = "txtNumeroCelular";
            this.txtNumeroCelular.Size = new System.Drawing.Size(150, 20);
            this.txtNumeroCelular.TabIndex = 8;
            this.txtNumeroCelular.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 263);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(17, 247);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(97, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Correo Electronico:";
            this.lblEmail.Visible = false;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(25, 25);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(85, 13);
            this.lblMonto.TabIndex = 11;
            this.lblMonto.Text = "Monto a Prestar:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(25, 41);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(150, 20);
            this.txtMonto.TabIndex = 12;
            // 
            // lblSaldoNum
            // 
            this.lblSaldoNum.AutoSize = true;
            this.lblSaldoNum.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSaldoNum.Location = new System.Drawing.Point(90, 15);
            this.lblSaldoNum.Name = "lblSaldoNum";
            this.lblSaldoNum.Size = new System.Drawing.Size(79, 13);
            this.lblSaldoNum.TabIndex = 21;
            this.lblSaldoNum.Text = "999999999999";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSaldo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSaldo.Location = new System.Drawing.Point(3, 15);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(67, 13);
            this.lblSaldo.TabIndex = 20;
            this.lblSaldo.Text = "Total Saldo: ";
            // 
            // gbDinero
            // 
            this.gbDinero.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbDinero.Controls.Add(this.lblSaldoNum);
            this.gbDinero.Controls.Add(this.lblSaldo);
            this.gbDinero.Location = new System.Drawing.Point(585, 0);
            this.gbDinero.Name = "gbDinero";
            this.gbDinero.Padding = new System.Windows.Forms.Padding(0);
            this.gbDinero.Size = new System.Drawing.Size(185, 40);
            this.gbDinero.TabIndex = 22;
            this.gbDinero.TabStop = false;
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
            this.cbNumeroCelular.CheckedChanged += new System.EventHandler(this.cbNumeroCelular_CheckedChanged);
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
            this.cbCorreoElectronico.CheckedChanged += new System.EventHandler(this.cbCorreoElectronico_CheckedChanged);
            // 
            // lblPrestamoFijo
            // 
            this.lblPrestamoFijo.AutoSize = true;
            this.lblPrestamoFijo.Location = new System.Drawing.Point(25, 157);
            this.lblPrestamoFijo.Name = "lblPrestamoFijo";
            this.lblPrestamoFijo.Size = new System.Drawing.Size(73, 13);
            this.lblPrestamoFijo.TabIndex = 26;
            this.lblPrestamoFijo.Text = "Prestamo Fijo:";
            this.lblPrestamoFijo.Visible = false;
            // 
            // txtPrestamoFijo
            // 
            this.txtPrestamoFijo.Location = new System.Drawing.Point(25, 173);
            this.txtPrestamoFijo.Name = "txtPrestamoFijo";
            this.txtPrestamoFijo.Size = new System.Drawing.Size(150, 20);
            this.txtPrestamoFijo.TabIndex = 27;
            this.txtPrestamoFijo.Visible = false;
            // 
            // txtPrestamoInteres
            // 
            this.txtPrestamoInteres.Location = new System.Drawing.Point(25, 173);
            this.txtPrestamoInteres.Name = "txtPrestamoInteres";
            this.txtPrestamoInteres.Size = new System.Drawing.Size(150, 20);
            this.txtPrestamoInteres.TabIndex = 29;
            this.txtPrestamoInteres.Visible = false;
            // 
            // lblPrestamoInteres
            // 
            this.lblPrestamoInteres.AutoSize = true;
            this.lblPrestamoInteres.Location = new System.Drawing.Point(25, 157);
            this.lblPrestamoInteres.Name = "lblPrestamoInteres";
            this.lblPrestamoInteres.Size = new System.Drawing.Size(110, 13);
            this.lblPrestamoInteres.TabIndex = 28;
            this.lblPrestamoInteres.Text = "Prestamo con Interes:";
            this.lblPrestamoInteres.Visible = false;
            // 
            // btnRegistrarPrestamo
            // 
            this.btnRegistrarPrestamo.Location = new System.Drawing.Point(231, 348);
            this.btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            this.btnRegistrarPrestamo.Size = new System.Drawing.Size(115, 25);
            this.btnRegistrarPrestamo.TabIndex = 30;
            this.btnRegistrarPrestamo.Text = "Registrar Prestamo";
            this.btnRegistrarPrestamo.UseVisualStyleBackColor = true;
            this.btnRegistrarPrestamo.Click += new System.EventHandler(this.btnRegistrarPrestamo_Click);
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Location = new System.Drawing.Point(22, 224);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(83, 13);
            this.lblFechaPago.TabIndex = 31;
            this.lblFechaPago.Text = "Fecha de Pago:";
            // 
            // gbFormaContacto
            // 
            this.gbFormaContacto.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbFormaContacto.Controls.Add(this.cbNumeroCelular);
            this.gbFormaContacto.Controls.Add(this.cbCorreoElectronico);
            this.gbFormaContacto.Location = new System.Drawing.Point(20, 93);
            this.gbFormaContacto.Name = "gbFormaContacto";
            this.gbFormaContacto.Size = new System.Drawing.Size(150, 77);
            this.gbFormaContacto.TabIndex = 33;
            this.gbFormaContacto.TabStop = false;
            this.gbFormaContacto.Text = "Forma de Contacto";
            // 
            // gbTipoPrestamo
            // 
            this.gbTipoPrestamo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbTipoPrestamo.Controls.Add(this.rbPrestamoFijo);
            this.gbTipoPrestamo.Controls.Add(this.rbPrestamoInteres);
            this.gbTipoPrestamo.Location = new System.Drawing.Point(25, 72);
            this.gbTipoPrestamo.Name = "gbTipoPrestamo";
            this.gbTipoPrestamo.Size = new System.Drawing.Size(150, 77);
            this.gbTipoPrestamo.TabIndex = 34;
            this.gbTipoPrestamo.TabStop = false;
            this.gbTipoPrestamo.Text = "Tipo Prestamo";
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbDatos.Controls.Add(this.gbDatosPrestamos);
            this.gbDatos.Controls.Add(this.gbDatosClientes);
            this.gbDatos.Controls.Add(this.btnRegistrarPrestamo);
            this.gbDatos.Location = new System.Drawing.Point(90, 50);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(575, 379);
            this.gbDatos.TabIndex = 35;
            this.gbDatos.TabStop = false;
            // 
            // gbDatosPrestamos
            // 
            this.gbDatosPrestamos.Controls.Add(this.dtpFechaPago);
            this.gbDatosPrestamos.Controls.Add(this.lblMonto);
            this.gbDatosPrestamos.Controls.Add(this.gbTipoPrestamo);
            this.gbDatosPrestamos.Controls.Add(this.lblFechaPago);
            this.gbDatosPrestamos.Controls.Add(this.txtMonto);
            this.gbDatosPrestamos.Controls.Add(this.txtPrestamoInteres);
            this.gbDatosPrestamos.Controls.Add(this.lblPrestamoFijo);
            this.gbDatosPrestamos.Controls.Add(this.lblPrestamoInteres);
            this.gbDatosPrestamos.Controls.Add(this.txtPrestamoFijo);
            this.gbDatosPrestamos.Location = new System.Drawing.Point(356, 19);
            this.gbDatosPrestamos.Name = "gbDatosPrestamos";
            this.gbDatosPrestamos.Size = new System.Drawing.Size(200, 320);
            this.gbDatosPrestamos.TabIndex = 35;
            this.gbDatosPrestamos.TabStop = false;
            this.gbDatosPrestamos.Text = "Datos del Prestamo";
            // 
            // gbDatosClientes
            // 
            this.gbDatosClientes.Controls.Add(this.txtEmail);
            this.gbDatosClientes.Controls.Add(this.txtNombre);
            this.gbDatosClientes.Controls.Add(this.lblEmail);
            this.gbDatosClientes.Controls.Add(this.lblNombre);
            this.gbDatosClientes.Controls.Add(this.txtNumeroCelular);
            this.gbDatosClientes.Controls.Add(this.gbFormaContacto);
            this.gbDatosClientes.Controls.Add(this.lblNumeroCelular);
            this.gbDatosClientes.Location = new System.Drawing.Point(19, 19);
            this.gbDatosClientes.Name = "gbDatosClientes";
            this.gbDatosClientes.Size = new System.Drawing.Size(200, 320);
            this.gbDatosClientes.TabIndex = 34;
            this.gbDatosClientes.TabStop = false;
            this.gbDatosClientes.Text = "Datos del Cliente";
            // 
            // epRegistroPrestamo
            // 
            this.epRegistroPrestamo.ContainerControl = this;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Location = new System.Drawing.Point(22, 240);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaPago.TabIndex = 32;
            this.dtpFechaPago.Value = new System.DateTime(2024, 5, 21, 0, 0, 0, 0);
            // 
            // frmNewLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 451);
            this.Controls.Add(this.gbDinero);
            this.Controls.Add(this.lblVolver);
            this.Controls.Add(this.gbDatos);
            this.MaximumSize = new System.Drawing.Size(790, 490);
            this.MinimumSize = new System.Drawing.Size(790, 490);
            this.Name = "frmNewLoans";
            this.Text = "New Loans";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewLoans_FormClosing);
            this.Load += new System.EventHandler(this.frmNewLoans_Load);
            this.gbDinero.ResumeLayout(false);
            this.gbDinero.PerformLayout();
            this.gbFormaContacto.ResumeLayout(false);
            this.gbFormaContacto.PerformLayout();
            this.gbTipoPrestamo.ResumeLayout(false);
            this.gbTipoPrestamo.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatosPrestamos.ResumeLayout(false);
            this.gbDatosPrestamos.PerformLayout();
            this.gbDatosClientes.ResumeLayout(false);
            this.gbDatosClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRegistroPrestamo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVolver;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.RadioButton rbPrestamoFijo;
        private System.Windows.Forms.RadioButton rbPrestamoInteres;
        private System.Windows.Forms.Label lblNumeroCelular;
        private System.Windows.Forms.TextBox txtNumeroCelular;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblSaldoNum;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.GroupBox gbDinero;
        private System.Windows.Forms.CheckBox cbNumeroCelular;
        private System.Windows.Forms.CheckBox cbCorreoElectronico;
        private System.Windows.Forms.Label lblPrestamoFijo;
        private System.Windows.Forms.TextBox txtPrestamoFijo;
        private System.Windows.Forms.TextBox txtPrestamoInteres;
        private System.Windows.Forms.Label lblPrestamoInteres;
        private System.Windows.Forms.Button btnRegistrarPrestamo;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.GroupBox gbFormaContacto;
        private System.Windows.Forms.GroupBox gbTipoPrestamo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.GroupBox gbDatosClientes;
        private System.Windows.Forms.GroupBox gbDatosPrestamos;
        private System.Windows.Forms.ErrorProvider epRegistroPrestamo;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
    }
}