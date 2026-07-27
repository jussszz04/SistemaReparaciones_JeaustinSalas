using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones.Datos
{
    public class TecnicoDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Tecnico> Listar()
        {
            List<Tecnico> lista = new List<Tecnico>();

            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarTecnicos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tecnico tecnico = new Tecnico();

                    tecnico.TecnicoID = (int)dr["TecnicoID"];
                    tecnico.Nombre = dr["Nombre"].ToString();
                    tecnico.Especialidad = dr["Especialidad"].ToString();

                    lista.Add(tecnico);
                }
            }

            return lista;
        }

        public void Insertar(Tecnico tecnico)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarTecnico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", tecnico.Nombre);
                cmd.Parameters.AddWithValue(
                    "@Especialidad",
                    tecnico.Especialidad);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Tecnico tecnico)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarTecnico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@TecnicoID",
                    tecnico.TecnicoID);

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    tecnico.Nombre);

                cmd.Parameters.AddWithValue(
                    "@Especialidad",
                    tecnico.Especialidad);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarTecnico", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TecnicoID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}