using System.Collections.Generic;
using SistemaReparaciones.Datos;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones.Logica
{
    public class EquipoLogica
    {
        EquipoDatos datos = new EquipoDatos();

        public List<Equipo> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Equipo equipo)
        {
            datos.Insertar(equipo);
        }

        public void Modificar(Equipo equipo)
        {
            datos.Modificar(equipo);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }
    }
}