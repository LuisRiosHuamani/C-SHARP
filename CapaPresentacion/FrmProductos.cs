using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            MostrarTablaProductos();
        }        

        private void pMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pWrapper_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void pSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void pHeader_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ocultarMoverAncharColumnas()
        {
            dtgPRODUCTOS.Columns[2].Visible = false;
            dtgPRODUCTOS.Columns[5].Visible = false;
            dtgPRODUCTOS.Columns[7].Visible = false;

            dtgPRODUCTOS.Columns[2].Width = 70;
            dtgPRODUCTOS.Columns[2].Width = 200;

            dtgPRODUCTOS.Columns[2].DisplayIndex = 11;
            dtgPRODUCTOS.Columns[2].DisplayIndex = 11;
        }
        public void MostrarTablaProductos()
        {
            N_PRODUCTOS objNegocio = new N_PRODUCTOS();
            dtgPRODUCTOS.DataSource = objNegocio.ListandoProductos();
        }
    }
}
