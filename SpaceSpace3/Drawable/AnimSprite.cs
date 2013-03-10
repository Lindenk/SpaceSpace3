using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Utils;

namespace Drawable
{
	public class AnimSprite : BaseSprite
	{		
		public AnimSprite(ContentManager CM, String assetName)
			:base(CM, assetName)
		{

		}

		public AnimSprite(Texture2D texture)
			:base(texture)
		{
			
		}

		public AnimSprite(ContentManager CM, String assetName, Vector position, Vector scale)
			:base(CM, assetName, position, scale)
		{
			
		}

		
	}
}

