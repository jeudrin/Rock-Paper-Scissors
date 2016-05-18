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
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        string consulta;

        Idioma idioma;
        Categoria categoria;

        public Modelo_Main()
        {
            conexion = new SqlConnection(SiteMaster.stringConnection);
        }

        public void inicializarSistema()
        {
            numeroPalabrasBD();

            cargarIdiomas();

            cargarCategorias();
        }

        public void numeroPalabrasBD()
        {
            try
            {
                conexion.Open();
                consulta = "Select count(nombrePalabra) from palabras";
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    SiteMaster.RockPaperScissors.getMain().setNumeroPalabrasBD(int.Parse(lector[0].ToString()));
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }

        public void cargarIdiomas()
        {
            try
            {
                conexion.Open();
                consulta = "Select nombreIdioma from idiomas";
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    idioma = new Idioma(lector[0].ToString());
                    SiteMaster.RockPaperScissors.getMain().agregarIdioma(idioma);
                }
                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }

            cargarPalabrasIdioma();
        }

        public void cargarPalabrasIdioma()
        {
            try
            {
                conexion.Open();

                for (int i = 0; i < SiteMaster.RockPaperScissors.getMain().getListaIdiomas().Count; i++)
                {
                    consulta = string.Format("select nombrePalabra from palabras where nombreIdioma = '{0}' and nombreCategoria = ''", SiteMaster.RockPaperScissors.getMain().getListaIdiomas().ElementAt(i).getNombre());

                    comando = new SqlCommand(consulta, conexion);
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        SiteMaster.RockPaperScissors.getMain().getListaIdiomas().ElementAt(i).agregarPalabra(lector[0].ToString());
                    }
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }

        public void cargarCategorias()
        {
            try
            {
                conexion.Open();
                consulta = "Select nombreCategoria from categorias";
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    categoria = new Categoria(lector[0].ToString());
                    SiteMaster.RockPaperScissors.getMain().agregarCategoria(categoria);
                }
                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }

            cargarPalabrasCategoria();
        }

        public void cargarPalabrasCategoria()
        {
            try
            {
                conexion.Open();

                for (int i = 0; i < SiteMaster.RockPaperScissors.getMain().getListaCategorias().Count; i++)
                {
                    consulta = string.Format("select nombrePalabra from palabras where nombreCategoria = '{0}'", SiteMaster.RockPaperScissors.getMain().getListaCategorias().ElementAt(i).getNombre());

                    comando = new SqlCommand(consulta, conexion);
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        SiteMaster.RockPaperScissors.getMain().getListaCategorias().ElementAt(i).agregarPalabra(lector[0].ToString());
                    }
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }

        public void nuevasPalabras()
        {
            int incidencias;
            String estado;

            for(int i = 0; i < SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().Count(); i++)
            {
                if(!existeIdioma(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i)))
                {
                    insertarPalabraIdiomaAprendida(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));
                }
                else
                {
                    incidencias = getIncidenciasPalabraIdioma(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));
                    
                    if (incidencias < 10)
                    {
                        modificarPalabraIdioma(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i), (incidencias + 1), "En proceso");
                    }
                    else
                    {
                        modificarPalabraIdioma(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i), incidencias, "Aprendida");
                    }

                    estado = getEstadoPalabraIdioma(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));

                    if (estado == "Aprendida" && !existePalabraIdioma(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i)))
                    {
                        insertarNuevaPalabraIdioma(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));
                    }
                }

                if (!existeCategoria(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i)))
                {
                    insertarPalabraCategoriaAprendida(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));
                }
                else
                {
                    incidencias = getIncidenciasPalabraCategoria(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));

                    if (incidencias < 15)
                    {
                        modificarPalabraCategoria(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i), (incidencias + 1), "En proceso");
                    }
                    else
                    {
                        modificarPalabraCategoria(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i), incidencias, "Aprendida");
                    }

                    estado = getEstadoPalabraCategoria(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));

                    if (estado == "Aprendida" && !existePalabraCategoria(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i)))
                    {
                        insertarNuevaPalabraCategoria(SiteMaster.RockPaperScissors.getMain().getListaPalabrasNuevas().ElementAt(i));
                    }
                }
            }
        }

        // Idioma

        public Boolean existeIdioma(String nombrePalabra)
        {
            try
            {
                conexion.Open();
                consulta = string.Format("Select nombrePalabra,nombreIdioma from palabrasAprendidas where nombrePalabra = '{0}' and nombreIdioma = '{1}'", nombrePalabra, SiteMaster.RockPaperScissors.getMain().getIdiomaIdentificado());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    conexion.Close();

                    return true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();

                return false;
            }

            return false;
        }

        public Boolean existePalabraIdioma(String nombrePalabra)
        {
            try
            {
                conexion.Open();
                consulta = string.Format("Select nombrePalabra,nombreIdioma from palabras where nombrePalabra = '{0}' and nombreIdioma = '{1}'", nombrePalabra, SiteMaster.RockPaperScissors.getMain().getIdiomaIdentificado());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    conexion.Close();

                    return true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();

                return false;
            }

            return false;
        }

        public void insertarPalabraIdiomaAprendida(String palabra)
        {
            try
            {
                conexion.Open();

                consulta = string.Format("EXEC InsertarPalabraAprendida '{0}','{1}','{2}',{3}, '{4}'", palabra, SiteMaster.RockPaperScissors.getMain().getIdiomaIdentificado(), "", 1, "En proceso");
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }
              
        public int getIncidenciasPalabraIdioma(String palabra)
        {
            int incidencias = 0;

            try
            {
                conexion.Open();
                consulta = string.Format("Select incidencias from palabrasAprendidas where nombrePalabra = '{0}' and nombreIdioma = '{1}'", palabra, SiteMaster.RockPaperScissors.getMain().getIdiomaIdentificado());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();
                lector.Read();

                incidencias = int.Parse(lector["incidencias"].ToString());

                conexion.Close();

                return incidencias;
            }
            catch (SqlException)
            {
                conexion.Close();

                return incidencias;
            }
        }

        public String getEstadoPalabraIdioma(String palabra)
        {
            String estado = "";

            try
            {
                conexion.Open();
                consulta = string.Format("Select estado from palabrasAprendidas where nombrePalabra = '{0}' and nombreIdioma = '{1}'", palabra, SiteMaster.RockPaperScissors.getMain().getIdiomaIdentificado());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();
                lector.Read();

                estado = lector["estado"].ToString();

                conexion.Close();

                return estado;
            }
            catch (SqlException)
            {
                conexion.Close();

                return estado;
            }
        }

        public void modificarPalabraIdioma(String palabra, int incidencias, String estado)
        {
            try
            {
                conexion.Open();

                consulta = string.Format("EXEC ModificarPalabraIdiomaAprendida '{0}','{1}',{2},'{3}'", palabra, SiteMaster.RockPaperScissors.getMain().getIdiomaIdentificado(), incidencias, estado);
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }

        public void insertarNuevaPalabraIdioma(String palabra)
        {
            try
            {
                conexion.Open();

                consulta = string.Format("EXEC InsertarPalabra '{0}','{1}','{2}'", palabra, SiteMaster.RockPaperScissors.getMain().getIdiomaIdentificado(), "");
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }

        // Categoria
        
        public Boolean existeCategoria(String nombrePalabra)
        {
            try
            {
                conexion.Open();
                consulta = string.Format("Select nombrePalabra,nombreCategoria from palabrasAprendidas where nombrePalabra = '{0}' and nombreCategoria = '{1}'", nombrePalabra, SiteMaster.RockPaperScissors.getMain().getCategoriaIdentificada());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    conexion.Close();

                    return true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();

                return false;
            }

            return false;
        }

        private Boolean existePalabraCategoria(String nombrePalabra)
        {
            try
            {
                conexion.Open();
                consulta = string.Format("Select nombrePalabra,nombreCategoria from palabras where nombrePalabra = '{0}' and nombreCategoria = '{1}'", nombrePalabra, SiteMaster.RockPaperScissors.getMain().getCategoriaIdentificada());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    conexion.Close();

                    return true;
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();

                return false;
            }

            return false;
        }

        public void insertarPalabraCategoriaAprendida(String palabra)
        {
            try
            {
                conexion.Open();

                consulta = string.Format("EXEC InsertarPalabraAprendida '{0}','{1}','{2}',{3}, '{4}'", palabra, "", SiteMaster.RockPaperScissors.getMain().getCategoriaIdentificada(), 1, "En proceso");
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }

        public int getIncidenciasPalabraCategoria(String palabra)
        {
            int incidencias = 0;

            try
            {
                conexion.Open();
                consulta = string.Format("Select incidencias from palabrasAprendidas where nombrePalabra = '{0}' and nombreCategoria = '{1}'", palabra, SiteMaster.RockPaperScissors.getMain().getCategoriaIdentificada());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();
                lector.Read();

                incidencias = int.Parse(lector["incidencias"].ToString());

                conexion.Close();

                return incidencias;
            }
            catch (SqlException)
            {
                conexion.Close();

                return incidencias;
            }
        }

        private String getEstadoPalabraCategoria(String palabra)
        {
            String estado = "";

            try
            {
                conexion.Open();
                consulta = string.Format("Select estado from palabrasAprendidas where nombrePalabra = '{0}' and nombreCategoria = '{1}'", palabra, SiteMaster.RockPaperScissors.getMain().getCategoriaIdentificada());
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();
                lector.Read();

                estado = lector["estado"].ToString();

                conexion.Close();

                return estado;
            }
            catch (SqlException)
            {
                conexion.Close();

                return estado;
            }
        }

        private void modificarPalabraCategoria(String palabra, int incidencias, String estado)
        {
            try
            {
                conexion.Open();

                consulta = string.Format("EXEC ModificarPalabraCategoriaAprendida '{0}','{1}',{2},'{3}'", palabra, SiteMaster.RockPaperScissors.getMain().getCategoriaIdentificada(), incidencias, estado);
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }

        private void insertarNuevaPalabraCategoria(String palabra)
        {
            try
            {
                conexion.Open();

                consulta = string.Format("EXEC InsertarPalabra '{0}','{1}','{2}'", palabra, "", SiteMaster.RockPaperScissors.getMain().getCategoriaIdentificada());
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException)
            {
                conexion.Close();
            }
        }
    }
}