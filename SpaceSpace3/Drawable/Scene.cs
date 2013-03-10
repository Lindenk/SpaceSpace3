using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using ScreenAssets;
using Main;

namespace Drawable
{
    public class Scene
    {
        Stack<Screen> _screens = new Stack<Screen>();

        public Scene()
        {
            //start out with the intro screen
            //pushScreen(new IntroScreen(removeScreen, CM, gameOver, aspectRatio));
            //pushScreen(new Level(CM, removeScreen, gameOver, aspectRatio));
        }

        public void pushScreen(Screen screen)
        {
            _screens.Push(screen);
        }
		public void popScreen ()
		{
			_screens.Pop();
		}
		//removes the given screen if it exists
        public void removeScreen (Screen screen)
		{
			//create a new stack to store the screens not being deleted
			Stack<Screen> newScreens = new Stack<Screen>();
			foreach (Screen s in _screens.Reverse()) {
				if(s != screen)
					newScreens.Push(s);
			}
            //clear the old stack and assign it the new one
			_screens.Clear();
			_screens = newScreens;
        }
		//removes all screens in the stack
		public void clearScreens ()
		{
			_screens.Clear();
		}

        public bool update()
        {
			//update all screens that can be updated
			foreach (Screen s in _screens) {
				s.update();
				if(s.PreventUpdates)
					break;
			}

			return false;
        }

		public Stack<Screen> getUpdatableScreens ()
		{
			Stack<Screen> retStack = new Stack<Screen>();

			foreach (Screen s in _screens) {
				retStack.Push(s);
				if(s.PreventUpdates)
					break;
			}
			
			return retStack;
		}

        public void draw (SpriteBatch spritebatch, GameTime gametime)
		{
			//get all the screens needing to be drawn in order
			Stack<Screen> drawables = new Stack<Screen>();
			foreach (Screen s in _screens) {
				drawables.Push (s);
				if(s.PreventDrawing)
					break;
			}
			//draw them all in order
            foreach (Screen screen in drawables)
            {
                screen.draw(spritebatch, gametime);
            }
        }
    }
}
