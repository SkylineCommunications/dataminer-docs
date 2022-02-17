using System;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Messages that are sent by subscribers, requesting a response message of some kind.
	/// </summary>
	[Serializable]
	public abstract class ClientRequestMessage : DMSMessage
	{
		/// <summary>
		/// Required for serialization
		/// </summary>
		protected ClientRequestMessage() { }
	}
}
