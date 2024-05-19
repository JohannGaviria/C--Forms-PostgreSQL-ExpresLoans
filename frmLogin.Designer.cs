namespace expressLoan
{
    partial class frmLogin
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
            this.gbIngreso = new System.Windows.Forms.GroupBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblTexto = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.epLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // gbIngreso
            // 
            this.gbIngreso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbIngreso.Controls.Add(this.btnIngresar);
            this.gbIngreso.Controls.Add(this.lblTexto);
            this.gbIngreso.Controls.Add(this.lblContrasena);
            this.gbIngreso.Controls.Add(this.lblEmail);
            this.gbIngreso.Controls.Add(this.txtContrasena);
            this.gbIngreso.Controls.Add(this.txtEmail);
            this.gbIngreso.Controls.Add(this.lblTitulo);
            this.gbIngreso.Location = new System.Drawing.Point(235, 50);
            this.gbIngreso.Name = "gbIngreso";
            this.gbIngreso.Size = new System.Drawing.Size(300, 360);
            this.gbIngreso.TabIndex = 1;
            this.gbIngreso.TabStop = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.Location = new System.Drawing.Point(88, 295);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(115, 25);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTexto.Location = new System.Drawing.Point(53, 236);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(183, 13);
            this.lblTexto.TabIndex = 3;
            this.lblTexto.Text = "¿No tienes una cuenta? Ingresa Aqui";
            this.lblTexto.Click += new System.EventHandler(this.lblTexto_Click);
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(53, 173);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena.TabIndex = 7;
            this.lblContrasena.Text = "Contraseña";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(53, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(97, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Correo Electronico:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(56, 189);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(180, 20);
            this.txtContrasena.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(56, 115);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(26, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(249, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Inicio de Sesión de Usuario";
            // 
            // epLogin
            // 
            this.epLogin.ContainerControl = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 451);
            this.Controls.Add(this.gbIngreso);
            this.MaximumSize = new System.Drawing.Size(790, 490);
            this.MinimumSize = new System.Drawing.Size(790, 490);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.gbIngreso.ResumeLayout(false);
            this.gbIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIngreso;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ErrorProvider epLogin;
    }
}