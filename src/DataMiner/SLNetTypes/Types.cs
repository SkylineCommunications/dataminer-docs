using System;

namespace Skyline.DataMiner.Net.Messages
{
	[Serializable]
	public abstract class DMSMessage
	{
		protected DMSMessage()
		{

		}

		public static readonly DMSMessage[] NoMessages = new DMSMessage[0];

		public static DMSMessage ExtractSingleResponse(DMSMessage[] msgs)
		{
			return null;
		}

		public static DMSMessage[] Combine(DMSMessage[] a, DMSMessage[] b)
		{
			return null;
		}

		public static bool NeedsLoggingForMessage(DMSMessage message)
		{
			return true;
		}
	}

	[Serializable]
	public class ExceptionMessage : DMSMessage
	{
		public Exception Exception;

		public ExceptionMessage() { }

		public ExceptionMessage(Exception exception)
		{
			this.Exception = exception;
		}
	}
}
