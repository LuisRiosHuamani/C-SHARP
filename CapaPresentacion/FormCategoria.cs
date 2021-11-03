using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class TopFormulario : Form
    {
        private string idcategoria;
        private bool Editarse = false;

        E_CATEGORIA objEntidad = new E_CATEGORIA();
        N_CATEGORIA objNegocio = new N_CATEGORIA();

        public TopFormulario()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TopFormulario_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
        }
        public void accionesTabla()
        {
            dtgCategorias.Columns[0].Visible = false;
            dtgCategorias.Columns[1].Width = 60;
            dtgCategorias.Columns[2].Width = 170;

            dtgCategorias.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_CATEGORIA objNegocio = new N_CATEGORIA();
            dtgCategorias.DataSource = objNegocio.ListandoCategoria(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void limpiarCajas()
        {
            Editarse = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dtgCategorias.SelectedRows.Count > 0)
            {
                Editarse = true;
                idcategoria = dtgCategorias.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dtgCategorias.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dtgCategorias.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dtgCategorias.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Editarse == false)
            {
                try
                {
                    objEntidad.Idcategoria = Convert.ToInt32(idcategoria);
                    objEntidad.Nombrecategoria = txtNombre.Text.ToUpper();
                    objEntidad.Descripcioncategoria = txtDescripcion.Text.ToUpper();

                    objNegocio.InsertandoCategoria(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    mostrarBuscarTabla("");                    
                    limpiarCajas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
            if (Editarse == true)
            {
                try
                {
                    objEntidad.Idcategoria = Convert.ToInt32(idcategoria);
                    objEntidad.Nombrecategoria = txtNombre.Text.ToUpper();
                    objEntidad.Descripcioncategoria = txtDescripcion.Text.ToUpper();

                    objNegocio.EditandoCategoria(objEntidad);
                    MessageBox.Show("Se edito el registro");
                    mostrarBuscarTabla("");
                    limpiarCajas();
                    Editarse = false;                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dtgCategorias.SelectedRows.Count > 0)
            {
                objEntidad.Idcategoria = Convert.ToInt32(dtgCategorias.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoCategoria(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que deseas eliminar");
            }
        }
    }
}
