using Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios;
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
                    SiteMaster.RockPaperScissors.crearCarpetaTemporal(Server.MapPath("/UploadedFiles"));

                    // Se guarda el archivo en la carpeta temporal
                    fuSeleccioneArchivo.SaveAs(Server.MapPath("/UploadedFiles/" + nombreArchivo));
                    Session["ImagePath"] = Server.MapPath("/UploadedFiles/" + nombreArchivo);

                    // Archivos .txt
                    if (extensionArchivo == ".txt")
                    {
                        SiteMaster.RockPaperScissors.inicializarSistema();

                        string content = SiteMaster.RockPaperScissors.cargarTXT(Server.MapPath("/UploadedFiles/" + nombreArchivo));
                        
                        tbArchivoCargado.Text = content;

                        if (SiteMaster.RockPaperScissors.getJugadores(content)) ;

                        else
                            lblResultado.Text = "Se ha detectado una estrategia no válida";

                        if (SiteMaster.RockPaperScissors.listaJugadores.Count % 2 != 0)
                            lblResultado.Text = "Cantidad de jugadores no válida";
                        else
                        {
                            Jugador j = SiteMaster.RockPaperScissors.ganador(SiteMaster.RockPaperScissors.listaJugadores, new List<Jugador>());
                            lblResultado.Text = "El ganador es: " + j.nombre + ", usando " + j.jugada + " como estrategia";
                        }
                    }
                   
                    // Se elimina la carpeta temporal
                    SiteMaster.RockPaperScissors.eliminarCarpetaTemporal(Server.MapPath("/UploadedFiles"));
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