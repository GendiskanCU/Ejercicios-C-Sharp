/*(12.1.4) Crea un programa que muestre el calendario del mes actual (pista: 
primero deberás calcular qué día de la semana es el día 1 de este mes).*/

using System;

public class CalendarioMes
{
    public static void Main()
    {
        DateTime fecha = DateTime.Now;
        int[] diasCadaMes = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
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

        DateTime fechaPrimerDia = new DateTime(fecha.Year, fecha.Month, 1);
        diaSemanaPrimero = Convert.ToInt32(fechaPrimerDia.DayOfWeek);

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
    }

    private static bool esBisiesto(int año)
    {
        return (año % 4 == 0);
    }
}