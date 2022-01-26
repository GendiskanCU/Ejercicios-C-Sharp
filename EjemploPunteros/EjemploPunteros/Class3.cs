using System;

public class EjemploAritmeticaPunteros
{
    public unsafe static void Main()
    {
        const int elementosArray = 5;

        int* datos = stackalloc int[elementosArray];
        int* posicion = datos;

        Console.WriteLine("Posición actual: {0}", (int)posicion);

        //Ponemos un 0 en el primer dato
        *datos = 0;

        //Rellenamos los demás con números
        for(int i = 1; i < elementosArray; i++)
        {
            posicion++;
            Console.WriteLine("Posición actual: {0}", (int)posicion);
            *posicion = i * 10;
        }

        //Mostramos el array
        Console.WriteLine("Contenido");
        for(int i= 0; i < elementosArray; i++)
        {
            Console.WriteLine(datos[i]);
        }
    }
}