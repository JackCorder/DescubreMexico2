using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DescubreMexico2.pages.Gestion
{
    public partial class AgendaAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var recorridos = BllRecorridos.GetLstRecorridos(null, null, null);
            ddlNuevoRecorrido.DataSource = recorridos;
            ddlNuevoRecorrido.DataTextField = "Titulo";
            ddlNuevoRecorrido.DataValueField = "IdRecorrido";
            ddlNuevoRecorrido.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {


            try
            {
                int IdRecorrido = int.Parse(ddlNuevoRecorrido.SelectedValue);
                DateTime FechaN = DateTime.Parse(txtNuevaFecha.Text);
                DateTime HoraN = DateTime.Parse(txtNuevaHora.Text);

                // Validación adicional opcional (por código)
                if ((IdRecorrido == 0 )|| FechaN == null || HoraN == null)
                {
                    UtilControls.SweetBox("Advertencia", "Todos los campos son obligatorios", "warning", this.Page, this.GetType());
                    return;
                }

                // Aquí deberías llamar al método BLL para insertar al usuario
                BllAgenda.InsAgenda(IdRecorrido, FechaN, HoraN);

                UtilControls.SweetBoxConfirm(
                    "Éxito!",
                    "Evento agregado exitosamente",
                    "success",
                    "Agenda.aspx",
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