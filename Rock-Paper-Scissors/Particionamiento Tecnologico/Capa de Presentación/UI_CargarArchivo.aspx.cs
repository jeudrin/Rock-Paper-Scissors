using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación
{
    public partial class UI_CargarArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método para crear la carpeta temporal
        /// </summary>
        /// <param name="directorio"></param>
        public void crearCarpetaTemporal(String directorio)
        {
            // Se crea una carpeta temporal para almacenar los archivos que se van a analizar
            if (!System.IO.Directory.Exists(directorio))
            {
                System.IO.Directory.CreateDirectory(directorio);
            }
        }

        /// <summary>
        /// Método para eliminar la carpeta temporal
        /// </summary>
        /// <param name="directorio"></param>
        public void eliminarCarpetaTemporal(String directorio)
        {
            // Se elimina la carpeta temporal que almacena los archivos que se van a analizar
            if (System.IO.Directory.Exists(directorio))
            {
                Directory.Delete(directorio, true);
            }
        }

        /// <summary>
        /// Método para cargar el contenido de un archivo .txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public String cargarTXT(String archivo)
        {
            string content;

            using (StreamReader inputStreamReader = new StreamReader(archivo))
            {
                content = inputStreamReader.ReadToEnd();
            }

            return content;
        }

        /// <summary>
        /// Método para cargar un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            // Valida si se seleccionó un archivo
            if (fuSeleccioneArchivo.HasFile)
            {
                string nombreArchivo = Path.GetFileName(fuSeleccioneArchivo.PostedFile.FileName);
                string extensionArchivo = System.IO.Path.GetExtension(fuSeleccioneArchivo.FileName);

                if (extensionArchivo == ".txt")
                {
                    // Se crea la carpeta temporal
                    crearCarpetaTemporal(Server.MapPath("/UploadedFiles"));

                    // Se guarda el archivo en la carpeta temporal
                    fuSeleccioneArchivo.SaveAs(Server.MapPath("/UploadedFiles/" + nombreArchivo));
                    Session["ImagePath"] = Server.MapPath("/UploadedFiles/" + nombreArchivo);

                    // Archivos .txt
                    if (extensionArchivo == ".txt")
                    {
                        tbArchivoCargado.Text = cargarTXT(Server.MapPath("/UploadedFiles/" + nombreArchivo));
                    }
                   
                    // Se elimina la carpeta temporal
                    eliminarCarpetaTemporal(Server.MapPath("/UploadedFiles"));
                }

                else
                {
                    tbArchivoCargado.Text = "Solo se permiten archivos: '.txt'";
                }
            }

            else
            {
                tbArchivoCargado.Text = "Seleccione un archivo";
            }
        }
    }
}