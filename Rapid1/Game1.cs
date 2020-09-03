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
        private Texture2D background;

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
            //_graphics.ToggleFullScreen();
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _cam = new Camera();

            background = Content.Load<Texture2D>("PP background");

            sprites = new List<Sprite>() {
            // TODO: load in player, paddles(floor shit), enemies
                new Player(Content.Load<Texture2D>("player/texture_cha_idle_w_0004"))
                {
                    Position = new Vector2(100, -1000),
                    scale = .5f
                },

                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_004"))
                {
                    Position = new Vector2(-400,800),
                    scale = 5f
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Green1"))
                {
                    Position = new Vector2(5000,600),
                    paddleType = 1
                },

                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_003"))
                {
                    Position = new Vector2(5500,300),
                    scale = 5f
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Green1"))
                {
                    Position = new Vector2(9000,0),
                    paddleType = 1
                },

                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_003"))
                {
                    Position = new Vector2(9500,-200),
                    scale = 5f
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Yellow2"))
                {
                    Position = new Vector2(14500,1200),
                    paddleType = 2
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Yellow1"))
                {
                    Position = new Vector2(16000,500),
                    paddleType = 2
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Yellow1"))
                {
                    Position = new Vector2(17500,0),
                    paddleType = 2
                },

                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_001"))
                {
                    Position = new Vector2(18500,-1000),
                    scale = 5f
                },

                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 3"))
                {
                    Position = new Vector2(18500,-1400),
                    enemyType = 3,
                },

                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 1"))
                {
                    Position = new Vector2(20000,500),
                    enemyType = 1,
                },

                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_001"))
                {
                    Position = new Vector2(21000,0),
                    scale = 5f
                },

                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 2"))
                {
                    Position = new Vector2(21000,-400),
                    enemyType = 2,
                },

                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 1"))
                {
                    Position = new Vector2(22500, 400),
                    enemyType = 1,
                },

                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 1"))
                {
                    Position = new Vector2(23500, 0),
                    enemyType = 1,
                },

                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 1"))
                {
                    Position = new Vector2(24500, 800),
                    enemyType = 1,
                },

                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 1"))
                {
                    Position = new Vector2(25500, 900),
                    enemyType = 1,
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Red1"))
                {
                    Position = new Vector2(26000,-200),
                    paddleType = 2,
                    scale = 2
                },
                
                new Enemy(Content.Load<Texture2D>("enemy/PP enemy 3"))
                {
                    Position = new Vector2(26500, 1700),
                    enemyType = 3,
                },

                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_003"))
                {
                    Position = new Vector2(30000,0),
                    scale = 5f
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

            if (player.getHealth() == 0 || player.Position.Y > 3000)
                player.Respawn();
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(transformMatrix: _cam.Transform);

            _spriteBatch.Draw(background, new Vector2(-4000,-14000), null, Color.White, 0f, Vector2.Zero, 4.5f, SpriteEffects.None, 0f);

            foreach (var sprite in sprites){
                if (sprite.isActive) 
                sprite.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
