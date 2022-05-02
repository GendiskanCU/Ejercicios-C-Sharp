using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Ahorcado
{
    public partial class Ahorcado : Form
    {
        
        private List<string> listaPalabras;

        private StreamReader ficheroListaPalabras;

        private int numeroPalabras;//Número de palabras en la base de datos
        private string palabraAdivinar;//Para almacenar la palabra que el jugador debe adivinar

        public Ahorcado()
        {
            InitializeComponent();

            /*Estos dos primeros métodos solo se van a utilizar al inicio del proyecto
             * con el fin de crear la base de datos de palabras a partir de un
             * fichero de texto*/
            //CargaPalabrasDelFichero();
            //CreaLaBaseDeDatos();          


            //CargaPalabrasDeBaseDatos();
        }

        private void btComenzar_Click(object sender, EventArgs e)
        {
            //Obtiene el número de palabras que hay en la BD
            CuentaNumeroPalabras();

            palabraAdivinar = ObtienePalabraAleatoria();
            if (palabraAdivinar != "")
                MessageBox.Show("La palabra a adivinar es: " + palabraAdivinar);
            else
                MessageBox.Show("No es posible cargar ninguna nueva palabra");
        }


        //Obtiene el número de registros en la base de datos y lo almacena en la variable global
        private void CuentaNumeroPalabras()
        {
            //Crea la conexión a la Base de Datos
            //El DataSource contiene la ruta del archivo
            SQLiteConnection conexionBD = new SQLiteConnection("Data Source=palabras.sqlite;Version=3;New=False;Compress=True;");

            //Abre la conexión con la base de datos
            conexionBD.Open();

            //Lanza la consulta y prepara la estructura para leer datos
            string consultaBD = "select count (*) from listapalabras";
            SQLiteCommand comando = new SQLiteCommand(consultaBD, conexionBD);
            //ExecuteScala devuelve solo el primer (y en este caso único) dato obtenido
            numeroPalabras = Convert.ToInt32(comando.ExecuteScalar());            

            //Cierra la conexión con la base de datos
            conexionBD.Close();

            lbPalabra.Text = "En la base de datos hay: " + numeroPalabras + " palabras";
        }

        /// <summary>
        /// Ejecuta una consulta en la base de datos para obtener un registro aleatorio entre los existentes
        /// </summary>
        /// <returns>El valor del campo que contiene la palabra en el registro obtenido aleatoriamente</returns>
        private string ObtienePalabraAleatoria()
        {
            //Calcula el número de registro aleatorio
            Random aleatorio = new Random();
            int registro = aleatorio.Next(1, numeroPalabras);            

            // Crea la conexión a la Base de Datos
             //El DataSource contiene la ruta del archivo
             SQLiteConnection conexionBD = new SQLiteConnection("Data Source=palabras.sqlite;Version=3;New=False;Compress=True;");

            //Abre la conexión con la base de datos
            conexionBD.Open();

            //Lanza la consulta y prepara la estructura para leer datos
            string consultaBD = "select * from listapalabras where id_palabra = " + registro.ToString();
            SQLiteCommand comando = new SQLiteCommand(consultaBD, conexionBD);
            SQLiteDataReader palabrasLeidas = comando.ExecuteReader();

            string nuevaPalabra = "";

            while (palabrasLeidas.Read())
            {
                nuevaPalabra = palabrasLeidas[1].ToString();
            }

            //Cierra la conexión con la base de datos
            conexionBD.Close();

            return nuevaPalabra;
        }

        //Carga el fichero de palabras y las almacena en la lista
        private void CargaPalabrasDelFichero()
        {
            try
            {
                if (File.Exists("ListaPalabras.txt"))
                {
                    ficheroListaPalabras = File.OpenText("ListaPalabras.txt");

                    listaPalabras = new List<string>();

                    string linea = ficheroListaPalabras.ReadLine();                    

                    while (linea != null)
                    {
                        listaPalabras.Add(linea);

                        linea = ficheroListaPalabras.ReadLine();
                    }

                    ficheroListaPalabras.Close();

                    lbPalabra.Text = "Número de palabras cargadas: " + listaPalabras.Count;                    
                }
                else
                {
                    lbPalabra.Text = "Error al abrir el fichero. No se ha encontrado";
                }
            }
            catch (Exception error)
            {
                lbPalabra.Text = "Error al abrir el fichero: " + error.Message;
            }
        }

        private void CargaPalabrasDeBaseDatos()
        {
            //Crea la conexión a la Base de Datos
            //El DataSource contiene la ruta del archivo
            SQLiteConnection conexionBD = new SQLiteConnection("Data Source=palabras.sqlite;Version=3;New=False;Compress=True;");

            //Abre la conexión con la base de datos
            conexionBD.Open();

            //Lanza la consulta y prepara la estructura para leer datos
            string consultaBD = "select * from listapalabras";
            SQLiteCommand comando = new SQLiteCommand(consultaBD, conexionBD);
            SQLiteDataReader palabrasLeidas = comando.ExecuteReader();            

            //Lee las palabras y las carga en la lista
            listaPalabras = new List<string>();            
            while(palabrasLeidas.Read())
            {
                listaPalabras.Add(Convert.ToString(palabrasLeidas[1]));
            }

            //Cierra la conexión con la base de datos
            conexionBD.Close();

            lbPalabra.Text = "Número de palabras en la base de datos: " + listaPalabras.Count;            
        }


        //Crea la base de datos de palabras e inserta en ella el contenido de la lista de palabras
        private void CreaLaBaseDeDatos()
        {
            //Crea la conexión a la BD. El Data Source tiene la ruta del archivo
            SQLiteConnection conexion;
            conexion = new SQLiteConnection("Data Source=palabras.sqlite;Version=3;New=True;Compress=True;");
            conexion.Open();

            //Crea la tabla listapalabras
            string comandoCreacion = "create table listapalabras ("
                + " id_palabra int, palabra varchar(25), usada int);";
            SQLiteCommand comando = new SQLiteCommand(comandoCreacion, conexion);
            comando.ExecuteNonQuery();

            //Establece el valor máximo de la barra de progreso
            int numeroRegistros = listaPalabras.Count;
            pbBarra1.Maximum = numeroRegistros;

            //Inserta las palabras de la lista en la base de datos y va mostrando el progreso
            int numeroPalabra = 1;            

            foreach(string pal in listaPalabras)
            {
                string insercion = "insert into listapalabras values ("
                    + numeroPalabra.ToString() + ", '" + pal
                    + "', 0)";
                comando = new SQLiteCommand(insercion, conexion);
                comando.ExecuteNonQuery();

                pbBarra1.Value = numeroPalabra;
                numeroPalabra++;
            }

            //Cierra la conexión a la base de datos
            conexion.Close();

            //Limpia la lista de palabras para liberar memoria
            listaPalabras.Clear();
        }

        private void btCrearBD_Click(object sender, EventArgs e)
        {
            CargaPalabrasDelFichero();
            CreaLaBaseDeDatos();         
        }
    }
}
