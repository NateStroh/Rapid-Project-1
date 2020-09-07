using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;

public class AnimationManager
{
	public Animation a;
	float timer;
	public float scale;
	public Vector2 animationPosition;

	public AnimationManager(Animation animation){
		a = animation;
	}

	public void playAnimation(Animation animation) {
		if (a != animation){
			a = animation;
			a.currFrame = 0;
			timer = 0;
		}
	}

	public void stopAnimation(Animation animation) {
		a.currFrame = 0;
		timer = 0;
	}

	public void Update(GameTime gameTime) {
		timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

		if (timer > a.frameSpeed) {
			a.currFrame++;
			timer = 0;

			if (a.currFrame == a.numFrames) {
				a.currFrame = 0;
			}
		}
	}

	public void Draw(SpriteBatch spriteBatch){
		spriteBatch.Draw(a.texture, animationPosition, new Rectangle(a.frameWidth * a.currFrame, 0, a.frameWidth, a.frameHeight), a.color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
	}
}
