using System;

public class Ejemplo2Punteros
{
    public unsafe static void Incrementar(int* p)
    {
        //Incrementamos el entero apuntado por p
        *p += 1;
    }

    public static void Main()
    {
        int i = 1;

        //Parte insegura de Main
        unsafe
        {
            //La función espera un puntero, por lo que
            //pasamos la dirección de memoria del entero
            Incrementar(&i);
        }

        //Mostramos el resultado
        Console.Write(i);
    }
}