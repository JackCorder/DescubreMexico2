using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DescubreMexico2.pages.Guias
{
    public partial class GuiaAlta : System.Web.UI.Page
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
                string telefono = txtTelefono.Text.Trim();
                string experiencia = txtTelefono.Text.Trim();

                // Validación adicional opcional (por código)
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(experiencia) || string.IsNullOrEmpty(telefono))
                {
                    UtilControls.SweetBox("Advertencia", "Todos los campos son obligatorios", "warning", this.Page, this.GetType());
                    return;
                }

                // Aquí deberías llamar al método BLL para insertar al usuario
                BllGuias.InsGuia(nombre, email, telefono, experiencia);

                UtilControls.SweetBoxConfirm(
                    "Éxito!",
                    "Guia agregado exitosamente",
                    "success",
                    "Guias.aspx",
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