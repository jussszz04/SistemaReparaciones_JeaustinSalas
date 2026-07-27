using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaReparaciones.Logica;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones
{
    public partial class Equipos : Page
    {
        private readonly EquipoLogica equipoLogica = new EquipoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipos();
            }
        }

        private void CargarEquipos()
        {
            gvEquipos.DataSource = equipoLogica.Listar();
            gvEquipos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                Equipo equipo = new Equipo();

                equipo.TipoEquipo = txtTipoEquipo.Text.Trim();
                equipo.Modelo = txtModelo.Text.Trim();
                equipo.UsuarioID = int.Parse(txtUsuarioID.Text.Trim());

                equipoLogica.Insertar(equipo);

                MostrarMensaje("Equipo guardado correctamente.", Color.Green);
                LimpiarCampos();
                CargarEquipos();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, Color.Red);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int equipoID;

            if (!int.TryParse(hfEquipoID.Value, out equipoID))
            {
                MostrarMensaje("Primero seleccione un equipo.", Color.Red);
                return;
            }

            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                Equipo equipo = new Equipo();

                equipo.EquipoID = equipoID;
                equipo.TipoEquipo = txtTipoEquipo.Text.Trim();
                equipo.Modelo = txtModelo.Text.Trim();
                equipo.UsuarioID = int.Parse(txtUsuarioID.Text.Trim());

                equipoLogica.Modificar(equipo);

                MostrarMensaje("Equipo modificado correctamente.", Color.Green);
                LimpiarCampos();
                CargarEquipos();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al modificar: " + ex.Message, Color.Red);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            lblMensaje.Text = "";
        }

        protected void gvEquipos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarEquipo")
            {
                string[] datos = e.CommandArgument.ToString().Split('|');

                hfEquipoID.Value = datos[0];
                txtTipoEquipo.Text = datos[1];
                txtModelo.Text = datos[2];
                txtUsuarioID.Text = datos[3];

                MostrarMensaje("Equipo seleccionado.", Color.Blue);
            }

            if (e.CommandName == "EliminarEquipo")
            {
                int equipoID;

                if (int.TryParse(e.CommandArgument.ToString(), out equipoID))
                {
                    try
                    {
                        equipoLogica.Eliminar(equipoID);

                        MostrarMensaje("Equipo eliminado correctamente.", Color.Green);
                        LimpiarCampos();
                        CargarEquipos();
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje("No se pudo eliminar: " + ex.Message, Color.Red);
                    }
                }
            }
        }

        private bool ValidarCampos()
        {
            if (txtTipoEquipo.Text.Trim() == "" ||
                txtModelo.Text.Trim() == "" ||
                txtUsuarioID.Text.Trim() == "")
            {
                MostrarMensaje("Debe completar todos los campos.", Color.Red);
                return false;
            }

            int usuarioID;

            if (!int.TryParse(txtUsuarioID.Text.Trim(), out usuarioID))
            {
                MostrarMensaje("El ID del usuario debe ser un número.", Color.Red);
                return false;
            }

            if (usuarioID <= 0)
            {
                MostrarMensaje("El ID del usuario debe ser mayor que cero.", Color.Red);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            hfEquipoID.Value = "";
            txtTipoEquipo.Text = "";
            txtModelo.Text = "";
            txtUsuarioID.Text = "";
        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }
    }
}