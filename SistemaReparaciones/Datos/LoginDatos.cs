using System.Data;
using System.Data.SqlClient;

namespace SistemaReparaciones.Datos
{
    public class LoginDatos
    {
        private readonly Conexion conexion = new Conexion();

        public DataTable ValidarUsuario(string correo, string clave)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);

                adaptador.Fill(tabla);
            }

            return tabla;
        }
    }
}