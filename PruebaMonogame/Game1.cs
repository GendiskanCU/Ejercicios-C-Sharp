using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PruebaMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declara las texturas a utilizar
        private Texture2D serpiente;

        //Coordenadas para situar a la serpiente
        private double x, y;

        //Velocidad de movimiento de la serpiente (aprox. píxeles/segundo)
        private int velocidad = 120;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Establece un tamaño de pantalla
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            //Posición inicial de la serpiente
            x = 300;
            y = 200;

           
            
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Limpia la pantalla y estable un color de fondo con datos RGB
            GraphicsDevice.Clear(new Color(30, 30, 30));           

            //Inicia proceso de lotes de dibujado
            _spriteBatch.Begin();

            //Dibuja las texturas dentro del rectángulo de destino definido
            _spriteBatch.Draw(serpiente,
                new Rectangle((int)x, (int)y, 40, 40),
                Color.White);

            //Finaliza el proceso de lotes dibujado
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
