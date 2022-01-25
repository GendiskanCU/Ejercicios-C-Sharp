using System;

public class EjemploPuntero
{
    private unsafe static void pruebaPunteros()
    {
        int* punteroAEntero;
        int x;

        //Damos un valor a x
        x = 2;

        //punteroAEntero será la dirección de memoria de x
        punteroAEntero = &x;

        //Los dos están en la misma dirección
        Console.WriteLine("x vale {0}", x);
        Console.WriteLine("En punteroAEntero hay un {0}", *punteroAEntero);

        //Ahora cambiamos el valor guardado en punteroAEntero
        *punteroAEntero = 5;
        //Y x se modifica también
        Console.WriteLine("x vale {0}", x);
        Console.WriteLine("En punteroAEntero hay un {0}", *punteroAEntero);
    }

    public static void Main()
    {
        pruebaPunteros();
    }
}