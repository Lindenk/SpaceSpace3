using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Utils;

namespace Drawable
{
    public class BaseSprite
    {
        protected Texture2D _texture;
        protected Vector _position;
        protected Color _tint;
        protected Vector _scale;
        protected float _rotation;
        protected Vector _origin;
        protected SpriteEffects _spriteEffects;
        protected float _layerDepth;
        protected Rectangle _viewBox;

		public Texture2D Texture
		{
			get { return _texture; }
			set { _texture = value; }
		}

        public Color Tint
        {
            get { return _tint; }
            set { _tint = value; }
        }
        public Vector Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        public Vector Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        public SpriteEffects SpriteEffects
        {
            get { return _spriteEffects; }
            set { _spriteEffects = value; }
        }
        public float LayerDepth
        {
            get { return _layerDepth; }
            set { _layerDepth = value; }
        }
        public virtual Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Rectangle ViewBox
        {
            get { return _viewBox; }
            set { _viewBox = value; }
        }

        public virtual int Width
        {
            get { return (int)(_texture.Width * _scale.X); }
        }
        public virtual int Height
        {
            get { return (int)(_texture.Height * _scale.Y); }
        }


        public BaseSprite(ContentManager CM, String assetName)
        {

			init(CM.Load<Texture2D>(assetName));
            
        }
        public BaseSprite(Texture2D texture)
        {
            init(texture);
        }

		public BaseSprite (ContentManager CM, String assetName, Vector position, Vector scale)
		{
			init(CM.Load<Texture2D>(assetName));
			_position = position;
			_scale = scale;

		}

        private void init(Texture2D texture)
        {
            _texture = texture;
            _position = new Vector();
            _tint = Color.White;
            _viewBox = _texture.Bounds;
            _scale = new Vector(1, 1);
            _rotation = 0;
            _origin = new Vector();
            _spriteEffects = SpriteEffects.None;
            _layerDepth = 0;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture, 
                _position.toVector2(), 
                _viewBox, 
                _tint, 
                _rotation, 
                _origin.toVector2(), 
                _scale.toVector2(), 
                _spriteEffects, 
                _layerDepth);
        }


    }
}
