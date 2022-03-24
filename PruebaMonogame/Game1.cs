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

        //Coordenadas para situar a la serpiente
        private double x, y;

        //Número de filas y columnas que tendrá el escenario
        private int filas, columnas;

        //Array que representará internamente el escenario (la X representa una pared)
        string[] escenario =
            {
                 "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                 "X                              X",
                 "X                              X",
                 "X         X             X      X",
                 "X         X                    X",
                 "X                              X",
                 "X              XXXX            X",
                 "X                              X",
                 "X                      XXXXX   X",
                 "X     XXX                      X",
                 "X       X                      X",
                 "X       X                      X",
                 "X       X             X        X",
                 "X       XXXXXX        X        X",
                 "X                     X        X",
                 "X                              X",
                 "X                              X",
                 "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
                 };

        //Velocidad de movimiento de la serpiente (aprox. píxeles/segundo)
        private int velocidad = 120;

        //Lista de rectángulos que representará internamente todos los obstáculos presentes en el escenario
        private List<Rectangle> obstaculos = new List<Rectangle>();

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
