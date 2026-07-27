using System.Configuration;
using System.Data.SqlClient;

namespace SistemaReparaciones.Datos
{
    public class Conexion
    {
        public SqlConnection ObtenerConexion()
        {
            string cadena = ConfigurationManager
                .ConnectionStrings["ConexionBD"]
                .ConnectionString;

            return new SqlConnection(cadena);
        }
    }
}