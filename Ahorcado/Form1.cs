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
        private string palabraParcial;//Para almacenar la palabra que se irá mostrando parcialmente
        private List<char> caracteresPalabraParcial;//Para manipular los caracteres individualmente de la palabra parcial
        private List<char> letrasUtilizadas;//Para guardar las letras que el jugador ya ha utilizado y evitar que repita
        
        private int numeroCaracteresAdivinar;//Número de caracteres que tiene/faltan de la palabra a adivinar
        private int numeroFallos;//Número de fallos que acumula el jugador
        private const int numeroMaximoFallos = 7;//Número máximo de fallos que puede acumular el jugador

        private Graphics ventanaGrafica;
        public Ahorcado()
        {
            InitializeComponent();

            /*Estos dos primeros métodos solo se van a utilizar al inicio del proyecto
             * con el fin de crear la base de datos de palabras a partir de un
             * fichero de texto*/
            //CargaPalabrasDelFichero();
            //CreaLaBaseDeDatos();

            //Método desechado finalmente, pues solo se cargará una palabra en cada momento
            //CargaPalabrasDeBaseDatos();           

        }

        //Inicializa todas las variables para comenzar de nuevo el juego de adivinar una palabra
        private void btComenzar_Click(object sender, EventArgs e)
        {
            numeroFallos = 0;
            palabraParcial = "";
            palabraAdivinar = ObtienePalabraAleatoria();
            caracteresPalabraParcial = new List<char>();
            letrasUtilizadas = new List<char>();
            tbLetraJugador.Text = "";
            lbLetrasUtilizadas.Text = "";

            if (palabraAdivinar != "")
            {                
                //Actualiza el número de caracteres que tiene la palabra a adivinar
                numeroCaracteresAdivinar = palabraAdivinar.Length;

                for(int i = 0; i < numeroCaracteresAdivinar; i++)
                {
                    palabraParcial = palabraParcial + "_";
                    caracteresPalabraParcial.Add('_');
                }
                MuestraPalabraParcial();
            }
            else
                MessageBox.Show("No es posible cargar una nueva palabra");

            lbInformacion.Text = "Introduce una letra y pulsa sobre el botón para comprobar si está en la palabra";
            panelJuegoActivo.Visible = true;

            DibujaAhorcado();

            tbLetraJugador.Focus();
        }


        //Actualiza la palabra que se va mostrando parcialmente
        private void MuestraPalabraParcial()
        {
            
            lbPalabra.Text = palabraParcial;
            lbCaracteresRestantes.Text = "Caracteres por adivinar: " + numeroCaracteresAdivinar.ToString("00");
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

            //lbPalabra.Text = "En la base de datos hay: " + numeroPalabras + " palabras";
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

            pbBarra1.Visible = true;

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

            pbBarra1.Visible = false;
            btCrearBD.Enabled = false;
        }

        private void btCrearBD_Click(object sender, EventArgs e)
        {
            CargaPalabrasDelFichero();
            CreaLaBaseDeDatos();         
        }

        private void lbPalabra_Click(object sender, EventArgs e)
        {

        }

        private void Ahorcado_Load(object sender, EventArgs e)
        {
            //Si la BD ya existe, desactiva el botón de crearla
            if (File.Exists("palabras.sqlite"))
            {
                btCrearBD.Visible = false;
                btCrearBD.Enabled = false;

                //Y Obtiene el número de palabras que hay en la BD
                CuentaNumeroPalabras();
            }

            //Inicializa la ventana gráfica para poder dibujar el ahorcado
            ventanaGrafica = this.CreateGraphics();
        }

        private void Ahorcado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Seguro que deseas salir?", "Salir del juego", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No )
            {
                e.Cancel = true;
            }                       
        }

        private void btComprobarLetra_Click(object sender, EventArgs e)
        {
            if(tbLetraJugador.Text != "")
            {
                CompruebaLetraEnPalabra();
            }
        }

        //Comprueba si la letra introducida por el jugador está en la palabra, actualiza las
        //variables de control del juego en función del resultado
        private void CompruebaLetraEnPalabra()
        {
            char letraJugador = Convert.ToChar(tbLetraJugador.Text);

            if (!LetraYaUtilizada(letraJugador))
            {

                //Añade la letra introducida a las que ya han sido utilizadas
                letrasUtilizadas.Add(letraJugador);
                MuestraLetrasUtilizadas();

                int totalLetras = palabraAdivinar.Length;

                bool letraEncontrada = false;

                //Busca si la letra está en la palabra
                for (int i = 0; i < totalLetras; i++)
                {
                    if (palabraAdivinar[i] == letraJugador)
                    {
                        letraEncontrada = true;
                        caracteresPalabraParcial[i] = letraJugador;
                        numeroCaracteresAdivinar--;
                        ActualizaPalabraParcial();
                    }
                }

                tbLetraJugador.Text = "";
                tbLetraJugador.Focus();

                //Si la letra no estaba, se aumenta el número de fallos y comprueba si se ha perdido
                if (!letraEncontrada)
                {
                    numeroFallos++;
                    DibujaAhorcado();
                    CompruebaDerrota();
                }//En caso contrario, se comprueba si se ha vencido
                else
                {
                    CompruebaVictoria();
                }
                
            }
            else
            {
                MessageBox.Show("Ya has usado la letra " + letraJugador +". Utiliza otra",
                    "Letra repetida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbLetraJugador.Text = "";
                tbLetraJugador.Focus();
            }
        }


        //Comprueba si una letra ya ha sido utilizada por el jugador
        private bool LetraYaUtilizada(char letra)
        {
            foreach(char c in letrasUtilizadas)
            {
                if (c == letra)
                    return true;
            }

            return false;
        }

        //Muestra en pantalla las letras que el jugador ha utilizado, ordenadas alfabéticamente
        private void MuestraLetrasUtilizadas()
        {
            string utilizadas = "";
            letrasUtilizadas.Sort();
            lbLetrasUtilizadas.Visible = false;
            foreach (char c in letrasUtilizadas)
            {
                utilizadas += c;
                utilizadas += '-';
            }

            lbLetrasUtilizadas.Text =  utilizadas;
            lbLetrasUtilizadas.Visible = true;
        }
        
        //Actualiza y muestra la palabra parcial
        private void ActualizaPalabraParcial()
        {
            palabraParcial = "";

            for(int i = 0; i < caracteresPalabraParcial.Count; i++)
            {
                palabraParcial += caracteresPalabraParcial[i];
            }

            lbPalabra.Text = palabraParcial;
            lbCaracteresRestantes.Text = "Caracteres por adivinar: " + numeroCaracteresAdivinar.ToString("00");
        }

        //Comprueba si el jugador ha acertado todos las letras y en caso afirmativo le felicita
        //y desactiva el panel del juego hasta que comience una nueva partida
        private void CompruebaVictoria()
        {
            if(numeroCaracteresAdivinar <= 0)
            {
                MessageBox.Show("¡Enhorabuena, has adivinado la palabra!", "¡¡¡Victoria!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelJuegoActivo.Visible = false;
            }
        }

        //Comprueba si el jugador ha consumido todos los intentos, en cuyo caso finaliza la partida con derrota
        private void CompruebaDerrota()
        {
            if(numeroFallos >= numeroMaximoFallos)
            {
                MessageBox.Show("Lo siento, se acabaron los intentos\n" +
                    "La palabra oculta era: " + palabraAdivinar, "¡Has perdido...!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                panelJuegoActivo.Visible = false;
            }
        }

        private void DibujaAhorcado()
        {
            Image imagenAhorcado;

            switch (numeroFallos)
            {
                case 0:
                    imagenAhorcado = new Bitmap("imagen_vacia.png");
                    break;
                case 1:
                    imagenAhorcado = new Bitmap("ahorcado01.png");
                    break;                    
                case 2:
                    imagenAhorcado = new Bitmap("ahorcado02.png");
                    break;
                case 3:
                    imagenAhorcado = new Bitmap("ahorcado03.png");
                    break;
                case 4:
                    imagenAhorcado = new Bitmap("ahorcado04.png");
                    break;
                case 5:
                    imagenAhorcado = new Bitmap("ahorcado05.png");
                    break;
                case 6:
                    imagenAhorcado = new Bitmap("ahorcado06.png");
                    break;
                case 7:
                    imagenAhorcado = new Bitmap("ahorcado07.png");
                    break;
                default:
                    imagenAhorcado = new Bitmap("imagen_vacia.png");
                    break;
            }

            if(imagenAhorcado != null)
                ventanaGrafica.DrawImage(imagenAhorcado, 595, 70, 80, 180);
        }
    }
}
