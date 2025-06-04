using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DescubreMexico2.Util.Enumeradores;

namespace DescubreMexico2.pages.Gestion
{
    public partial class RecorridoAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Llenar dificultad desde Enum
            ddlDificultad.DataSource = Enum.GetNames(typeof(Dificultad));
            ddlDificultad.DataBind();

            // Llenar Tipo Recorrido desde base de datos
            ddlTipoRecorrido.DataSource = BllTiposRecorridos.GetLstTiposR(); // debe devolver DataTable o List
            ddlTipoRecorrido.DataTextField = "Nombre";   // nombre visible
            ddlTipoRecorrido.DataValueField = "IdTipoRecorrido";  // valor al guardar
            ddlTipoRecorrido.DataBind();

            // Llenar Guías desde base de datos
            ddlGuia.DataSource = BllGuias.GetLstGuias(true); // debe devolver DataTable o List
            ddlGuia.DataTextField = "Nombre";
            ddlGuia.DataValueField = "IdGuia";
            ddlGuia.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Titulo = txtTitulo.Text.Trim();
                string Descripcion = txtDescripcion.Text.Trim();
                int IdTipo = int.Parse(ddlTipoRecorrido.SelectedValue);
                int DuracionHoras = int.Parse(txtDuracionHoras.Text);
                decimal Precio = decimal.Parse(txtPrecio.Text);
                string Dificultad = ddlDificultad.SelectedValue;
                int MaxParticipantes = int.Parse(txtMaxParticipantes.Text);
                int IdGuia = int.Parse(ddlGuia.SelectedValue);
                string GuiaNombre = ddlGuia.SelectedItem.Text;

                BllRecorridos.InsRecorrido(Titulo, Descripcion, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia);

                UtilControls.SweetBoxConfirm("Exito!", "Guia Registrado Exitosamente", "success",
                    "GestionIndex.aspx", this.Page, this.GetType());

            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}