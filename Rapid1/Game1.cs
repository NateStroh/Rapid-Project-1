using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rapid1.Sprites;
using System.Collections.Generic;

namespace Rapid1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int screenWidth;
        public static int screenHeight;

        private List<Sprite> sprites;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {


            //Sets the size of the application window
            screenWidth = 1920;
            screenHeight = 1080;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ToggleFullScreen();
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sprites = new List<Sprite>() {

            // TODO: load in player, paddles(floor shit), enemies
                new Player(Content.Load<Texture2D>("testPlayer"))
                {
                    Position = new Vector2(100, 100)

                },

                new Sprite(Content.Load<Texture2D>("Block"))
                {
                    Position = new Vector2(0,1000)
                },

                new Paddle(Content.Load<Texture2D>("Small"))
                {
                    Position = new Vector2(300,800),
                    paddleType = 1
                },

                new Paddle(Content.Load<Texture2D>("Small"))
                {
                    Position = new Vector2(900,800),
                    paddleType = 2
                },

                new Paddle(Content.Load<Texture2D>("Small"))
                {
                    Position = new Vector2(1600,1000),
                    paddleType = 3
                },
            };


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            foreach (var sprite in sprites) {
                sprite.Update(gameTime, sprites);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            foreach (var sprite in sprites){
                sprite.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
