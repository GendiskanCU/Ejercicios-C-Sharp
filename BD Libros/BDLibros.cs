using System;
using System.Collections.Generic;
using System.Text;

namespace BD_Libros
{
    class BDDocumentos
    {

        protected Documento[] librosBiblioteca;
        protected int numeroDocumentos = 0;
        protected int maximoDocumentos;

        public BDDocumentos(int totalLibros)//Constructor
        {
            librosBiblioteca = new Documento[totalLibros];
            maximoDocumentos = totalLibros;
        }

        public void nuevoDocumento()//Añade un nuevo libro o documento genérico a la base de datos
        {
            Console.Clear();
            if (numeroDocumentos == maximoDocumentos)  //Si se ha alcanzado el límite de la BD
                Console.WriteLine("\nNo es posible añadir más documentos a la biblioteca. Se ha alcanzado el límite máximo");
            else
            {
                Console.WriteLine("\n¿Desea añadir un libro (L) o un artículo (otra)?");
                char opcion = Convert.ToChar(Console.ReadLine());
                if (opcion == 'L' || opcion == 'l')
                {
                    Console.WriteLine("\nSe va a incluir un nuevo libro en la base de datos. Introduzca a continuación los datos del mismo:");
                    Console.WriteLine("Título: ");
                    string tituloNL = Console.ReadLine();
                    Console.WriteLine("Autor: ");
                    string autorNL = Console.ReadLine();
                    Console.WriteLine("Nº páginas: ");
                    int paginasNL;
                    try { paginasNL = Convert.ToInt32(Console.ReadLine()); }
                    catch { paginasNL = 0; }
                    Console.WriteLine("Ubicación: ");
                    string ubicacionNL = Console.ReadLine();
                    librosBiblioteca[numeroDocumentos] = new Libro(tituloNL, autorNL, ubicacionNL, paginasNL);//Creamos el libro nuevo llamando al constructor que inicializa todos los datos                
                    Console.WriteLine("Nuevo libro creado con éxito:");
                    librosBiblioteca[numeroDocumentos].MuestraDatos();
                }
                else
                {
                    Console.WriteLine("\nSe va a incluir un nuevo artículo en la base de datos. Introduzca a continuación los datos del mismo:");
                    Console.WriteLine("Título: ");
                    string tituloNL = Console.ReadLine();
                    Console.WriteLine("Autor: ");
                    string autorNL = Console.ReadLine();                    
                    Console.WriteLine("Ubicación: ");
                    string ubicacionNL = Console.ReadLine();
                    Console.WriteLine("Procedencia: ");
                    string procedeDe = Console.ReadLine();
                    librosBiblioteca[numeroDocumentos] = new Articulo(tituloNL, autorNL, ubicacionNL, procedeDe);//Creamos el artículo nuevo llamando al constructor que inicializa todos los datos                
                    Console.WriteLine("Nuevo artículo creado con éxito:");
                    librosBiblioteca[numeroDocumentos].MuestraDatos();
                }
                numeroDocumentos++;//Aumentamos el número de libros que hay en la base de datos                
            }
        }

        public void MuestraDocumentosExistentes()//Mostrará los datos de todos los libros que hay en la base de datos
        {
            Console.Clear();
            Console.WriteLine($"LISTADO DE DOCUMENTOS EXISTENTES EN LA BASE DE DATOS:\n ({numeroDocumentos} en total)\n");            
            
            if (numeroDocumentos > 0)
            {
                for (int i = 0; i < numeroDocumentos; i++)
                {
                    librosBiblioteca[i].MuestraDatos();
                    Console.WriteLine("-------------------");
                    if (i >0 && i % 3 == 0) //Cada 3 libros hará una pausa
                    {
                        Console.Write("Pulse una tecla para continuar...");
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                }
            }
            else
                Console.WriteLine("La base de datos está vacía...");
        }
    }
}
