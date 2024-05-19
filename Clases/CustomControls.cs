using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace expressLoan.Clases
{
    internal class CustomControls
    {
        public static GroupBox CreateCustomGroupBox(string name, string titulo, string texto, Form parentForm, EventHandler onAccept)
        {
            GroupBox gbModal = new GroupBox();
            gbModal.Name = name;
            gbModal.Text = titulo;
            gbModal.Size = new System.Drawing.Size(455, 275);
            gbModal.Location = new System.Drawing.Point(160, 140);
            gbModal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

            Label lblTexto = new Label();
            lblTexto.Name = "lblTexto";
            lblTexto.Location = new System.Drawing.Point(132, 70);
            lblTexto.Text = texto;

            TextBox txtSaldo = new TextBox();
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Location = new System.Drawing.Point(135, 100);
            txtSaldo.Size = new System.Drawing.Size(175, 20);

            Button btnCancelar = new Button();
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new System.Drawing.Point(60, 215);
            btnCancelar.Size = new System.Drawing.Size(100, 35);
            btnCancelar.BackColor = SystemColors.Window;
            btnCancelar.Click += (sender, e) => parentForm.Controls.Remove(gbModal);

            Button btnAceptar = new Button();
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Text = "Aceptar";
            btnAceptar.Location = new System.Drawing.Point(290, 215);
            btnAceptar.Size = new System.Drawing.Size(100, 35);
            btnAceptar.BackColor = SystemColors.Window;
            btnAceptar.Click += (sender, e) => {
                onAccept?.Invoke(txtSaldo, EventArgs.Empty);
            };

            gbModal.Controls.Add(txtSaldo);
            gbModal.Controls.Add(lblTexto);
            gbModal.Controls.Add(txtSaldo);
            gbModal.Controls.Add(btnCancelar);
            gbModal.Controls.Add(btnAceptar);

            return gbModal;
        }
    }
}
