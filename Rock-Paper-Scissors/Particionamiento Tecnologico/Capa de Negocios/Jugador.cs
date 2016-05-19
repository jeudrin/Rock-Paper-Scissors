using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios
{
    [Serializable()]
    public class Jugador
    {
        // ATRIBUTOS

        public string nombre { get; set; }
        public string jugada { get; set; }
        public int partidasGanadas { get; set; }

        // CONSTRUCTOR

        public Jugador(string n, string j)
        {
            this.nombre = n;
            this.jugada = j;
            this.partidasGanadas = 0;
        }

        // METODOS

    }
}