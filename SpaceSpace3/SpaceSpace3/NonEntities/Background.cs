using System;
using ScreenAssets;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Drawable;
using Main;

namespace SpaceSpace2
{
	public class Background : Screen
	{
		BaseSprite image;
		public Background (string filename)
		{
			image = new BaseSprite(Game1.g_game.CM, filename);
			//scale it to fit the screen
			image.Scale.X = Game1.g_game.ScreenSize.Y / image.Height;
			image.Scale.Y = Game1.g_game.ScreenSize.X / image.Width;

			if(image.Scale.X > image.Scale.Y)
				image.Scale.Y = image.Scale.X;
			else
				image.Scale.X = image.Scale.Y;
		}

		public override Screen update()
		{
			return null;
		}

		public override void draw(SpriteBatch sb, GameTime gametime)
		{
			image.Draw(gametime, sb);
		}
	}
}

