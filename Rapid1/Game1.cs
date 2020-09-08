using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rapid1.Sprites;
using System;
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
        private List<Sprite> backgroundBuildings;
        private Player player;
        private Texture2D background;
        private Vector2 backgroundPos;
        

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
            backgroundPos = new Vector2(-4000, -7000);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _cam = new Camera();

            background = Content.Load<Texture2D>("PP background");

            backgroundBuildings = new List<Sprite>()
            {
                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_004"))
                {
                    Position = new Vector2(4000,0),
                    isCollider = false,
                    scale = 2f
                }
            };

            sprites = new List<Sprite>() {
            // TODO: load in player, paddles(floor shit), enemies
                new FireSprite(new Dictionary<string, Animation>() {
                    {"Gfire", new Animation(Content.Load<Texture2D>("player/texture_fire_b_1500_500"), 6, .2f)},
                    {"Yfire", new Animation(Content.Load<Texture2D>("player/texture_fire_y_1500_500"), 6, .2f)},
                    {"Rfire", new Animation(Content.Load<Texture2D>("player/texture_fire_r_1500_500"), 6, .2f)}
                }, new Vector2(100, -1000)){
                },

                new Player(new Dictionary<string, Animation>() {
                    {"RedFalling", new Animation(Content.Load<Texture2D>("player/texture_cha_air_r_sheet_2000_500"), 4, .2f) },
                    {"RedUp", new Animation(Content.Load<Texture2D>("player/texture_cha_jump_r_sheet_1500_1000"), 6, .2f)},
                    {"RedWalkRight", new Animation(Content.Load<Texture2D>("player/texture_cha_walk_r_sheet_2000_500"), 4, .2f)},
                    //{"RedLeft", new Animation(Content.Load<Texture2D>(""), 4, .2f)},
                    {"RedIdle", new Animation(Content.Load<Texture2D>("player/texture_cha_idle_r_sheet_500_500"), 8, .2f)},
                    {"YellowFalling", new Animation(Content.Load<Texture2D>("player/texture_cha_air_y_sheet_2000_500"), 4, .2f)},
                    {"YellowUp", new Animation(Content.Load<Texture2D>("player/texture_cha_jump_y_sheet_1500_1000"), 6, .2f)},
                    {"YellowWalkRight", new Animation(Content.Load<Texture2D>("player/texture_cha_walk_y_sheet_2000_500"), 4, .2f)},
                    //{"YellowLeft", new Animation(Content.Load<Texture2D>(""), 4, .2f)},
                    {"YellowIdle", new Animation(Content.Load<Texture2D>("player/texture_cha_idle_y_sheet_500_500"), 8, .2f)},
                    {"GreenFalling", new Animation(Content.Load<Texture2D>("player/texture_cha_air_g_sheet_2000_500"), 4, .2f)},
                    {"GreenUp", new Animation(Content.Load<Texture2D>("player/texture_cha_jump_g_sheet_1500_1000"), 6, .2f)},
                    {"GreenWalkRight", new Animation(Content.Load<Texture2D>("player/texture_cha_walk_b_sheet_2000_500"), 4, .2f)},
                    //{"GreenLeft", new Animation(Content.Load<Texture2D>(""), 4, .2f)},
                    {"GreenIdle", new Animation(Content.Load<Texture2D>("player/texture_cha_idle_b_sheet_500_500"), 8, .2f)},
                    {"GreyFalling", new Animation(Content.Load<Texture2D>("player/texture_cha_air_w_sheet_2000_500"), 4, .2f)},
                    {"GreyUp", new Animation(Content.Load<Texture2D>("player/texture_cha_jump_w_sheet_1500_1000"), 6, .2f)},
                    {"GreyWalkRight", new Animation(Content.Load<Texture2D>("player/texture_cha_walk_w_sheet_2000_500"), 4, .2f)},
                    //{"GreyLeft", new Animation(Content.Load<Texture2D>(""), 4, .2f)},
                    {"GreyIdle", new Animation(Content.Load<Texture2D>("player/texture_cha_idle_w_sheet_500_500"), 8, .2f)},

                    }, new Vector2(100, -1000))
                {
                    isCollider = true,
                    //scale = .7f
                },

                new Enemy(Content.Load<Texture2D>("mountain/deathwall"))
                {
                    Position = new Vector2(-8000,-2500),
                    
                    //Rotation = MathHelper.Pi/2,
                    enemyType = 0,
                    scale = 5f
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
                    paddleType = 2,
                    scale = 2
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

                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 3 Idle"), 4, .2f)}
                }, new Vector2(18500,-1400)){
                    enemyType = 3,
                },

                //animated enemy
                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 1 Idle"), 4, .2f)}
                }, new Vector2(20000,500)){
                    enemyType = 1,
                },

                new Sprite(Content.Load<Texture2D>("house/texture_bg_ruin_building_001"))
                {
                    Position = new Vector2(21000,0),
                    scale = 5f
                },

                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 2 Idle"), 4, .2f)}
                }, new Vector2(21000,-400)){
                    enemyType = 2,
                },

                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 1 Idle"), 4, .2f)}
                }, new Vector2(22500, 400)){
                    enemyType = 1,
                },

                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 1 Idle"), 4, .2f)}
                }, new Vector2(23500, 0)){
                    enemyType = 1,
                },

                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 1 Idle"), 4, .2f)}
                }, new Vector2(24500, 800)){
                    enemyType = 1,
                },

                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 1 Idle"), 4, .2f)}
                }, new Vector2(25500, 900)){
                    enemyType = 1,
                },

                new Paddle(Content.Load<Texture2D>("platform/Platform-Red1"))
                {
                    Position = new Vector2(26000,-200),
                    paddleType = 2,
                    scale = 2
                },

                new Enemy(new Dictionary<string, Animation>() {
                    {"idle", new Animation(Content.Load<Texture2D>("enemy/PP enemy 3 Idle"), 4, .2f)}
                }, new Vector2(26500, 1700)){
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
                if (sprite.isActive) {
                    sprite.Update(gameTime, sprites);
                }
                
                if(sprite.GetType() == typeof(Player))
                {
                    _cam.Follow(sprite.Position, sprite.texture);
                    player = (Player)sprite;
                }
            }

            if (player.getHealth() == 0 || player.Position.Y > 2500){
                foreach (var sprite in sprites){
                    sprite.isActive = true;
                    if(sprite.GetType() == typeof(Enemy))
                    {
                        if (((Enemy)sprite).enemyType == 0)
                        {
                            sprite.Position = new Vector2(-8000, -2500);
                        }
                    }
                }
                player.Respawn();
                backgroundPos = new Vector2(-4000, -7000);
            }

            backgroundPos = backgroundPos + (player.Velocity * .7f);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(transformMatrix: _cam.Transform);

            _spriteBatch.Draw(background, backgroundPos, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);

            foreach (var sprite in sprites){
                if (sprite.isActive) 
                sprite.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
