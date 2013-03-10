using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Main;
using Utils;

namespace Drawable
{
	public class SpriteSheet : BaseSprite
	{
		Vec2<int> sheetSize;

		public SpriteSheet (string filename, int height, int width)
			: this(filename, new Vec2<int>(height, width))
		{}
		public SpriteSheet (string filename, Vec2<int> size)
			:base(Game1.g_game.CM, filename)
		{
			sheetSize = size;

			_viewBox.Width = sheetSize.x;
			_viewBox.Height = sheetSize.y;
		}

		public void Draw(SpriteBatch sb, int tile, Vec2<int> pos, Rectangle cam)
		{
			if(tile < 0)
				return;

			_viewBox.X = tile * sheetSize.x % _texture.Bounds.Width;
			_viewBox.Y = (tile * sheetSize.x / Texture.Bounds.Width) * sheetSize.y;

			_position.X = pos.x - cam.X;
			_position.Y = pos.y - cam.Y;
			Draw(Game1.g_game.gametime, sb);
		}
		public void Draw(SpriteBatch sb)
		{
			Draw(Game1.g_game.gametime, sb);
		}
	}
}

