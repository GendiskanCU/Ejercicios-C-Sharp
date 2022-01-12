using System;


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

