//Ejemplo de la clase Environment, datos sobre el entorno
using System;
using System.Diagnostics;

public class EjemploEnvironment
{
    public static void Main()
    {
        //Capturamos el/los carácter/caracteres de avance de línea
        string avanceLinea = Environment.NewLine;

        Console.WriteLine("Directorio actual:\n{0}",
            Environment.CurrentDirectory);

        Console.WriteLine("Nombre del PC:\n{0}",
            Environment.MachineName);

        Console.WriteLine("Nombre de usuario:\n{0}",
            Environment.UserName);

        Console.WriteLine("Dominio:\n{0}",
            Environment.UserDomainName);

        Console.WriteLine("Código de salida del programa anterior:\n{0}",
            Environment.ExitCode);

        Console.WriteLine("Línea de comandos:\n{0}",
            Environment.CommandLine);

        Console.WriteLine("Versión del S.O.:\n{0}",
            Environment.OSVersion);

        Console.WriteLine("Versión de .Net:\n{0}",
            Environment.Version);

        string [] unidadesDisco = Environment.GetLogicalDrives();

        Console.WriteLine("Unidades lógicas:\n{0}",
            String.Join(", ", unidadesDisco));

        Console.WriteLine("Carpeta de documentos:\n{0}",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        Console.WriteLine("Carpeta de sistema:\n{0}",
            Environment.GetFolderPath(Environment.SpecialFolder.System));


        Console.ReadKey();
    }
}