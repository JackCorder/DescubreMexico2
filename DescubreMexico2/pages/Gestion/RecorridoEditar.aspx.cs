using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;
using static DescubreMexico2.Util.Enumeradores;

namespace DescubreMexico2.pages.Gestion
{
    public partial class RecorridoEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefrescarGrid();
            }
        }

        public void RefrescarGrid()
        {
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("GestionIndex.aspx");
            }
            else
            {
                //Obtener Id del chofer
                int IdRecorrido = int.Parse(Request.QueryString["Id"]);
                RecorridoVO recorrido = BllRecorridos.GetRecorridoById(IdRecorrido);

                //Validar que el chofer es correcto
                if (recorrido.IdRecorrido == IdRecorrido)
                {
                    //Desplegar la información del chofer
                    this.lblIdRecorrido.Text = IdRecorrido.ToString();
                    this.txtTitulo.Text = recorrido.Titulo.ToString();
                    this.txtDescripcion.Text = recorrido.Descripcion.ToString();
                    this.ddlTipoRecorrido.SelectedValue = recorrido.IdTipo.ToString();
                    this.txtDuracionHoras.Text = recorrido.DuracionHoras.ToString();
                    this.txtPrecio.Text = recorrido.Precio.ToString();
                    this.ddlDificultad.SelectedValue = recorrido.Dificultad.ToString();
                    this.txtMaxParticipantes.Text = recorrido.MaxParticipantes.ToString();
                    this.ddlGuia.SelectedValue = recorrido.IdGuia.ToString();
                    this.chkActivo.Checked = recorrido.Activo;

                    CargarLugaresDelRecorrido();

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
                else
                {
                    Response.Redirect("GestionIndex.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdRecorrido = int.Parse(this.lblIdRecorrido.Text);
                string Titulo = txtTitulo.Text.Trim();
                string Descripcion = txtDescripcion.Text.Trim();
                int IdTipo = int.Parse(ddlTipoRecorrido.SelectedValue);
                int DuracionHoras = int.Parse(txtDuracionHoras.Text);
                decimal Precio = decimal.Parse(txtPrecio.Text);
                string Dificultad = ddlDificultad.SelectedValue;
                int MaxParticipantes = int.Parse(txtMaxParticipantes.Text);
                int IdGuia = int.Parse(ddlGuia.SelectedValue);
                string GuiaNombre = ddlGuia.SelectedItem.Text;
                bool Activo = chkActivo.Checked;

                BllRecorridos.UpdRecorrido(IdRecorrido, Titulo, Descripcion, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia, Activo);

                UtilControls.SweetBoxConfirm("Exito!", "Guia Editado exitosamente", "success",
                    "GestionIndex.aspx", this.Page, this.GetType());

            }
            catch (Exception) {
                throw;
            }
            

        }

        private void CargarLugaresDelRecorrido()
        {
            int idRecorrido = int.Parse(this.lblIdRecorrido.Text);
            gvLugaresRecorrido.DataSource = BllRecorridoLugar.GetLstRecorridoLugar(idRecorrido);
            gvLugaresRecorrido.DataBind();

            ddlIdLugarNuevo.DataSource = BllLugares.GetLstLugares(null); // Tu método para obtener lugares
            ddlIdLugarNuevo.DataTextField = "Nombre";             // Nombre que verá el usuario
            ddlIdLugarNuevo.DataValueField = "IdLugar";           // Valor interno (ID)
            ddlIdLugarNuevo.DataBind();
        }

        protected void btnAgregarLugar_Click(object sender, EventArgs e)
        {
            int idRecorrido = int.Parse(this.lblIdRecorrido.Text);
            int idLugar = int.Parse(ddlIdLugarNuevo.SelectedValue);

            BllRecorridoLugar.InsLugar(idRecorrido, idLugar); // Método que tú defines

            RefrescarGrid();

            UtilControls.SweetBox("Lugar agregado", "", "success", this.Page, this.GetType());
        }

        protected void gvLugaresRecorrido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvLugaresRecorrido.Rows[index];
                int idRecorridoLugar = Convert.ToInt32(gvLugaresRecorrido.DataKeys[index].Value);

                BllRecorridoLugar.DelRecorridoLugar(idRecorridoLugar); // Método que tú defines

                RefrescarGrid();

                UtilControls.SweetBox("Lugar eliminado", "", "success", this.Page, this.GetType());
            }
        }
    }
}