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
    public partial class esclarecerForm : Form
    {
        public esclarecerForm(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void esclarecerForm_Load(object sender, EventArgs e)
        {
            
        }
        public static void confirmacionForm(string mensaje)
        {
            esclarecerForm frm = new esclarecerForm(mensaje);
            frm.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
