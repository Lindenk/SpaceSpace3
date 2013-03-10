using System;
using System.Reflection;

namespace EventManagerr
{
	abstract public class Event
	{
		//keep track of whether this event is done being processed
		public bool isDoneProcessing = false;

		//override basic comparision functions
		public override bool Equals(Object obj)
		{
			return this.GetType() == obj.GetType();
		}
		public override int GetHashCode ()
		{
			return this.ToString().GetHashCode();
		}
	}
}

