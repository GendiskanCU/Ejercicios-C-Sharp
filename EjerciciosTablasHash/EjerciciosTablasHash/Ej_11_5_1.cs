/*11.5.1) Crea una versión alternativa del ejercicio 11.4.2.1, pero que tenga las 
traducciones almacenadas en una tabla Hash.
(11.4.2.1) Crea un programa que, cuando el usuario introduzca el nombre de un 
número del 1 al 10 en inglés (por ejemplo, "two"), diga su traducción en español 
(por ejemplo, "dos").*/
using System;
using System.Collections;

public class EjercicioTablaHash
{
    public static void Main()
    {
        Hashtable numeros = new Hashtable(10);

        numeros.Add("one", "uno");
        numeros.Add("two", "dos");
        numeros.Add("three", "tres");
        numeros.Add("four", "cuatro");
        numeros.Add("five", "cinco");
        numeros.Add("six", "seis");
        numeros.Add("seven", "siete");
        numeros.Add("eigth", "ocho");
        numeros.Add("nine", "nueve");
        numeros.Add("ten", "diez");

        //Recorremos la tabla hash utilizando un enumerado
        IDictionaryEnumerator enumerator = numeros.GetEnumerator();
        Console.WriteLine("Contenido del diccionario:");
        while (enumerator.MoveNext())
        {
            Console.WriteLine("{0} - {1}", enumerator.Key, enumerator.Value);
        }

        Console.WriteLine("Número en inglés a traducir (en blanco para finalizar):");
        string number = Console.ReadLine();

        while(number != "")
        {
            if(numeros.Contains(number))
            {
                Console.WriteLine("La traducción de {0} es: {1}", number,
                    numeros[number]);
            }
            else
            {
                Console.WriteLine("El número {0} no se ha encontrado", number);
            }

            Console.WriteLine("Número en inglés a traducir (en blanco para finalizar):");
            number = Console.ReadLine();
        }


        Console.ReadLine();

    }
}
