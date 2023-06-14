using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libOpeVerduras;

namespace VerdurasDelCampo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region "Metodos propios"
        private void Mensaje(string texto)
        {
            MessageBox.Show(texto, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            for (int i = 1; i <= 6; i++)
                this.cmbCodigo.Items.Add(i);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = cmbCodigo.SelectedIndex;

            if (item == 0)
            {
                lblVerdura.Text = "Aguacate";
                lblPrecioKg.Text = "$1.85";
            }
            if (item == 1)
            {
                lblVerdura.Text = "Zanahoria";
                lblPrecioKg.Text = "$1.20";
            }
            if (item == 2)
            {
                lblVerdura.Text = "Papa Nevada";
                lblPrecioKg.Text = "$1.75";
            }
            if (item == 3)
            {
                lblVerdura.Text = "Cebolla Huevo";
                lblPrecioKg.Text = "$0.98";
            }
            if (item == 4)
            {
                lblVerdura.Text = "Tomate de Aliño";
                lblPrecioKg.Text = "$1.15";
            }
            if (item == 5)
            {
                lblVerdura.Text = "Pera";
                lblPrecioKg.Text = "$2.00";
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int intCode;
            float fltvD, fltvCant;

            try
            {
                //Captura de la info
                intCode = this.cmbCodigo.SelectedIndex + 1;
                fltvD = Convert.ToSingle(this.txtVrDolar.Text);
                fltvCant = Convert.ToSingle(this.txtCantidad.Text);

                //Crear el objeto
                clsOpeVerduras Op = new clsOpeVerduras();

                //Enviar info
                Op.Codigo = intCode;
                Op.vrDolar = fltvD;
                Op.cantidad = fltvCant;

                if (!Op.Calcular())
                {
                    Mensaje(Op.Error);
                    Op = null;
                    return;
                }

                //Recuperar y mostrar info
                this.lblDescuento.Text = Op.vrDescuento.ToString();
                this.lblTotAPag.Text = Op.Total.ToString();
                this.grbTotal.Visible = true;
                Op = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text = string.Empty;
            this.txtVrDolar.Text = string.Empty;
            this.lblVerdura.Text = string.Empty;
            this.lblPrecioKg.Text = string.Empty;
            this.cmbCodigo.SelectedIndex = -1;
            this.grbTotal.Visible = false;
        }
    }
}
