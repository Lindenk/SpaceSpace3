using System;

namespace EventManagerr
{
	//using OnGO = Listener.OnEvent;

	public interface Listener
	{
		void OnEvent(Event e);
	}
}

