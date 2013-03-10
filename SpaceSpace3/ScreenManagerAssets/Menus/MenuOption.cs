using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreenAssets.Menus
{
    class MenuOption
    {
        string _text;
        Rectangle _buttonBox;
        Color _backgroundColor;
        Color _textColor;
        Color _selectedColor;
        SpriteFont _spritefont;

        bool _isSelected = false;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        public Color Color
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value;}
        }
        public float buttonLayer = .5f;
        public float textLayer = 1;

        public MenuOption(string text, Rectangle tangle, Color backgroundColor, Color textColor, SpriteFont spritefont)
        {
            _text = text;
            _buttonBox = tangle;
            _backgroundColor = backgroundColor;
            _textColor = textColor;
            _spritefont = spritefont;

            //invert the normal color
            _selectedColor = new Color(0xFF - _backgroundColor.R, 0xFF - _backgroundColor.G, 0xFF - _backgroundColor.B);
        }

        public void draw(SpriteBatch spritebatch, GameTime gametime)
        {
            //make an array of colors equal to the amount of pixels in the box then set the texture to it
            Color[] color;
            if (_isSelected)
            {
                color = Enumerable.Range(0, _buttonBox.Width * _buttonBox.Height).Select(i => _selectedColor).ToArray();
            }
            else
            {
                color = Enumerable.Range(0, _buttonBox.Width * _buttonBox.Height).Select(i => _backgroundColor).ToArray();
            }
            Texture2D texture = new Texture2D(spritebatch.GraphicsDevice, _buttonBox.Width, _buttonBox.Height, false, SurfaceFormat.Color);
            texture.SetData(color);

            spritebatch.Draw(
                texture,
                new Vector2(
                    _buttonBox.Location.X,
                    _buttonBox.Location.Y),
                    null,
                    Color.White,
                    0,
                    new Vector2(0,0),
                    1,
                    SpriteEffects.None,
                    buttonLayer);

            spritebatch.DrawString(_spritefont, _text,
                                    new Vector2(_buttonBox.Location.X + _buttonBox.Width / 2 - _spritefont.MeasureString(_text).X/2,
                                        _buttonBox.Location.Y + _buttonBox.Height / 2 - _spritefont.MeasureString(_text).Y/2),
                                        _textColor,
                                        0,
                                        new Vector2(0, 0),
                                        1,
                                        SpriteEffects.None,
                                        textLayer);

        }
    }
}
