using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación
{
    public partial class UI_AnalizarTexto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método para limpiar el texto ingresado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLimpiarTextoIngresado_Click(object sender, EventArgs e)
        {
            tbTextoIngresado.Text = "";
        }

        /// <summary>
        /// Método para analizar el texto ingresado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnalizarTextoIngresado_Click(object sender, EventArgs e)
        {
            if (tbTextoIngresado.Text == "" || tbTextoIngresado.Text == "Ingrese un texto")
            {
                tbTextoIngresado.Text = "Ingrese un texto";
            }
            else
            {
                // Se vuelve a inicializar el Sistema
                SiteMaster.RockPaperScissors.inicializarSistema();

                SiteMaster.RockPaperScissors.getMain().agregarBusqueda(tbTextoIngresado.Text);
                SiteMaster.RockPaperScissors.analizarBusquedas();
            }
        }
    }
}