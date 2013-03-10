using System;
using Microsoft.Xna.Framework.Input;

namespace EventManagerr.Events
{
	public enum MouseButtons
	{
		Left,
		Right,
		Middle
	}

	public class MouseButtonPressed : Event
	{
		public MouseButtons button;
		public MouseButtonPressed () {}
		public MouseButtonPressed (MouseButtons btn)
		{
			button = btn;
		}
	}
}

