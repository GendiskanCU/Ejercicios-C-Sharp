using System;


namespace ConsolaPersonalizada
{
    public class Console
    {
        public static void WriteLine(string texto)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(texto);
        }

        public static void ReadKey()
        {
            System.Console.Write("Pulsa una tecla para continuar...");
            System.Console.ReadKey();
        }
    }
}


public class Prueba
{
    public static void Main()
    {
        ConsolaPersonalizada.Console.WriteLine("Hola");

        ConsolaPersonalizada.Console.ReadKey();
    }
}