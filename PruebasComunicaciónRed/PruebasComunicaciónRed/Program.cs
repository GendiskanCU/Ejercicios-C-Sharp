using System;
using System.IO; //Para Stream
using System.Text; //Para Encoding
using System.Net; //Para Dns, IpAdress
using System.Net.Sockets; //Para NetworkStream

public class Jugador
{    
    string nombre;
    char ficha;
    string estado; //0 receptor, 1 emisor

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

        string [] datosSeparados = datosRecibidos.Split(',');
        dato1 = Convert.ToInt32(datosSeparados[0]);
        dato2 = Convert.ToInt32(datosSeparados[1]);
    }
}

public static class JuegaEnRed
{    public static void Juega(Jugador jugador)
    {
        string direccion = "localhost";
        int puerto = 2112;

        bool finPartida = false;

        while (!finPartida)
        {

            if (jugador.Estado() == "EMISOR")
            {
                Console.Clear();
                Console.WriteLine("Te toca tirar");
                Console.Write("Escribe el primer dato: ");
                int primerDato = Convert.ToInt32(Console.ReadLine());
                Console.Write("Escribe el segundo dato: ");
                int segundoDato = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enviando tu tirada: {0}, {1}", primerDato, segundoDato);
                jugador.EnviarDatos(direccion, puerto, primerDato, segundoDato);
                Console.WriteLine("Jugada enviada. ");
                jugador.CambiaEstado();
                //Console.Write("Pulsa una tecla para continuar...");
                //Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Le toca tirar al otro jugador");
                Console.WriteLine("Esperando su jugada...");
                int fila, columna;
                jugador.RecibirDatos(direccion, puerto, out fila, out columna);
                Console.WriteLine("Tirada recibida: {0}, {1}. ", fila, columna);
                jugador.CambiaEstado();
                Console.Write("Pulsa una tecla para continuar...");
                Console.ReadKey();
            }

            
        }
    }
}

public class Juego
{
    public static void Main()
    {
        Jugador jugadorActual;
        Console.WriteLine("Elige Jugador1 (1) / Jugador2 (2)");
        int eleccion = Convert.ToInt32(Console.ReadLine());

        if(eleccion == 1)
        {
            jugadorActual = new Jugador("Jugador1", 'X');
            jugadorActual.EstableceEstado("EMISOR");
        }
        else
        {
            jugadorActual = new Jugador("Jugador2", 'O');
            jugadorActual.EstableceEstado("RECEPTOR");
        }

        JuegaEnRed.Juega(jugadorActual);
    }
}