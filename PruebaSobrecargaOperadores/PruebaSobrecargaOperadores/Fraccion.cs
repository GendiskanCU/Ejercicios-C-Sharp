using System;
using System.Collections.Generic;
using System.Text;

public class Fraccion
{
    int numerador, denominador;

    public Fraccion(int numeradorFraccion)//Constructor que solo recibe el numerador    
    {
        numerador = numeradorFraccion;
        denominador = 1;
    }

    public Fraccion()//Constructor por defecto
    {
        numerador = 0;
        denominador = 1;
    }

    public Fraccion(int numeradorFraccion, int denominadorFraccion)//Constructor que recibe los dos valores
    {
        numerador = numeradorFraccion;
        denominador = denominadorFraccion != 0 ? denominadorFraccion : 1;//No se admitirá un cero como denominador
    }

    public void Escribir() //Muestra la fracción
    {
        Console.WriteLine("{0}/{1}", numerador, denominador);
    }

    public static Fraccion operator +(Fraccion fr1, Fraccion fr2)//Sobrecarga del operador suma para sumar dos fracciones
    {
        Fraccion resultado = new Fraccion();

        resultado.denominador = PruebaOperadoresSobrecargados.MinimoComunMultiplo(fr1.denominador, fr2.denominador);
        resultado.numerador = fr1.numerador * (resultado.denominador / fr1.denominador) + fr2.numerador * (resultado.denominador / fr2.denominador);
        
        return resultado;
    }

    public static Fraccion operator *(Fraccion fr1, Fraccion fr2)//Sobrecarga del operador multiplicacion
    {
        Fraccion resultado = new Fraccion();

        resultado.numerador = fr1.numerador * fr2.numerador;
        resultado.denominador = fr1.denominador * fr2.denominador;

        return resultado;
    }
}