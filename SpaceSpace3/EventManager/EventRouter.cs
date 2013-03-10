using System;
using System.Collections.Generic;
using System.Collections;

namespace EventManagerr
{
	public class EventRouter
	{
		Dictionary<Event, List<Listener>> EventListeners = new Dictionary<Event, List<Listener>>();

		public EventRouter ()
		{
		}

		/// <summary>
		/// Processes the event. ALSO THIS AUTOCOMPLETE IS DEVIL MAGIC
		/// </summary>
		/// <returns>
		/// <c>true</c>, if event was processed, <c>false</c> otherwise.
		/// </returns>
		/// <param name='e'>
		/// The event to be processed.
		/// </param> 
		public bool ProcessEvent(Event e)
		{
			if (!EventListeners.ContainsKey (e))
				return false;
			
			//call each listener registered to this event type
			foreach (Listener l in EventListeners[e]) {
				l.OnEvent (e);
				if (e.isDoneProcessing)
					break;
			}

			return true;
		}
		
		public void AddListener(Event e, Listener l)
		{
			if (!EventListeners.ContainsKey(e))
				EventListeners.Add (e, new List<Listener>());
			EventListeners[e].Add (l);
		}
		
		public void RemoveListener(Event e, Listener l)
		{
			//TODO: Implement this
			EventListeners[e].Remove(l);
		}
		
		public void ClearListeners ()
		{
			EventListeners.Clear();
		}
	}
}

