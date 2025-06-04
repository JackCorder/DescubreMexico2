using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DescubreMexico2.pages.Usuarios
{
    public partial class Usuarios : System.Web.UI.Page
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
            var lista = BllUsuarios.GetLstUsuarios(null);
            GVUsuarios.DataSource = lista;
            GVUsuarios.DataBind();

            System.Diagnostics.Debug.WriteLine("Usuarios encontrados: " + lista.Count);
        }

        protected void GVUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdUsuario = GVUsuarios.DataKeys[e.RowIndex].Values["IdUsuario"].ToString();
            string Resultado = BllUsuarios.DelUsuario(int.Parse(IdUsuario));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Usuario Eliminado con éxito";
                    sub = "";
                    clase = "success";
                    break;
                default:
                    mensaje = "Usuario no puede ser eliminado";
                    sub = "Usuario inactivo no pueden ser eliminado";
                    clase = "warning";
                    break;
            }
            UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //este boton va a redireccionar a un nuevo aspx llamado EditarChofer
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string IdUsuario = GVUsuarios.DataKeys[index].Values["IdUsuario"].ToString();
                Response.Redirect("UsuarioEdit.aspx?Id=" + IdUsuario);
            }

        }

        protected void GVUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVUsuarios.EditIndex = e.NewEditIndex;
            RefrescarGrid();

        }

        protected void GVUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string IdUsuario = GVUsuarios.DataKeys[e.RowIndex].Values["IdUsuario"].ToString();
            string Nombre = e.NewValues["Nombre"].ToString();
            string Email = e.NewValues["Email"].ToString();
            string Telefono = e.NewValues["Telefono"].ToString();

            CheckBox ChkAux = (CheckBox)GVUsuarios.Rows[e.RowIndex].FindControl("ChkEditActivo");
            bool Activo = ChkAux.Checked;

            BllUsuarios.UpdUsuario(int.Parse(IdUsuario), Nombre, Email, Telefono, Activo);

            GVUsuarios.EditIndex = -1;
            RefrescarGrid();
            UtilControls.SweetBox("Registro actualizado", "", "success", this.Page, this.GetType());
        }

        protected void GVUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVUsuarios.EditIndex = -1;
            RefrescarGrid();
        }
    }
}