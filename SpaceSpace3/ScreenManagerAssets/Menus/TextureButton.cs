using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Utils;
using EventManagerr;
using Drawable;
using EventManagerr.Events;

namespace ScreenAssets.Menus
{
	public class TextureButton : Listener
	{
		Texture2D idle;
		Texture2D hover;
		Texture2D clicked;

		public BaseSprite tool;

		BaseSprite sprote;

		public Rectangle hitbox;

		State state;

		public delegate void OnPressed();
		public OnPressed onPressed;

		public Vector position {
			get{ return sprote.Position;}
			set{ 
				sprote.Position = value;
				hitbox = new Rectangle((int)value.X, (int)value.Y, idle.Width, idle.Height);
				if(tool != null)
					tool.Position = value;
			}
		}
		
		public enum State
		{
			Idle,
			Hovered,
			Clicked
		}

		public TextureButton(Texture2D idle, Vector position = null, Texture2D hover = null, Texture2D clicked = null)
		{
			this.idle = idle;
			this.hover = hover;
			this.clicked = clicked;
			if(position != null)
				this.position = position;
			else
				this.position = Vector.Zero;
			//hitbox is the same size as the texture for now
			//hitbox = new Rectangle(position.X, position.Y, idle.;

			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new MouseButtonPressed(), this);
			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
		}

		public TextureButton (ContentManager Content, String Idl, Vector position = null, String Hov = null, String Cli = null, String Tool = null)
		{
			idle = Content.Load<Texture2D> (Idl);
			if(Hov != null) hover = Content.Load<Texture2D>(Hov);
			if(Cli != null) clicked = Content.Load<Texture2D>(Cli);

			sprote = new BaseSprite(idle);

			if (Tool != null)
			{
				tool = new BaseSprite(Content.Load<Texture2D>(Tool));
				tool.Position = sprote.Position;
			}
			if(position != null)
				this.position = position;
			else
				this.position = Vector.Zero;

			hitbox = new Rectangle((int)position.X, (int)position.Y, idle.Width, idle.Height);

			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new MouseButtonPressed(), this);
			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
		}


		public void Draw (GameTime gameTime, SpriteBatch spriteBatch)
		{
			Texture2D tex;

			//select the correct texture
			switch (state) {
			case State.Idle:
				tex = idle;
				break;
			case State.Hovered:
				tex = hover;
				//reset the state to idle
				state = State.Idle;
				break;
			case State.Clicked:
				tex = clicked;
				break;
			default:
				throw new Exception("Invilad state set to button");
			}
			sprote.Texture = tex;
			sprote.Draw(gameTime, spriteBatch);
			if(tool != null)
				tool.Draw(gameTime, spriteBatch);
			//spriteBatch.Draw(tex, hitbox, null, Color.White);
		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition mp = (MousePosition)e;
				if (hitbox.Contains(mp.pos.X, mp.pos.Y)) {
					//mouse is hovering over the button, change the texture
					if(state == State.Idle)
						state = State.Hovered;

					//e.isDoneProcessing = true;
				}

			} else if (e is MouseButtonPressed) {
				MouseButtonPressed mbp = (MouseButtonPressed)e;

				if (state == State.Hovered) {
					state = State.Clicked;
					//mbp.isDoneProcessing = true;
				}
			} else if (e is MouseButtonReleased) {
				//set the state back to idle
				if(state == State.Clicked)
				{
					state = State.Idle;
					if(onPressed != null)
						onPressed();
				}


			}
		}
	}
}

