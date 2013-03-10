using System;
using Drawable;

using SpaceSpace2.Levels;

namespace SpaceSpace2
{
	public class SceneIngame : Scene
	{
		public SceneIngame ()
		{
			//push on the level screen
			this.pushScreen(new Background("background"));
			this.pushScreen(new Level1());
		}
	}
}

