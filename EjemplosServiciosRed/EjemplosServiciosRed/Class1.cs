using System;
using System.IO;//Para Stream
using System.Text;//Para Encoding
using System.Net;//Para DNS, IPAdress
using System.Net.Sockets;//Para NetworkStream

public class EjemploComunicacionRed
{
    static string direccionPrueba = "localhost";
    static int puertoPrueba = 2112;

    private static void Enviar(string direccion, int puerto, string frase)
    {
        TcpClient cliente = new TcpClient(direccion, puerto);

        NetworkStream conexion = cliente.GetStream();

        byte[] secuenciaLetras = Encoding.ASCII.GetBytes(frase);
        
        conexion.Write(secuenciaLetras, 0, secuenciaLetras.Length);

        conexion.Close();
        cliente.Close();
    }

    private static string Esperar(string direccion, int puerto)
    {
        //Hallamos la primera IP que corresponde a la dirección "localhost" recibida
        IPAddress direccionIP = Dns.GetHostEntry(direccion).AddressList[0];
        //Comienza la espera de información
        TcpListener listener = new TcpListener(direccionIP, puerto);
        listener.Start();
        TcpClient cliente = listener.AcceptTcpClient();
        NetworkStream conexion = cliente.GetStream();
        StreamReader lector = new StreamReader(conexion);

        string frase = lector.ReadToEnd();

        cliente.Close();
        listener.Stop();

        return frase;
    }

    public static void Main()
    {
        Console.WriteLine("Pulsa 1 para recibir, 2 para enviar");
        string respuesta = Console.ReadLine();

        if(respuesta == "1")
        {
            Console.WriteLine("Esperando...");
            Console.WriteLine(Esperar(direccionPrueba, puertoPrueba));
            Console.WriteLine("Recibido");
        }
        else
        {
            Console.WriteLine("Enviando");
            Enviar(direccionPrueba, puertoPrueba, "Probando envío de mensaje de texto");
            Console.WriteLine("Enviado");
        }

        Console.WriteLine("Pulsa una tecla para salir");
        Console.ReadLine();
    }
}