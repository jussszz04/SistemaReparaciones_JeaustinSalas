using System.Collections.Generic;
using SistemaReparaciones.Datos;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones.Logica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public List<Usuario> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Usuario usuario)
        {
            datos.Insertar(usuario);
        }

        public void Modificar(Usuario usuario)
        {
            datos.Modificar(usuario);
        }

        public void Eliminar(int usuarioID)
        {
            datos.Eliminar(usuarioID);
        }
    }
}