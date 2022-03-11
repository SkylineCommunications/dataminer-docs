using System;
using System.Xml.Serialization;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Abstract class grouping all messages that are sent in response to client request messages.
	/// You can also use <c>ResponseMessageWithInfo</c> to add some error info to the response.
	/// </summary>
	[Serializable]
	public abstract class ResponseMessage : DMSMessage
	{
		protected ResponseMessage() { }
	}
}