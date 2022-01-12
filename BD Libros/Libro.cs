using System;
using System.Collections.Generic;
using System.Text;

namespace BD_Libros
{
    public class Libro : Documento
    {
        protected int numeroPaginas;

        public Libro()
        {
            Console.WriteLine("Creando libro en blanco");
            numeroPaginas = 0;
        }

        public Libro(string titul, string autor)
        {
            tituloDocumento = titul;
            autorDocumento = autor;
            ubicacionDocumento = "Sin especificar";
            numeroPaginas = 0;
        }

        public Libro(string tit, string aut, string ub, int np) : base(tit, aut, ub)
        {            
            numeroPaginas = np;
        }

        ~Libro()
        { }

        public void setNumPaginas(int num)
        {
            numeroPaginas = num;
        }

        public override int getNumPaginas()
        {
            return numeroPaginas;
        }

        public override void MuestraDatos() 
        {
            base.MuestraDatos();
            Console.WriteLine("Tipo: Libro. Nº páginas: {0}", AString(numeroPaginas));
        }

        private string AString(int numeroAConvertir)
        {
            return Convert.ToString(numeroAConvertir);
        }

        public override void ModificaDocumento()
        {
            base.ModificaDocumento();
            Console.WriteLine("Nuevo número de páginas: ");
            int nuevoNumPag;
            try
            {
                nuevoNumPag = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                nuevoNumPag = 0;
            }
            numeroPaginas = nuevoNumPag;
        }

        public override string TipoDocumento()//Devuelve el tipo de documento del que se trata
        {
            return "Libro";
        }
    }
}
