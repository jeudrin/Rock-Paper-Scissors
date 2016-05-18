using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios.Archivos_Comprimidos
{
    public class Activities
    {
        public string retweeters_count { get; set; }
        public List<object> retweeters { get; set; }
        public List<object> favoriters { get; set; }
        public string favoriters_count { get; set; }
        public List<object> repliers { get; set; }
        public string repliers_count { get; set; }
    }
}