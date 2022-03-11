namespace Skyline.DataMiner.Library.Common
{
	using Net.Messages;

	using Skyline.DataMiner.Net;

	using System;

	/// <summary>
	/// Defines methods to send messages to a DataMiner System.
	/// </summary>
	public interface ICommunication
	{
		/// <summary>
		/// Add an SLNet Subscription Handler without a filter.
		/// </summary>
		/// <param name="handler">The handler containing the action to be performed when the event triggers.</param>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		void AddSubscriptionHandler(NewMessageEventHandler handler);

		/// <summary>
		/// Add an SLNet Subscription.
		/// </summary>
		/// <param name="handler">The handler containing the action to be performed when the event triggers.</param>
		/// <param name="handleGuid">A unique identifier for the handler.</param>
		/// <param name="subscriptions">All the subscription filters that define when to trigger an event.</param>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/>, <paramref name="handleGuid"/> or <paramref name="subscriptions"/> is <see langword="null"/>.</exception>
		void AddSubscriptions(NewMessageEventHandler handler, string handleGuid, SubscriptionFilter[] subscriptions);

		/// <summary>
		/// Clear an SLNet Subscription.
		/// </summary>
		/// <param name="handler">The handler containing the action to be cleared.</param>
		///  <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>..</exception>
		void ClearSubscriptionHandler(NewMessageEventHandler handler);

		/// <summary>
		/// Clear an SLNet Subscription.
		/// </summary>
		/// <param name="handler">The handler containing the action to be cleared.</param>
		/// <param name="handleGuid">A unique identifier for the handler to be cleared.</param>
		/// <param name="replaceWithEmpty">Indicates if the handler should be replaced with an empty handler after removal.</param>
		///  <exception cref="ArgumentNullException"><paramref name="handler"/>, <paramref name="handleGuid"/> is <see langword="null"/>.</exception>
		void ClearSubscriptions(NewMessageEventHandler handler, string handleGuid, bool replaceWithEmpty = false);

		/// <summary>
		/// Sends a message to the SLNet process that can have multiple responses.
		/// </summary>
		/// <param name="message">The message to be sent.</param>
		/// <exception cref="ArgumentNullException">The message cannot be null.</exception>
		/// <returns>The message responses.</returns>
		DMSMessage[] SendMessage(DMSMessage message);

		/// <summary>
		/// Sends a message to the SLNet process that returns a single response.
		/// </summary>
		/// <param name="message">The message to be sent.</param>
		/// <exception cref="ArgumentNullException"><paramref name="message"/> is <see langword="null"/>.</exception>
		/// <returns>The message response.</returns>
		DMSMessage SendSingleResponseMessage(DMSMessage message);

		/// <summary>
		/// Sends a message to the SLNet process that returns a single response.
		/// </summary>
		/// <param name="message">The message to be sent.</param>
		/// <exception cref="ArgumentNullException"><paramref name="message"/> is <see langword="null"/>.</exception>
		/// <returns>The message response.</returns>
		DMSMessage SendSingleRawResponseMessage(DMSMessage message);
	}
}