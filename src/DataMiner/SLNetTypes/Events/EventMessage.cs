using System;

namespace Skyline.DataMiner.Net.Messages
{
	[Serializable]
	public abstract class EventMessage : DMSMessage
	{
		protected EventMessage() { }

		public virtual bool NeedsLogging { get { return true; } }

		public virtual double WeightHint
		{
			get { return 1; }
		}

	}
}