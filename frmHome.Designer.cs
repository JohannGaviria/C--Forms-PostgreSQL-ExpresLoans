namespace expressLoan
{
    partial class frmHome
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
            this.dgvPrestamosPedientes = new System.Windows.Forms.DataGridView();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnNuevoPrestamo = new System.Windows.Forms.Button();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblPrestamo = new System.Windows.Forms.Label();
            this.lblPagosRecientes = new System.Windows.Forms.Label();
            this.lblPrestamosPedientes = new System.Windows.Forms.Label();
            this.btnPagosRecientes = new System.Windows.Forms.Button();
            this.btnPrestamosPedientes = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.dgvPagosRecientes = new System.Windows.Forms.DataGridView();
            this.lblSaldoNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDinero = new System.Windows.Forms.GroupBox();
            this.btnSaldo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosPedientes)).BeginInit();
            this.gbMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosRecientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrestamosPedientes
            // 
            this.dgvPrestamosPedientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamosPedientes.Location = new System.Drawing.Point(477, 167);
            this.dgvPrestamosPedientes.Name = "dgvPrestamosPedientes";
            this.dgvPrestamosPedientes.Size = new System.Drawing.Size(285, 226);
            this.dgvPrestamosPedientes.TabIndex = 0;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(22, 91);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(115, 25);
            this.btnRegistrarPago.TabIndex = 5;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // btnNuevoPrestamo
            // 
            this.btnNuevoPrestamo.Location = new System.Drawing.Point(22, 33);
            this.btnNuevoPrestamo.Name = "btnNuevoPrestamo";
            this.btnNuevoPrestamo.Size = new System.Drawing.Size(115, 25);
            this.btnNuevoPrestamo.TabIndex = 6;
            this.btnNuevoPrestamo.Text = "Nuevo Prestamo";
            this.btnNuevoPrestamo.UseVisualStyleBackColor = true;
            this.btnNuevoPrestamo.Click += new System.EventHandler(this.btnNuevoPrestamo_Click);
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSaldo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSaldo.Location = new System.Drawing.Point(593, 9);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(67, 13);
            this.lblSaldo.TabIndex = 7;
            this.lblSaldo.Text = "Total Saldo: ";
            // 
            // lblPrestamo
            // 
            this.lblPrestamo.AutoSize = true;
            this.lblPrestamo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblPrestamo.Location = new System.Drawing.Point(593, 45);
            this.lblPrestamo.Name = "lblPrestamo";
            this.lblPrestamo.Size = new System.Drawing.Size(81, 13);
            this.lblPrestamo.TabIndex = 8;
            this.lblPrestamo.Text = "Total Prestamo:";
            // 
            // lblPagosRecientes
            // 
            this.lblPagosRecientes.AutoSize = true;
            this.lblPagosRecientes.Location = new System.Drawing.Point(164, 129);
            this.lblPagosRecientes.Name = "lblPagosRecientes";
            this.lblPagosRecientes.Size = new System.Drawing.Size(88, 13);
            this.lblPagosRecientes.TabIndex = 9;
            this.lblPagosRecientes.Text = "Pagos Recientes";
            // 
            // lblPrestamosPedientes
            // 
            this.lblPrestamosPedientes.AutoSize = true;
            this.lblPrestamosPedientes.Location = new System.Drawing.Point(474, 129);
            this.lblPrestamosPedientes.Name = "lblPrestamosPedientes";
            this.lblPrestamosPedientes.Size = new System.Drawing.Size(106, 13);
            this.lblPrestamosPedientes.TabIndex = 10;
            this.lblPrestamosPedientes.Text = "Prestamos Pedientes";
            // 
            // btnPagosRecientes
            // 
            this.btnPagosRecientes.Location = new System.Drawing.Point(256, 414);
            this.btnPagosRecientes.Name = "btnPagosRecientes";
            this.btnPagosRecientes.Size = new System.Drawing.Size(115, 25);
            this.btnPagosRecientes.TabIndex = 11;
            this.btnPagosRecientes.Text = "Ver mas";
            this.btnPagosRecientes.UseVisualStyleBackColor = true;
            this.btnPagosRecientes.Click += new System.EventHandler(this.btnPagosRecientes_Click);
            // 
            // btnPrestamosPedientes
            // 
            this.btnPrestamosPedientes.Location = new System.Drawing.Point(558, 414);
            this.btnPrestamosPedientes.Name = "btnPrestamosPedientes";
            this.btnPrestamosPedientes.Size = new System.Drawing.Size(115, 25);
            this.btnPrestamosPedientes.TabIndex = 12;
            this.btnPrestamosPedientes.Text = "Ver mas";
            this.btnPrestamosPedientes.UseVisualStyleBackColor = true;
            this.btnPrestamosPedientes.Click += new System.EventHandler(this.btnPrestamosPedientes_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(22, 151);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(115, 25);
            this.btnCliente.TabIndex = 13;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(21, 416);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(115, 25);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbMenu
            // 
            this.gbMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbMenu.Controls.Add(this.btnSaldo);
            this.gbMenu.Controls.Add(this.btnCliente);
            this.gbMenu.Controls.Add(this.btnSalir);
            this.gbMenu.Controls.Add(this.btnRegistrarPago);
            this.gbMenu.Controls.Add(this.btnNuevoPrestamo);
            this.gbMenu.Location = new System.Drawing.Point(1, 0);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(160, 451);
            this.gbMenu.TabIndex = 15;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Menu";
            // 
            // dgvPagosRecientes
            // 
            this.dgvPagosRecientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagosRecientes.Location = new System.Drawing.Point(167, 167);
            this.dgvPagosRecientes.Name = "dgvPagosRecientes";
            this.dgvPagosRecientes.Size = new System.Drawing.Size(285, 226);
            this.dgvPagosRecientes.TabIndex = 16;
            // 
            // lblSaldoNum
            // 
            this.lblSaldoNum.AutoSize = true;
            this.lblSaldoNum.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSaldoNum.Location = new System.Drawing.Point(680, 9);
            this.lblSaldoNum.Name = "lblSaldoNum";
            this.lblSaldoNum.Size = new System.Drawing.Size(79, 13);
            this.lblSaldoNum.TabIndex = 17;
            this.lblSaldoNum.Text = "999999999999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(680, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "999999999999";
            // 
            // gbDinero
            // 
            this.gbDinero.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbDinero.Location = new System.Drawing.Point(585, 0);
            this.gbDinero.Name = "gbDinero";
            this.gbDinero.Padding = new System.Windows.Forms.Padding(0);
            this.gbDinero.Size = new System.Drawing.Size(187, 72);
            this.gbDinero.TabIndex = 19;
            this.gbDinero.TabStop = false;
            // 
            // btnSaldo
            // 
            this.btnSaldo.Location = new System.Drawing.Point(22, 208);
            this.btnSaldo.Name = "btnSaldo";
            this.btnSaldo.Size = new System.Drawing.Size(115, 25);
            this.btnSaldo.TabIndex = 15;
            this.btnSaldo.Text = "Saldo";
            this.btnSaldo.UseVisualStyleBackColor = true;
            this.btnSaldo.Click += new System.EventHandler(this.btnSaldo_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSaldoNum);
            this.Controls.Add(this.dgvPagosRecientes);
            this.Controls.Add(this.btnPrestamosPedientes);
            this.Controls.Add(this.btnPagosRecientes);
            this.Controls.Add(this.lblPrestamosPedientes);
            this.Controls.Add(this.lblPagosRecientes);
            this.Controls.Add(this.lblPrestamo);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.dgvPrestamosPedientes);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.gbDinero);
            this.MaximumSize = new System.Drawing.Size(790, 490);
            this.MinimumSize = new System.Drawing.Size(790, 490);
            this.Name = "frmHome";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHome_FormClosing);
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosPedientes)).EndInit();
            this.gbMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosRecientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrestamosPedientes;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnNuevoPrestamo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblPrestamo;
        private System.Windows.Forms.Label lblPagosRecientes;
        private System.Windows.Forms.Label lblPrestamosPedientes;
        private System.Windows.Forms.Button btnPagosRecientes;
        private System.Windows.Forms.Button btnPrestamosPedientes;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.DataGridView dgvPagosRecientes;
        private System.Windows.Forms.Label lblSaldoNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDinero;
        private System.Windows.Forms.Button btnSaldo;
    }
}

