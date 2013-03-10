#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Utils;
using SpaceSpace2;
using Drawable;

#endregion

namespace Main
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		public static Game1 g_game;
		public GameTime gametime;
		public Vector ScreenSize
		{
			get{ return screenSize; }
		}
		public ContentManager CM {
			get{ return cm; }
		}

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Vector screenSize;
		ContentManager cm;
		public InputManager im;

		Scene currentScene;

		public Game1 ()
		{
			g_game = this;
			gametime = new GameTime();

			graphics = new GraphicsDeviceManager (this);
			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 500;
			graphics.ApplyChanges();

			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;

			screenSize = new Vector(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 0);
			cm = Content;

			im = new InputManager();
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			base.Initialize ();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			currentScene = new SceneIngame();
			//TODO: use this.Content to load your game content here 
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			gametime = gameTime;
			im.update();
			EventManagerr.EventManager.g_EM.Update(currentScene);
			currentScene.update();

			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
		
			spriteBatch.Begin(SpriteSortMode.Immediate, null);
			currentScene.draw(spriteBatch, gametime);
			spriteBatch.End();
            
			base.Draw (gameTime);
		}
	}
}

