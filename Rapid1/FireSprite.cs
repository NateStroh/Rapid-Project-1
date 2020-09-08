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
        animationManager.animationPosition = p.Position;
        if (animations != null)
        {
            updateAnimations();
            animationManager.Update(gameTime);
        }
    }

    private void updateAnimations()
    {
        if (p.SpeedY > 3000 || p.SpeedX > 3600)
        {
            animationManager.a.scale = 1.5f;
            animationManager.animationPosition += new Vector2(-100, -100);
            animationManager.playAnimation(animations["Rfire"]);
        }
        else if (p.SpeedY > 1000 || p.SpeedX > 3000)
        {
            animationManager.a.scale = 1.3f;
            animationManager.animationPosition += new Vector2(-50, -50);
            animationManager.playAnimation(animations["Yfire"]);
        }
        else if (p.SpeedY > 500 || p.SpeedX > 500)
        {
            animationManager.a.scale = 1.1f;
            animationManager.animationPosition += new Vector2(-50, -50);
            animationManager.playAnimation(animations["Gfire"]);
        }
        else
        {
            animationManager.a.scale = .5f;
            animationManager.animationPosition += new Vector2(100, 100);
        }
    }
}
