namespace expressLoan
{
    partial class frmBalance
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
            this.SuspendLayout();
            // 
            // lblVolver
            // 
            this.lblVolver.AutoSize = true;
            this.lblVolver.Location = new System.Drawing.Point(13, 13);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(17, 13);
            this.lblVolver.TabIndex = 0;
            this.lblVolver.Text = "⪡";
            this.lblVolver.Click += new System.EventHandler(this.lblVolver_Click);
            // 
            // frmBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 451);
            this.Controls.Add(this.lblVolver);
            this.MaximumSize = new System.Drawing.Size(790, 490);
            this.MinimumSize = new System.Drawing.Size(790, 490);
            this.Name = "frmBalance";
            this.Text = "Balance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBalance_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVolver;
    }
}