using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

using Main;
using Drawable;
using ScreenAssets.Menus;
using Utils;

namespace ScreenAssets
{
    public abstract class Menu : Screen
    {
        protected BaseSprite _backGround;
        protected List<TextureButton> buttons = new List<TextureButton>();

        public Menu (Texture2D backGround)
		{
			_backGround = new BaseSprite (backGround);

			//scale the sprite based on the screen size for the background
			float heightRatio = Game1.g_game.ScreenSize.Y / backGround.Height;
			float widthRatio = Game1.g_game.ScreenSize.X / backGround.Width;

			if (heightRatio > widthRatio) {
				_backGround.Scale = new Vector(heightRatio, heightRatio, heightRatio);
				//center it
				//_backGround.Position.X -= (backGround.Width - Game1.ScreenSize.X) / 2;
			} else {
				//center it
				//_backGround.Position.Y -= (backGround.Height - Game1.ScreenSize.Y) / 2;

				_backGround.Scale = new Vector(widthRatio, widthRatio, widthRatio);
			}
        }

        public override void draw (SpriteBatch spriteBatch, GameTime gametime)
		{
			_backGround.Draw (gametime, spriteBatch);

			foreach (TextureButton btn in buttons) {
				btn.Draw(gametime, spriteBatch);
			}
		}
    }
}
