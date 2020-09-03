using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rapid1
{
    class Camera
    {

        public Matrix Transform { get; private set; }

        public void Follow(Vector2 position, Texture2D text)
        {
            Transform 
                = Matrix.CreateTranslation(-position.X,0,0) * 
                  Matrix.CreateScale(.2f) *
                  Matrix.CreateTranslation(Game1.screenWidth * .5f, Game1.screenHeight * .5f, 0);

        }

    }
}
