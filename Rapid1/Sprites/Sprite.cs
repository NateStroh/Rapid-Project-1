﻿using Microsoft.Xna.Framework;
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
        public Color color;
        public float SpeedX;
        public float SpeedY;
        public bool isActive;
        private AnimationManager animationManager;
        private Dictionary<string, Animation> animations;

        //a collision box for each sprite
        public Rectangle SpriteBox {
            get{ return new Rectangle((int)Position.X, (int)Position.Y, (int)(texture.Width*scale), (int)(texture.Height*scale)); }
        }

        public Sprite(Texture2D t) {
            texture = t;
            animations = null;
            color = Color.White;
            isActive = true;
            scale = 1f;
        }

        public Sprite(Dictionary<string, Animation> animationDict)
        {
            texture = null;
            animations = animationDict;
            AnimationManager am = new AnimationManager(animationDict.First().Value);
            color = Color.White;
            isActive = true;
            scale = 1f;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites){

        }

        public virtual void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture, Position, null, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
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
