using System;
using System.IO; // Para comprobar si el fichero existe
using System.Data.SQLite; // Para acceder a SQLite


public class pruebaSQLite01
{
   static SQLiteConnection conexion;
    
    private static void CrearBBDDSiNoExiste()
    {
        if (!File.Exists("personal.sqlite") )
        {
            // Creamos la conexion a la BD. 
            // El Data Source contiene la ruta del archivo de la BD 
            conexion =
                  new SQLiteConnection
                  ("Data Source=personal.sqlite;Version=3;New=True;Compress=True;");
            conexion.Open();      
            
            // Creamos la primera tabla
            string creacion = "CREATE TABLE ciudad "
              +"(codigo VARCHAR(2) PRIMARY KEY, nombre VARCHAR(30));";
            SQLiteCommand cmd = new SQLiteCommand(creacion, conexion);
            cmd.ExecuteNonQuery();            
            
            // Creamos la segunda tabla
            creacion = "CREATE TABLE persona "
              +"(codigo VARCHAR(2) PRIMARY KEY, nombre VARCHAR(30),"
              +" codigoCiudad VARCHAR(2) );";
            cmd = new SQLiteCommand(creacion, conexion);
            cmd.ExecuteNonQuery();            
        }
        else
        {
            // Creamos la conexion a la BD. 
            // El Data Source contiene la ruta del archivo de la BD 
            conexion =
                  new SQLiteConnection
                  ("Data Source=personal.sqlite;Version=3;New=False;Compress=True;");
            conexion.Open();
        }
    }
    
    
    private static void InsertarDatos()
    {
        
        string insercion;  // Orden de insercion, en SQL
        SQLiteCommand cmd; // Comando de SQLite
        int cantidad;      // Resultado: cantidad de datos
        
        try 
        {
          insercion = "INSERT INTO ciudad "+
            "VALUES  ('t','Toledo');";
          cmd = new SQLiteCommand(insercion, conexion);
          cantidad = cmd.ExecuteNonQuery();
          if (cantidad < 1)
              Console.WriteLine("No se ha podido insertar");
              
          insercion = "INSERT INTO ciudad "+
            "VALUES  ('a','Alicante');";
          cmd = new SQLiteCommand(insercion, conexion);
          cantidad = cmd.ExecuteNonQuery();
          if (cantidad < 1)
              Console.WriteLine("No se ha podido insertar");
              
         insercion = "INSERT INTO persona "+
            "VALUES  ('j','Juan','t');";
          cmd = new SQLiteCommand(insercion, conexion);
          cantidad = cmd.ExecuteNonQuery();
          if (cantidad < 1)
              Console.WriteLine("No se ha podido insertar");
              
          insercion = "INSERT INTO persona "+
            "VALUES  ('p','Pepe','t');";
          cmd = new SQLiteCommand(insercion, conexion);
          cantidad = cmd.ExecuteNonQuery();
          if (cantidad < 1)
              Console.WriteLine("No se ha podido insertar");
        }
        catch (Exception e)
        {
            Console.WriteLine("No se ha podido insertar");
            Console.WriteLine("Posiblemente un código está repetido");
            Console.WriteLine("Error encontrado: {0} ", e.Message);
        }
    }
    
    private static void MostrarCiudades()
    {
        // Lanzamos la consulta y preparamos la estructura para leer datos
        string consulta = "select * from ciudad";
        SQLiteCommand cmd = new SQLiteCommand(consulta, conexion);
        SQLiteDataReader datos = cmd.ExecuteReader();
        // Leemos los datos de forma repetitiva
        while (datos.Read())
        {
            string codigo = Convert.ToString(datos[0]);
            string nombre = Convert.ToString(datos[1]);
            // Y los mostramos
            Console.WriteLine("Codigo: {0}, Nombre: {1}",
                codigo, nombre);
        }
    }
    
    
    private static void MostrarPersonas()
    {
        // Lanzamos la consulta y preparamos la estructura para leer datos
        string consulta = "select * from persona";
        SQLiteCommand cmd = new SQLiteCommand(consulta, conexion);
        SQLiteDataReader datos = cmd.ExecuteReader();
        // Leemos los datos de forma repetitiva
        while (datos.Read())
        {
            string codigo = Convert.ToString(datos[0]);
            string nombre = Convert.ToString(datos[1]);
            // Y los mostramos
            Console.WriteLine("Codigo: {0}, Nombre: {1}",
                codigo, nombre);
        }
    }
    
    private static void MostrarCiudadesYPersonas()
    {
        // Lanzamos la consulta y preparamos la estructura para leer datos
        string consulta = 
            "select persona.nombre, ciudad.nombre "+
            "from persona, ciudad "+
            "where persona.codigoCiudad = ciudad.Codigo";
        SQLiteCommand cmd = new SQLiteCommand(consulta, conexion);
        SQLiteDataReader datos = cmd.ExecuteReader();
        // Leemos los datos de forma repetitiva
        while (datos.Read())
        {
            string nombrePersona = Convert.ToString(datos[0]);
            string nombreCiudad = Convert.ToString(datos[1]);
            // Y los mostramos
            Console.WriteLine("{0} vive en {1}",
                nombrePersona, nombreCiudad);
        }
    }
    
    private static void CerrarBBDD()
    {
        conexion.Close();
    }
    
    
    public static void Main()
    {
        Console.WriteLine("Accediendo...");
        CrearBBDDSiNoExiste();
        Console.WriteLine("Añadiendo datos...");
        InsertarDatos();
        Console.WriteLine("Datos de ciudades:");
        MostrarCiudades();
        Console.WriteLine("Datos de personas:");
        MostrarPersonas();
        Console.WriteLine("Datos de personas y ciudades:");
        MostrarCiudadesYPersonas();
        CerrarBBDD();
    }

}