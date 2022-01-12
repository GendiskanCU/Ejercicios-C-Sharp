using System;


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