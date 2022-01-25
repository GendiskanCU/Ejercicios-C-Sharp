/*(11.9.3.1) Crea un programa que intercambie la posición de memoria en la que se 
encuentran dos variables y que luego muestre sus contenidos en pantalla, para 
comprobar que no son los mismos que al principio.*/

public class EjercicioPunteros
{
    private static unsafe void Intercambia()
    {
        float var1 = 1.1f;
        float var2 = 2.2f;

        float* punt1 = &var1;
        float* punt2 = &var2;

        Console.WriteLine("El valor en la dirección de punt1 es {0}", *punt1);
        Console.WriteLine("El valor en la dirección de punt2 es {0}", *punt2);

        //Intercambiamos
        punt1 = &var2;
        punt2 = &var1;

        Console.WriteLine("Tras el intercambio");
        Console.WriteLine("El valor en la dirección de punt1 es {0}", *punt1);
        Console.WriteLine("El valor en la dirección de punt2 es {0}", *punt2);
    }

    public static void Main()
    {
        Intercambia();
    }
}