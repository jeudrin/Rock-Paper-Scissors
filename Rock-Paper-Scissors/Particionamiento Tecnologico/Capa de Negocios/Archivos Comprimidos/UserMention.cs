using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios.Archivos_Comprimidos
{
    public class UserMention
    {
        public List<int> indices { get; set; }
        public string name { get; set; }
        public string id_str { get; set; }
        public int id { get; set; }
        public string screen_name { get; set; }
    }
}