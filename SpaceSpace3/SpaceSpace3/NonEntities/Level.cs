using System;

using ScreenAssets;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Drawable;
using Utils;
using Main;

namespace SpaceSpace2
{
	public abstract class Level : Screen
	{
		public struct Camera
		{
			public int height, width, x, y;
		}

		protected Room[] rooms;
		protected Room currentRoom;
		protected Camera camera = new Camera();
		protected SpriteSheet tiles;
		protected Player player;

		public Level ()
		{
			player = new Player(this, new Vec2<int>(0, 0));
		}

		protected void initailizeRooms (string startRoom)
		{
			//create a map for dealing with door relations when done loading
			Dictionary<string, List<Room.DoorLink>> doormap = new Dictionary<string, List<Room.DoorLink>> ();

			//create a temp list to hold rooms as we load them
			List<Room> loadedRooms = new List<Room> ();
			//find and load every room connected using a bredth-first search
			Queue<string> roomnames = new Queue<string> ();
			roomnames.Enqueue (startRoom);

			//load the given room and all rooms connected to in once and store them in rooms[]
			while (roomnames.Count > 0) {
				//load the next room to be loaded
				Room cRoom = new Room (tiles);
				List<Room.DoorLink> nextRooms = cRoom.loadRoom (roomnames.Dequeue ());
				loadedRooms.Add(cRoom);
				//add the door data to the map
				if(nextRooms.Count > 0)
					doormap.Add (cRoom.roomName, nextRooms);

				//add only the rooms to the queue that we have not loaded
				foreach (Room.DoorLink dr in nextRooms) {
					bool alreadyLoaded = false;

					foreach (Room r in loadedRooms) {
						if (dr.roomLink == r.roomName) {
							alreadyLoaded = true;
							break;
						}
					}
					if (!alreadyLoaded) {
						//enqueue the room to be loaded
						roomnames.Enqueue (dr.roomLink);
					}
				}
			}

			//move all the found rooms into the rooms array
			rooms = loadedRooms.ToArray ();

			//create a door relation, perhaps this can be made more efficient later
			foreach (var e in doormap) {
				//find the room this name refers to. Throw an error if not found
				Room cRoom = findRoom(e.Key, loadedRooms);
				List<Door> doors = new List<Door>();

				foreach(var v in e.Value)
				{
					//make a new door and copy over the data
					Door d = new Door();
					d.doornum = v.doornum;
					//find the linked room
					d.linkedRoom = findRoom(v.roomLink, loadedRooms);
					doors.Add(d);
				}

				//set the doors of the room to reflect this
				cRoom.doors = doors.ToArray();
			}

			//define the current room
			currentRoom = loadedRooms[0];
			//set the player to the landing
			player.position = new Vec2<int>(currentRoom.landing.x, currentRoom.landing.y);
		}

		private Room findRoom (string roomname, IEnumerable<Room> rooms)
		{
			Room retRoom = null;

			foreach(Room r in rooms)
			{
				if(r.roomName == roomname)
					retRoom = r;
			}
			
			if(retRoom == null)
				throw new Exception("Could not find room to link with: " + roomname);

			return retRoom;
		}

		/// <summary>
		/// Moves to.
		/// </summary>
		/// <returns>
		/// A vec2 containing the new position to move to.
		/// </returns>
		/// <param name=''>
		/// .
		/// </param>
		public Vec2<int> MoveTo (Vec2<int> prevPos, Vec2<int> nextPos)
		{
			Vec2<int> retVec;

			//check collisions
			//see if the sprite will collide with a collidable tile

			if (currentRoom.collidesWithTile (nextPos)) {
				//find the collision point on the vector from sprite.pos to nextPos
				//Vec2<int> wallVec = 
				//find the would-be x position if the y value was moved to the surface
				//int x = 

				retVec = new Vec2<int>(0, 0);
			} else {
				retVec = new Vec2<int>(nextPos.x, nextPos.y);
			}

			Console.WriteLine("Sprite pos: x: " + retVec.x + ", y: " + retVec.y);

			return retVec;
		}

		#region implemented abstract members of Screen

		public override Screen update ()
		{
			player.Update();

			return null;
		}

		public override void draw (SpriteBatch spriteBatch, GameTime gametime)
		{
			player.Draw(gametime, spriteBatch);

			//for now camera just assumes the size of the screen
			//find the position the camera should be at (shouldn't go off an edge)
			int x = (int)(player.position.x - Game1.g_game.ScreenSize.X/2);
			int y = (int)(player.position.y - Game1.g_game.ScreenSize.Y/2);
			x = x > 0 ? x : 0;
			x = x < currentRoom.size.x ? x : currentRoom.size.x;
			y = y > 0 ? y : 0;
			y = y < currentRoom.size.y ? y : currentRoom.size.y;
			currentRoom.draw(spriteBatch, new Rectangle(x, y, 
												(int)Game1.g_game.ScreenSize.X, (int)Game1.g_game.ScreenSize.Y));
		}

		#endregion
	}
}

