using System;

public class EjemploFixed
{
    public unsafe static void Main()
    {
        int[] datos = { 10, 20, 30 };

        Console.WriteLine("Leyendo el segundo dato...");
        fixed (int* posicionDato = &datos[1])
        {
            Console.WriteLine("En posicionDato hay {0}", *posicionDato);
        }

        Console.WriteLine("Leyendo ahora el primer dato...");
        fixed (int* posicionDato = &datos[0])
        {
            Console.WriteLine("Ahora en posicionDato hay {0}", *posicionDato);
        }
    }
}