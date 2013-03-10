using System;
using Drawable;
using Microsoft.Xna.Framework;
using EventManagerr;
using Main;
using Microsoft.Xna.Framework.Input;
using EventManagerr.Events;
using Microsoft.Xna.Framework.Graphics;
using Utils;

namespace SpaceSpace2
{
	public class Player: Listener
	{

		SpriteSheet playerSprite;
		Vec2<int> _position;
		Vector2 speed;

		int movementSpeed = 5;

		//Booleans for the player's movement based on whether or not a key is being pressed
		Boolean WKEY = false;
		Boolean AKEY = false;
		Boolean SKEY = false;
		Boolean DKEY = false;
		Boolean SPACE = false;

		Level parent;

		public Vec2<int> position
		{
			get{return _position;}
			set{_position = value;}
		}

		public Player (Level parent, Vec2<int> sentPos)
		{
			this.parent = parent;

			Game1.g_game.im.addActiveButton (Keys.W);
			Game1.g_game.im.addActiveButton (Keys.A);
			Game1.g_game.im.addActiveButton (Keys.S);
			Game1.g_game.im.addActiveButton (Keys.D);
			Game1.g_game.im.addActiveButton (Keys.Space);

			EventManager.g_EM.AddListener (new KeyboardButtonPressed(), this);
			EventManager.g_EM.AddListener (new KeyboardButtonReleased(), this);

			playerSprite = new SpriteSheet ("Icon", new Vec2<int> (32, 32));
			playerSprite.Position.X = (int)Game1.g_game.ScreenSize.X/2;
			playerSprite.Position.Y = (int)Game1.g_game.ScreenSize.Y/2;

			_position = sentPos;
			speed = new Vector2 (0, 0);
		}

		public void Update()
		{
			//Animate the player

			//Move the player

			if (WKEY)
				speed.Y = movementSpeed * -1;
			if(SKEY)
				speed.Y = movementSpeed;
			if(!(WKEY || SKEY))
				speed.Y = 0;

			if (DKEY)
				speed.X = movementSpeed;
			if(AKEY)
				speed.X = movementSpeed * -1;
			if(!(DKEY || AKEY))
				speed.X = 0;

			_position = parent.MoveTo(_position, new Vec2<int>((int)(position.x + speed.X), (int)(position.y + speed.Y)));
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//Draw the player sprite
			playerSprite.Draw(spriteBatch);
			//playerSprite.Draw (spriteBatch, 0, 
			//                   new Vec2<int>((int)Game1.g_game.ScreenSize.X/2, (int)Game1.g_game.ScreenSize.Y/2), 
			//                   new Rectangle());
		}

		public void OnEvent (Event e)
		{
			//Determines which keys are up or down

			if (e is KeyboardButtonPressed)
			{
				KeyboardButtonPressed KBP = (KeyboardButtonPressed)e;
				switch(KBP.keyPressed)
				{
				case(Keys.W):
					WKEY = true;
					break;
				case(Keys.A):
					AKEY = true;
					break;
				case(Keys.S):
					SKEY = true;
					break;
				case(Keys.D):
					DKEY = true;
					break;
				case(Keys.Space):
					SPACE = true;
					break;
				}
			}
			else if (e is KeyboardButtonReleased)
			{
				Console.WriteLine("Processing Key");

				KeyboardButtonReleased KBR = (KeyboardButtonReleased)e;
				switch(KBR.keyReleased)
				{
				case(Keys.W):
					WKEY = false;
					break;
				case(Keys.A):
					AKEY = false;
					break;
				case(Keys.S):
					SKEY = false;
					break;
				case(Keys.D):
					DKEY = false;
					break;
				case(Keys.Space):
					SPACE = false;
					break;
				}
			}
		}
	}
}

