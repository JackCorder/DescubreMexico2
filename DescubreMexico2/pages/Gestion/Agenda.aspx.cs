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
    public partial class Agenda : System.Web.UI.Page
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
            var lista = BllAgenda.GetLstAgendas();
            GVAgendas.DataSource = lista;
            GVAgendas.DataBind();

        }

        protected void GVAgendas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdAgenda = GVAgendas.DataKeys[e.RowIndex].Values["IdAgenda"].ToString();
            string Resultado = BllAgenda.DelAgenda(int.Parse(IdAgenda));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Evento Eliminado con éxito";
                    sub = "";
                    clase = "success";
                    break;
                default:
                    mensaje = "Evento no puede ser eliminado";
                    sub = "Evento cancelado no pueden ser eliminado";
                    clase = "warning";
                    break;
            }
            UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }


        protected void GVAgendas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVAgendas.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVAgendas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GVAgendas.Rows[e.RowIndex];

            string IdAgenda = GVAgendas.DataKeys[e.RowIndex].Values["IdAgenda"].ToString();

            TextBox txtFecha = row.FindControl("txtFecha") as TextBox;
            TextBox txtHora = row.FindControl("txtHoraInicio") as TextBox;

            DateTime fecha = DateTime.Parse(txtFecha.Text);
            DateTime horaInicio = DateTime.Parse(txtHora.Text);

            DropDownList ddlRecorrido = (DropDownList)row.FindControl("DDLRecorrido");
            int IdRecorrido = int.Parse(ddlRecorrido.SelectedValue);

            DropDownList ddlEstado = (DropDownList)row.FindControl("DDLEstado");
            string Estado = ddlEstado.SelectedValue;

            BllAgenda.UpdGuia(int.Parse(IdAgenda), IdRecorrido, fecha, horaInicio, Estado);

            GVAgendas.EditIndex = -1;
            RefrescarGrid();

            UtilControls.SweetBox("Registro actualizado", "", "success", this.Page, this.GetType());
        }


        protected void GVAgendas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVAgendas.EditIndex = -1;
            RefrescarGrid();
        }

        protected void GVAgendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                // Cargar guías
                List<RecorridoVO> recorridos = BllRecorridos.GetLstRecorridos(null, null, null);

                DropDownList ddlRecorrido = (DropDownList)e.Row.FindControl("DDLRecorrido");
                if (ddlRecorrido != null)
                {
                    ddlRecorrido.DataSource = recorridos;
                    ddlRecorrido.DataTextField = "Titulo";
                    ddlRecorrido.DataValueField = "IdRecorrido";
                    ddlRecorrido.DataBind();

                    string idRecorridoActual = DataBinder.Eval(e.Row.DataItem, "IdRecorrido").ToString();
                    ddlRecorrido.SelectedValue = idRecorridoActual;
                }
            }
        }


        

    }
}