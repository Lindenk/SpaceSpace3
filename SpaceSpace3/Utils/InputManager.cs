using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using EventManagerr;
using EventManagerr.Events;

namespace Utils
{
    public class InputManager
    {
		//stuff
		List<Keys> activeButtons = new List<Keys>();

		KeyboardState currentKeyState = Keyboard.GetState();
		KeyboardState prevKeyState = Keyboard.GetState();

		MouseState currentMouseState = Mouse.GetState();
		MouseState prevMouseState = Mouse.GetState();


		//functions
		public void addActiveButton (Keys btn)
		{
			activeButtons.Add(btn);
		}
		public void clearActiveButtons ()
		{
			activeButtons.Clear();
		}
		public void removeActiveButton (Keys btn)
		{
			activeButtons.Remove(btn);
		}

        public void update ()
		{
			//update pressed keys and mouse state
			prevKeyState = currentKeyState;
			currentKeyState = Keyboard.GetState ();

			prevMouseState = currentMouseState;
			currentMouseState = Mouse.GetState ();

			//queue events based on new button presses and releases
			foreach (Keys b in activeButtons) {
				if (currentKeyState.IsKeyDown (b) != prevKeyState.IsKeyDown (b)) {
					if (currentKeyState.IsKeyDown (b))
						EventManager.g_EM.QueueEvent (new KeyboardButtonPressed (b));
					else
						EventManager.g_EM.QueueEvent (new KeyboardButtonReleased (b));
				}
			}

			//queue a mouse position event
//			Mouse.POINT mousePos;
//			Mouse.GetCursorPos(out mousePos)
			MouseState mouseState = Mouse.GetState();
			EventManager.g_EM.QueueEvent(new MousePosition(new Point(mouseState.X, mouseState.Y)));

			//queue mouse state events
			if (!currentMouseState.Equals(prevMouseState)) {
				//check left mouse button
				if(currentMouseState.LeftButton != prevMouseState.LeftButton)
				{
					if(currentMouseState.LeftButton == ButtonState.Pressed)
						EventManager.g_EM.QueueEvent(new MouseButtonPressed(MouseButtons.Left));
					else
						EventManager.g_EM.QueueEvent(new MouseButtonReleased(MouseButtons.Left));
				}
				//check right mouse button
				if(currentMouseState.MiddleButton != prevMouseState.MiddleButton)
				{
					if(currentMouseState.MiddleButton == ButtonState.Pressed)
						EventManager.g_EM.QueueEvent(new MouseButtonPressed(MouseButtons.Middle));
					else
						EventManager.g_EM.QueueEvent(new MouseButtonReleased(MouseButtons.Middle));
				}
				//check middle mouse button
				if(currentMouseState.RightButton != prevMouseState.RightButton)
				{
					if(currentMouseState.RightButton == ButtonState.Pressed)
						EventManager.g_EM.QueueEvent(new MouseButtonPressed(MouseButtons.Right));
					else
						EventManager.g_EM.QueueEvent(new MouseButtonReleased(MouseButtons.Right));
				}
			}
        }
    }
}
