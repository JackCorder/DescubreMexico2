using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace DescubreMexico2.pages.Gestion
{
    public partial class GestionIndex : System.Web.UI.Page
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
            var lista = BllRecorridos.GetLstRecorridos(null, null, null);
            GVRecorridos.DataSource = lista;
            GVRecorridos.DataBind();

            System.Diagnostics.Debug.WriteLine("Recorridos encontrados: " + lista.Count);
        }

        protected void GVRecorridos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdRecorrido = GVRecorridos.DataKeys[e.RowIndex].Values["IdRecorrido"].ToString();
            string Resultado = BllRecorridos.DelRecorrido(int.Parse(IdRecorrido));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Recorrido Eliminado con éxito";
                    sub = "";
                    clase = "success";
                    break;
                default:
                    mensaje = "Recorrido no puede ser eliminado";
                    sub = "Recorrido inactivo no pueden ser eliminado";
                    clase = "warning";
                    break;
            }
            UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVRecorridos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string IdRecorrido = GVRecorridos.DataKeys[index].Values["IdRecorrido"].ToString();
                Response.Redirect("RecorridoEditar.aspx?Id=" + IdRecorrido);
            }
        }

        protected void GVRecorridos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVRecorridos.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVRecorridos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GVRecorridos.Rows[e.RowIndex];

            string IdRecorrido = GVRecorridos.DataKeys[e.RowIndex].Values["IdRecorrido"].ToString();

            string Titulo = e.NewValues["Titulo"].ToString();
            int DuracionHoras = int.Parse(e.NewValues["DuracionHoras"].ToString());
            decimal Precio = decimal.Parse(e.NewValues["Precio"].ToString());
            int MaxParticipantes = int.Parse(e.NewValues["MaxParticipantes"].ToString());

            DropDownList ddlTipo = (DropDownList)row.FindControl("DDLTipoRecorrido");
            int IdTipo = int.Parse(ddlTipo.SelectedValue);

            DropDownList ddlGuia = (DropDownList)row.FindControl("DDLGuia");
            int IdGuia = int.Parse(ddlGuia.SelectedValue);

            DropDownList ddlDificultad = (DropDownList)row.FindControl("DDLDificultad");
            string Dificultad = ddlDificultad.SelectedValue;

            CheckBox chkActivo = (CheckBox)row.FindControl("ChkEditActivo");
            bool Activo = chkActivo.Checked;

            BllRecorridos.UpdRecorrido(int.Parse(IdRecorrido), Titulo, null, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia, Activo);

            GVRecorridos.EditIndex = -1;
            RefrescarGrid();

            UtilControls.SweetBox("Registro actualizado", "", "success", this.Page, this.GetType());
        }


        protected void GVRecorridos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVRecorridos.EditIndex = -1;
            RefrescarGrid();
        }

        protected void GVRecorridos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                // Cargar guías
                List<GuiaVO> guias = BllGuias.GetLstGuias(true);

                DropDownList ddlGuia = (DropDownList)e.Row.FindControl("DDLGuia");
                if (ddlGuia != null)
                {
                    ddlGuia.DataSource = guias;
                    ddlGuia.DataTextField = "Nombre";
                    ddlGuia.DataValueField = "IdGuia";
                    ddlGuia.DataBind();

                    string idGuiaActual = DataBinder.Eval(e.Row.DataItem, "IdGuia").ToString();
                    ddlGuia.SelectedValue = idGuiaActual;
                }

                List<TipoRecorridoVO> tiposR = BllTiposRecorridos.GetLstTiposR();

                // Cargar tipos de recorrido si usas DDLTipoRecorrido también
                DropDownList ddlTipo = (DropDownList)e.Row.FindControl("DDLTipoRecorrido");
                if (ddlTipo != null)
                {
                    ddlTipo.DataSource = tiposR; // Ejemplo, cambia si tu método es diferente
                    ddlTipo.DataTextField = "Nombre";
                    ddlTipo.DataValueField = "IdTipoRecorrido";
                    ddlTipo.DataBind();

                    string idTipoActual = DataBinder.Eval(e.Row.DataItem, "IdTipo").ToString();
                    ddlTipo.SelectedValue = idTipoActual;
                }
            }
        }
    }
}