using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D pelota, raqueta1, raqueta2, pared, lineadivisora;
        private SpriteFont tipoLetra;

        //Posición de la pelota en cada momento
        private int pelotaX, pelotaY;
        //Guarda la posición de salida de la pelota
        private Vector2 posicionSalida = new Vector2(496, 384);
        
        //Posición de las raquetas
        private int raqueta1X, raqueta1Y, raqueta2X, raqueta2Y;
        
        //Campo de juego
        private int filas = 21, columnas = 32;
        private string [] CampoJuego={
            "PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "P                              P",
            "P              D               P",
            "PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP"};

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            //Establece tamaño de la ventana (en píxeles)
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            
            //Posición inicial de la pelota
            pelotaX = (int)posicionSalida.X;
            pelotaY = (int)posicionSalida.Y;
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
            raqueta1 = Content.Load<Texture2D>("raquetacolor");
            raqueta2 = Content.Load<Texture2D>("raquetacolor");
            pared = Content.Load<Texture2D>("paredcolor");
            lineadivisora = Content.Load<Texture2D>("lineadivisoracolor");

            tipoLetra = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            
            _spriteBatch.DrawString(tipoLetra, "0 - 0",
                new Vector2(400, 0), Color.Green);            
           

            for (int fila = 0; fila < filas; fila++)
            {
                for(int columna = 0; columna < columnas; columna++)
                {
                    if (CampoJuego[fila][columna] == 'P')
                    {
                        _spriteBatch.Draw(pared,
                            new Rectangle(columna * 32, 64 + (fila * 32), 32, 32),
                            Color.White);                        
                    }

                    if (CampoJuego[fila][columna] == 'D')
                    {
                        _spriteBatch.Draw(lineadivisora,
                            new Rectangle(24 + (columna * 32), 64 + (fila * 32), 16, 32),
                            Color.White);  
                    }
                }
            }
            
            
            
            _spriteBatch.Draw(pelota,
                new Rectangle(pelotaX, pelotaY, 32, 32),
                Color.White);
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

        
    }
}