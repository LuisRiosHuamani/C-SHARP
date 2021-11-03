using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocios
{
    public class N_MARCA
    {
        D_MARCA objDato = new D_MARCA();

        public List<E_MARCA> ListandoMarca(string buscar)
        {
            return objDato.ListarMarcas(buscar);
        }
        public void InsertandoMarca(E_MARCA Marca)
        {
            objDato.InsertarMarca(Marca);
        }
        public void EditandoMarca(E_MARCA Marca)
        {
            objDato.EditarMarca(Marca);
        }
        public void EliminandoMarca(E_MARCA Marca)
        {
            objDato.EliminarMarca(Marca);
        }
    }
}
