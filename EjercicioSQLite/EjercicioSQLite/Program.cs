using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


public class Ejemplo_04_06a
{
    struct tipoFicha
    {
        public string nombreFich;
        public long tamanyo;
        public string categoria;
    };

    public static void Main()
    {
        tipoFicha[] fichas = new tipoFicha[1000];
        int numeroFichas = 0;
        int i;//contador
        int opcion;
        string textoBuscar;
        int tamanyoBuscar;

        SQLiteConnection conexionBD = new SQLiteConnection("Data Source = bdficheros.sqlite;Version=3;New=False;Compress=True;");
        conexionBD.Open();

        string leerDatosBD = "select ficheros.nombrefichero, ficheros.numerokb, categorias.nombrecategoria from ficheros, categorias where categorias.idcategoria=ficheros.categoria";

        SQLiteCommand cmd = new SQLiteCommand(leerDatosBD, conexionBD);
        SQLiteDataReader datosBD = cmd.ExecuteReader();

        while (datosBD.Read())
        {
            fichas[numeroFichas].nombreFich = Convert.ToString(datosBD[0]);
            fichas[numeroFichas].tamanyo = Convert.ToInt32(datosBD[1]);
            fichas[numeroFichas].categoria = Convert.ToString(datosBD[2]);
            numeroFichas++;
        }

        do
        {
            Console.WriteLine("\nEscoja una opción:\n");
            Console.WriteLine("1. Añadir datos de un nuevo fichero");
            Console.WriteLine("2. Mostrar los nombres de todos los ficheros");
            Console.WriteLine("3. Mostrar los ficheros por encima de un cierto tamaño");
            Console.WriteLine("4. Ver datos de un fichero");
            Console.WriteLine("5. Modificar datos de un fichero");
            Console.WriteLine("6. Eliminar un fichero");
            Console.WriteLine("7. Contar los ficheros existentes en cada categoría");
            Console.WriteLine("8. Salir");

            opcion = Convert.ToInt32(Console.ReadLine());   

            switch (opcion)
            {
                case 1:
                    if (numeroFichas < 1000)
                    {
                        Console.WriteLine(numeroFichas);
                        Console.WriteLine("Introduce el nombre del fichero:");
                        fichas[numeroFichas].nombreFich = Console.ReadLine();
                        Console.WriteLine("Introduce el tamaño en KB:");
                        fichas[numeroFichas].tamanyo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Introduce la categoría (1. Imagen, 2. vídeo, 3. utilidades)");
                        int categoriaEscogida = Convert.ToInt32(Console.ReadLine());
                        switch(categoriaEscogida)
                        {
                            case 1:
                                fichas[numeroFichas].categoria = "imagen";
                                break;
                            case 2:
                                fichas[numeroFichas].categoria = "videos";
                                break;
                            case 3:
                                fichas[numeroFichas].categoria = "utilidades";
                                break;
                            default:
                                break;
                        }

                        string escribirDatosBD = "insert into ficheros values('" + fichas[numeroFichas].nombreFich + "'," + fichas[numeroFichas].tamanyo + "," + categoriaEscogida + ");";
                        Console.WriteLine(escribirDatosBD);
                        cmd = new SQLiteCommand(escribirDatosBD, conexionBD);
                        int cantidad = cmd.ExecuteNonQuery();
                        if (cantidad < 1)
                            Console.WriteLine("No se ha podido guardar en la BD");
                        
                        numeroFichas++;
                        
                    }
                    else
                        Console.WriteLine("Máximo de 1000 fichas alcanzado");
                    break;
                case 2:                    
                    for (i = 0; i < numeroFichas; i++)
                        Console.WriteLine("Nombre: {0}, tamaño: {1}, categoría: {2}", fichas[i].nombreFich, fichas[i].tamanyo, fichas[i].categoria);
                    break;
                case 3:
                    Console.WriteLine("Introduzca el tamaño a partir del cual quiere ver:");
                    tamanyoBuscar = Convert.ToInt32(Console.ReadLine());
                    for (i = 0; i < numeroFichas; i++)
                        if (fichas[i].tamanyo >= tamanyoBuscar)
                            Console.WriteLine("Nombre: {0}, tamaño: {1}, categoría: {2}", fichas[i].nombreFich, fichas[i].tamanyo, fichas[i].categoria);
                    break;
                case 4:
                    Console.WriteLine("¿De qué fichero quiere ver los datos?");
                    textoBuscar = Console.ReadLine();
                    for (i = 0; i < numeroFichas; i++)
                        if (fichas[i].nombreFich == textoBuscar)
                            Console.WriteLine("Nombre: {0}, tamaño: {1}, categoría: {2}", fichas[i].nombreFich, fichas[i].tamanyo, fichas[i].categoria);
                    break;
                case 5:
                    Console.WriteLine("¿De qué fichero quiere modificar los datos?");
                    textoBuscar = Console.ReadLine();
                    for (i = 0; i < numeroFichas; i++)
                        if (fichas[i].nombreFich == textoBuscar)
                        {
                            Console.WriteLine("Datos actuales:");
                            Console.WriteLine("Nombre: {0}, tamaño: {1}, categoría: {2}", fichas[i].nombreFich, fichas[i].tamanyo, fichas[i].categoria);
                            Console.WriteLine("Introduzca los nuevos datos:");

                            Console.WriteLine("Introduce el nuevo nombre del fichero:");
                            string nuevoNombre = Console.ReadLine();
                            
                            Console.WriteLine("Introduce el nuevo tamaño en KB:");
                            int nuevoTamanyo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Introduce la nueva categoría (1. Imagen, 2. vídeo, 3. utilidades)");
                            int categoriaEscogida = Convert.ToInt32(Console.ReadLine());
                            string nuevaCategoria="";
                            switch (categoriaEscogida)
                            {
                                case 1:
                                    nuevaCategoria = "imagen";
                                    break;
                                case 2:
                                    nuevaCategoria = "videos";
                                    break;
                                case 3:
                                    nuevaCategoria = "utilidades";
                                    break;
                                default:
                                    break;
                            }

                            string modificarDatosBD = "update ficheros set nombrefichero = '" + nuevoNombre
                                + "', numerokb=" + nuevoTamanyo + ", categoria=" + categoriaEscogida + " where " +
                                "nombrefichero='" + fichas[i].nombreFich + "';";
                            Console.WriteLine(modificarDatosBD);

                            cmd = new SQLiteCommand(modificarDatosBD, conexionBD);
                            int cantidad = cmd.ExecuteNonQuery();
                            if (cantidad < 1)
                                Console.WriteLine("No se ha podido guardar en la BD");

                            fichas[i].nombreFich = nuevoNombre;
                            fichas[i].tamanyo = nuevoTamanyo;
                            fichas[i].categoria = nuevaCategoria;
                        }
                    break;
                case 6:                
                    Console.WriteLine("¿Qué fichero quiere eliminar?");
                    textoBuscar = Console.ReadLine();
                    for (i = 0; i < numeroFichas; i++)
                        if (fichas[i].nombreFich == textoBuscar)
                        {
                            Console.WriteLine("Datos actuales:");
                            Console.WriteLine("Nombre: {0}, tamaño: {1}, categoría: {2}", fichas[i].nombreFich, fichas[i].tamanyo, fichas[i].categoria);
                            Console.WriteLine("¿Está seguro de querer eliminarlo?(s/n)");
                            char respuesta = Convert.ToChar(Console.ReadLine());
                            if(respuesta == 's')
                            {
                                string borrarDatosBD = "delete from ficheros where " +
                                "nombrefichero='" + fichas[i].nombreFich + "';";
                                Console.WriteLine(borrarDatosBD);

                                cmd = new SQLiteCommand(borrarDatosBD, conexionBD);
                                int cantidad = cmd.ExecuteNonQuery();
                                if (cantidad < 1)
                                    Console.WriteLine("No se ha podido guardar en la BD");

                                
                                for(int j = i; j < numeroFichas-1; j++)
                                {
                                    fichas[j] = fichas[j+1];
                                }
                                
                                numeroFichas--;
                            }
                        }
                    break;
                case 7:
                    Console.WriteLine("Número de ficheros en cada categoría:");
                    leerDatosBD = "select count(nombrefichero), categorias.nombrecategoria from ficheros, categorias where ficheros.categoria=categorias.idcategoria group by categorias.idcategoria;";
                    cmd = new SQLiteCommand(leerDatosBD, conexionBD);
                    datosBD = cmd.ExecuteReader();

                    while(datosBD.Read())                    
                        Console.WriteLine(datosBD[0].ToString() + " - " + datosBD[1].ToString());
                    
                    break;
                case 8:                    
                    Console.WriteLine("Fin de ejecución");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        } while (opcion != 8);

        conexionBD.Close();
    }
}
