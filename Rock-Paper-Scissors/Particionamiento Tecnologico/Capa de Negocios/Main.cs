using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios
{
    public class Main
    {
        // ATRIBUTOS
        private List<Idioma> listaIdiomas;
        private List<Categoria> listaCategorias;
        private List<String> listaBusquedas;
        private int numeroPalabrasBD;
        private String idiomaIdentificado;
        private String categoriaIdentificada;
        private String informacionIdioma;
        private String informacionCategoria;
        private List<String> listaPalabrasNuevas;

        // CONSTRUCTOR
        public Main()
        {
            this.listaIdiomas = new List<Idioma>();
            this.listaCategorias = new List<Categoria>();
            this.listaBusquedas = new List<String>();
            this.numeroPalabrasBD = 0;
            this.idiomaIdentificado = "";
            this.categoriaIdentificada = "";
            this.informacionIdioma = "";
            this.informacionCategoria = "";
            this.listaPalabrasNuevas = new List<String>();
        }

        // GET
        public List<Idioma> getListaIdiomas()
        {
            return this.listaIdiomas;
        }

        public List<Categoria> getListaCategorias()
        {
            return this.listaCategorias;
        }

        public List<String> getListaBusquedas()
        {
            return this.listaBusquedas;
        }

        public int getNumeroPalabrasBD()
        {
            return this.numeroPalabrasBD;
        }

        public String getIdiomaIdentificado()
        {
            return this.idiomaIdentificado;
        }

        public String getCategoriaIdentificada()
        {
            return this.categoriaIdentificada;
        }

        public String getInformacionIdioma()
        {
            return this.informacionIdioma;
        }

        public String getInformacionCategoria()
        {
            return this.informacionCategoria;
        }

        public List<String> getListaPalabrasNuevas()
        {
            return this.listaPalabrasNuevas;
        }

        // SET
        public void setListaIdiomas(List<Idioma> li)
        {
            this.listaIdiomas = li;
        }

        public void setListaCategorias(List<Categoria> lc)
        {
            this.listaCategorias = lc;
        }

        public void setListaBusquedas(List<String> la)
        {
            this.listaBusquedas = la;
        }

        public void setNumeroPalabrasBD(int npbd)
        {
            this.numeroPalabrasBD = npbd;
        }

        public void setIdiomaIdentificado(String ii)
        {
            this.idiomaIdentificado = ii;
        }

        public void setCategoriaIdentificada(String ci)
        {
            this.categoriaIdentificada = ci;
        }

        public void setInformacionIdioma(String s)
        {
            this.informacionIdioma += s;
        }

        public void setInformacionCategoria(String s)
        {
            this.informacionCategoria += s;
        }

        public void setListaPalabrasNuevas(List<String> la)
        {
            this.listaPalabrasNuevas = la;
        }

        // METODOS
        public void agregarIdioma(Idioma i)
        {
            this.listaIdiomas.Add(i);
        }

        public void agregarCategoria(Categoria c)
        {
            this.listaCategorias.Add(c);
        }

        public void agregarBusqueda(String b)
        {
            this.listaBusquedas.Add(b);
        }

        public void agregarPalabraNueva(String p)
        {
            this.listaPalabrasNuevas.Add(p);
        }
    }
}