namespace Skyline.DataMiner.Library.Common.InterAppCalls.CallBulk
{
	using Skyline.DataMiner.Library.Common.InterAppCalls.CallSingle;
	using Skyline.DataMiner.Library.Common.InterAppCalls.Shared;
	using Skyline.DataMiner.Library.Common.Serializing;
	using Skyline.DataMiner.Net;

	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Represents an inter-app call containing multiple messages.
	/// </summary>
	public interface IInterAppCall
	{
		/// <summary>
		/// Gets or sets a globally unique identifier (GUID) identifying this inter-app call.
		/// </summary>
		/// <value>A globally unique identifier (GUID) identifying this inter-app call.</value>
		string Guid { get; set; }

		/// <summary>
		/// The serializer used internally to convert data to and from a class model.
		/// </summary>
		ISerializer InternalSerializer { get; set; }

		/// <summary>
		/// Gets or sets all messages of this inter-app call.
		/// </summary>
		/// <value>The messages of this inter-app call.</value>
		Messages Messages { get; }

		/// <summary>
		/// Gets or sets the time this call was received.
		/// </summary>
		/// <value>The time this call was received.</value>
		DateTime ReceivingTime { get; set; }

		/// <summary>
		/// Gets or sets the return address.
		/// </summary>
		/// <value>The return address.</value>
		/// <remarks>The return address represents a parameter on a specific element (identified by a DataMiner Agent ID, element ID and parameter ID) that will be checked for a return message. This use of this property is optional.</remarks>
		ReturnAddress ReturnAddress { get; set; }

		/// <summary>
		/// Gets the time this call was sent.
		/// </summary>
		/// <value>The time this call was sent.</value>
		DateTime SendingTime { get; }

		/// <summary>
		/// Gets or sets the source of this call.
		/// </summary>
		/// <value>The source of this call.</value>
		Source Source { get; set; }

		/// <summary>
		/// Sends this call via SLNet to the specified DataMiner Agent ID/element ID/parameter ID without waiting on a reply.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">Element ID of the destination.</param>
		/// <param name="parameterId">Parameter ID of the destination.</param>
		/// <exception cref="InvalidOperationException">The state of the specified element is not "Active".</exception>
		void Send(IConnection connection, int agentId, int elementId, int parameterId);

		/// <summary>
		/// Sends this call via SLNet to the specific DataMiner Agent ID/element ID/parameter ID and waits until timeout for a single reply for each message.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">Element ID of the destination.</param>
		/// <param name="parameterId">Parameter ID of the destination.</param>
		/// <param name="timeout">Maximum time to wait between received replies. Resets each time a reply is received.</param>
		/// <returns>The responses.</returns>
		/// <exception cref="InvalidOperationException">The state of the specified element is not "Active".</exception>
		/// <exception cref="InvalidOperationException">ReturnAddress is not filled in.</exception>
		IEnumerable<Message> Send(IConnection connection, int agentId, int elementId, int parameterId, TimeSpan timeout);

		/// <summary>
		/// Sends this call via SLNet to the specified DataMiner Agent ID/element ID/parameter ID without waiting on a reply.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">Element ID of the destination.</param>
		/// <param name="parameterId">Parameter ID of the destination.</param>
		/// <param name="serializer">A custom serializer to be used internally.</param>
		/// <exception cref="InvalidOperationException">The state of the specified element is not "Active".</exception>
		void Send(IConnection connection, int agentId, int elementId, int parameterId, ISerializer serializer);

		/// <summary>
		/// Sends this call via SLNet to the specific DataMiner Agent ID/element ID/parameter ID and waits until timeout for a single reply for each message.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">Element ID of the destination.</param>
		/// <param name="parameterId">Parameter ID of the destination.</param>
		/// <param name="timeout">Maximum time to wait between received replies. Resets each time a reply is received.</param>
		/// <param name="serializer">A custom serializer to be used internally.</param>
		/// <returns>The responses.</returns>
		/// <exception cref="InvalidOperationException">The state of the specified element is not "Active".</exception>
		/// <exception cref="InvalidOperationException">ReturnAddress is not filled in.</exception>
		IEnumerable<Message> Send(IConnection connection, int agentId, int elementId, int parameterId, TimeSpan timeout, ISerializer serializer);

		/// <summary>
		/// Serializes this call as a string.
		/// </summary>
		/// <returns>The string representing this serialized call.</returns>
		string Serialize();
	}
}