using Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Acceso_a_Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios
{
    public class RockPaperScissors
    {
        // Variable para realizar todas las operaciones del Sistema
        Main Main;

        // Variable para hacer consultas a la base de datos
        Modelo_Main Modelo_Main;

        public RockPaperScissors()
        {
            Main = new Main();
            Modelo_Main = new Modelo_Main();
        }

        public Main getMain()
        {
            return this.Main;
        }

        public Modelo_Main getModeloMain()
        {
            return this.Modelo_Main;
        }

        public void setMain(Main m)
        {
            this.Main = m;
        }

        public void setModeloMain(Modelo_Main mm)
        {
            this.Modelo_Main = mm;
        }

        /// <summary>
        /// Método para inicializar el Sistema
        /// </summary>
        public void inicializarSistema()
        {
            Main = new Main();

            Modelo_Main = new Modelo_Main();

            Modelo_Main.inicializarSistema();
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
        /// Método para cargar el contenido de un archivo .docx
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public String cargarDOCX(String archivo)
        {
            Microsoft.Office.Interop.Word.Application objWordApp = new Microsoft.Office.Interop.Word.Application();

            object objWordFile = archivo;
            object objNull = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word.Document WordDoc = objWordApp.Documents.Open(
                ref objWordFile, ref objNull, ref objNull,
                ref objNull, ref objNull, ref objNull,
                ref objNull, ref objNull, ref objNull,
                ref objNull, ref objNull, ref objNull, ref objNull, ref objNull, ref objNull, ref objNull);

            WordDoc.ActiveWindow.Selection.WholeStory();
            WordDoc.ActiveWindow.Selection.Copy();

            string strWordText = WordDoc.Content.Text;

            WordDoc.Close(ref objNull, ref objNull, ref objNull);

            objWordApp.Quit(ref objNull, ref objNull, ref objNull);

            return strWordText;
        }

        /// <summary>
        /// Método para cargar el contenido de un archivo .html
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        private string cargarHTML(String archivo)
        {
            HTMLtoText HTMLtoText = new HTMLtoText();

            return StripTagsRegex(HTMLtoText.Convert(archivo));
        }

        /// <summary>
        /// Remover HTML de string con Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        /// <summary>
        /// Método para convertir String en Array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string[] splitString(String s)
        {
            string[] separadores = { "{", "}", "[", "]", "(", ")", ",", ".", "!", "?", ";", ":", " ", "“", "”", "‘", "’", "\n", "\t", "\r" };
            string[] arreglo = s.Split(separadores, StringSplitOptions.RemoveEmptyEntries);

            return arreglo;
        }

        /// <summary>
        /// Método que realiza el análisis del texto
        /// </summary>
        public void analizarBusquedas()
        {
            Boolean palabraNuevaIdioma;
            Boolean palabraNuevaCategoria;

            foreach (string busqueda in Main.getListaBusquedas())
            {
                string[] busquedaDividida = splitString(busqueda);

                foreach (string b in busquedaDividida)
                {
                    palabraNuevaIdioma = false;
                    palabraNuevaCategoria = false;

                    for (int x = 0; x < Main.getListaIdiomas().Count(); x++)
                    {
                        if (Main.getListaIdiomas().ElementAt(x).getListaPalabras().Contains(b))
                        {
                            Main.getListaIdiomas().ElementAt(x).incrementarIncidencias();

                            palabraNuevaIdioma = true;
                        }
                    }

                    for (int y = 0; y < Main.getListaCategorias().Count(); y++)
                    {
                        if (Main.getListaCategorias().ElementAt(y).getListaPalabras().Contains(b))
                        {
                            Main.getListaCategorias().ElementAt(y).incrementarIncidencias();

                            palabraNuevaCategoria = true;
                        }
                    }

                    if (!palabraNuevaIdioma || !palabraNuevaCategoria)
                    {
                        Main.agregarPalabraNueva(b);
                    }
                }
            }
        }
    }
}