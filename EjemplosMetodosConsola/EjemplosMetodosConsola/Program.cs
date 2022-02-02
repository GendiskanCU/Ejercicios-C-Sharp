using System;

public class EjemploPosibilidadesConsola
{
    public static void Main()
    {
        int posX, posY;

        Console.Title = "EJEMPLO DE CONSOLA";

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        posY = 10;//Fila 10

        Random r = new Random(DateTime.Now.Millisecond);
        posX = r.Next(20, 40);//Columna aleatoria entre 20 y 40
        Console.SetCursorPosition(posX, posY);
        Console.WriteLine("Bienvenido/a");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(10, 15);
        Console.Write("Pulsa 1 o 2");

        ConsoleKeyInfo tecla;

        do
        {
            tecla = Console.ReadKey(true);
        } while (tecla.KeyChar != '1' && tecla.KeyChar != '2');

        int maxX = Console.WindowWidth;
        int maxY = Console.WindowHeight;

        Console.SetCursorPosition(maxX - 50, maxY - 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Pulsa una tecla para salir...");

        Console.ReadKey(true);
    }
}