﻿using System;

//Jugadores
public struct Jugador
{
    public string nombre;
    public char ficha;
}


//Celdas del tablero de juego
public class Celda
{
    //Posición de la celda en la consola para colocar la ficha
    int posX, posY;
    //Estado de la celda: 0 vacía, 1 con ficha Jugador1, 2 con ficha Jugador2
    int estado;

    public void EstableceEstado(int nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public void EstablecePosicion(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public int Estado()
    {
        return estado;
    }

    public int PosicionX()
    {
        return posX;
    }

    public int PosicionY()
    {
        return posY;
    }

}
public class TresEnRayaRed
{
    //Array que representará el tablero de celdas
    Celda [,] celdas;    
    
    Jugador jugador1, jugador2;

    const int VACIA = 0, FJUG1 = 1, FJUG2 = 2;

    //Constructor genérico
    public TresEnRayaRed()
    {
        //El tablero tendrá un tamaño fijo de 3x3
        celdas = new Celda[3, 3];
        for(int i = 0; i < 3; i++)
            for(int j = 0; j < 3; j++)
                celdas[i, j] = new Celda();

        //Se asigna un nombre genérico a los jugadores        
        jugador1.nombre = "Jugador1";
        jugador2.nombre = "Jugador2";

        //Se asigna ficha a los jugadores
        jugador1.ficha = 'X';
        jugador2.ficha = 'O';

        BorraTablero();
    }

    //Constructor que recibe el nombre de los jugadores
    public TresEnRayaRed(string Jugador1 = "Jugador1", string Jugador2 = "Jugador2")
    {
        //El tablero tendrá un tamaño fijo de 3x3
        celdas = new Celda[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                celdas[i, j] = new Celda();

        //Se asigna el nombre a los jugadores
        jugador1.nombre = Jugador1;
        jugador2.nombre = Jugador2;

        //Se asigna ficha a los jugadores
        jugador1.ficha = 'X';
        jugador2.ficha = 'O';

        BorraTablero();
    }


    /// <summary>
    /// Comienza una nueva partida
    /// </summary>
    public void IniciaPartida()
    {
        DibujaTablero();
    }


    /// <summary>Deja el tablero de juego en blanco, todas las celdas vacías</summary>
    private void BorraTablero()
    {
        //Se dejan todas las celdas en el estado "vacía"
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {                
                celdas[i, j].EstableceEstado(VACIA);
            }
        }
    }

    /// <summary>
    /// Dibuja el tablero de juego en pantalla al inicio de cada partida y asigna posición de cada celda
    /// </summary>
    private void DibujaTablero()
    {
        Console.Clear();        
        Console.WriteLine("JUEGO DE LAS TRES EN RAYA");
        Console.WriteLine("=========================\n");

        Console.WriteLine("{0}: {1} vs. {2}: {3}", jugador1.nombre, jugador1.ficha,
            jugador2.nombre, jugador2.ficha);

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("=========================");
            for (int j = 0; j < 3; j++)
                Console.WriteLine(":       :       :       :");
        }
        Console.WriteLine("=========================");

        //Recorre las celdas asignando la posición en la consola donde irá la ficha
        int aumentoX;
        int aumentoY = 6;
        for (int fila = 0; fila < 3; fila++)
        {
            aumentoX = 4;
            for (int columna = 0; columna < 3; columna++)
            {
                celdas[fila, columna].EstablecePosicion(aumentoX, aumentoY);
                aumentoX += 8;                
            }            
            aumentoY += 4;            
        }        

        /*Console.SetCursorPosition(4, 6);
        Console.Write("X");
        Console.SetCursorPosition(12, 6);
        Console.Write("X");
        Console.SetCursorPosition(20, 6);
        Console.Write("X");
        Console.SetCursorPosition(4, 10);
        Console.Write("X");
        Console.SetCursorPosition(12, 10);
        Console.Write("X");
        Console.SetCursorPosition(20, 10);
        Console.Write("X");
        Console.SetCursorPosition(4, 14);
        Console.Write("X");
        Console.SetCursorPosition(12, 14);
        Console.Write("X");
        Console.SetCursorPosition(20, 14);
        Console.Write("X");*/

        Console.SetCursorPosition(0, 18);
        

    }
}







//============================================================================================
//============================================================================================
public class Juego3Raya
{
    public static void Main()
    {
        string jug1, jug2;
        Console.Clear();
        Console.WriteLine("Juego de las tres en raya. Introduce el nombre de los dos jugadores");
        
        TresEnRayaRed juego = new TresEnRayaRed();

        juego.IniciaPartida();

        Console.ReadKey();
    }
}