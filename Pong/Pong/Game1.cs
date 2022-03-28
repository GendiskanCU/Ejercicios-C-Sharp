using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Pong
{ public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D pelota, raqueta, pared, lineadivisora;
        private SpriteFont tipoLetra;

        //Velocidad de movimiento de la pelota
        private int velocidad = 250;
        //Para aplicar la velocidad de la pelota en cada eje
        private int velocidadX, velocidadY;
        
        //Velocidad de movimiento de las raquetas
        private int velocidadRaqueta = 300;

        //Posición de la pelota en cada momento
        private double posicionPelotaX, posicionPelotaY;
        //Guarda la posición de salida de la pelota
        private Vector2 posicionSalida = new Vector2(496, 384);
        
        //Posición de la porción inferior de cada raqueta con valores iniciales
        private Vector2 posRaqueta1 = new Vector2(33, 384);
        private Vector2 posRaqueta2 = new Vector2(959, 384);
        //Límites en Y para la posición de la porción inferior de las raquetas
        private float limiteSuperiorRaqueta = 161f, limiteInferiorRaqueta = 671f;
        
        //Puntuación de los jugadores
        private int puntuacion1 = 0, puntuacion2 = 0;
        
        //Número de filas y columnas en que se divide internamente el campo de juego
        private int filas = 21, columnas = 32;
        
        //Campo de juego. Leyenda: U-Pared superior / D-Pared inferior
        //L-Pared izquierda / R-Pared derecha / V-Línea divisora
        private string [] CampoJuego={
            "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "L                              R",
            "L              V               R",
            "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD"};
        
        //Listas de rectángulos que representan internamente las paredes del campo de juego
        private List<Rectangle> paredesHorizontales = new List<Rectangle>();
        private List<Rectangle> paredesLaterales = new List<Rectangle>();
        
        //Arrays de rectángulos que representan internamente las tres partes de ambas raquetas
        private Rectangle[] raquetaJug1 = new Rectangle[3];
        private Rectangle[] raquetaJug2 = new Rectangle[3];

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            //Establece tamaño de la ventana (en píxeles)
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            
            //Posición inicial de la pelota
            posicionPelotaX = (int)posicionSalida.X;
            posicionPelotaY = (int)posicionSalida.Y;
            
            //Movimiento inicial de la pelota
            velocidadX = velocidad;
            velocidadY = velocidad;
            
            //Posición inicial de las raquetas
            for (int fragmento = 0; fragmento < 3; fragmento++)
            {
                raquetaJug1[fragmento] = new Rectangle((int)posRaqueta1.X,
                    (int)(posRaqueta1.Y - (32 * fragmento )),
                    32, 32);
                raquetaJug2[fragmento] = new Rectangle((int)posRaqueta2.X,
                    (int)(posRaqueta2.Y - (32 * fragmento)),
                    32, 32);
            }

            //Rellena las listas que representan internamente las paredes del campo de juego
            for (int fila = 0; fila < filas; fila++)
            {
                for(int columna = 0; columna < columnas; columna++)
                {
                    if (CampoJuego[fila][columna] == 'U' || CampoJuego[fila][columna] == 'D')
                    {
                        paredesHorizontales.Add(new Rectangle(columna * 32, 64 + (fila * 32), 32, 32));
                    }
                }
            }
            
            for (int fila = 0; fila < filas; fila++)
            {
                for(int columna = 0; columna < columnas; columna++)
                {
                    if (CampoJuego[fila][columna] == 'L' || CampoJuego[fila][columna] == 'R')
                    {
                        paredesLaterales.Add(new Rectangle(columna * 32, 64 + (fila * 32), 32, 32));
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

            //Carga las texturas que se van a utilizar
            pelota = Content.Load<Texture2D>("pelotacolor");
            raqueta = Content.Load<Texture2D>("raquetaporcion");
            pared = Content.Load<Texture2D>("paredcolor");
            lineadivisora = Content.Load<Texture2D>("lineadivisoracolor");

            //Carga el tipo de letra para el marcador
            tipoLetra = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            MueveRaquetas(gameTime.ElapsedGameTime.TotalSeconds);
            CompruebaColisionPared();

            //Establece la nueva posición de la pelota
            posicionPelotaX += velocidadX * gameTime.ElapsedGameTime.TotalSeconds;
            posicionPelotaY += velocidadY * gameTime.ElapsedGameTime.TotalSeconds;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            
            //Dibuja el marcador
            string marcador = puntuacion1.ToString("00") + " - " + puntuacion2.ToString("00");
            _spriteBatch.DrawString(tipoLetra, marcador,
                new Vector2(356, 0), Color.Green);            
           
            //Dibuja el campo de juego
            for (int fila = 0; fila < filas; fila++)
            {
                for(int columna = 0; columna < columnas; columna++)
                {
                    if (CampoJuego[fila][columna] == 'U' || CampoJuego[fila][columna] == 'D'
                        || CampoJuego[fila][columna] == 'L' || CampoJuego[fila][columna] == 'R')
                    {
                        _spriteBatch.Draw(pared,
                            new Rectangle(columna * 32, 64 + (fila * 32), 32, 32),
                            Color.White);                        
                    }

                    if (CampoJuego[fila][columna] == 'V')
                    {
                        _spriteBatch.Draw(lineadivisora,
                            new Rectangle(24 + (columna * 32), 64 + (fila * 32), 16, 32),
                            Color.White);  
                    }
                }
            }
            
            //Dibuja las raquetas
            for (int fragmento = 0; fragmento < 3; fragmento++)
            {
                _spriteBatch.Draw(raqueta, new Rectangle((int)posRaqueta1.X,
                    (int)(posRaqueta1.Y - (32 * fragmento )), 32, 32), Color.White);
                _spriteBatch.Draw(raqueta, new Rectangle((int)posRaqueta2.X,
                    (int)(posRaqueta2.Y - (32 * fragmento )), 32, 32), Color.White);
            }

            //Dibuja la pelota
            _spriteBatch.Draw(pelota,
                new Rectangle((int)posicionPelotaX, (int)posicionPelotaY, 32, 32),
                Color.White);
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

        /// <summary>
        /// Comprueba si la pelota colisiona con alguna pared. En caso afirmativo establece
        /// la próxima dirección de movimiento de la pelota
        /// </summary>
        private void CompruebaColisionPared()
        {
            int contadorColisiones = 0;
            //Recorre cada una de la lista de paredes
            foreach (Rectangle p in paredesHorizontales)
            {
                if (p.Intersects(new Rectangle((int) posicionPelotaX, (int) posicionPelotaY, 32, 32)))
                {
                    contadorColisiones++;
                    if (contadorColisiones == 1)
                    {
                        velocidadY *= -1;
                        contadorColisiones++;
                    }
                }
            }
            
            foreach (Rectangle pared in paredesLaterales)
            {
                if (pared.Intersects(new Rectangle((int) posicionPelotaX, (int) posicionPelotaY, 32, 32)))
                {
                    contadorColisiones++;
                    if (contadorColisiones == 1)
                    {
                        velocidadX *= -1;
                        contadorColisiones++;
                    }
                }
            }
        }
        
        /// <summary>
        /// Comprueba las pulsaciones de teclas y mueve las raquetas en consonancia
        /// </summary>
        /// <param name="_elapsedTime">Multiplicador de la velocidad raqueta</param>
        private void MueveRaquetas(double _elapsedTime)
        {            
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                posRaqueta1.Y -= (float)(velocidadRaqueta * _elapsedTime);
                if (posRaqueta1.Y < limiteSuperiorRaqueta)
                    posRaqueta1.Y = limiteSuperiorRaqueta;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                posRaqueta1.Y += (float)(velocidadRaqueta * _elapsedTime);
                if (posRaqueta1.Y > limiteInferiorRaqueta)
                    posRaqueta1.Y = limiteInferiorRaqueta;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                posRaqueta2.Y -= (float)(velocidadRaqueta * _elapsedTime);
                if (posRaqueta2.Y < limiteSuperiorRaqueta)
                    posRaqueta2.Y = limiteSuperiorRaqueta;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                posRaqueta2.Y += (float)(velocidadRaqueta * _elapsedTime);
                if (posRaqueta2.Y > limiteInferiorRaqueta)
                    posRaqueta2.Y = limiteInferiorRaqueta;
            }
        }
    }
}