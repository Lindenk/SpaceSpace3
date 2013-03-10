using System;

using Main;
using Drawable;

namespace SpaceSpace2.Levels
{
	public class Level1 : Level
	{
		public Level1 ()
		{
			//load assets needed for this level
			tiles = new SpriteSheet("Tiles", 32, 32);

			//setup the rooms of level1
			initailizeRooms("StartZone");
		}


	}
}

