using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EventManagerr;

namespace ScreenAssets
{
    public abstract class Screen
    {
		public EventRouter eventRouter = new EventRouter(); //used to process local events that will not be processed on inactive screens

		protected bool preventUpdates = false;
		protected bool preventDrawing = false;
		public bool PreventUpdates {
			get { return preventUpdates;}
		}
		public bool PreventDrawing {
			get { return preventDrawing;}
		}

        public Screen()
        {
        }

        abstract public Screen update(); //returns the next screen to 
        abstract public void draw(SpriteBatch spriteBatch, GameTime gametime);
    }
}
