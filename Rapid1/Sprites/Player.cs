using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rapid1.Sprites
{
    class Player : Sprite
    {
        private bool hasJumped;

        public Player(Texture2D texture) : base(texture){
            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites) {
            //get user input
            pollKeys();
            //Gravity acting on the player
            SpeedY += 20;

            foreach (var sprite in sprites) 
            {
                if (sprite != this) 
                {
                    //this should stop the player if they hit a paddle
                    if (sprite.GetType() == typeof(Paddle)) 
                    {
                        if (((Paddle)sprite).paddleType == 1)
                        {
                            if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                            {
                                this.SpeedY = -SpeedY * .9F;
                            }
                        }
                        else if (((Paddle)sprite).paddleType == 2)
                        {
                            if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                            {
                                this.SpeedY = -SpeedY;
                            }
                        }
                        else if (((Paddle)sprite).paddleType == 3)
                        {
                            if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                            {
                                this.SpeedY = -SpeedY * 1.5f;
                            }
                        }
                    }
                }
            }

            foreach (var sprite in sprites)
            {
                if (sprite != this)
                {
                    
                    if ((this.SpeedX > 0 && this.IsTouchingLeft(sprite)) || (this.SpeedX < 0 & this.IsTouchingRight(sprite)))
                    {
                        this.SpeedX = 0;
                    }
                    if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                    {
                        this.SpeedY = 0;
                        hasJumped = false;
                    }
                    
                }
            }

            //adjust player positions
            Velocity = new Vector2(SpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds, SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds);
            Position += Velocity;

            
        }

        private void pollKeys() {

            //move character - WASD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                SpeedX = MathHelper.Lerp(SpeedX, -1000, .2f);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                SpeedX = MathHelper.Lerp(SpeedX, 1000, .2f);

            }
            else
            {
                SpeedX = MathHelper.Lerp(SpeedX, 0, .9f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W)&&!hasJumped)
            {
                hasJumped = true;
                Position.Y -= 5;
                SpeedY = -800;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                SpeedY += 20;
            }
        }
    }
}
