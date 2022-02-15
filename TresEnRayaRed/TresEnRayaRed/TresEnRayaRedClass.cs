using System;

//Jugadores
public struct Jugador
{
    public string nombre;
    public char ficha;
}
public class TresEnRayaRed
{
    //El tablero de juego de las tres en raya
    //Cada celda puede tener tres estados: vacía, con ficha del jugador1, con ficha del jugador2
    enum EstadoCelda
    {
        VACIA,
        JUG_1,
        JUG_2
    }
    //Array que representará el tablero de celdas
    EstadoCelda [,] celdas;    
    
    Jugador jugador1, jugador2;
   


    //Constructor genérico
    public TresEnRayaRed()
    {
        //El tablero tendrá un tamaño fijo de 3x3
        celdas = new EstadoCelda[3, 3];

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
        celdas = new EstadoCelda[3, 3];

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
                celdas[i, j] = EstadoCelda.VACIA;
        }
    }

    /// <summary>
    /// Dibuja el tablero de juego en pantalla al inicio de cada partida
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