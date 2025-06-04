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
    public partial class Lugares : System.Web.UI.Page
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
            var lista = BllLugares.GetLstLugares(null);
            GVLugares.DataSource = lista;
            GVLugares.DataBind();

            System.Diagnostics.Debug.WriteLine("Lugares encontrados: " + lista.Count);
        }

        protected void GVLugares_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = GVLugares.DataKeys[e.RowIndex].Values["IdLugar"].ToString();
            string Resultado = BllLugares.DelLugar(int.Parse(Id));
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

        protected void GVLugares_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string Id = GVLugares.DataKeys[index].Values["IdLugar"].ToString();
                Response.Redirect("LugarEditar.aspx?Id=" + Id);
            }
        }

        protected void GVLugares_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVLugares.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVLugares_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Id = GVLugares.DataKeys[e.RowIndex].Values["IdLugar"].ToString();
            string Nombre = e.NewValues["Nombre"].ToString();
            string Descripcion = e.NewValues["Descripcion"].ToString();
            string Ciudad = e.NewValues["Ciudad"].ToString();
            decimal Latitud = decimal.Parse(e.NewValues["Latitud"].ToString());
            decimal Longitud = decimal.Parse(e.NewValues["Longitud"].ToString());

            CheckBox ChkAux = (CheckBox)GVLugares.Rows[e.RowIndex].FindControl("ChkEditActivo");
            bool Activo = ChkAux.Checked;

            BllLugares.UpdLugar(int.Parse(Id), Nombre, Descripcion, Ciudad, Latitud, Longitud, null, Activo);

            GVLugares.EditIndex = -1;
            RefrescarGrid();
            UtilControls.SweetBox("Registro actualizado", "", "success", this.Page, this.GetType());
        }

        protected void GVLugares_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVLugares.EditIndex = -1;
            RefrescarGrid();
        }
    }
}