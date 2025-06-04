using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;
using static DescubreMexico2.Util.Enumeradores;

namespace DescubreMexico2.pages.Gestion
{
    public partial class LugarEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Primera carga de la página
            {

                //Obtenemos la información del Lugar seleccionado
                string Id = Request.QueryString["Id"];
                if ((Id == null))
                {
                    Response.Redirect("Lugares.aspx");
                }
                else
                {
                    //Verificamos que el camion exista
                    LugaresVO lugar = BllLugares.GetLugarById(int.Parse(Id));
                    if (lugar.IdLugar == int.Parse(Id))
                    {
                        //Desplegamos la información del camion
                        lblIdLugar.Text = lugar.IdLugar.ToString();
                        txtNombre.Text = lugar.Nombre;
                        txtDescripcion.Text = lugar.Descripcion;
                        txtCiudad.Text = lugar.Ciudad;
                        txtLatitud.Text = lugar.Latitud.ToString();
                        txtLongitud.Text = lugar.Longitud.ToString();
                        imgFotoLugar.ImageUrl = lugar.ImagenUrl;
                        this.urlFoto.Text = lugar.ImagenUrl;
                        chkActivo.Checked = lugar.Activo;
                    }
                    else
                    {
                        Response.Redirect("ListarCamiones.aspx");
                    }
                }
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (SubeImagen.HasFile)
                {
                    string fileName = Path.GetFileName(SubeImagen.FileName);
                    string fileExt = Path.GetExtension(fileName).ToLower();

                    if (fileExt != ".jpg" && fileExt != ".png" && fileExt != ".jfif")
                    {
                        UtilControls.SweetBox("Atención!", "Seleccione un archivo válido (.jpg, .png, .jfif)", "warning", this.Page, this.GetType());
                        return;
                    }

                    string pathDir = Server.MapPath("~/assets/images/lugares/");
                    if (!Directory.Exists(pathDir))
                    {
                        Directory.CreateDirectory(pathDir);
                    }

                    string savePath = Path.Combine(pathDir, fileName);
                    SubeImagen.SaveAs(savePath);

                    // Mostrar el path relativo
                    string direccion = "/assets/images/lugares/" + fileName;
                    this.urlFoto.Text = direccion;
                    imgFotoLugar.ImageUrl = direccion;

                    // Mostrar nombre archivo y la imagen
                    lblNombreArchivo.Text = "Archivo seleccionado: " + fileName;
                    divFoto.Visible = true;

                    btnGuardar.Visible = true;
                }
                else
                {
                    UtilControls.SweetBox("Atención!", "Seleccione un archivo válido", "warning", this.Page, this.GetType());
                }
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                int IdLugar = int.Parse(lblIdLugar.Text);
                string Nombre = txtNombre.Text;
                string Descripcion = txtDescripcion.Text;
                string Ciudad = txtCiudad.Text;
                decimal latitud = decimal.Parse(txtLatitud.Text);
                decimal longitud = decimal.Parse (txtLongitud.Text);
                string urlfoto = this.urlFoto.Text;
                bool Activo = chkActivo.Checked;
                string Resultado =
                BllLugares.UpdLugar(IdLugar, Nombre, Descripcion, Ciudad, latitud, longitud, urlfoto, Activo);
                if (Resultado.IndexOf("Lugar actualizado correctamente") > -1)
                {
                    UtilControls.SweetBoxConfirm("OK!", Resultado, "success", "Lugares.aspx", this.Page, this.GetType());
                }
                else
                {
                    //Mensaje de error
                    UtilControls.SweetBox("Atención!", Resultado, "warning", this.Page, this.GetType());
                }
            }
            catch (Exception ex)
            {

                UtilControls.SweetBox("ERROR!", ex.Message, "danger", this.Page, this.GetType());
            }

        }
    }
}