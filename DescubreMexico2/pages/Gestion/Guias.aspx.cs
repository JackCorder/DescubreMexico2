using CapaNegocio;
using DescubreMexico2.pages.Gestion;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DescubreMexico2.pages.Gestion
{
    public partial class Guias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Es true si se acaba de recargar la página utilizando algín evento. en este caso, el false indica que es la priemra vez que se carga la página.
            {
                try
                {
                    RefrescarGrid();
                }
                catch (Exception ex)
                {
                    UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
                }
            }
        }


        public void RefrescarGrid()
        {
            var lista = BllGuias.GetLstGuias(null);
            GVGuiass.DataSource = lista;
            GVGuiass.DataBind();

            System.Diagnostics.Debug.WriteLine("Guias encontrados: " + lista.Count);
        }

        protected void GVGuiass_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = GVGuiass.DataKeys[e.RowIndex].Values["IdGuia"].ToString();
            string Resultado = BllGuias.DelGuia(int.Parse(Id));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Guia Eliminado con éxito";
                    sub = "";
                    clase = "success";
                    break;
                default:
                    mensaje = "Guia no puede ser eliminado";
                    sub = "Guia inactivo no pueden ser eliminado";
                    clase = "warning";
                    break;
            }
            UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVGuiass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string Id = GVGuiass.DataKeys[index].Values["IdGuia"].ToString();
                Response.Redirect("GuiaEditar.aspx?Id=" + Id);
            }
        }

        protected void GVGuiass_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVGuiass.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVGuiass_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Id = GVGuiass.DataKeys[e.RowIndex].Values["IdGuia"].ToString();
            string Nombre = e.NewValues["Nombre"].ToString();
            string Email = e.NewValues["Email"].ToString();
            string Telefono = e.NewValues["Telefono"].ToString();
            
            CheckBox ChkAux = (CheckBox)GVGuiass.Rows[e.RowIndex].FindControl("ChkEditActivo");
            bool Activo = ChkAux.Checked;

            BllGuias.UpdGuia(int.Parse(Id), Nombre, Email, Telefono, null, Activo);

            GVGuiass.EditIndex = -1;
            RefrescarGrid();
            UtilControls.SweetBox("Registro actualizado", "", "success", this.Page, this.GetType());

        }

        protected void GVGuiass_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVGuiass.EditIndex = -1;
            RefrescarGrid();
        }
    }
}