using System;
using System.Collections.Generic;
using System.Text;

namespace BD_Libros
{
    public class Documento
    {
        protected int IdDocumento;
        protected string tituloDocumento, autorDocumento, ubicacionDocumento;

        public Documento()
        {
            Console.WriteLine("Creando documento en blanco");
            tituloDocumento = "Sin especificar";
            autorDocumento = "Sin especificar";
            ubicacionDocumento = "Sin especificar";
        }

        public Documento(string titulo, string autor, string ubicacion)
        {
            tituloDocumento = titulo;
            autorDocumento = autor;
            ubicacionDocumento = ubicacion;
        }
        
        public int GetId()
        {
            return IdDocumento;
        }

        public void SetId(int nuevoID)
        {
            IdDocumento = nuevoID;
        }


        public string getTitulo()
        {
            return tituloDocumento;
        }

        public void setTitulo(string titulo)
        {
            tituloDocumento = titulo;
        }

        public string getAutor()
        {
            return autorDocumento;
        }

        public void setAutor(string autor)
        {
            autorDocumento = autor;
        }

        public string getUbicacion()
        {
            return ubicacionDocumento;
        }

        public void setUbicacion(string ubicacion)
        {
            ubicacionDocumento = ubicacion;
        }

        public virtual int getNumPaginas()
        {
            return 0;
        }

        public virtual string GetProcedencia()
        {
            return "";
        }

        public virtual void MuestraDatos()
        {
            Console.WriteLine("Id: {1}. Título del documento - Autor - Ubicación: {0}", AString(),IdDocumento);
        }

        public virtual bool Contiene(string textoBuscado)
        {            
            return (tituloDocumento.ToUpper().Contains(textoBuscado.ToUpper()) || autorDocumento.ToUpper().Contains(textoBuscado.ToUpper()));
        }

        private string AString()
        {
            return tituloDocumento + " - " + autorDocumento + " - " + ubicacionDocumento;
        }
        
        public virtual void ModificaDocumento()
        {
            Console.WriteLine("Nuevo título: ");
            tituloDocumento = Console.ReadLine();
            Console.WriteLine("Nuevo autor: ");
            autorDocumento = Console.ReadLine();
            Console.WriteLine("Nueva ubicación: ");
            ubicacionDocumento = Console.ReadLine();
        }

        public virtual string TipoDocumento()//Devuelve el tipo de documento del que se trata
        {
            return "Documento";
        }
    }
}
