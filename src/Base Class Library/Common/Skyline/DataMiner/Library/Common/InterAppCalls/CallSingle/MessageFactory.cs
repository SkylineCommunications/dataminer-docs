namespace Skyline.DataMiner.Library.Common.InterAppCalls.CallSingle
{
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.Serializing;
	using Skyline.DataMiner.Net;

	using System;

	/// <summary>
	/// A static factory to create a single <see cref="Message"/>.
	/// </summary>
	public static class MessageFactory
	{
		/// <summary>
		/// Creates a message from a raw serialized string.
		/// </summary>
		/// <param name="rawData">The serialized raw data.</param>
		/// <param name="serializer">Optional serializer to use. Leave empty to use default.</param>
		/// <returns>The message.</returns>
		/// <exception cref="ArgumentException">Format of <paramref name="rawData"/> is invalid and deserialization failed.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> was <see langword="null"/> or empty.</exception>
		public static Message CreateFromRaw(string rawData, ISerializer serializer = null)
		{
			if (String.IsNullOrWhiteSpace(rawData)) throw new ArgumentNullException("rawData");
			if (serializer == null) serializer = SerializerFactory.CreateInterAppSerializer(typeof(Message));
			var returnedResult = serializer.DeserializeFromString<Message>(rawData);
			returnedResult.InternalSerializer = serializer;

			return returnedResult;
		}

		/// <summary>
		/// Creates a message from the content of a remote parameter. The value of this parameter should contain a serialized message created with the InterAppSerializer.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="dataMinerId">The DataMiner Agent ID of the remote parameter.</param>
		/// <param name="elementId">The element ID of the remote parameter.</param>
		/// <param name="parameterId">The parameter ID of the remote parameter.</param>
		/// <param name="serializer">Optional serializer to use. Leave empty to use default.</param>
		/// <returns>The deserialized message.</returns>
		/// <exception cref="ArgumentException">The format of the content of the specified parameter is invalid and deserialization failed.</exception>
		public static Message CreateFromRemote(IConnection connection, int dataMinerId, int elementId, int parameterId, ISerializer serializer = null)
		{
			IDms thisDms = connection.GetDms();
			var element = thisDms.GetElement(new DmsElementId(dataMinerId, elementId));
			var parameter = element.GetStandaloneParameter<string>(parameterId);
			var returnedResultRaw = parameter.GetValue();

			return CreateFromRaw(returnedResultRaw, serializer);
		}

		/// <summary>
		/// Creates an instance of <see cref="Message"/> with a new GUID created using the <see cref="System.Guid.NewGuid"/>.
		/// </summary>
		/// <returns>An instance of <see cref="Message"/> with a new GUID created using the <see cref="System.Guid.NewGuid"/>.</returns>
		public static Message CreateNew()
		{
			return new Message();
		}

		internal static bool TryCreateFromRaw(string rawData, out Message message, ISerializer serializer = null)
		{
			try
			{
				message = CreateFromRaw(rawData, serializer);
				return true;
			}
			catch (Exception)
			{
				message = default(Message);
				return false;
			}
		}
	}
}