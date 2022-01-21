using System;

public class PilaString
{
    string[] datosPila;
    int posicionPila;
    const int maxPila = 200;

    //Constructor
    public PilaString()
    {
        posicionPila = 0;
        datosPila = new string[maxPila];
    }

    //Añadir a la pila: Apilar
    public void Apilar(string nuevoDato)
    {
        if (posicionPila == maxPila)
            Console.WriteLine("La pila está llena");
        else
        {
            datosPila[posicionPila] = nuevoDato;
            posicionPila++;
        }
    }

    //Extraer de la pila: Desapilar
    public string Desapilar()
    {
        if(posicionPila < 0)
            Console.WriteLine("La pila está vacía");
        else
        {
            posicionPila--;
            return datosPila[posicionPila];
        }
        return null;
    }

    public static void Main()
    {
        string palabra;

        PilaString miPila = new PilaString();
        miPila.Apilar("Hola,");
        miPila.Apilar("soy");
        miPila.Apilar("yo");

        for(byte i= 0; i < 4; i++)
        {
            palabra = (string)miPila.Desapilar();
            Console.WriteLine(palabra);
        }

        Console.ReadLine();
    }
    
}


