/*(13.8.2) Crea un programa que prepare un array de palabras. Luego, el usuario 
debe introducir una palabra, y el programa responderá si es palabra está en el 
array o no, utilizando LINQ.*/
using System;
using System.Linq;

public class EjercicioLinq2
{
    public static void Main()
    {
        string[] palabras =
        {
            "gorrión", "perro", "gato", "elefante",
            "oveja", "ciervo", "oso", "ardilla"
        };

        bool finalizar = false;
        while (!finalizar)
        {
            Console.WriteLine("Introduce el animal a buscar: ");
            string animal = Console.ReadLine();
            if (animal == "")
            {
                finalizar = true;
            }
            else
            {
                var buscar =
                    from ani in palabras
                    where ani == animal
                    select ani;

                if (buscar.Count() == 0)
                {
                    Console.WriteLine("{0} no está en el diccionario", animal);
                }
                else
                {
                    Console.WriteLine("{0} sí se ha encontrado en el diccionario", animal);
                }
            }
        }
    }
}