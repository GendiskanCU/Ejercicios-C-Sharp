using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

public class EjemploSQLite2
{
    public static void Main()
    {
        //Creamos la conexión a la BD
        //El Data Source contiene la ruta del archivo de la BD

        SQLiteConnection conexion = new SQLiteConnection("Data Source = ejemplo.sqlite;Version=3;New=False;Compress=True;");
        conexion.Open();

        //Lanzamos la consulta y preparamos la estructura para leer datos
        string consulta = "select * from personas";
        SQLiteCommand cmd = new SQLiteCommand(consulta, conexion);
        SQLiteDataReader datos = cmd.ExecuteReader();

        //Leemos los datos de forma repetitiva
        while(datos.Read())
        {
            string nombre = Convert.ToString(datos[0]);
            int edad = Convert.ToInt32(datos[2]);
            //Y los mostramos
            Console.WriteLine("Nombre: {0}, edad: {1}", nombre, edad);
        }

        //Cerramos la conexión
        conexion.Close();
        Console.ReadLine();
    }
}
