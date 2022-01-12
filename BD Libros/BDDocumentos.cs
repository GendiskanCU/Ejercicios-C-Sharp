using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
                char opcion;
                try
                {
                    opcion = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    opcion = 'o';
                }
                string tituloNL, autorNL, ubicacionNL;
                if (opcion == 'L' || opcion == 'l')
                {
                    Console.WriteLine("\nSe va a incluir un nuevo libro en la base de datos. Introduzca a continuación los datos del mismo:");
                    Console.WriteLine("Título: ");
                    tituloNL = Console.ReadLine();
                    Console.WriteLine("Autor: ");
                    autorNL = Console.ReadLine();
                    Console.WriteLine("Nº páginas: ");
                    int paginasNL;
                    try { paginasNL = Convert.ToInt32(Console.ReadLine()); }
                    catch { paginasNL = 0; }
                    Console.WriteLine("Ubicación: ");
                    ubicacionNL = Console.ReadLine();
                    librosBiblioteca[numeroDocumentos] = new Libro(tituloNL, autorNL, ubicacionNL, paginasNL);//Creamos el libro nuevo llamando al constructor que inicializa todos los datos                                                        
                }
                else
                {
                    Console.WriteLine("\nSe va a incluir un nuevo artículo en la base de datos. Introduzca a continuación los datos del mismo:");
                    Console.WriteLine("Título: ");
                    tituloNL = Console.ReadLine();
                    Console.WriteLine("Autor: ");
                    autorNL = Console.ReadLine();                    
                    Console.WriteLine("Ubicación: ");
                    ubicacionNL = Console.ReadLine();
                    Console.WriteLine("Procedencia: ");
                    string procedeDe = Console.ReadLine();
                    librosBiblioteca[numeroDocumentos] = new Articulo(tituloNL, autorNL, ubicacionNL, procedeDe);//Creamos el artículo nuevo llamando al constructor que inicializa todos los datos                                    
                }

                librosBiblioteca[numeroDocumentos].SetId(numeroDocumentos);//Al documento recién creado le asignamos su número de identificación
                Console.WriteLine("Nuevo documento creado con éxito:");
                librosBiblioteca[numeroDocumentos].MuestraDatos();
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

        public void BuscaDocumentos(string textoABuscar)//Hará una búsqueda y mostrará los documentos que contengan el texto a buscar
        {
            Console.Clear();
            Console.WriteLine($"Documentos que contienen la expresión \"{textoABuscar}\":");
            if (numeroDocumentos > 0)
            {
                for (int i = 0; i < numeroDocumentos; i++)
                {
                    if (librosBiblioteca[i].Contiene(textoABuscar))
                    {
                        librosBiblioteca[i].MuestraDatos();
                        Console.WriteLine("-------------------");
                        if (i > 0 && i % 3 == 0) //Cada 3 documentos hará una pausa
                        {
                            Console.Write("Pulse una tecla para continuar...");
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                    }
                }
            }
            else
                Console.WriteLine("La base de datos está vacía...");


        }
        public void Modificar()//Modifica un documento
        {
            Console.Clear();
            if (numeroDocumentos > 0)
            {
                Console.WriteLine("Introduzca el Identificador del documento a modificar: ");
                int idBuscado;
                try
                {
                    idBuscado = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    idBuscado = librosBiblioteca.Length + 1;
                }
                
                if (idBuscado < 0 || idBuscado > (numeroDocumentos - 1))
                    Console.WriteLine("No hay ningún documento con el Identificador especificado");
                else
                {
                    Console.WriteLine("Localizado el siguiente documento:");
                    librosBiblioteca[idBuscado].MuestraDatos();
                    Console.WriteLine("\nIntroduzca los nuevos datos:");
                    librosBiblioteca[idBuscado].ModificaDocumento();
                    Console.WriteLine("Documento modificado:");
                    librosBiblioteca[idBuscado].MuestraDatos();
                }

            }
            else
                Console.WriteLine("La base de datos está vacía");

        }

        public void Eliminar()//Elimina un documento
        {
            Console.Clear();
            if (numeroDocumentos > 0)
            {
                Console.WriteLine("Introduzca el Identificador del documento a modificar: ");
                int idBuscado;
                try
                {
                    idBuscado = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    idBuscado = librosBiblioteca.Length + 1;
                }

                if (idBuscado < 0 || idBuscado > (numeroDocumentos - 1))
                    Console.WriteLine("No hay ningún documento con el Identificador especificado");
                else
                {
                    Console.WriteLine("Localizado el siguiente documento:");
                    librosBiblioteca[idBuscado].MuestraDatos();
                    Console.WriteLine("\n¿Está seguro de querer eliminarlo? (escriba 's' para confirmar): ");
                    char opcion = Convert.ToChar(Console.ReadLine());
                    if (opcion == 's' || opcion == 'S')
                    {
                        for (int i = idBuscado; i < (numeroDocumentos - 1); i++)
                        {
                            librosBiblioteca[i] = librosBiblioteca[i + 1];
                            librosBiblioteca[i].SetId(i);
                        }
                        numeroDocumentos--;
                        Console.WriteLine("Documento eliminado con éxito");
                    }
                    else
                        Console.WriteLine("Acción cancelada");
                }
            }
            else
                Console.WriteLine("La base de datos está vacía");
        }

        public void RellenaConEjemplos()//Rellena la base de datos con algunos ejemplos
        {
            for (int i = 0; i < 10; i++)
            {
                if ( i % 2 == 0)
                {
                    librosBiblioteca[i] = new Libro("Título libro " + i, "Autor libro " + i, "Estantería I", i + 109);
                }
                else
                {
                    librosBiblioteca[i] = new Articulo("Artículo " + i, "Autor artículo " + i, "Estantería II", "Periódico " + i);
                }
                librosBiblioteca[i].SetId(i);
                numeroDocumentos++;
            }
        }

        public void VuelcaDatosAFichero(string nombreFichero = "BDDocumentos.txt")//Vuelca todos los datos en un fichero de texto
        {
            if (numeroDocumentos > 0)//Si hay documentos en la base de datos, se procederá a su volcado
            {
                StreamWriter fichero = new StreamWriter(nombreFichero);
                Console.WriteLine("Volcando datos en el archivo: {0} .....", nombreFichero);
                for (int i = 0; i < numeroDocumentos; i++)
                {
                    if (librosBiblioteca[i].TipoDocumento() == "Libro")//Si es un Libro se vuelcan algunos datos distintos que si es un Artículo
                    {
                        fichero.Write("L&");//El primer campo marcará el tipo de documento
                        fichero.Write(librosBiblioteca[i].getNumPaginas() + "&");
                    }
                    if (librosBiblioteca[i].TipoDocumento() == "Artículo")
                    {
                        fichero.Write("A&");//El primer campo marcará el tipo de documento
                        fichero.Write(librosBiblioteca[i].GetProcedencia() + "&");
                    }
                    //Luego se vuelcan los datos comunes
                    fichero.Write(librosBiblioteca[i].GetId() + "&");
                    fichero.Write(librosBiblioteca[i].getTitulo() + "&");
                    fichero.Write(librosBiblioteca[i].getAutor() + "&");
                    fichero.WriteLine(librosBiblioteca[i].getUbicacion());

                    
                }
                fichero.Close();
                Console.WriteLine("Datos volcados");
            }
        }

        public void CargaDatosDeFichero(string nombreFichero = "BDDocumentos.txt")//Leerá los datos de un fichero y los cargará en memoria
        {
            StreamReader fichero;
            string linea;
            string[] camposLinea;

            if (File.Exists(nombreFichero))//Si existe el fichero, se abre y se cargan sus datos en memoria
            {
                try
                {

                    fichero = File.OpenText(nombreFichero);

                    do
                    {
                        linea = fichero.ReadLine();//Se lee una línea del archivo


                        if (linea != null)
                        {
                            //La línea la vamos a separar en fragmentos, a raíz del separador del campo "&"
                            camposLinea = linea.Split('&');
                            if (camposLinea[0] == "L")//El primer campo indica si el documento es un libro o es un artículo, creándose el objeto propio de cada caso                    
                                librosBiblioteca[numeroDocumentos] = new Libro(camposLinea[3], camposLinea[4], camposLinea[5], Convert.ToInt32(camposLinea[1]));
                            if (camposLinea[0] == "A")
                                librosBiblioteca[numeroDocumentos] = new Articulo(camposLinea[3], camposLinea[4], camposLinea[5], camposLinea[1]);
                            librosBiblioteca[numeroDocumentos].SetId(Convert.ToInt32(camposLinea[2]));

                            numeroDocumentos++;
                        }

                    } while (linea != null);

                    fichero.Close();
                }
                catch (Exception error)
                {
                    Console.WriteLine("\n" + error.Message + "\n");
                }
            }
            else
                Console.WriteLine("No se han encontrado datos previos\n");
        }
    }
}
