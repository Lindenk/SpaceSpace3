using System;
using NUnit.Framework;

using SpaceSpace2;
using Drawable;

namespace RoomTesting
{
	[TestFixture()]
	public class Unittest
	{
		[Test()]
		public void TestRoomLoading ()
		{
			Room r = new Room(new SpriteSheet("Tiles", 32, 32));
			r.loadRoom("Template");
		}
	}
}

