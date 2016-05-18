using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios.Archivos_Comprimidos
{
    public class Entities
    {
        public List<object> hashtags { get; set; }
        public List<UserMention> user_mentions { get; set; }
        public List<object> urls { get; set; }
    }
}