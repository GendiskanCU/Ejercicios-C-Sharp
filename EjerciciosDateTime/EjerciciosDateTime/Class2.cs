/*(12.1.3) Crea un programa que pida al usuario su fecha de nacimiento,
  y diga de qué día de la semana se trataba.*/

using System;


public class DiaNacimiento
{
    public static void Main()
    {
        string fechaNacimiento;
        string[] fechaNacimientoPartida;
        int día, mes, año;


        char seguir = 'n';
        do
        {
            Console.WriteLine("Introduce tu fecha de nacimiento con el formato dd-mm-aaaa");
            fechaNacimiento = Console.ReadLine();
            fechaNacimientoPartida = fechaNacimiento.Split('-');
            try
            {                
                día = Convert.ToInt32(fechaNacimientoPartida[0]);
                mes = Convert.ToInt32(fechaNacimientoPartida[1]);
                año = Convert.ToInt32(fechaNacimientoPartida[2]);
            }
            catch
            {
                día = mes = año = 0;
            }

            Console.WriteLine("Tu fecha de nacimiento es: {0}-{1}-{2}", día, mes, año);
            Console.WriteLine("Si es correcto, escribe 's'. Otra para introducir de nuevo");
            try
            {
                seguir = Convert.ToChar(Console.ReadLine());
            }
            catch
            {
                seguir = 'n';
            }
        } while (seguir != 's') ;

        DateTime fecha = new DateTime(año, mes, día);

        Console.WriteLine("El día que naciste era: {0}", fecha.DayOfWeek);

        Console.ReadLine();
    }
}