/*(12.1.2) Crea un reloj que se muestre en pantalla, y que se actualice cada segundo 
(usando "Sleep"). En esta primera aproximación, el reloj se escribirá con 
"WriteLine", de modo que aparecerá en la primera línea de pantalla, luego en la 
segunda, luego en la tercera y así sucesivamente*/

using System;
using System.Threading;

public class EjercicioReloj
{
    public static void Main()
    {
        DateTime horaActual;
        string hora, minutos, segundos;

        while(!(Console.KeyAvailable && Console.ReadKey(true).Key ==ConsoleKey.Escape))
        {
            horaActual = DateTime.Now;
            hora = horaActual.Hour.ToString("00");
            minutos = horaActual.Minute.ToString("00");
            segundos = horaActual.Second.ToString("00");
            Console.WriteLine("TIME: {0}:{1}:{2}  --(PRESS \'ESC\' TO EXIT)--", hora, minutos, segundos);
            Thread.Sleep(1000);
        }        
    }

}