using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_PRODUCTOS
    {
        D_PRODUCTOS objDato = new D_PRODUCTOS();

        public DataTable ListandoProductos()
        {
            return objDato.ListarProductos();
        }
    }
}
