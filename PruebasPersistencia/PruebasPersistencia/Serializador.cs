using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Serializador
{
    string nombre;

    public Serializador(string nombreFich)
    {
        nombre = nombreFich;
    }

    public void Guardar(ClaseAGuardar objeto)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);

        formatter.Serialize(stream, objeto);
        stream.Close();
    }

    public ClaseAGuardar Cargar()
    {
        ClaseAGuardar objeto;
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);

        objeto = (ClaseAGuardar)formatter.Deserialize(stream);
        stream.Close();
        return objeto;
    }
}