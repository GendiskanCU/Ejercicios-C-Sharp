using System;

[Serializable]
public class Ejemplo
{
    int numero;
    float numero2;
    MiniEjemplo[] mini;

    public Ejemplo()
    {
        mini = new MiniEjemplo[100];
        for(int i = 0; i<100; i++)
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

    public void SetNumero2(float n)
    {
        numero2 = n;
    }

    public float GetNumero2()
    {
        return numero2;
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