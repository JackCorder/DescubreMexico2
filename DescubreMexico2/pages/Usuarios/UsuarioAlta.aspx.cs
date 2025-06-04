using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DescubreMexico2.pages.Usuarios
{
    public partial class UsuarioAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;
                string telefono = txtTelefono.Text.Trim();
                string tipoUsuario = ddlTipoUsuario.SelectedValue;

                // Validación adicional opcional (por código)
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(tipoUsuario))
                {
                    UtilControls.SweetBox("Advertencia", "Todos los campos son obligatorios", "warning", this.Page, this.GetType());
                    return;
                }

                // Aquí deberías llamar al método BLL para insertar al usuario
                BllUsuarios.InsUsuario(nombre, email, password, telefono, tipoUsuario);

                UtilControls.SweetBoxConfirm(
                    "Éxito!",
                    "Usuario agregado exitosamente",
                    "success",
                    "Usuarios.aspx",
                    this.Page,
                    this.GetType()
                );
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
            }
        }
    }
}