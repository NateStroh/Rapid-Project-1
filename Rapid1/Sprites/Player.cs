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
        private int health = 1;
        private const int REDSPEED = 2000;
        private const int YELLOWSPEED = 1000;
        private const int GREENSPEED = 500;
        int speedCap = 2000;
        public Player(Texture2D texture) : base(texture) {

        }

        public int getHealth(){
            return health;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites) {
            //get user input
            pollKeys();
            //Gravity acting on the player
            SpeedY += 40;

            //this is just test code to change player color instead of the different textures
            if (SpeedY > REDSPEED)
            {
                color = Color.Red;
            }
            else if (SpeedY > YELLOWSPEED)
            {
                color = Color.Yellow;
            }
            else if (SpeedY > GREENSPEED)
            {
                color = Color.Green;
            }
            else {
                color = Color.White;
            }

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
                                this.SpeedY = -SpeedY - 400;
                            }
                        }
                        else if (((Paddle)sprite).paddleType == 2)
                        {
                            if ((this.SpeedY > 0 && this.IsTouchingTop(sprite)) || (this.SpeedY < 0 & this.IsTouchingBottom(sprite)))
                            {
                                this.SpeedY = -SpeedY - 600;
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
                    else if (sprite.GetType() == typeof(Enemy)) {
                        collideWithEnemy((Enemy) sprite, sprites);
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

            
            //Speed Cap
            if(SpeedX > speedCap)
            {
                SpeedX = MathHelper.Lerp(SpeedX, speedCap, .02f);
            }
            else if(SpeedX < -speedCap)
            {
                SpeedX = MathHelper.Lerp(SpeedX, -speedCap, .02f);
            }

            if (SpeedY > speedCap)
            {
                SpeedY = MathHelper.Lerp(SpeedY, speedCap, .02f);
            }
            else if (SpeedY < -speedCap)
            {
                SpeedY = MathHelper.Lerp(SpeedY, -speedCap, .02f);
            }

            //adjust player positions
            Velocity = new Vector2(SpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds, SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds);
            Position += Velocity;
            
        }

        private void pollKeys() {

            //move character - WASD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                SpeedX = MathHelper.Lerp(SpeedX, -1500, .2f);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                SpeedX = MathHelper.Lerp(SpeedX, 1500, .2f);

            }
            else
            {
                SpeedX = MathHelper.Lerp(SpeedX, 0, .9f);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W)&&!hasJumped)
            {
                hasJumped = true;
                Position.Y -= 5;
                SpeedY = -1400;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                SpeedY += 20;
            }
        }

        private void collideWithEnemy(Enemy enemy, List<Sprite> spriteList) {
            //if its a green enemy
            if (enemy.enemyType == 1)
            {
                //if it's colliding
                if ((this.SpeedY > 0 && this.IsTouchingTop(enemy)) || (this.SpeedY < 0 & this.IsTouchingBottom(enemy)))
                {
                    //if player has enough speed
                    if (SpeedY > GREENSPEED)
                    {
                        this.SpeedY = -SpeedY - 200;
                        enemy.isActive = false;
                    }
                    else {
                        health--;
                    }
                }
            }
            else if (enemy.enemyType == 2)
            {
                //if it's colliding
                if ((this.SpeedY > 0 && this.IsTouchingTop(enemy)) || (this.SpeedY < 0 & this.IsTouchingBottom(enemy)))
                {
                    //if player has enough speed
                    if (SpeedY > YELLOWSPEED)
                    {
                        this.SpeedY = -SpeedY - 400;
                        enemy.isActive = false;
                    }
                    else
                    {
                        health--;
                    }
                }
            }
            if (enemy.enemyType == 3)
            {
                //if it's colliding
                if ((this.SpeedY > 0 && this.IsTouchingTop(enemy)) || (this.SpeedY < 0 & this.IsTouchingBottom(enemy)))
                {
                    //if player has enough speed
                    if (SpeedY > REDSPEED)
                    {
                        this.SpeedY = -SpeedY *1.5f;
                        enemy.isActive = false;
                    }
                    else
                    {
                        health--;
                    }
                }
            }

        }

        public void Respawn()
        {
            Position = new Vector2(100, 100);
        }
    }
}
