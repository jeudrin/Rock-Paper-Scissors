using Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios;
using Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Acceso_a_Datos
{
    public class Modelo_Main
    {
        // ATRIBUTOS

        public SqlConnection conexion { get; set; }
        public SqlCommand comando { get; set; }
        public SqlDataReader lector { get; set; }
        public string consulta { get; set; }

        // CONSTRUCTOR

        public Modelo_Main()
        {
            this.conexion = new SqlConnection(SiteMaster.stringConnection);
        }

        // METODOS

    }
}