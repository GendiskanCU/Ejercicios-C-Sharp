/*(12.1.5) Crea un programa que muestre el calendario correspondiente al mes y el 
año que se indiquen como parámetros en línea de comando.*/

using System;

public class CalendarioMes
{
    public static int Main(string [] args)
    {
        int anyo, mes;
        try
        {
            anyo = Convert.ToInt32(args[0]);
        }
        catch
        {
            anyo = 1900;
        }
        
        try
        {
            mes = Convert.ToInt32(args[1]);
        }
        catch
        {
            mes = 1;
        }
        if (mes < 1 || mes > 12)
            mes = 1;
         

        DateTime fecha = new DateTime(anyo, mes, 1);

        int[] diasCadaMes = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] meses = {"nada", "enero", "febrero", "marzo", "abril", "mayo", "junio",
        "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"};

        int numDias;
        int diaSemanaPrimero;        
        int siguientePosicion = 1;

        if(fecha.Month == 2 && esBisiesto(fecha.Year))
        {
            numDias = 29;
        }
        else
        {
            numDias = diasCadaMes[fecha.Month];
        }

        
        diaSemanaPrimero = Convert.ToInt32(fecha.DayOfWeek);

        Console.WriteLine("Calendario de {0}\nde {1}:\n", meses[mes], anyo);

        Console.WriteLine("lu ma mi ju vi sá do");

        for(int i = siguientePosicion; siguientePosicion < diaSemanaPrimero; siguientePosicion++)
        {
            Console.Write("   ");
        }
        siguientePosicion--;

        for(int siguienteDia = 1; siguienteDia <= numDias; siguienteDia++)
        {
            if (siguienteDia < 10)
                Console.Write(" {0} ", siguienteDia);
            else
                Console.Write("{0} ", siguienteDia);

            siguientePosicion++;

            if (siguientePosicion % 7 == 0)
                Console.WriteLine();
        }

        Console.WriteLine();
        Console.ReadLine();
        return 0;
    }

    private static bool esBisiesto(int año)
    {
        return (año % 4 == 0);
    }
}