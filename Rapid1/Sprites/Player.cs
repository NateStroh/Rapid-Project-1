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
        public Player(Texture2D texture) : base(texture){
            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites) {
            //get user input
            pollKeys();

            foreach (var sprite in sprites) {
                if (sprite != this) {
                    //this should stop the player if they hit a paddle
                    if (sprite.GetType() == typeof(Paddle)) {
                        if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) || (this.Velocity.X < 0 & this.IsTouchingRight(sprite))){
                            this.Velocity.X = 0;
                        }
                        if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) || (this.Velocity.Y < 0 & this.IsTouchingBottom(sprite)))                        {
                            this.Velocity.Y = 0;
                        }
                    }
                }
            }

            //adjust player position
            Position += Velocity;

            Velocity = Vector2.Zero;
        }

        private void pollKeys() {

            //move character - WASD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                Velocity.X = Speed;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                Velocity.Y = Speed;
        }
    }
}
