using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PruebaMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declara las texturas a utilizar
        private Texture2D serpiente;
        private Texture2D pared;
        private Texture2D comida;


        //Lista con la posición (x, y) de cada segmento que compone la serpiente
        List<Vector2> posicionSegmentos = new List<Vector2>();

        //Número de filas y columnas que tendrá el escenario
        private int filas, columnas;

        //Puntuación
        int puntuacion = 0;

        //Array que representará internamente el escenario (la X representa una pared)
        //(La C representa comida)
        string[] escenario =
            {
                 "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                 "X                              X",
                 "X    C                    C    X",
                 "X         X     C       X      X",
                 "X         X                    X",
                 "X                     C        X",
                 "X    C         XXXX            X",
                 "X                              X",
                 "X                      XXXXX   X",
                 "X     XXX               C      X",
                 "X       X       C              X",
                 "X  C    X                      X",
                 "X       X             X        X",
                 "X       XXXXXX        X        X",
                 "X                     X        X",
                 "X    C                     C   X",
                 "X              C               X",
                 "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
                 };

        //Velocidad de movimiento de la serpiente (aprox. píxeles/segundo)
        private int velocidad = 40;

        //Velocidad de movimiento en cada eje. Determinarán hacia dónde se mueve la serpiente en cada momento
        private int velocidadX, velocidadY;

        //Lista de rectángulos que representará internamente todos los obstáculos presentes en el escenario
        private List<Rectangle> obstaculos = new List<Rectangle>();

        //Lista de rectángulos que representará internamente todos los alimentos presentes en el escenario
        private List<Rectangle> alimentos = new List<Rectangle>();

        //El tipo de letra del marcador
        SpriteFont tipoLetra;

        //Para fijar los fotogramas por segundo a los que se moverá el juego
        int fotogramasPorSegundo = 3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Establece un tamaño de pantalla
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            //Establece el nº de casillas del escenario  según el tamaño de pantalla, siendo cada una de 40 de alto y ancho
            //Que es el tamaño de las texturas que estamos utilizando
            filas = 720 / 40;
            columnas = 1280 / 40;

            //Posición inicial de la serpiente (el primer segmento)
            posicionSegmentos.Add(new Vector2(300, 200));

            //Movimiento inicial de la serpiente: hacia la derecha
            velocidadX = 40;
            velocidadY = 0;

            //Rellena la lista de obstáculos en el escenario
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    if (escenario[fila][columna] == 'X')
                    {
                        obstaculos.Add(new Rectangle(columna * 40, fila * 40, 40, 40));
                    }
                }
            }

            //Rellena la lista de alimentos en el escenario
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    if (escenario[fila][columna] == 'C')
                    {
                        alimentos.Add(new Rectangle(columna * 40, fila * 40, 40, 40));
                    }
                }
            }

            //Fija la velocidad del juego (FPS) a la deseada por nosotros
            IsFixedTimeStep = true;
            TargetElapsedTime = System.TimeSpan.FromSeconds(1.0f / fotogramasPorSegundo);
        }        

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);            

            //Carga las texturas desde la carpeta Content
            serpiente = Content.Load<Texture2D>("Cuerpo");
            pared = Content.Load<Texture2D>("Pared");
            comida = Content.Load<Texture2D>("Comida");

            //Carga el tipo de letra
            tipoLetra = Content.Load<SpriteFont>("Arcade");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Si se pulsa alguna de las teclas de movimiento cambia la dirección hacia la que se moverá la serpiente            
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocidadX = velocidad;
                velocidadY = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocidadX = -velocidad;
                velocidadY = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                velocidadX = 0;
                velocidadY = -velocidad;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                velocidadX = 0;
                velocidadY = velocidad;
            }

            //Recorre los segmentos que tenga la serpiente, de forma que cada uno se desplace a la posición del anterior
            //empezando desde el último. El primer segmento "va por libre", se moverá hacia la posición que corresponda
            //en función de la dirección de movimiento actual
            for(int i = posicionSegmentos.Count - 1; i >= 1; i--)
            {
                posicionSegmentos[i] = posicionSegmentos[i - 1];
            }

            //Mueve el primer segmento (la cabeza) de la serpiente desde la posición actual a la dirección establecida
            posicionSegmentos[0] = new Vector2(
               (float)(posicionSegmentos[0].X + velocidadX),
               (float)(posicionSegmentos[0].Y + velocidadY));


            //Comprueba si hay colisión entre la cabeza de la serpiente y algún obstáculo
            //(Los rectángulos de ambos intersectarán o se solaparán)
            foreach( Rectangle r in obstaculos)
            {
                if (r.Intersects(new Rectangle(
                    (int) posicionSegmentos[0].X,
                    (int) posicionSegmentos[0].Y,
                    40, 40)))
                        Exit();//Finaliza el juego
            }

            //Comprueba si hay colisión entre la cabeza serpiente y algún alimento
            //(Los rectángulos de ambos intersectarán o se solaparán)
            for(int i = 0; i < alimentos.Count; i++)
            {
                if (alimentos[i].Intersects(new Rectangle(
                    (int)posicionSegmentos[0].X,
                    (int)posicionSegmentos[0].Y,
                    40, 40)))
                {//Si la serpiente ha colisionado con algún alimento
                    puntuacion += 100;//Aumenta la puntuación
                    alimentos.RemoveAt(i);//Borra el alimento de la lista interna

                    //La serpiente tiene que crecer en un segmento a partir de la posición del último que ya existe
                    float posXUltimo = posicionSegmentos[posicionSegmentos.Count - 1].X;
                    float posYUltimo = posicionSegmentos[posicionSegmentos.Count - 1].Y;

                    //Obtenida esa posición, incrementamos el tamaño del nuevo segmento, en la dirección contraria al movimiento actual
                    //(es decir, si el movimiento era positivo en un eje el incremento será negativo y viceversa)
                    posXUltimo = posXUltimo - System.Math.Sign(velocidadX) * 40;
                    posYUltimo = posYUltimo - System.Math.Sign(velocidadY) * 40;

                    //Añade el nuevo segmento
                    posicionSegmentos.Add(new Vector2(posXUltimo, posYUltimo));
                }
            }

            //Comprueba si la cabeza de la serpiente colisiona con alguno de los otros segmentos de sí misma
            //TODO: implementar colisión de la cabeza de la serpiente con sus propios segmentos

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Limpia la pantalla y estable un color de fondo con datos RGB
            GraphicsDevice.Clear(new Color(30, 30, 30));           

            //Inicia proceso de lotes de dibujado
            _spriteBatch.Begin();

            //Dibuja las texturas dentro del rectángulo de destino definido
            //El escenario
            for(int fila = 0; fila < filas; fila++)
            {
                for(int columna = 0; columna < columnas; columna++)
                {
                    if(escenario[fila][columna] == 'X')
                    {
                        _spriteBatch.Draw(pared,
                            new Rectangle(columna * 40, fila * 40, 40, 40),
                            Color.White);
                    }
                }
            }

            //Los alimentos (para esto utilizaremos la lista de rectángulos que los representa internamente
            //ya que esta lista se actualizará cada vez que el jugador coja un nuevo alimento)
            foreach(Rectangle a in alimentos)
            {
                _spriteBatch.Draw(comida,
                            a,
                            Color.White);
            }


            //El texto marcador con el tipo de letra cargado
            _spriteBatch.DrawString(tipoLetra, "SCORE: " + puntuacion.ToString("0000"),
                new Vector2(1000, 650), Color.Yellow);

            //La serpiente (todos sus fragmentos)
            foreach(Vector2 fragmento in posicionSegmentos)
            {
                _spriteBatch.Draw(serpiente,
                    new Rectangle((int)fragmento.X, (int)fragmento.Y, 40, 40),
                    Color.White);
            }            

            //Finaliza el proceso de lotes dibujado
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
