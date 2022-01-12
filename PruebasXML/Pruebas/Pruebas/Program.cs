using System;
using System.IO;
using System.Linq;
using System.Xml; //Debe ser incluido para poder hacer la serialización a XML
using System.Xml.Serialization;//Debe ser incluido para poder hacer la serialización a XML


public class miniDato
{
    public int dato;//Para que esta serialización funcione, los atributos de las clases deben ser públicos

    public void SetDato(int d)
    {
        dato = d;
    }
}

//La clase que vamos a guardar
public class ClaseAGuardar
{
    public miniDato[] datos;//Para que esta serialización funcione, los atributos de las clases deben ser públicos
    public string frase;//Para que esta serialización funcione, los atributos de las clases deben ser públicos


    public ClaseAGuardar()//Constructor por defecto. Inicializa los datos
    {
        frase = "";

        datos = new miniDato[10];

        for (int i = 0; i < 10; i++)
        {
            datos[i] = new miniDato();
            datos[i].SetDato(i * 2);
        }
    }

    public void SetFrase(string f)
    {
        frase = f;
    }

    public void SetDato(int posicion, int valor)
    {
        datos[posicion].SetDato(valor);
    }

    public string GetFrase()
    {
        return frase;
    }
}

public class ProgramaPrueba
{
    public static void Main()
    {

        /*serialización a un fichero XML
        ClaseAGuardar prueba = new ClaseAGuardar();
        prueba.SetFrase("Esto es una prueba");
        prueba.SetDato(1, 8888);

        System.Xml.Serialization.XmlSerializer serializador = new System.Xml.Serialization.XmlSerializer(prueba.GetType());

        FileStream ficheroXML;
        ficheroXML = new FileStream("ClaseAGuardar.xlm", FileMode.Create, FileAccess.Write);

        serializador.Serialize(ficheroXML, prueba);

        ficheroXML.Close();*/

        //deserialización desde el fichero XML a un objeto de la clase
        var deserializador = new XmlSerializer(typeof(ClaseAGuardar));

        FileStream ficheroXML;
        ficheroXML = File.OpenRead("ClaseAGuardar.xlm");

        ClaseAGuardar prueba = (ClaseAGuardar)deserializador.Deserialize(ficheroXML);

        Console.WriteLine(prueba.GetFrase());
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Dato {0}: {1}", i + 1, prueba.datos[i].dato);
        }

        ficheroXML.Close();
    }
}



