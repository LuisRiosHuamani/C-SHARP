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
    public partial class TopMarca : Form
    {
        private string idmarca;
        private bool Editarse = false;

        E_MARCA objEntidad = new E_MARCA();
        N_MARCA objNegocio = new N_MARCA();

        public TopMarca()
        {
            InitializeComponent();
        }

        private void FormMarca_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
        }

        private void CerrarFormulario_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void accionesTabla()
        {
            dtgMarcas.Columns[0].Visible = false;
            dtgMarcas.Columns[1].Width = 60;
            dtgMarcas.Columns[2].Width = 170;

            dtgMarcas.ClearSelection();
        }
        public void mostrarBuscarTabla(string buscar)
        {
            N_MARCA objNegocio = new N_MARCA();
            dtgMarcas.DataSource = objNegocio.ListandoMarca(buscar);
        }

        private void limpiarCajas()
        {
            Editarse = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
        }
       
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dtgMarcas.SelectedRows.Count > 0)
            {
                Editarse = true;
                idmarca = dtgMarcas.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dtgMarcas.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dtgMarcas.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dtgMarcas.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.Idmarca = Convert.ToInt32(idmarca);
                    objEntidad.Nombremarca = txtNombre.Text.ToUpper();
                    objEntidad.Descripcionmarca = txtDescripcion.Text.ToUpper();

                    objNegocio.InsertandoMarca(objEntidad);

                    esclarecerForm.confirmacionForm("GUARDADO");
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
                    objEntidad.Idmarca = Convert.ToInt32(idmarca);
                    objEntidad.Nombremarca = txtNombre.Text.ToUpper();
                    objEntidad.Descripcionmarca = txtDescripcion.Text.ToUpper();

                    objNegocio.EditandoMarca(objEntidad);
                    esclarecerForm.confirmacionForm("EDITADO");
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = new DialogResult();
                FrmInformation frm = new FrmInformation("¿Estas segujro de eliminar el registro?");
                resultado = frm.ShowDialog();

                if(resultado == DialogResult.OK)
                {
                    objEntidad.Idmarca = Convert.ToInt32(dtgMarcas.CurrentRow.Cells[0].Value.ToString());
                    objNegocio.EliminandoMarca(objEntidad);

                    esclarecerForm.confirmacionForm("ELIMINADO");
                    mostrarBuscarTabla("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione la fila que desea eliminar" + ex);
            }
            
        }
    }
}
