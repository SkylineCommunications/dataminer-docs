namespace Skyline.DataMiner.Library.Common.InterAppCalls.CallBulk
{
	using System;
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.InterAppCalls.CallSingle;
	using Skyline.DataMiner.Library.Common.Serializing;
	using Skyline.DataMiner.Net;

	/// <summary>
	/// Factory class that can create inter-app calls.
	/// </summary>
	public static class InterAppCallFactory
	{
		/// <summary>
		/// Creates an inter-app call from the specified string.
		/// </summary>
		/// <param name="rawData">The serialized raw data.</param>
		/// <returns>An inter-app call.</returns>
		/// <param name="serializer">Optional serializer to use. Leave empty to use default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is empty or null.</exception>
		/// <exception cref="ArgumentException">Format of <paramref name="rawData"/> is invalid and deserialization failed.</exception>
		public static IInterAppCall CreateFromRaw(string rawData, ISerializer serializer = null)
		{
			return null;
		}

		/// <summary>
		/// Creates an inter-app call from the specified string.
		/// </summary>
		/// <param name="rawData">The serialized raw data.</param>
		/// <returns>An inter-app call.</returns>
		/// <param name="interAppSerializer">Optional serializer to use for InterAppCall. Leave empty to use default.</param>
		/// <param name="messageSerializer">Optional serializer to use for Message. Leave empty to use default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is empty or null.</exception>
		/// <exception cref="ArgumentException">Format of <paramref name="rawData"/> is invalid and deserialization failed.</exception>
		public static IInterAppCall CreateFromRawAndAcceptMessage(string rawData, ISerializer interAppSerializer = null, ISerializer messageSerializer = null)
		{
			if (String.IsNullOrWhiteSpace(rawData))
			{
				throw new ArgumentNullException("rawData");
			}

			IInterAppCall returnedResult = null;

			return returnedResult;
		}

		/// <summary>
		/// Creates an inter-app call from the contents of the specified parameter.
		/// </summary>
		/// <param name="connection">The raw SLNet connection.</param>
		/// <param name="agentId">The source DataMiner Agent ID.</param>
		/// <param name="elementId">The source element ID.</param>
		/// <param name="parameterId">The source parameter ID.</param>
		/// <param name="serializer">Optional serializer to use. Leave empty to use default.</param>
		/// <returns>An inter-app call.</returns>
		/// <exception cref="ArgumentException">The format of the content of the specified parameter is invalid and deserialization failed.</exception>
		public static IInterAppCall CreateFromRemote(IConnection connection, int agentId, int elementId, int parameterId, ISerializer serializer = null)
		{
			IDms thisDms = connection.GetDms();
            var element = thisDms.GetElement(new DmsElementId(agentId, elementId));
            var parameter = element.GetStandaloneParameter<string>(parameterId);
            var returnedResultRaw = parameter.GetValue();

			return CreateFromRaw(returnedResultRaw, serializer);
		}

		/// <summary>
		/// Creates an inter-app call from the contents of the specified parameter.
		/// </summary>
		/// <param name="connection">The raw SLNet connection.</param>
		/// <param name="agentId">The source DataMiner Agent ID.</param>
		/// <param name="elementId">The source element ID.</param>
		/// <param name="parameterId">The source parameter ID.</param>
		/// <param name="interAppSerializer">Optional serializer to use for InterAppCall. Leave empty to use default.</param>
		/// <param name="messageSerializer">Optional serializer to use for Message. Leave empty to use default.</param>
		/// <returns>An inter-app call.</returns>
		/// <exception cref="ArgumentException">The format of the content of the specified parameter is invalid and deserialization failed.</exception>
		public static IInterAppCall CreateFromRemoteAndAcceptMessage(IConnection connection, int agentId, int elementId, int parameterId, ISerializer interAppSerializer = null, ISerializer messageSerializer = null)
		{
			IDms thisDms = connection.GetDms();
			IDmsElement element = thisDms.GetElement(new DmsElementId(agentId, elementId));
			IDmsStandaloneParameter<string> parameter = element.GetStandaloneParameter<string>(parameterId);
			string returnedResultRaw = parameter.GetValue();

			return CreateFromRawAndAcceptMessage(returnedResultRaw, interAppSerializer, messageSerializer);
		}

		/// <summary>
		/// Creates a blank inter-app call.
		/// </summary>
		/// <returns>An inter-app call.</returns>
		public static IInterAppCall CreateNew()
		{
			return new null;
		}
	}
}