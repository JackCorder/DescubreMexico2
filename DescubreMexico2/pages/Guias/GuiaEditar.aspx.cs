using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace DescubreMexico2.pages.Guias
{
    public partial class GuiaEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("Guias.aspx");
                }
                else
                {
                    //Obtener Id del chofer
                    int IdGuia = int.Parse(Request.QueryString["Id"]);
                    GuiaVO guia = BllGuias.GetGuiaById(IdGuia);

                    //Validar que el chofer es correcto
                    if (guia.IdGuia == IdGuia)
                    {
                        //Desplegar la información del chofer
                        this.lblIdGuia.Text = IdGuia.ToString();
                        this.txtNombre.Text = guia.Nombre;
                        this.txtEmail.Text = guia.Email;
                        this.txtTelefono.Text = guia.Telefono;
                        this.txtExperiencia.Text = guia.Experiencia.ToString();
                        this.chkActivo.Checked = guia.Activo;
                    }
                    else
                    {
                        Response.Redirect("Guias.aspx");
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.lblIdGuia.Text);
                string nombre = this.txtNombre.Text;
                string telefono = this.txtTelefono.Text;
                string email = this.txtEmail.Text;
                string experiencia = this.txtExperiencia.Text;
                bool Activo = chkActivo.Checked;

                BllGuias.UpdGuia(id, nombre, email, telefono, experiencia, Activo);

                UtilControls.SweetBoxConfirm("Exito!", "Guia Editado exitosamente", "success",
                    "Guias.aspx", this.Page, this.GetType());

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}