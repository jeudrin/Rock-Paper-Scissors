using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios
{
    public class Idioma
    {
        // ATRIBUTOS
        private String nombre;
        private List<String> listaPalabras;
        private int incidencias;
        private float porcentaje;

        // CONSTRUCTOR
        public Idioma(String n)
        {
            this.nombre = n;
            this.listaPalabras = new List<String>();
            this.incidencias = 0;
            this.porcentaje = 0;
        }

        // GET
        public String getNombre()
        {
            return this.nombre;
        }

        public List<String> getListaPalabras()
        {
            return this.listaPalabras;
        }

        public int getIncidencias()
        {
            return this.incidencias;
        }

        public float getPorcentaje()
        {
            return this.porcentaje;
        }

        // SET
        public void setNombre(String n)
        {
            this.nombre = n;
        }

        public void setListaPalabras(List<String> lp)
        {
            this.listaPalabras = lp;
        }

        public void setIncidencias(int i)
        {
            this.incidencias = i;
        }

        public void incrementarIncidencias()
        {
            this.incidencias++;
        }

        public void setPorcentaje(float p)
        {
            this.porcentaje = p;
        }

        // METODOS
        public void agregarPalabra(String p)
        {
            this.listaPalabras.Add(p);
        }
    }
}