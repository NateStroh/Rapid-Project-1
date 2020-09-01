using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rapid1.Sprites
{
    class Paddle : Sprite
    {
        //1 for green
        //2 for yellow
        //3 for red
        public int paddleType;
        public Paddle(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
    }
}
