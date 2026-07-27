using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones.Datos
{
    public class UsuarioDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.CorreoElectronico = reader["CorreoElectronico"].ToString();
                    usuario.Telefono = reader["Telefono"].ToString();

                    lista.Add(usuario);
                }
            }

            return lista;
        }

        public void Insertar(Usuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Usuario usuario)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int usuarioID)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}