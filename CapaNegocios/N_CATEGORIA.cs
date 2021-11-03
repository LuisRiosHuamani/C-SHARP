using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocios
{
    public class N_CATEGORIA
    {
        D_CATEGORIA objDato = new D_CATEGORIA();

        public List<E_CATEGORIA>ListandoCategoria(string buscar)
        {
            return objDato.ListarCategorias(buscar);
        }
        public void InsertandoCategoria(E_CATEGORIA Categoria)
        {
            objDato.InsertarCategoria(Categoria);
        }
        public void EditandoCategoria(E_CATEGORIA Categoria)
        {
            objDato.EditarCategoria(Categoria);
        }
        public void EliminandoCategoria(E_CATEGORIA Categoria)
        {
            objDato.EliminarCategoria(Categoria);
        }
    }
}
