using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

public class EjemploSQLite
{
    public static void Main()
    {
        Console.WriteLine("Creando la base de datos...");

        //Creamos la conexión a la BD
        //El Data Source contiene la ruta del archivo de la BD
        SQLiteConnection conexion = new SQLiteConnection("Data Source=ejemplo.sqlite;Version=3;New=True;Compress=True;");
        conexion.Open();

        //Creamos una tabla
        string comandoCreacion = "create table personas (nombre varchar(20),direccion varchar(20),edad int);";
        SQLiteCommand cmd = new SQLiteCommand(comandoCreacion, conexion);
        cmd.ExecuteNonQuery();

        //Insertamos dos datos en la tabla
        string comandoInsercion = "insert into personas values ('miguel', 'casa miguel', 20);";
        cmd = new SQLiteCommand(comandoInsercion, conexion);

        int cantidad = cmd.ExecuteNonQuery();

        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar un registro");

        comandoInsercion = "insert into personas (nombre, direccion, edad) values ('maria', 'casa maria', 21);";
        cmd = new SQLiteCommand(comandoInsercion, conexion);

        cantidad = cmd.ExecuteNonQuery();

        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar un registro");

        //Cerramos la conexión a la BD
        conexion.Close();

        Console.WriteLine("BD creada. Pulse Intro para salir");
        Console.ReadLine();

    }
}

