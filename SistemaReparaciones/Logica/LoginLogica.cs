using System.Data;
using SistemaReparaciones.Datos;

namespace SistemaReparaciones.Logica
{
    public class LoginLogica
    {
        private readonly LoginDatos datos = new LoginDatos();

        public DataTable ValidarUsuario(string correo, string clave)
        {
            return datos.ValidarUsuario(correo, clave);
        }
    }
}