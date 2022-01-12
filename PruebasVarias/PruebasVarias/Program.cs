using System;

namespace PruebasVarias
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase = "L&109&0&Título libro 0&Autor libro 0&Estantería I";
            string[] porcion;

            porcion = frase.Split('&');
            for (int i = 0; i < porcion.Length; i++)
                Console.WriteLine(porcion[i]);
        }
    }
}
