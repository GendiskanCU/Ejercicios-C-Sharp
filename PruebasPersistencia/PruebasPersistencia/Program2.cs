using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Persistencia
{
    int numero;

    public void SetNumero(int n)
    {
        numero = n;
    }

    public int GetNumero()
    {
        return numero;
    }

    //Métodos para guardar en fichero y leer desde él

    public static void Guardar(string nombre, Persistencia objeto)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, objeto);
        stream.Close();
    }

    public static Persistencia Cargar(string nombre)
    {
        Persistencia objeto;
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
        objeto = (Persistencia)formatter.Deserialize(stream);
        stream.Close();
        return objeto;
    }

    public static void Main()
    {
        Persistencia ejemplo = new Persistencia();
        ejemplo.SetNumero(5);
        Console.WriteLine("Valor: {0}", ejemplo.GetNumero());
        Guardar("ejemplo.dat", ejemplo);

        Persistencia ejemplo2 = new Persistencia();
        Console.WriteLine("Valor: {0}", ejemplo2.GetNumero());
        ejemplo2 = Cargar("ejemplo.dat");
        Console.WriteLine("Valor: {0}", ejemplo2.GetNumero());
    }
}