using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rapid1.Sprites
{
    class Enemy : Sprite
    {
        //1 for green
        //2 for yellow
        //3 for red
        //0 for deathwall
        public int enemyType;
        public Enemy(Texture2D texture) : base(texture)
        {

        }
        public Enemy(Dictionary<string, Animation> animationDict, Vector2 pos) : base(animationDict, pos)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if(this.enemyType == 0){
                this.Position += new Vector2(17,0);
            }
            if (animations != null) {
                updateAnimations();
                animationManager.Update(gameTime);
            }    
        }

        private void updateAnimations(){
            animationManager.playAnimation(animations["idle"]);
        }
    }
}
