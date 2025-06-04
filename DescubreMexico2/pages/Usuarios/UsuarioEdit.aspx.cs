using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace DescubreMexico2.pages.Usuarios
{
    public partial class UsuarioEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("Usuarios.aspx");
                }
                else
                {
                    //Obtener Id del chofer
                    int IdUsuario = int.Parse(Request.QueryString["Id"]);
                    UsuarioVO usuario = BllUsuarios.GetUsuarioById(IdUsuario);

                    //Validar que el chofer es correcto
                    if (usuario.IdUsuario == IdUsuario)
                    {
                        //Desplegar la información del chofer
                        this.lblIdUsuario.Text = IdUsuario.ToString();
                        this.txtNombre.Text = usuario.Nombre;
                        this.txtEmail.Text = usuario.Email;
                        this.txtTelefono.Text = usuario.Telefono;
                        this.txtFechaRegistro.Text = usuario.FechaRegistro.ToString();
                        this.txtTipoUsuario.Text = usuario.TipoUsuario;
                        this.chkActivo.Checked = usuario.Activo;
                    }
                    else
                    {
                        Response.Redirect("Usuarios.aspx");
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.lblIdUsuario.Text);
                string nombre = this.txtNombre.Text;
                string telefono = this.txtTelefono.Text;
                string email = this.txtEmail.Text;
                bool Activo = chkActivo.Checked;

                BllUsuarios.UpdUsuario(id, nombre, email, telefono, Activo);

                UtilControls.SweetBoxConfirm("Exito!", "Usuario Editado exitosamente", "success",
                    "Usuarios.aspx", this.Page, this.GetType());

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}