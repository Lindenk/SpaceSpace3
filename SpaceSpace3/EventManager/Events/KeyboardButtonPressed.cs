using System;
using Microsoft.Xna.Framework.Input;

namespace EventManagerr.Events
{
	public class KeyboardButtonPressed : Event
	{
		public Keys keyPressed;
		public KeyboardButtonPressed() {}
		public KeyboardButtonPressed(Keys key) {
			keyPressed = key;
		}
	}
}

