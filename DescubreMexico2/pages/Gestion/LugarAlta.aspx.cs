using CapaNegocio;
using DescubreMexico2.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DescubreMexico2.pages.Gestion
{
    public partial class LugarAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (SubeImagen.HasFile)
                {
                    string fileName = Path.GetFileName(SubeImagen.FileName);
                    string fileExt = Path.GetExtension(fileName).ToLower();

                    // Validar extensión
                    if (fileExt != ".jpg" && fileExt != ".png" && fileExt != ".jfif")
                    {
                        UtilControls.SweetBox("Atención", "Solo se permiten archivos .jpg, .png o .jfif", "warning", this.Page, this.GetType());
                        return;
                    }

                    // Crear ruta del directorio
                    string pathDir = Server.MapPath("~/assets/images/lugares/");
                    if (!Directory.Exists(pathDir))
                    {
                        Directory.CreateDirectory(pathDir);
                    }

                    // Crear nombre único para evitar colisiones
                    string nombreUnico = Guid.NewGuid().ToString() + fileExt;
                    string rutaCompleta = Path.Combine(pathDir, nombreUnico);

                    // Guardar archivo
                    SubeImagen.SaveAs(rutaCompleta);

                    // Mostrar imagen en el formulario
                    string urlRelativa = "/assets/images/lugares/" + nombreUnico;
                    imgFotoLugar.ImageUrl = urlRelativa;
                    urlFoto.Text = urlRelativa;
                    imgFoto.Visible = true;

                    // (Opcional) Habilitar botón guardar
                    btnGuardar.Visible = true;
                }
                else
                {
                    UtilControls.SweetBox("Atención", "Seleccione un archivo antes de subir", "warning", this.Page, this.GetType());
                }
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                string ciudad = txtCiudad.Text.Trim();
                // Validar y convertir latitud
                decimal latitud;
                if (!decimal.TryParse(txtLatitud.Text.Trim(), out latitud))
                {
                    UtilControls.SweetBox("Error", "La latitud no es válida", "warning", this.Page, this.GetType());
                    return;
                }

                // Validar y convertir longitud
                decimal longitud;
                if (!decimal.TryParse(txtLongitud.Text.Trim(), out longitud))
                {
                    UtilControls.SweetBox("Error", "La longitud no es válida", "warning", this.Page, this.GetType());
                    return;
                }

                // Validar que haya imagen cargada (opcional)
                string imagenUrl = urlFoto.Text.Trim();
                if (string.IsNullOrEmpty(imagenUrl))
                {
                    UtilControls.SweetBox("Atención", "Debe subir una imagen antes de guardar", "info", this.Page, this.GetType());
                    return;
                }

                // Validación adicional opcional (por código)
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) ||
                    string.IsNullOrEmpty(ciudad))
                {
                    UtilControls.SweetBox("Advertencia", "Todos los campos son obligatorios", "warning", this.Page, this.GetType());
                    return;
                }

                // Aquí deberías llamar al método BLL para insertar al usuario
                BllLugares.InsLugar(nombre, descripcion, ciudad, latitud, longitud, imagenUrl);

                UtilControls.SweetBoxConfirm(
                    "Éxito!",
                    "Lugar agregado exitosamente",
                    "success",
                    "Lugares.aspx",
                    this.Page,
                    this.GetType()
                );
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
            }
        }
    }
}