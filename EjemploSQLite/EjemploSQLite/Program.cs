using System;

public class pruebaSQLite
{
    public static void Main()
    {
        AgendaSQLite agenda = new AgendaSQLite();
        string opcion;

        do
        {
            Console.WriteLine("Escoja una opción...");
            Console.WriteLine("1. Añadir");
            Console.WriteLine("2. Ver todos");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Borrar");
            Console.WriteLine("5. Modificar");
            Console.WriteLine("6. Exportar");
            Console.WriteLine("7. Importar");
            Console.WriteLine("0. Salir");

            opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    Console.WriteLine("Nombre de la nueva persona:");
                    string n = Console.ReadLine();
                    Console.WriteLine("Dirección de la nueva persona:");
                    string d = Console.ReadLine();
                    Console.WriteLine("Edad de la nueva persona:");
                    int e = Convert.ToInt32(Console.ReadLine());

                    agenda.InsertarDatos(n, d, e);
                    break;
                case "2":
                    Console.WriteLine(agenda.LeerTodosDatos());
                    break;
                case "3":
                    Console.WriteLine("Texto a buscar:");
                    string txt = Console.ReadLine();
                    Console.WriteLine(agenda.LeerBusqueda(txt));
                    break;
                case "4":
                    Console.WriteLine("Nombre de la persona a borrar:");
                    string p = Console.ReadLine();
                    agenda.BorrarRegistro(p);
                    break;
                case "5":
                    Console.WriteLine("Nombre de la persona a modificar:");
                    string nn = Console.ReadLine();
                    Console.WriteLine("Nueva dirección de esa persona:");
                    string nd = Console.ReadLine();
                    Console.WriteLine("Nueva edad de esa persona:");
                    int ne = Convert.ToInt32(Console.ReadLine());
                    agenda.ModificarRegistro(nn, nd, ne);
                    break;
                case "6":
                    Console.WriteLine("Nombre del fichero al que exportar:");
                    string nFich = Console.ReadLine();
                    bool exportacion = agenda.ExportarAFichero(nFich);
                    if (exportacion)
                        Console.WriteLine("El fichero {0} ha sido creado con éxito", nFich);
                    else
                        Console.WriteLine("Error al exportar datos");
                    break;
                case "7":
                    Console.WriteLine("Nombre del fichero del que importar:");
                    string fichImportacion = Console.ReadLine();
                    bool importacion = agenda.ImportaDeFichero(fichImportacion);
                    if (importacion)
                        Console.WriteLine("Importación del fichero {0} finalizada con éxito", fichImportacion);
                    else
                        Console.WriteLine("Error al importar datos");
                    break;
                default:
                    break;
            }

        } while (opcion != "0");
              
    }
}