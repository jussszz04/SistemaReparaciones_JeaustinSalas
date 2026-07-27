using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using SistemaReparaciones.Logica;

namespace SistemaReparaciones
{
    public partial class Login : Page
    {
        private readonly LoginLogica loginLogica = new LoginLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text.Trim() == "" ||
                txtClave.Text.Trim() == "")
            {
                MostrarMensaje(
                    "Debe completar todos los campos.",
                    Color.Red);

                return;
            }

            try
            {
                DataTable resultado = loginLogica.ValidarUsuario(
                    txtCorreo.Text.Trim(),
                    txtClave.Text.Trim());

                if (resultado.Rows.Count > 0)
                {
                    Session["UsuarioID"] =
                        resultado.Rows[0]["UsuarioID"].ToString();

                    Session["NombreUsuario"] =
                        resultado.Rows[0]["Nombre"].ToString();

                    Response.Redirect("Menu.aspx");
                }
                else
                {
                    MostrarMensaje(
                        "Correo o contraseña incorrectos.",
                        Color.Red);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje(
                    "Error al iniciar sesión: " + ex.Message,
                    Color.Red);
            }
        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }
    }
}