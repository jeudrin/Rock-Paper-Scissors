using Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Acceso_a_Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios
{
    public class RockPaperScissors
    {
        // ATRIBUTOS

        // Variable para almacenar los jugadores
        public List<Jugador> listaJugadores { get; set; }
        // Variable para almacenar los jugadores
        public List<Jugador> listaTopJugadores { get; set; }

        // Variable para hacer consultas a la base de datos
        public Modelo_Main Modelo_Main { get; set; }

        // CONSTRUCTOR

        public RockPaperScissors()
        {
            this.listaJugadores = new List<Jugador>();
            this.listaTopJugadores = new List<Jugador>();
            this.Modelo_Main = new Modelo_Main();
        }

        // METODOS

        /// <summary>
        /// Método para inicializar el Sistema
        /// </summary>
        public void inicializarSistema()
        {
            this.listaJugadores = new List<Jugador>();

            this.Modelo_Main = new Modelo_Main();
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
        public string cargarTXT(String archivo)
        {
            string content;

            using (StreamReader inputStreamReader = new StreamReader(archivo))
            {
                content = inputStreamReader.ReadToEnd();
            }

            return content;
        }

        public bool getJugadores(string content)
        {
            int leer = 0;

            int banderaUsuario = 0;
            int banderaJugada = 0;

            string nombre = "";
            string jugada = "";

            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == '\"')
                {
                    i++;

                    if (leer == 0)
                        leer = 1;
                    else
                    {
                        leer = 0;
                        if (banderaUsuario == 0)
                            banderaUsuario = 1;
                        else
                            banderaJugada = 1;
                    }
                }

                if (leer == 1 && banderaUsuario == 0)
                    nombre += content[i];

                else if (leer == 1 && banderaUsuario == 1)
                    jugada += content[i];

                if (banderaUsuario == 1 && banderaJugada == 1)
                {
                    if (jugada == "R" || jugada == "P" || jugada == "S")
                    {
                        this.listaJugadores.Add(new Jugador(nombre, jugada));

                        nombre = "";
                        jugada = "";

                        banderaUsuario = 0;
                        banderaJugada = 0;
                    }
                    else
                        return false;
                }
            }

            return true;
        }

        public Jugador ganador(List<Jugador> lj, List<Jugador> ln)
        {
            for (int i = 0; i < lj.Count; i++)
            {
                if (i + 1 == lj.Count)
                    ln.Add(lj.ElementAt(i));
                else if (lj.ElementAt(i).jugada == "R" && lj.ElementAt(i + 1).jugada == "R")
                    ln.Add(lj.ElementAt(i));
                else if (lj.ElementAt(i).jugada == "P" && lj.ElementAt(i + 1).jugada == "P")
                    ln.Add(lj.ElementAt(i));
                else if (lj.ElementAt(i).jugada == "S" && lj.ElementAt(i + 1).jugada == "S")
                    ln.Add(lj.ElementAt(i));
                else if (lj.ElementAt(i).jugada == "R" && lj.ElementAt(i + 1).jugada == "S")
                    ln.Add(lj.ElementAt(i));
                else if (lj.ElementAt(i).jugada == "S" && lj.ElementAt(i + 1).jugada == "P")
                    ln.Add(lj.ElementAt(i));
                else if (lj.ElementAt(i).jugada == "P" && lj.ElementAt(i + 1).jugada == "R")
                    ln.Add(lj.ElementAt(i));
                else
                    ln.Add(lj.ElementAt(i + 1));

                i++;
            }
            if (ln.Count > 2)
                return ganador(ln, new List<Jugador>());
            else
                //actualizarTop(ln.ElementAt(0), ln.ElementAt(1));

            return ln.ElementAt(0);
        }

        public void actualizarTop(Jugador j1, Jugador j2)
        {
            int j11 = 0;
            int j22 = 0;

            foreach(Jugador j in this.listaTopJugadores)
            {
                if (j.nombre == j1.nombre)
                {
                    j.partidasGanadas += 3;
                    j11 = 1;
                }
                else if (j.nombre == j2.nombre)
                {
                    j.partidasGanadas += 1;
                    j22 = 1;
                }
            }

            if (j11 == 0)
                this.listaTopJugadores.Add(j1);
            else if (j22 == 0)
                this.listaTopJugadores.Add(j2);
        }
    }
}