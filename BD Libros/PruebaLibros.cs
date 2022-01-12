using System;

namespace BD_Libros
{
    public class PruebaLibros
    {
        
        public static void Main()
        {
            BDDocumentos miBiblioteca = new BDDocumentos(100); //Creamos una nueva base de datos indicando su capacidad máxima
            miBiblioteca.CargaDatosDeFichero();//Cargamos en memoria los datos existentes en el archivo

            bool salir=false;            
            int accionARealizar;

            while(!salir)
            {
                accionARealizar = MenuBiblioteca.MuestraMenu(); //Mostramos el menú inicial y capturamos la opción elegida por el usuario
                
                switch(accionARealizar)
                {
                    case 1:
                        miBiblioteca.nuevoDocumento();
                        break;
                    case 2:
                        miBiblioteca.MuestraDocumentosExistentes();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Introduzca el texto que desea buscar: ");
                        string textoBuscado = Console.ReadLine();
                        miBiblioteca.BuscaDocumentos(textoBuscado);
                        break;
                    case 4:
                        miBiblioteca.Modificar();
                        break;
                    case 5:
                        miBiblioteca.Eliminar();
                        break;
                    case 8:
                        miBiblioteca.RellenaConEjemplos();
                        break;
                    case 9:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción escogida: {0}", accionARealizar);
                        break;
                }
            }
            //Al salir se vuelcan los datos existentes en un archivo
            miBiblioteca.VuelcaDatosAFichero();
        }
    }
}
