using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DescubreMexico2.pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si quieres, puedes limpiar mensajes aquí o cualquier otra lógica
            if (!IsPostBack)
            {
                lblMensaje.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Aquí llamas a tu método que obtiene la contraseña almacenada por email
            string passObtenido = BllUsuarios.GetUsuarioByEmail(email);
            
            if(passObtenido != "")
            {
                if (!string.IsNullOrEmpty(email))
                {
                    if (password == passObtenido)
                    {
                        // Login exitoso, guarda sesión y redirige
                        Session["Usuario"] = email;
                        Response.Redirect("Gestion/GestionIndex.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Correo o contraseña incorrectos.";
                    }
                }
                else
                {
                    lblMensaje.Text = "Por favor, ingrese un correo válido.";
                }
            }
            else
            {
                lblMensaje.Text = "Correo o contraseña incorrectos.";
            }
        }
    }
}