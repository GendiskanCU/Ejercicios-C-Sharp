using System;

public class EjemploDateTime
{
    public static void Main()
    {
        DateTime fechaActual = DateTime.Now;

        Console.WriteLine("Hoy es {0} de {1} de {2}",
            fechaActual.Day, fechaActual.Month, fechaActual.Year);

        DateTime diaSiguiente = fechaActual.AddDays(1);

        Console.WriteLine("Mañana será {0}", diaSiguiente.Day);

        //Diferencia entre dos fechas
        DateTime fechaNacimiento = new DateTime(1970, 9, 15);

        TimeSpan diferenciaFechas = fechaActual.Subtract(fechaNacimiento);

        Console.WriteLine("Desde mi fecha de nacimiento, el {0}-{1}-{2}",
            fechaNacimiento.Day, fechaNacimiento.Month, fechaNacimiento.Year);
        Console.WriteLine("Han transcurrido {0} días", diferenciaFechas.Days);
        Console.WriteLine("Con decimales serían {0} días", diferenciaFechas.TotalDays);
        Console.WriteLine("Con más detalle sería: {0}", diferenciaFechas);
    }
}