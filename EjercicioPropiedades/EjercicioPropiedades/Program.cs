using System;

public class Persona
{
    private string nombre;

    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }
}

public class Prueba
{
    public static void Main()
    {
        Persona persona = new Persona();

        persona.Nombre = "MARÍA";

        Console.WriteLine(persona.Nombre);

        Console.ReadKey();
    }
}