using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

//Clases de prueba
[Serializable]
public class MiniEjemplo
{
    int dato;

    public void SetDato(int n)
    {
        dato = n;
    }

    public int GetDato()
    {
        return dato;
    }

}


[Serializable]
public class Ejemplo
{
    int numero;
    float numero2;
    MiniEjemplo[] mini;

    public Ejemplo()
    {
        mini = new MiniEjemplo[100];
        for (int i = 0; i<100; i++)
        {
            mini[i] = new MiniEjemplo();
            mini[i].SetDato(i * 2);
        }
    }


    public void SetNumero(int n)
    {
        numero = n;
    }

    public int GetNumero()
    {
        return numero;
    }

    public void SetMini(int n, int valor)
    {
        mini[n].SetDato(valor);
    }

    public int GetMini(int n)
    {
        return mini[n].GetDato();
    }
}

//La clase que vamos a guardar
[Serializable]
public class ClaseAGuardar
{
    Ejemplo e;

    public void SetDatos(Ejemplo e1)
    {
        e = e1;
    }

    public Ejemplo GetDatos()
    {
        return e;
    }
}

//La clase que realizará la operación de guardar
public class Serializador
{
    string nombre;

    public Serializador(string nombreFich)
    {
        nombre = nombreFich;
    }

    public void Guardar(ClaseAGuardar objeto)
    {
        IFormatter formatter = new SoapFormatter();
    }
}
    


