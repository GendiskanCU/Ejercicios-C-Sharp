using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D pelota, raqueta1, raqueta2, paredhorizontal, lineadivisoria;

        //Posición de la pelota
        private int pelotaX, pelotaY;
        
        //Posición de las raquetas
        private int raqueta1X, raqueta1Y, raqueta2X, raqueta2Y;
        
        //Campo de juego
        private int filas = 21, columnas = 32;
        private string [] CampoJuego={
            "VHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHV",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "V                              V",
            "V              DD              V",
            "VHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHV"};

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            //Establece tamaño de la ventana (en píxeles)
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            
            //Posición inicial de la pelota
            pelotaX = 481;
            pelotaY = 417;
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
            pelota = Content.Load<Texture2D>("pelota");
            raqueta1 = Content.Load<Texture2D>("raqueta");
            raqueta2 = Content.Load<Texture2D>("raqueta");
            paredhorizontal = Content.Load<Texture2D>("paredhorizontal");
            lineadivisoria = Content.Load<Texture2D>("paredvertical");
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
            
            
            _spriteBatch.Draw(pelota,
                new Rectangle(pelotaX, pelotaY, 32, 32),
                Color.White);

            for (int fila = 0; fila < filas; fila++)
            {
                for(int columna = 0; columna < columnas; columna++)
                {
                    if (CampoJuego[fila][columna] == 'H')
                    {
                        _spriteBatch.Draw(paredhorizontal,
                            new Rectangle(columna * 32, 96 + (fila * 32), 32, 32),
                            Color.White);                        
                    }

                    if (CampoJuego[fila][columna] == 'V')
                    {
                        _spriteBatch.Draw(lineadivisoria,
                            new Rectangle(columna * 32, 96 + (fila * 32), 32, 32),
                            Color.White);  
                    }
                    
                    if (CampoJuego[fila][columna] == 'D')
                    {
                        _spriteBatch.Draw(lineadivisoria,
                            new Rectangle(columna * 32, 96 + (fila * 32), 16, 16),
                            Color.White);  
                    }
                }
            }
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

        
    }
}