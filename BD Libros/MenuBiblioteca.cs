using System;
using System.Collections.Generic;
using System.Text;

namespace BD_Libros
{
    public class MenuBiblioteca
    {

        static void MuestraMensajeError()
        {
            Console.Clear();
            Console.WriteLine("\nPor favor, introduzca una opción correcta\n");
        }
        public static int MuestraMenu()
        {
            int opcion = 0;
            bool todoOK = false;

            while (!todoOK)
            {                
                Console.WriteLine("\nEscribe la opción deseada:");
                Console.WriteLine("1. Añadir nuevo documento");
                Console.WriteLine("2. Mostrar documentos existentes");
                Console.WriteLine("3. Buscar documentos entre los existentes");
                Console.WriteLine("4. Modificar datos de un documento");
                Console.WriteLine("5. Eliminar documento");

                Console.WriteLine("8. Rellenar la base de datos con datos de ejemplo");
                Console.WriteLine("9. Salir del programa");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    MuestraMensajeError();
                }

                if (opcion >= 1 && opcion <= 9)
                    todoOK = true;
                else
                    MuestraMensajeError();
            }

            return opcion;
    }



    }
}
