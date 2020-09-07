using Microsoft.Xna.Framework.Graphics;
using System;

public class Animation
{
	Texture2D texture;
	int curFrame;
	int numFrames;
	int frameHeight;
	int frameWidth;
	float frameSpeed;
	bool looping;

	public Animation(Texture2D tex, int numOfFrames, float speed)
	{
		texture = tex;
		curFrame = 0;
		numFrames = numOfFrames;
		frameHeight = tex.Height;
		frameWidth = tex.Width / numOfFrames;
		frameSpeed = speed;
		looping = true;
	}
}
