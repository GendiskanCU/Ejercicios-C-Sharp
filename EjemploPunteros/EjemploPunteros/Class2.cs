using System;

public class EjemploReservaEspacio
{
    public unsafe static void Main()
    {
        //Reservamos el espacio para el array
        const int elementosArray = 5;
        int* datos = stackalloc int[elementosArray];

        //Rellenamos el array
        for(int i = 0; i < elementosArray; i++)
        {
            datos[i] = i * 10;
        }

        //Mostramos el array
        for (int i = 0; i < elementosArray; i++)
        {
            Console.WriteLine(datos[i]);
        }
    }
}