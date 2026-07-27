using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaReparaciones.Logica;
using SistemaReparaciones.Modelo;

namespace SistemaReparaciones
{
    public partial class Usuarios : Page
    {
        private readonly UsuarioLogica usuarioLogica = new UsuarioLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            gvUsuarios.DataSource = usuarioLogica.Listar();
            gvUsuarios.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = txtNombre.Text.Trim();
                usuario.CorreoElectronico = txtCorreo.Text.Trim();
                usuario.Telefono = txtTelefono.Text.Trim();

                usuarioLogica.Insertar(usuario);

                MostrarMensaje("Usuario guardado correctamente.", Color.Green);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, Color.Red);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int usuarioID;

            if (!int.TryParse(hfUsuarioID.Value, out usuarioID))
            {
                MostrarMensaje("Primero seleccione un usuario.", Color.Red);
                return;
            }

            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                Usuario usuario = new Usuario();

                usuario.UsuarioID = usuarioID;
                usuario.Nombre = txtNombre.Text.Trim();
                usuario.CorreoElectronico = txtCorreo.Text.Trim();
                usuario.Telefono = txtTelefono.Text.Trim();

                usuarioLogica.Modificar(usuario);

                MostrarMensaje("Usuario modificado correctamente.", Color.Green);
                LimpiarCampos();
                CargarUsuarios();
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

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarUsuario")
            {
                string[] datos = e.CommandArgument.ToString().Split('|');

                hfUsuarioID.Value = datos[0];
                txtNombre.Text = datos[1];
                txtCorreo.Text = datos[2];
                txtTelefono.Text = datos[3];

                MostrarMensaje("Usuario seleccionado.", Color.Blue);
            }

            if (e.CommandName == "EliminarUsuario")
            {
                int usuarioID;

                if (int.TryParse(e.CommandArgument.ToString(), out usuarioID))
                {
                    try
                    {
                        usuarioLogica.Eliminar(usuarioID);

                        MostrarMensaje("Usuario eliminado correctamente.", Color.Green);
                        LimpiarCampos();
                        CargarUsuarios();
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
            if (txtNombre.Text.Trim() == "" ||
                txtCorreo.Text.Trim() == "" ||
                txtTelefono.Text.Trim() == "")
            {
                MostrarMensaje("Debe completar todos los campos.", Color.Red);
                return false;
            }

            if (!txtCorreo.Text.Contains("@"))
            {
                MostrarMensaje("Ingrese un correo válido.", Color.Red);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            hfUsuarioID.Value = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }
    }
}