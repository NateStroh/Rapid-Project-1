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
            Transform = Matrix.CreateTranslation(
                -position.X - text.Width / 2,
                -position.Y - text.Height / 2,
                0) * Matrix.CreateTranslation(
                Game1.screenWidth / 2,
                Game1.screenHeight / 2,
                0);

        }

    }
}
