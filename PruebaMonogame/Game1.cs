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

        //Coordenadas para situar a la serpiente
        private double x, y;

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
        private int velocidad = 120;

        //Lista de rectángulos que representará internamente todos los obstáculos presentes en el escenario
        private List<Rectangle> obstaculos = new List<Rectangle>();

        //Lista de rectángulos que representará internamente todos los alimentos presentes en el escenario
        private List<Rectangle> alimentos = new List<Rectangle>();

        //El tipo de letra del marcador
        SpriteFont tipoLetra;

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

            //Posición inicial de la serpiente
            x = 300;
            y = 200;

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

            //Si se pulsa alguna de las teclas de movimiento cambia las coordenadas x e y de la serpiente en consonancia
            //realizando el ajuste correspondiente según el tiempo transcurrido desde el anterior frame
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                x += velocidad * gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                x -= velocidad * gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                y -= velocidad * gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                y += velocidad * gameTime.ElapsedGameTime.TotalSeconds;


            //Comprueba si hay colisión entre la serpiente y algún obstáculo
            //(Los rectángulos de ambos intersectarán o se solaparán)
            foreach( Rectangle r in obstaculos)
            {
                if (r.Intersects(new Rectangle((int)x, (int)y, 40, 40)))
                    Exit();
            }

            //Comprueba si hay colisión entre la serpiente y algún alimento
            //(Los rectángulos de ambos intersectarán o se solaparán)
            for(int i = 0; i < alimentos.Count; i++)
            {
                if (alimentos[i].Intersects(new Rectangle((int)x, (int)y, 40, 40)))
                {
                    puntuacion += 100;//Aumenta la puntuación
                    alimentos.RemoveAt(i);//Borra el alimento de la lista interna
                }
            }

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

            //La serpiente
            _spriteBatch.Draw(serpiente,
                new Rectangle((int)x, (int)y, 40, 40),
                Color.White);
            

            //Finaliza el proceso de lotes dibujado
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
