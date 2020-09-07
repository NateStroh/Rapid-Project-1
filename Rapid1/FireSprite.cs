using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rapid1.Sprites;
using System;
using System.Collections.Generic;

class FireSprite : Sprite
{
    public Player p;

    public FireSprite(Dictionary<string, Animation> animationDict, Vector2 pos) : base(animationDict, pos)
    {

    }

    public override void Update(GameTime gameTime, List<Sprite> sprites)
    {
        foreach (var sprite in sprites)
        {
            if (sprite.GetType() == typeof(Player)) {
                p = (Player)sprite;
            }
        }
        this.Position = p.Position;
        if (animations != null)
        {
            updateAnimations();
            animationManager.Update(gameTime);
        }
    }

    private void updateAnimations()
    {
        if (SpeedY > 2000 || SpeedX > 2000)
        {
            animationManager.playAnimation(animations["Rfire"]);
        }
        else if (SpeedY > 1000 || SpeedX > 1000)
        {
            animationManager.playAnimation(animations["Yfire"]);
        }
        else if (SpeedY > 500 || SpeedX > 500)
        {
            animationManager.playAnimation(animations["Gfire"]);
        }
        else
        {
            animationManager.stopAnimation(animationManager.a);
        }
    }
}
