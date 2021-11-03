using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_MARCA
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_MARCA> ListarMarcas(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_MARCA> Listar = new List<E_MARCA>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_MARCA
                {
                    Idmarca = LeerFilas.GetInt32(0),
                    Codigomarca = LeerFilas.GetString(1),
                    Nombremarca = LeerFilas.GetString(2),
                    Descripcionmarca = LeerFilas.GetString(3)
                });
            }
            conexion.Close();
            LeerFilas.Close();

            return Listar;
        }
        public void InsertarMarca(E_MARCA Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Marca.Nombremarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.Descripcionmarca);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EditarMarca(E_MARCA Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDMARCA", Marca.Idmarca);
            cmd.Parameters.AddWithValue("@NOMBRE", Marca.Nombremarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.Descripcionmarca);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EliminarMarca(E_MARCA Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDMARCA", Marca.Idmarca);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
