using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rapid1.Sprites
{
    class Sprite {
        public Texture2D texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public float SpeedX;
        public float SpeedY;

        //a collision box for each sprite
        public Rectangle SpriteBox {
            get{ return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }
        }

        public Sprite(Texture2D t) {
            texture = t;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites){

        }

        public virtual void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture, Position, Color.White);
        }

        protected bool isColliding(Sprite sprite) {
            return (IsTouchingBottom(sprite) || IsTouchingLeft(sprite) || IsTouchingRight(sprite) || IsTouchingTop(sprite));
        }

        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.SpriteBox.Right + this.Velocity.X > sprite.SpriteBox.Left &&
              this.SpriteBox.Left < sprite.SpriteBox.Left &&
              this.SpriteBox.Bottom > sprite.SpriteBox.Top &&
              this.SpriteBox.Top < sprite.SpriteBox.Bottom;
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.SpriteBox.Left + this.Velocity.X < sprite.SpriteBox.Right &&
              this.SpriteBox.Right > sprite.SpriteBox.Right &&
              this.SpriteBox.Bottom > sprite.SpriteBox.Top &&
              this.SpriteBox.Top < sprite.SpriteBox.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.SpriteBox.Bottom + this.Velocity.Y > sprite.SpriteBox.Top &&
              this.SpriteBox.Top < sprite.SpriteBox.Top &&
              this.SpriteBox.Right > sprite.SpriteBox.Left &&
              this.SpriteBox.Left < sprite.SpriteBox.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.SpriteBox.Top + this.Velocity.Y < sprite.SpriteBox.Bottom &&
              this.SpriteBox.Bottom > sprite.SpriteBox.Bottom &&
              this.SpriteBox.Right > sprite.SpriteBox.Left &&
              this.SpriteBox.Left < sprite.SpriteBox.Right;
        }
    }
}
