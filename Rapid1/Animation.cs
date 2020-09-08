using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml;

public class Animation
{
	public Texture2D texture;
	public float scale;
	public int currFrame;
	public int numFrames;
	public int frameHeight;
	public int frameWidth;
	public float frameSpeed;
	public bool looping;
	public Color color;

	public Animation(Texture2D tex, int numOfFrames, float speed)
	{
		texture = tex;
		scale = 1f;
		currFrame = 0;
		numFrames = numOfFrames;
		frameHeight = tex.Height;
		frameWidth = tex.Width / numOfFrames;
		frameSpeed = speed;
		looping = true;
		color = Color.White;
	}
}
