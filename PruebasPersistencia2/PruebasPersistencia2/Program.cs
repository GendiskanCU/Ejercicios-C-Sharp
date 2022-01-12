using System;

public class Prueba
{
    public static void Main()
    {
        Ejemplo ejemplo = new Ejemplo();
        ejemplo.SetNumero(5);
        ejemplo.SetNumero2(5.5f);
        ejemplo.SetMini(50, 500);
        Console.WriteLine("Valor 1: {0}", ejemplo.GetNumero());

        ClaseAGuardar contenedor = new ClaseAGuardar();
        contenedor.SetDatos(ejemplo);

        Serializador s = new Serializador("ejemplo.dat");
        s.Guardar(contenedor);

        Ejemplo ejemplo2 = new Ejemplo();
        Console.WriteLine("Valor 2: {0}", ejemplo2.GetNumero());
        ejemplo2 = s.Cargar().GetDatos();
        Console.WriteLine("Valor 2: {0}", ejemplo2.GetNumero());
    }
}