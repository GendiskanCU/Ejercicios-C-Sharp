/*(12.3.3) Crea un programa que permita "pasear" por la carpeta actual, al estilo del 
antiguo "Comandante Norton": mostrará la lista de ficheros y subdirectorios de la 
carpeta actual, y permitirá al usuario moverse hacia arriba o abajo dentro de la 
lista usando las flechas del cursor. El elemento seleccionado se mostrará en color 
distinto del resto.*/

using System;
using System.IO;
using System.Collections.Generic;

public class InfoFichero
{
    string nombreFichero;
    string longitudFichero;
    string fechaFichero;
    int posX, posY;


    public InfoFichero()
    {
        nombreFichero = "";
        longitudFichero = "";
        fechaFichero = "";
        posX = posY = 0;
    }

    public InfoFichero(string nombre, string longitud, string fecha, int x, int y)
    {
        if(nombre.Length < 20)
        {            
            for (int i = nombre.Length; i < 20; i++)
                nombre = nombre + " ";
        }
        else if(nombre.Length > 20)
        {
            nombre = nombre.Substring(0, 20);
        }

        if (longitud.Length < 15)
        {
            for (int i = longitud.Length; i < 15; i++)
                longitud = longitud + " ";
        }
        else if (longitud.Length > 20)
        {
            longitud = longitud.Substring(0, 20);
        }



        nombreFichero = nombre;
        longitudFichero= longitud;
        fechaFichero = fecha;
        posX = x;
        posY = y;        
    }

    public int GetPosX()
    {
        return posX;
    }

    public int GetPosY()
    {
        return posY;
    }

    public string GetNombre()
    {
        return nombreFichero;
    }

    public string GetFecha()
    {
        return fechaFichero;
    }

    public string GetLongitud()
    {
        return longitudFichero;
    }
}



public class ManejaDirectorio
{
    List<InfoFichero> listaFicheros;

    string directorioActual;

    private int posicionX, posicionY;

    public ManejaDirectorio(string directorio)
    {
        listaFicheros = new List<InfoFichero>();
        directorioActual = directorio;
    }

    public void MuestraDirectorio()
    {
        DirectoryInfo directorio = new DirectoryInfo(directorioActual);
        FileInfo[] ficherosEncontrados = directorio.GetFiles();
        DirectoryInfo[] directoriosEncontrados = directorio.GetDirectories();

        InfoFichero infoFichero;

        posicionX = posicionY = 0;

        foreach (DirectoryInfo dir in directoriosEncontrados)
        {
            infoFichero = new InfoFichero(dir.Name, "[DIR]",
                Convert.ToString(dir.CreationTime), posicionX, posicionY);
            listaFicheros.Add(infoFichero);
            posicionY++;
        }

        foreach (FileInfo fi in ficherosEncontrados)
        {
            infoFichero = new InfoFichero(fi.Name, Convert.ToString(fi.Length),
                Convert.ToString(fi.CreationTime), posicionX, posicionY);
            listaFicheros.Add(infoFichero);
            posicionY++;
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        foreach (InfoFichero fichero in listaFicheros)
        {
            Console.SetCursorPosition(fichero.GetPosX(), fichero.GetPosY());
            Console.Write(fichero.GetNombre() + "  " + fichero.GetLongitud()
                + "  " + fichero.GetFecha());
        }


        posicionY = 0;
        ActivaRegistro(posicionX, posicionY);

        MuevePorDirectorio();
    }

    private void MuevePorDirectorio()
    {
        bool finalizar = false;

        do
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Escape) finalizar = true;
                if(key.Key == ConsoleKey.UpArrow)
                {
                    if(posicionY > 0)
                    {
                        DesactivaRegistro(posicionX, posicionY);
                        posicionY--;
                        ActivaRegistro(posicionX, posicionY);
                    }
                }
                if(key.Key == ConsoleKey.DownArrow)
                {
                    if(posicionY < listaFicheros.Count - 1)
                    {
                        DesactivaRegistro(posicionX, posicionY);
                        posicionY++;
                        ActivaRegistro(posicionX, posicionY);
                    }
                }
            }

        } while (!finalizar);

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
    }

    private int IndiceFichero(int posY)
    {
        for (int i = 0; i < listaFicheros.Count; i++)
        {
            if (listaFicheros[i].GetPosY() == posY)
            {
                return i;
            }
        }

        return -1;
    }

    private void ActivaRegistro(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.BackgroundColor = ConsoleColor.Green;
        int indiceActual = IndiceFichero(y);
        Console.Write(listaFicheros[indiceActual].GetNombre() + "  " + listaFicheros[indiceActual].GetLongitud()
                + "  " + listaFicheros[indiceActual].GetFecha());
    }

    private void DesactivaRegistro(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.BackgroundColor = ConsoleColor.Black;
        int indiceActual = IndiceFichero(y);
        Console.Write(listaFicheros[indiceActual].GetNombre() + "  " + listaFicheros[indiceActual].GetLongitud()
                + "  " + listaFicheros[indiceActual].GetFecha());
    }

}



public class EjercicioFicheros
{

    public static void Main(string [] args)
    {
        string directorioActual;
        if (args.Length == 0)
            directorioActual = @"c:\";
        else
            directorioActual = args[0];

        ManejaDirectorio manejaDirectorio = new ManejaDirectorio(directorioActual);

        manejaDirectorio.MuestraDirectorio();


        //Console.ReadKey();

    }    
}