using System;
using System.IO; //Para Stream
using System.Text; //Para Encoding
using System.Net; //Para Dns, IpAdress
using System.Net.Sockets; //Para NetworkStream

//Jugadores
public class Jugador
{
    string nombre;
    char ficha;
    string estado; //receptor o emisor

    public Jugador(string nombreJugador, char fichaJugador)
    {
        nombre = nombreJugador;
        ficha = fichaJugador;
    }

    public void EstableceEstado(string estadoActual)
    {
        estado = estadoActual;
    }

    public void CambiaEstado()
    {
        if (estado == "EMISOR")
            estado = "RECEPTOR";
        else
            estado = "EMISOR";
    }

    public string Estado()
    {
        return estado;
    }

    public string Nombre()
    {
        return nombre;
    }

    public char Ficha()
    {
        return ficha;
    }

    public void EnviarDatos(string direccion, int puerto, int dato1, int dato2)
    {
        TcpClient cliente = new TcpClient(direccion, puerto);
        NetworkStream conexion = cliente.GetStream();
        string datosAEnviar = Convert.ToString(dato1) + ',' + Convert.ToString(dato2);
        byte[] buffer = Encoding.ASCII.GetBytes(datosAEnviar);
        conexion.Write(buffer, 0, buffer.Length);
        conexion.Close();
        cliente.Close();
    }

    public void RecibirDatos(string direccion, int puerto, out int dato1, out int dato2)
    {
        //Trata de encontrar la primera IP que corresponda a la dirección recibida
        IPAddress direccionIP = Dns.GetHostEntry(direccion).AddressList[0];
        //Espera a recibir los datos
        TcpListener listener = new TcpListener(direccionIP, puerto);
        listener.Start();
        TcpClient cliente = listener.AcceptTcpClient();
        NetworkStream conexion = cliente.GetStream();
        StreamReader lectura = new StreamReader(conexion);

        string datosRecibidos = lectura.ReadToEnd();

        cliente.Close();
        listener.Stop();

        string[] datosSeparados = datosRecibidos.Split(',');
        dato1 = Convert.ToInt32(datosSeparados[0]);
        dato2 = Convert.ToInt32(datosSeparados[1]);
    }
}

//==================================================================================
//==================================================================================

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

//==================================================================================
//==================================================================================

public class TresEnRayaRed
{
    //Array que representará el tablero de celdas
    Celda [,] celdas;    
    
    Jugador jugador;
       

    //Para controlar cuándo finaliza la partida
    bool finPartida;

    const int VACIA = 0, FJUG1 = 1, FJUG2 = 2, EMPATE = 4;

    //Constructor genérico
    public TresEnRayaRed()
    {
        //El tablero tendrá un tamaño fijo de 3x3
        celdas = new Celda[3, 3];
        for(int i = 0; i < 3; i++)
            for(int j = 0; j < 3; j++)
                celdas[i, j] = new Celda();

        //Se asigna un nombre y ficha genérico al jugador        
        jugador = new Jugador("Jugador ", 'S');
        

        BorraTablero();
    }

    //Constructor que recibe el Jugador
    public TresEnRayaRed(Jugador jugadorActual)
    {
        //El tablero tendrá un tamaño fijo de 3x3
        celdas = new Celda[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                celdas[i, j] = new Celda();

        //Se asigna el jugador recibido
        jugador = jugadorActual;

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

        Console.WriteLine("JUGADOR: {0} | FICHA: {1}", jugador.Nombre(), jugador.Ficha());

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

        //Si nadie ha vencido, comprueba si quedan casillas vacías
        for(int fila = 0; fila < 3; fila++)
            for(int columna = 0; columna < 3; columna++)
                if(celdas[fila, columna].Estado() == VACIA)
                    return VACIA;

        //Si ha llegado hasta aquí, todas las celdas están ocupadas y nadie ha vencido
        return EMPATE;
    }

    /// <summary>
    /// Coloca la ficha en la casilla elegida por el jugador
    /// </summary>
    /// <param name="jugador">Jugador al que le toca tirar</param>
    /// <param name="fila">Fila de la casilla escogida</param>
    /// <param name="columna">Columna de la casilla escogida</param>
    private void PonFicha(int fila, int columna)
    {
        if(jugador.Nombre() == "Jugador1")
        {
            celdas[fila, columna].EstableceEstado(FJUG1);
        }
        else
        {
            celdas[fila, columna].EstableceEstado(FJUG2);
        }

        Console.SetCursorPosition(celdas[fila, columna].PosicionX(),
            celdas[fila, columna].PosicionY());
        Console.Write(jugador.Ficha());

        //Console.SetCursorPosition(0, 18);
    }


    //TODO: Este método hay que modificarlo con la funcionalidad de juego en red
    private void ControlTiradas()
    {
        string direccion = "localhost";
        int puerto = 2112;

        Console.SetCursorPosition(0, 18);        
        int filaTirada, columnaTirada;

        //Muestra el nombre del jugador al que toca tirar
        Console.WriteLine("Turno para: {0}" + "                                              ",
               jugador.Nombre());


        if (jugador.Estado() == "EMISOR")
        {
            //Pide al jugador las coordenadas de la celda a que quiere tirar
            filaTirada = PideFilaColumna("fila");
            columnaTirada = PideFilaColumna("columna");

            //Comprueba que la celda no esté ya ocupada
            bool casillaOcupada = true;
            while (casillaOcupada)
            {
                if (celdas[filaTirada, columnaTirada].Estado() == VACIA)
                {
                    casillaOcupada = false;
                }
                else
                {
                    Console.SetCursorPosition(0, 19);
                    Console.Write("La celda ({0}, {1}) ya está ocupada", filaTirada, columnaTirada);
                    filaTirada = PideFilaColumna("fila");
                    columnaTirada = PideFilaColumna("columna");
                }
            }
            Console.SetCursorPosition(0, 19);
            Console.Write("                                                   ");

            //Coloca la ficha del jugador en el tablero
            PonFicha(filaTirada, columnaTirada);

            //Envía la tirada al otro jugador
            jugador.EnviarDatos(direccion, puerto, filaTirada, columnaTirada);            
        }
        else
        {
            //Console.WriteLine("Le toca tirar al otro jugador");
            //Console.WriteLine("Esperando su jugada...");
            int fila, columna;
            jugador.RecibirDatos(direccion, puerto, out fila, out columna);
            //Console.WriteLine("Tirada recibida: {0}, {1}. ", fila, columna);
            //Coloca la ficha del jugador en el tablero
            PonFicha(fila, columna);
            
        }

        //Comprueba el estado de victoria (o empate)
        if (CompruebaVictoria() != VACIA)
        {
            Console.SetCursorPosition(0, 22);
            if (CompruebaVictoria() == EMPATE)
            {
                Console.WriteLine("SE HA PRODUCIDO UN EMPATE");
            }
            else
            {
                Console.WriteLine("VICTORIA DEL JUGADOR {0}",
                    (CompruebaVictoria() == FJUG1 ? '1' : '2'));
            }
            finPartida = true;//Finaliza la partida
        }
        else//Si no hay victoria, ni tampoco un empate por estar el tablero lleno
            //Cambia el turno del jugador al que toca tirar
            jugador.CambiaEstado();       
    }


    /// <summary>
    /// Devuelve un número solicitado al usuario entre 0 y 2 para coordenadas del tablero de juego
    /// </summary>
    /// <param name="quePide">palabra que debe aparecer al usuario: fila/columna</param>
    /// <returns></returns>
    private int PideFilaColumna(string quePide)
    {
        bool datoCorrecto = false;
        Console.SetCursorPosition(0, 20);
        Console.WriteLine("Escribe la {0} donde quieres tirar (entre 0 y 2):                          ", quePide);
        Console.SetCursorPosition(0, 21);
        Console.Write("                            ");
        Console.SetCursorPosition(0, 21);
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


}







//============================================================================================
//============================================================================================
public class Juego3Raya
{
    public static void Main()
    {
        Jugador jugadorActual;
        Console.WriteLine("Elige Jugador1 (1) / Jugador2 (2)");
        int eleccion = Convert.ToInt32(Console.ReadLine());

        if (eleccion == 1)
        {
            jugadorActual = new Jugador("Jugador1", 'X');
            jugadorActual.EstableceEstado("EMISOR");
        }
        else
        {
            jugadorActual = new Jugador("Jugador2", 'O');
            jugadorActual.EstableceEstado("RECEPTOR");
        }
        

        TresEnRayaRed juego = new TresEnRayaRed(jugadorActual);

        juego.IniciaPartida();

        Console.WriteLine("Pulsa una tecla para salir");
        Console.ReadKey();
    }
}