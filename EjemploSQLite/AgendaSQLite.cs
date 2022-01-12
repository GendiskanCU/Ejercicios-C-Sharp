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
            conexion = new SQLiteConnection("Data Source=agenda.sqlite;Version=3;New=False;Compress=True;");
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
        catch 
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
            resultado += Convert.ToString(datos[0]) + "-" + Convert.ToString(datos[1]) + "-" + Convert.ToString(datos[2]) + "\n";
        }
        return resultado;
    }

    public string LeerBusqueda(string texto)
    {//Hace una búsqueda por nombre o dirección
        //Lanzamos la consulta y preparamos la estructura para leer datos
        string consulta = "select * from persona where nombre like '%" + texto + "%' or direccion like '%" + texto + "%';";
        string resultado = "";
        SQLiteCommand cmd = new SQLiteCommand(consulta, conexion);
        SQLiteDataReader datos = cmd.ExecuteReader();
        //Leemos los datos de forma repetitiva
        while(datos.Read())
        {
            resultado += Convert.ToString(datos[0]) + " - " + Convert.ToString(datos[1]) + " - " + Convert.ToString(datos[2]) + "\n";
        }
        return resultado;
    }

    public void BorrarRegistro(string n)
    {
        string elimina = "delete from persona where nombre ='" + n + "';";
        try
        {
            SQLiteCommand cmd = new SQLiteCommand(elimina, conexion);
            int filas = cmd.ExecuteNonQuery();
            if (filas < 1)
                Console.WriteLine("La persona no se ha encontrado o no se ha podido eliminar");
            else
                Console.WriteLine("Persona eliminada");
        }
        catch (Exception ex)
        {
            Console.WriteLine("No se ha podido ejecutar: " + ex.Message);
        }
    }

    public void ModificarRegistro(string nombrePersona, string nuevaDireccion, int nuevaEdad)
    {
        string modifica = "update persona set direccion='" + nuevaDireccion + "', edad="
            + nuevaEdad + " where nombre='" + nombrePersona + "';";
        try
        {
            SQLiteCommand cmd = new SQLiteCommand(modifica, conexion);
            int filas = cmd.ExecuteNonQuery();
            if (filas < 1)
                Console.WriteLine("No se ha encontrado el registro o no se ha podido modificar");
            else
                Console.WriteLine("Datos de {0} modificados", nombrePersona);
        }
        catch(Exception ex)
        {
            Console.WriteLine("No se ha podido ejecutar: " + ex.Message);
        }

    }

    public bool ExportarAFichero(string nombreFichero)
    {        
        try
        {
            StreamWriter fichero = new StreamWriter(nombreFichero);
            fichero.WriteLine(LeerTodosDatos());
            fichero.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error en la creación del fichero: {0}", e.Message);
            return false;
        }        

        return true;
    }

    public bool ImportaDeFichero(string nombreFichero)
    {
        if (File.Exists(nombreFichero))
        {
            try
            {
                StreamReader fichero = new StreamReader(nombreFichero);
                
                
                string registroLeido;
                string[] camposRegistroLeido;
                string insercionRegistro;
                int filaInsertada;

                do
                {
                    registroLeido = fichero.ReadLine();
                    if(registroLeido!="")
                    {
                        try
                        {
                            camposRegistroLeido = registroLeido.Split('-');
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return false;
                        }
                        Console.Write("Importando... {0}...", registroLeido);                        

                        insercionRegistro = "insert into persona values ('" + Convert.ToString(camposRegistroLeido[0]) +
                            "', '" + Convert.ToString(camposRegistroLeido[1]) + "', "
                            + Convert.ToInt32(camposRegistroLeido[2]) + ");";

                        SQLiteCommand cmd = new SQLiteCommand(insercionRegistro, conexion);
                        filaInsertada = cmd.ExecuteNonQuery();
                        if (filaInsertada < 1)
                            return false;
                        Console.WriteLine("Ok");
                    }


                } while (registroLeido != "");

                fichero.Close();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error en la apertura del fichero: " + e.Message);
                return false;
            }
        }
        else
        {
            Console.WriteLine("Fichero no encontrado");
            return false;
        }
    }

    ~AgendaSQLite()//Destructor
    {
        conexion.Close();
    }
}