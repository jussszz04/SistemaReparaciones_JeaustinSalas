using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaReparaciones.Logica;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones
{
    public partial class Tecnicos : Page
    {
        private readonly TecnicoLogica tecnicoLogica = new TecnicoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTecnicos();
            }
        }

        private void CargarTecnicos()
        {
            gvTecnicos.DataSource = tecnicoLogica.Listar();
            gvTecnicos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                Tecnico tecnico = new Tecnico();

                tecnico.Nombre = txtNombre.Text.Trim();
                tecnico.Especialidad = txtEspecialidad.Text.Trim();

                tecnicoLogica.Insertar(tecnico);

                MostrarMensaje("Técnico guardado correctamente.", Color.Green);
                LimpiarCampos();
                CargarTecnicos();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, Color.Red);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int tecnicoID;

            if (!int.TryParse(hfTecnicoID.Value, out tecnicoID))
            {
                MostrarMensaje("Primero seleccione un técnico.", Color.Red);
                return;
            }

            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                Tecnico tecnico = new Tecnico();

                tecnico.TecnicoID = tecnicoID;
                tecnico.Nombre = txtNombre.Text.Trim();
                tecnico.Especialidad = txtEspecialidad.Text.Trim();

                tecnicoLogica.Modificar(tecnico);

                MostrarMensaje("Técnico modificado correctamente.", Color.Green);
                LimpiarCampos();
                CargarTecnicos();
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

        protected void gvTecnicos_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarTecnico")
            {
                string[] datos =
                    e.CommandArgument.ToString().Split('|');

                if (datos.Length >= 3)
                {
                    hfTecnicoID.Value = datos[0];
                    txtNombre.Text = datos[1];
                    txtEspecialidad.Text = datos[2];

                    MostrarMensaje(
                        "Técnico seleccionado.",
                        Color.Blue);
                }
            }

            if (e.CommandName == "EliminarTecnico")
            {
                int tecnicoID;

                if (int.TryParse(
                    e.CommandArgument.ToString(),
                    out tecnicoID))
                {
                    try
                    {
                        tecnicoLogica.Eliminar(tecnicoID);

                        MostrarMensaje(
                            "Técnico eliminado correctamente.",
                            Color.Green);

                        LimpiarCampos();
                        CargarTecnicos();
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje(
                            "No se pudo eliminar: " + ex.Message,
                            Color.Red);
                    }
                }
            }
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text.Trim() == "" ||
                txtEspecialidad.Text.Trim() == "")
            {
                MostrarMensaje(
                    "Debe completar todos los campos.",
                    Color.Red);

                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            hfTecnicoID.Value = "";
            txtNombre.Text = "";
            txtEspecialidad.Text = "";
        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }
    }
}