using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Data;

public class AnimationManager
{
	private Animation a;
	float timer;
	public Vector2 position;

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

	public void update(GameTime gameTime) {
		timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

		if (timer > a.frameSpeed) {
			a.currFrame++;
			timer = 0;

			if (a.currFrame == a.numFrames) {
				a.currFrame = 0;
			}
		}
	}

	public void draw(SpriteBatch spriteBatch){
		spriteBatch.Draw(a.texture, new Rectangle(a.frameWidth * a.currFrame, 0, a.frameHeight, a.frameWidth), a.color);
	}
}
