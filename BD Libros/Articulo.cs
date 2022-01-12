using System;
using System.Collections.Generic;
using System.Text;

namespace BD_Libros
{
    class Articulo : Documento
    {
        protected string procedencia;

        public Articulo()//Constructor por defecto
        {
            procedencia = "Sin determinar";
        }

        public Articulo(string titulo, string autor, string ubicacio, string proceden) : base(titulo, autor, ubicacio)//Llamada al constructor de la clase base para que dé valor a los primeros atributos
        {            
            procedencia = proceden;
        }

        public void SetProcedencia(string Nuevaprocedencia)
        {
            procedencia = Nuevaprocedencia;
        }

        public override string GetProcedencia()
        {
            return procedencia;
        }

        public override void MuestraDatos()
        {
            base.MuestraDatos();
            Console.WriteLine("Tipo: Artículo. Procedencia: {0}", AString());
        }

        public override bool Contiene (string textoBuscado)
        {
            return (tituloDocumento.ToUpper().Contains(textoBuscado.ToUpper()) || autorDocumento.ToUpper().Contains(textoBuscado.ToUpper()) || procedencia.ToUpper().Contains(textoBuscado.ToUpper()));
        }

        private string AString()
        {
            return procedencia;
        }

        public override void ModificaDocumento()
        {
            base.ModificaDocumento();
            Console.WriteLine("Nueva procedencia: ");
            procedencia = Console.ReadLine();
        }

        public override string TipoDocumento()//Devuelve el tipo de documento del que se trata
        {
            return "Artículo";
        }
    
    }
}
