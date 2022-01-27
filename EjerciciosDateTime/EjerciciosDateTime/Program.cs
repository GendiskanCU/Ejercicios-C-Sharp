/*(12.1.1) Crea una versión mejorada del ejemplo 12_01a, que muestre el nombre 
del mes (usa un array para almacenar los nombres y accede a la posición 
correspondiente), la hora, los minutos, los segundos y las décimas de segundo (no 
las milésimas). Si los minutos o los segundos son inferiores a 10, deberán 
mostrarse con un cero inicial, de modo que siempre aparezcan con dos cifras.*/

using System;

public class EjercicioDateTime
{
    public static void Main()
    {
        string[] meses = {"enero", "febrero", "marzo", "abril", "mayo", "junio",
        "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"};

        

        Console.WriteLine("Fecha y hora actual:");

        
        DateTime fechaActual = DateTime.Now;

        string dia = fechaActual.Day.ToString("00");
        string mes = meses[fechaActual.Month - 1];
        string year = fechaActual.Year.ToString("0000");
        string hora = fechaActual.Hour.ToString("00");
        string minutos = fechaActual.Minute.ToString("00");
        string segundos = fechaActual.Second.ToString("00");
        string decimas = (fechaActual.Millisecond/100).ToString("00");

        Console.WriteLine("{0} de {1} de {2}", dia, mes, year);
        Console.WriteLine("{0}:{1}:{2}:{3}", hora, minutos, segundos, decimas);
            
        
        Console.ReadLine();
    }
}