namespace expressLoan
{
    partial class frmRegister
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
            this.gbRegistro = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblCelular = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.epRegistro = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRegistro
            // 
            this.gbRegistro.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbRegistro.Controls.Add(this.btnRegistrar);
            this.gbRegistro.Controls.Add(this.lblTexto);
            this.gbRegistro.Controls.Add(this.lblCelular);
            this.gbRegistro.Controls.Add(this.lblContrasena);
            this.gbRegistro.Controls.Add(this.lblEmail);
            this.gbRegistro.Controls.Add(this.lblNombre);
            this.gbRegistro.Controls.Add(this.txtCelular);
            this.gbRegistro.Controls.Add(this.txtContrasena);
            this.gbRegistro.Controls.Add(this.txtEmail);
            this.gbRegistro.Controls.Add(this.txtNombre);
            this.gbRegistro.Controls.Add(this.lblTitulo);
            this.gbRegistro.Location = new System.Drawing.Point(235, 50);
            this.gbRegistro.Name = "gbRegistro";
            this.gbRegistro.Size = new System.Drawing.Size(300, 360);
            this.gbRegistro.TabIndex = 0;
            this.gbRegistro.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(94, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(100, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Usuario";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(56, 85);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(56, 141);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(56, 196);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(180, 20);
            this.txtContrasena.TabIndex = 3;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(56, 250);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(180, 20);
            this.txtCelular.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(53, 69);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(94, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre Completo:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(53, 125);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(97, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Correo Electronico:";
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(53, 180);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena.TabIndex = 7;
            this.lblContrasena.Text = "Contraseña";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(53, 234);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(82, 13);
            this.lblCelular.TabIndex = 8;
            this.lblCelular.Text = "Numero Celular:";
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(53, 291);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(182, 13);
            this.lblTexto.TabIndex = 10;
            this.lblTexto.Text = "¿Ya tienes una cuenta? Ingresa Aqui";
            this.lblTexto.Click += new System.EventHandler(this.lblTexto_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(88, 316);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(115, 25);
            this.btnRegistrar.TabIndex = 11;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // epRegistro
            // 
            this.epRegistro.ContainerControl = this;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 451);
            this.Controls.Add(this.gbRegistro);
            this.MaximumSize = new System.Drawing.Size(790, 490);
            this.MinimumSize = new System.Drawing.Size(790, 490);
            this.Name = "frmRegister";
            this.Text = "Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegister_FormClosing);
            this.gbRegistro.ResumeLayout(false);
            this.gbRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRegistro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRegistro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.ErrorProvider epRegistro;
    }
}