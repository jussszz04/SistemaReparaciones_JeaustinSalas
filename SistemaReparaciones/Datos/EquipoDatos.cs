using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones.Datos
{
    public class EquipoDatos
    {
        Conexion conexion = new Conexion();

        public List<Equipo> Listar()
        {
            List<Equipo> lista = new List<Equipo>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarEquipos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Equipo equipo = new Equipo();

                    equipo.EquipoID = (int)dr["EquipoID"];
                    equipo.TipoEquipo = dr["TipoEquipo"].ToString();
                    equipo.Modelo = dr["Modelo"].ToString();
                    equipo.UsuarioID = (int)dr["UsuarioID"];

                    lista.Add(equipo);
                }
            }

            return lista;
        }

        public void Insertar(Equipo equipo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarEquipo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TipoEquipo", equipo.TipoEquipo);
                cmd.Parameters.AddWithValue("@Modelo", equipo.Modelo);
                cmd.Parameters.AddWithValue("@UsuarioID", equipo.UsuarioID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Equipo equipo)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarEquipo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EquipoID", equipo.EquipoID);
                cmd.Parameters.AddWithValue("@TipoEquipo", equipo.TipoEquipo);
                cmd.Parameters.AddWithValue("@Modelo", equipo.Modelo);
                cmd.Parameters.AddWithValue("@UsuarioID", equipo.UsuarioID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarEquipo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EquipoID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}