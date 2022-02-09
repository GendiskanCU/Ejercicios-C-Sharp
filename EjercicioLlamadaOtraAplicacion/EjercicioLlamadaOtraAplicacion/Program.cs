/*(12.4.3) Crea un programa que mida el tiempo que tarda en ejecutarse un cierto 
proceso. Este proceso se le indicará como parámetro en la línea de comandos.*/
using System;
using System.Diagnostics;

public class Llamada
{
    public static int Main(string [] args)
    {
        string proceso;
        Process procesoLanzado;

        if (args.Length == 0)
        {
            Console.WriteLine("Falta el parámetro");            
            return -1;
        }
        else
        {
            proceso = args[0];            

            Console.WriteLine("Lanzando el proceso:\n{0}", proceso);
            DateTime momentoInicio = DateTime.Now;
            try
            {
                procesoLanzado = Process.Start(proceso);                
            }
            catch(Exception ex)
            {
                Console.Write("Error: {0}", ex.Message);
                return -1;
            }

            procesoLanzado.WaitForExit();

            DateTime momentoFinal = DateTime.Now;

            TimeSpan tiempoTranscurrido = momentoFinal - momentoInicio;

            Console.WriteLine("El proceso {0} ha estado en ejecución:", proceso);
            Console.WriteLine("{0} minutos, {1} segundos", tiempoTranscurrido.Minutes.ToString("00"),
                tiempoTranscurrido.Seconds.ToString("00"));

            Console.Write("Pulsa una tecla para salir");
            Console.ReadKey();
            return 0;
        }
    }
}