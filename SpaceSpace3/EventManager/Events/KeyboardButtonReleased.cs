using System;
using Microsoft.Xna.Framework.Input;

namespace EventManagerr.Events
{
	public class KeyboardButtonReleased : Event
	{
		public Keys keyReleased;
		public KeyboardButtonReleased () {}
		public KeyboardButtonReleased(Keys key){
			keyReleased = key;
		}
	}
}

