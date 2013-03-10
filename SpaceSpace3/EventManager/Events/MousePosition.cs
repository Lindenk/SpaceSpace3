using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EventManagerr.Events
{
	public class MousePosition : Event
	{
		public Point pos;
		public MousePosition (){}
		public MousePosition(Point p)
		{
			pos = p;
		}
	}
}

