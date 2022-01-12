using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

public class EjemploSQLite3
{
    public static void Crear()
    {
        Console.WriteLine("Creando la base de datos...");

        //Creamos la conexión a la BD
        //El Data Source contiene la ruta del archivo de la BD
        SQLiteConnection conexion = new SQLiteConnection("Data Source=ejemplo02.sqlite;Version=3;New=True;Compress=True;");
        conexion.Open();

        //Creamos las tablas
        Console.WriteLine("Creando la tabla de ciudades");
        string creacion = "create table ciudades ( codigo varchar(3), nombre varchar(3), primary key (codigo));";
        SQLiteCommand cmd = new SQLiteCommand(creacion, conexion);
        cmd.ExecuteNonQuery();

        Console.WriteLine("Creando la tabla personas");
        creacion = "create table personas ( nombre varchar(20), direccion varchar(40), edad decimal(3), codciudad varchar(3));";
        cmd = new SQLiteCommand(creacion, conexion);
        cmd.ExecuteNonQuery();

        //E insertamos datos
        Console.WriteLine("Introduciendo ciudades");
        string insercion = "insert into ciudades values ('a', 'alicante');";
        cmd = new SQLiteCommand(insercion, conexion);
        int cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");
        insercion = "insert into ciudades values ('b', 'barcelona');";
        cmd = new SQLiteCommand(insercion, conexion);
        cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");
        insercion = "insert into ciudades values ('m', 'madrid');";
        cmd = new SQLiteCommand(insercion, conexion);
        cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");

        Console.WriteLine("Introduciendo personas");
        insercion = "insert into personas values ('juan', 'casa de juan', 25, 'a');";
        cmd = new SQLiteCommand(insercion, conexion);
        cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");
        insercion = "insert into personas values ('pedro', 'calle de pedro', 45, 'b');";
        cmd = new SQLiteCommand(insercion, conexion);
        cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");
        insercion = "insert into personas values ('maria', 'direccion de maria', 31, 'm');";
        cmd = new SQLiteCommand(insercion, conexion);
        cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");

        conexion.Close();
        Console.WriteLine("BD creada");
    }

    public static void Mostrar()
    {
        //Creamos la conexión a la BD
        SQLiteConnection conexion = new SQLiteConnection("Data Source=ejemplo02.sqlite;Version=3;New=False;Compress=True;");
        conexion.Open();

        string consulta = "select personas.nombre, direccion, ciudades.nombre from personas, ciudades where personas.codciudad = ciudades.codigo;";
        SQLiteCommand cmd = new SQLiteCommand(consulta, conexion);

        SQLiteDataReader datos = cmd.ExecuteReader();

        Console.WriteLine("Datos:");

        while (datos.Read())        
            Console.WriteLine("  {0} - {1} - {2}", Convert.ToString(datos[0]), Convert.ToString(datos[1]), Convert.ToString(datos[2]));

        conexion.Close();
    }

    public static void Main()
    {
        //Crear();
        Mostrar();
        Console.ReadLine();
    }
}
