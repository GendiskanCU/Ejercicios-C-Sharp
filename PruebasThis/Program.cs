/*(7.5.3) Crea una clase Casa, con una superficie (por ejemplo, 90 m2
) y un método "MostrarEstado" que escriba su superficie. Cada casa debe contener 3 puertas. Las
puertas tendrán un ancho, un alto y un método "MostrarEstado" que muestre su 
ancho y su alto y la superficie de la casa en la que se encuentran. Crea un 
programa de prueba que cree una casa y muestre sus datos y los de sus tres 
puertas*/
using System;


    public class Puerta
    {
        private int ancho, alto;

        public Puerta()
        {
            ancho = alto = 0;
        }

        public Puerta(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public void MostrarEstado(Casa casaContenedora)
        {
        Console.WriteLine($"Medidas puerta (ancho x alto): {ancho} x {alto}");
        Console.WriteLine("Superficie de la casa: {0}", casaContenedora.GetSuperficie());
        }
    }

    public class Casa
    {
        Puerta puerta1, puerta2, puerta3;
        int superficie;

        public Casa()
        {
        puerta1 = puerta2 = puerta3 = new Puerta();
        superficie = 0;
        }

        public Casa(int sup)
        {
        Console.WriteLine(sup);
        superficie = sup;
        Console.WriteLine(superficie);
        puerta1 = puerta2 = puerta3 = new Puerta();        
        }

        public Casa(int sup, int x, int y)
        {
        puerta1 = puerta2 = puerta3 = new Puerta(x, y);
        superficie = sup;
        }

        public void MostrarEstado()
        {
        Console.WriteLine("Casa. Superficie: {0}", superficie);
        puerta1.MostrarEstado(this);
        puerta2.MostrarEstado(this);
        puerta3.MostrarEstado(this);
        }

        public int GetSuperficie()
        {
        Console.WriteLine(superficie);
        return superficie;
        }
    }

public class Prueba
{
    public static void Main()
    {
        Casa miCasa = new Casa(86, 1, 2);
        miCasa.MostrarEstado();
    }
}

