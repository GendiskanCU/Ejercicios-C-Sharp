using System;

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

    //Para controlar a qué jugador le toca tirar
    bool turnoJugador2;

    //Para controlar cuándo finaliza la partida
    bool finPartida;

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
        jugador2.nombre = (Jugador1 == Jugador2) ? Jugador1 + "(bis)" : Jugador2;

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

        while(!finPartida)
        {
            ControlTiradas();
        }

        /*PonFicha(jugador1, 0, 2);
        PonFicha(jugador1, 1, 1);
        PonFicha(jugador1, 2, 0);

        Console.Write(CompruebaVictoria());*/
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

        AsignaPosicionFichas();
       
        Console.SetCursorPosition(0, 18);
    }


    /// <summary>
    /// Recorre las celdas asignando la posición en la consola donde irá la ficha
    /// </summary>
    private void AsignaPosicionFichas()
    {
        
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
    }


    /// <summary>
    /// Comprueba si hay tres fichas de un mismo jugador en línea
    /// </summary>
    /// <returns>VACÍA(0) si ningún jugador tiene tres fichas en línea. FJUG1(1) ó FJUG2(2) en caso contrario</returns>
    private int CompruebaVictoria()
    {
        //Recorre el tablero por filas
        for(int fila = 0; fila < 3; fila++)
        {
            if(celdas[fila, 0].Estado() != VACIA
                && celdas[fila, 0].Estado() == celdas[fila, 1].Estado() 
                && celdas[fila, 0].Estado() == celdas[fila, 2].Estado())
                return celdas[fila, 0].Estado();
        }

        //Recorre el tablero por columnas
        for(int columna = 0; columna < 3;columna++)
        {
            if (celdas[0, columna].Estado() != VACIA
                && celdas[0, columna].Estado() == celdas[1, columna].Estado()
                && celdas[0, columna].Estado() == celdas[2, columna].Estado())
                return celdas[0, columna].Estado();
        }

        //Comprueba las dos diagonales
        if (celdas[1, 1].Estado() != VACIA
            && ( (celdas[1, 1].Estado() == celdas[0, 0].Estado()
            && celdas[1, 1].Estado() == celdas[2, 2].Estado()) 
            ||  (celdas[1, 1].Estado() == celdas[0, 2].Estado()
            && celdas[1, 1].Estado() == celdas[2, 0].Estado()) ) )
            return celdas[1, 1].Estado();


        return VACIA;
    }

    /// <summary>
    /// Coloca la ficha en la casilla elegida por el jugador
    /// </summary>
    /// <param name="jugador">Jugador al que le toca tirar</param>
    /// <param name="fila">Fila de la casilla escogida</param>
    /// <param name="columna">Columna de la casilla escogida</param>
    private void PonFicha(Jugador jugador, int fila, int columna)
    {
        if(jugador.nombre == jugador1.nombre)
        {
            celdas[fila, columna].EstableceEstado(FJUG1);
        }
        else
        {
            celdas[fila, columna].EstableceEstado(FJUG2);
        }

        Console.SetCursorPosition(celdas[fila, columna].PosicionX(),
            celdas[fila, columna].PosicionY());
        Console.Write(jugador.ficha);

        //Console.SetCursorPosition(0, 18);
    }

    /// <summary>
    /// Cambia el jugador al que le toca tirar modificando la variable booleana turnoJugador2
    /// </summary>
    private void CambiaTurno()
    {
        turnoJugador2 = !turnoJugador2;
    }


    private void ControlTiradas()
    {
        Console.SetCursorPosition(0, 18);        
        int filaTirada, columnaTirada;

        if(!turnoJugador2)
        {
            Console.WriteLine("Turno para el jugador: {0}" + "                                              ",
                jugador1.nombre);            
        }
        filaTirada = PideFilaColumna("fila");
        columnaTirada = PideFilaColumna("columna");
        //TODO: Controlar que la casilla elegida no está ya ocupada
        //TODO: Terminar este método. Recordar cambiar la booleana finPartida
    }

    private int PideFilaColumna(string quePide)
    {
        bool datoCorrecto = false;
        Console.SetCursorPosition(0, 20);
        Console.WriteLine("Escribe la {0} donde quieres tirar (entre 0 y 2):                          ", quePide);
        int introducida = Convert.ToInt32(Console.ReadLine());
        while (!datoCorrecto)
        {
            if (introducida >= 0 && introducida <= 2)
                datoCorrecto = true;
            else
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Error. Escribe nuevamente la {0} donde quieres tirar (entre 0 y 2):", quePide);
                introducida = Convert.ToInt32(Console.ReadLine());
            }
        }

        return introducida;


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