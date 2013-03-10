using System;

using Utils;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;
using Drawable;

namespace SpaceSpace2
{
	public class Room
	{
		#if Windows
		const string LevelContentPath = "\\Levels\\";
		#else
		const string LevelContentPath = "Content/Levels/";
		#endif

		public struct DoorLink
		{
			public string roomLink; //room this door should lead to
			public int doornum; //id of the door in this room
			public int doorLink; //id of the door in the room this door leads to
		}

		public string roomName = "";
		public Vec2<int> size = new Vec2<int>();
		public Door[] doors;
		public Vec2<int> landing; //used for the start position and teleporters if they are ever implemented
		int[] tileData;
		bool[] collisionData;
		SpriteSheet tiles;

		public Room (SpriteSheet ss)
		{
			tiles = ss;
		}

		/// <summary>
		/// Loads the room.
		/// </summary>
		/// <returns>
		/// An array to the rooms connected to this one, and the door that leads to them.
		/// </returns>
		/// <param name='roomname'>
		/// Roomname.
		/// </param>
		public List<DoorLink> loadRoom (string roomname)
		{
			roomName = roomname;
			List<DoorLink> retList = new List<DoorLink>();

			XmlTextReader reader = new XmlTextReader (LevelContentPath + roomname + ".oel");
			reader.MoveToContent ();

			//first and only node should be named "level"
			if (reader.Name != "level")
				throw new Exception ("Found an unexpected node: " + reader.Name);

			//get the width and height attributes from it
			size.x = Convert.ToInt32 (reader.GetAttribute ("width"));
			size.y = Convert.ToInt32 (reader.GetAttribute ("height"));

			//move to the next node and parse it
			//reader.MoveToContent();

			//there should only be 3 main nodes to read
			while(reader.Read()) {
				switch (reader.Name) {
				case "Tiles":
					//read in the data (it should be a csv)
					tileData = ArrayManip.parseCSV(reader.ReadElementString(), size.x * size.y / (32*32));
					break;
				case "Collision":
					//read in the string of 1's and 0's. skip all \n's
					collisionData = new bool[size.x * size.y / (32*32)];
					string colStr = reader.ReadElementString();
					for(int i = 0, j = 0; i < collisionData.Length; i++, j++)
					{
						if(colStr[j] == '\n')
						{
							//skip it but keep our array at the same spot
							i--;
							continue;
						}
						collisionData[i] = Convert.ToInt32(colStr[j]) == 1;
					}
					break;
				case "Landing":
					//make a new landing with the parsed info
					landing = new Vec2<int>(Convert.ToInt32(reader.GetAttribute("x")), 
					                        Convert.ToInt32(reader.GetAttribute("y")));
					break;
				case "Door":
					//add this door to the list of door links in this room
					DoorLink dl = new DoorLink();
					dl.doornum = Convert.ToInt32(reader.GetAttribute("DoorNum"));
					dl.roomLink = reader.GetAttribute("RoomLink");
					dl.doorLink = Convert.ToInt32(reader.GetAttribute("DoorLink"));

					retList.Add(dl);
					break;
				}
			}

			return retList;                
		}

		public bool collidesWithTile (Vec2<int> pos)
		{
			int index = pos.x/32 + (pos.y/32)*(size.x/32);
			if(index > collisionData.Length || index < 0)
				return true;
			else
				return collisionData[index];
		}

		public void draw (SpriteBatch sb, Rectangle camera)
		{
			for (int i = 0; i < size.x/32; i++) {
				for(int j = 0; j < size.y/32; j++)
				{
					tiles.Draw(sb, tileData[i + j*32], new Vec2<int>(i*32, j*32), camera);
				}
			}
		}
	}
}

