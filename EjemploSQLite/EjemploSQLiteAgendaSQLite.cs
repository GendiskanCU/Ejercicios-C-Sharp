using System;
using System.IO;
using System.Data.SQLite;

public class AgendaSQLite
{
    static SQLiteConnection conexion;

    public AgendaSQLite()//Constructor
    {
        AbrirBD();
    }

    private void AbrirBD()
    {//Constructor
        if(!File.Exists("agenda.sqlite"))
        {
            //Si no existe, creamos la base de datos
            conexion = new SQLiteConnection("Data Source=agenda.sqlite;Version=3;New=True;Compress=True;");
            conexion.Open();

            //Y creamos la tabla
            string creacion = "create table persona (nombre varchar(30), direccion varchar(40), edad int);";
            SQLiteCommand cmd = new SQLiteCommand(creacion, conexion);
            cmd.ExecuteNonQuery();
        }
        else
        {
            //Si ya existe la abrimos
            conexion = new SQLiteConnection("Data Source=agenda.sqlite,Version=3;New=False;Compress=True;");
            conexion.Open();
        }
    }

    public bool InsertarDatos(string nombre, string direccion, int edad)
    {
        string insercion;//Orden de inserción en SQL
        SQLiteCommand cmd;//Comando de SQLite
        int cantidad;//Resultado: cantidad de datos insertados

        try
        {
            insercion = "insert into persona values('" + nombre + "', '" + direccion + "', " + edad + ");";
            cmd = new SQLiteCommand(insercion, conexion);
            cantidad = cmd.ExecuteNonQuery();
            if (cantidad < 1)
                return false;//Si no se ha podido insertar el registro
        }
        catch (Exception ex)
        {
            return false;//Si no se ha podido insertar
        }
        return true;//Todo ha ido bien
    }

    public string LeerTodosDatos()
    {//Lee todos los datos y los devuelve en un string de varias líneas
        //Lanzamos la consulta y preparamos la estructura para leer datos
        string consulta = "select * from persona";
        string resultado = "";
        SQLiteCommand cmd = new SQLiteCommand(consulta, conexion);
        SQLiteDataReader datos=cmd.ExecuteReader();
        //Leemos los datos de forma repetitiva
        while(datos.Read())
        {
            resultado += Convert.ToString(datos[0]) + " - " + Convert.ToString(datos[1]) + " - " + Convert.ToString(datos[2]) + "\n";
        }
        return resultado;
    }

    ~AgendaSQLite()//Destructor
    {
        conexion.Close();
    }
}