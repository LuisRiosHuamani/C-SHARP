using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmPrincipal01 : Form
    {
        public FrmPrincipal01()
        {
            InitializeComponent();
        }
        public void PantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void FrmPrincipal01_Load(object sender, EventArgs e)
        {
            PantallaOK();
        }

        private void pSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FrmInformation("¿SEGURO DESEA SALIR DEL SISTEMA?");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private Form formActivado = null;

        private void AbrirFormulariosEnWrapper(Form FormHijo)
        {
            if (formActivado != null)
                formActivado.Close();
            formActivado = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;            
            FormHijo.BringToFront();
            FormHijo.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulariosEnWrapper(new FrmDASHBOARD());
        }
    }
}
