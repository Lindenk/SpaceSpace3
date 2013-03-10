using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Drawable;
using ScreenAssets;

namespace EventManagerr
{
	public class EventManager
	{
		public static EventManager g_EM;

		EventRouter router = new EventRouter();
		Queue<Event> Events = new Queue<Event>();

		static EventManager()
		{
			g_EM = new EventManager();
		}

		public EventManager(){}

		public void QueueEvent(Event e)
		{
			Events.Enqueue(e);
		}

		public void Update (Scene scene)
		{
			//process all active events
			try {
				//pop the next event in the queue
				while (Events.Count > 0) {
					var e = Events.Peek ();
					Events.Dequeue ();

					router.ProcessEvent(e);

					//update scene if it exists
					if(scene == null)
						continue;

					foreach (Screen s in scene.getUpdatableScreens()) {
						s.eventRouter.ProcessEvent(e);
					}
				}
			} catch (InvalidOperationException e) {
			}
		}

		public void AddListener(Event e, Listener l)
		{
			router.AddListener(e, l);
		}
		
		public void RemoveListener(Event e, Listener l)
		{
			//TODO: Implement this
			router.RemoveListener(e, l);
		}
		
		public void ClearListeners ()
		{
			router.ClearListeners();
		}
	}
}

