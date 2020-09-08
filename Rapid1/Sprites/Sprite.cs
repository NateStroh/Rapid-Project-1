using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rapid1.Sprites
{
    class Sprite {

        public Texture2D texture;
        public float scale;
        public Vector2 Position;
        public Vector2 Velocity;
        public float Rotation;
        public Color color;
        public float SpeedX;
        public float SpeedY;
        public bool isActive;
        public bool isCollider;
        public AnimationManager animationManager;
        protected Dictionary<string, Animation> animations;

        //a collision box for each sprite
        public Rectangle SpriteBox {
            get{
                if (texture != null)
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, (int)(texture.Width * scale), (int)(texture.Height * scale));
                }
                else {
                    return new Rectangle((int)Position.X, (int)Position.Y, (int)(animations.First().Value.frameWidth * scale), (int)(animations.First().Value.frameHeight * scale));
                }
            }
        }

        public Sprite(Texture2D t) {
            texture = t;
            animations = null;
            color = Color.White;
            isActive = true;
            isCollider = true;
            scale = 1f;
            Rotation = 0f;
        }

        public Sprite(Dictionary<string, Animation> animationDict, Vector2 position)
        {
            texture = null;
            animations = animationDict;
            animationManager = new AnimationManager(animationDict.First().Value);
            color = Color.White;
            isActive = true;
            scale = 1f;
            animationManager.animationPosition = position;
            Position = position;
            
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites){

        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (texture != null)
            {
                spriteBatch.Draw(texture, Position, null, color, Rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
            else if (animations != null)
            {
                animationManager.Draw(spriteBatch);
            }
        }

        protected bool isColliding(Sprite sprite) {
            if (!isCollider)
            {
                return false;
            }
            return (IsTouchingBottom(sprite) || IsTouchingLeft(sprite) || IsTouchingRight(sprite) || IsTouchingTop(sprite));
        }

        protected bool IsTouchingLeft(Sprite sprite)
        {
            if (!isCollider)
            {
                return false;
            }

            return this.SpriteBox.Right + this.Velocity.X > sprite.SpriteBox.Left &&
              this.SpriteBox.Left < sprite.SpriteBox.Left &&
              this.SpriteBox.Bottom > sprite.SpriteBox.Top &&
              this.SpriteBox.Top < sprite.SpriteBox.Bottom;
            
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            if (!isCollider)
            {
                return false;
            }

            return this.SpriteBox.Left + this.Velocity.X < sprite.SpriteBox.Right &&
              this.SpriteBox.Right > sprite.SpriteBox.Right &&
              this.SpriteBox.Bottom > sprite.SpriteBox.Top &&
              this.SpriteBox.Top < sprite.SpriteBox.Bottom;
            
             
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            if (!isCollider)
            {
                return false;
            }

            return this.SpriteBox.Bottom + this.Velocity.Y > sprite.SpriteBox.Top &&
              this.SpriteBox.Top < sprite.SpriteBox.Top &&
              this.SpriteBox.Right > sprite.SpriteBox.Left &&
              this.SpriteBox.Left < sprite.SpriteBox.Right;

           
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            if (!isCollider)
            {
                return false;
            }

            return this.SpriteBox.Top + this.Velocity.Y < sprite.SpriteBox.Bottom &&
              this.SpriteBox.Bottom > sprite.SpriteBox.Bottom &&
              this.SpriteBox.Right > sprite.SpriteBox.Left &&
              this.SpriteBox.Left < sprite.SpriteBox.Right;
           
        }
    }
}
