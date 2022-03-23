using System;
using System.Diagnostics;

public class SegundoGrado
{
    public void Resolver(
        float a, float b, float c,
        out float x1, out float x2)
    {
        float discriminante;

        discriminante = b * b - 4 * a * c;

        if(discriminante < 0)
        {
            x1 = -9999;
            x2 = -9999;
        }
        else if(discriminante == 0)
        {
            x1 = -b / (2 * a);
            x2 = -9999;
        }
        else
        {
            x1 = (float)((-b + Math.Sqrt(discriminante)) / (2 * a));
            x2 = (float)((-b - Math.Sqrt(discriminante)) / (2 * a));
        }
    }
}

public class PruebaSegundoGrado
{
    public static void Main()
    {
        float solucion1, solucion2;

        Console.WriteLine("Probando ecuaciones de segundo grado");

        SegundoGrado ecuacion = new SegundoGrado();

        Console.Write("\nProbando x2 - 1 = 0... ");
        ecuacion.Resolver((float)1, (float)0, (float)-1,
            out solucion1, out solucion2);
        /*if ((solucion1 == 1) && (solucion2 == -1))
            Console.WriteLine("Correcto");
        else
            Console.WriteLine("Fallo");*/
        Debug.Assert(solucion1 == 1 && solucion2 == -1);

        Console.Write("\nProbando x2 = 0... ");
        ecuacion.Resolver((float)1, (float)0, (float)0,
            out solucion1, out solucion2);
        /*if ((solucion1 == 0) && (solucion2 == -9999))
            Console.WriteLine("Correcto");
        else
            Console.WriteLine("Fallo");*/
        Debug.Assert(solucion1 == 0 && solucion2 == -9999);

        Console.Write("\nProbando x2 - 3x = 0... ");
        ecuacion.Resolver((float)1, (float)-3, (float)0,
            out solucion1, out solucion2);
        /*if ((solucion1 == 3) && (solucion2 == 0))
            Console.WriteLine("Correcto");
        else
            Console.WriteLine("Fallo");*/
        Debug.Assert(solucion1 == 3 && solucion2 == 0);

        Console.Write("\nProbando 2x2 - 2 = 0... ");
        ecuacion.Resolver((float)2, (float)0, (float)-2,
            out solucion1, out solucion2);
        /*if ((solucion1 == 1) && (solucion2 == -1))
            Console.WriteLine("Correcto");
        else
            Console.WriteLine("Fallo");*/
        Debug.Assert(solucion1 == 1 && solucion2 == -1);
    }
}
