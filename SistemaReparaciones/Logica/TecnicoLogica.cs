using System.Collections.Generic;
using SistemaReparaciones.Datos;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones.Logica
{
    public class TecnicoLogica
    {
        private readonly TecnicoDatos datos = new TecnicoDatos();

        public List<Tecnico> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Tecnico tecnico)
        {
            datos.Insertar(tecnico);
        }

        public void Modificar(Tecnico tecnico)
        {
            datos.Modificar(tecnico);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }
    }
}