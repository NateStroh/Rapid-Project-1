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
        private Camera _cam;
        

        public static int screenWidth;
        public static int screenHeight;

        private List<Sprite> sprites;
        private Player player;

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
            _cam = new Camera();

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

                new Paddle(Content.Load<Texture2D>("platform/Platform-Green1"))
                {
                    Position = new Vector2(300,800),
                    paddleType = 1
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Yellow2"))
                {
                    Position = new Vector2(900,800),
                    paddleType = 2
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Red2"))
                {
                    Position = new Vector2(1600,1000),
                    paddleType = 3
                },

                new Enemy(Content.Load<Texture2D>("GreenEnemy"))
                {
                    Position = new Vector2(2000,1000),
                    enemyType = 1,
                },

                new Enemy(Content.Load<Texture2D>("GreenEnemy"))
                {
                    Position = new Vector2(2500,1000),
                    enemyType = 2,
                    color = Color.Yellow,
                },

                new Enemy(Content.Load<Texture2D>("GreenEnemy"))
                {
                    Position = new Vector2(3000,1000),
                    enemyType = 3,
                    color = Color.Red,
                },

                new Enemy(Content.Load<Texture2D>("GreenEnemy"))
                {
                    Position = new Vector2(-800,800),
                    enemyType = 1,
                },
            };


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in sprites) {
                sprite.Update(gameTime, sprites);
                if(sprite.GetType() == typeof(Player))
                {
                    _cam.Follow(sprite.Position, sprite.texture);
                    player = (Player)sprite;
                }
            }

            if (player.getHealth() == 0)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: _cam.Transform);

            foreach (var sprite in sprites){
                if (sprite.isActive) 
                sprite.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
