/*(7.6.3) Crea una clase "Fraccion", que represente a una fracción, formada por un 
numerador y un denominador. Crea un constructor que reciba ambos datos como 
parámetros y otro constructor que reciba sólo el numerador. Crea un método 
Escribir, que escriba la fracción en la forma "3 / 2". Redefine los operadores "+", "-", 
"*" y "/" para que permitan realizar las operaciones habituales con dos fracciones*/
using System;

public class PruebaOperadoresSobrecargados
{
    public static void Main()
    {
        Fraccion fraccion1, fraccion2, fraccion3, suma, multiplicacion, combinado;

        fraccion1 = new Fraccion(2, 3);
        fraccion2 = new Fraccion(5, 5);
        fraccion3 = new Fraccion(3, 4);

        fraccion1.Escribir();
        fraccion2.Escribir();

        Console.WriteLine("Suma");
        suma = fraccion1 + fraccion2;
        suma.Escribir();

        Console.WriteLine("Multiplicación");
        multiplicacion = fraccion1 * fraccion2;
        multiplicacion.Escribir();

        Console.WriteLine("Combinación (fr1 + fr2) * fr1");
        combinado = (fraccion1 + fraccion2) * fraccion1;
        combinado.Escribir();

        Console.WriteLine("Nueva suma");
        fraccion1.Escribir();
        fraccion2.Escribir();
        fraccion3.Escribir();
        suma = fraccion1 + fraccion2 + fraccion3;
        suma.Escribir();
    }

    public static int MinimoComunMultiplo(int num1, int num2)
    {
        int mcm;
        bool mcmEncontrado = false;

        mcm = (num1 >= num2) ? num1 : num2;

        while (!mcmEncontrado)
        {
            if (mcm % num1 == 0 && mcm % num2 == 0)
                mcmEncontrado = true;
            else            
                mcm++;            
        }

        return mcm;
    }
}