using System;
using System.Threading;

//Hacer una pausa temporal en la ejecución del programa
public class EjemploThread
{
    public static void Main()
    {
        DateTime fechaActual = DateTime.Now;
        Console.WriteLine("Son las {0}:{1}:{2}", fechaActual.Hour
            ,fechaActual.Minute, fechaActual.Second);
        Console.WriteLine("Pausamos la ejecución 10 segundos");
        Thread.Sleep(10000);
        fechaActual = DateTime.Now;
        Console.WriteLine("Ahora son las {0}:{1}:{2}", fechaActual.Hour
            , fechaActual.Minute, fechaActual.Second);
    }
}