using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net
{
	/// <summary>
	/// Connection closed handler delegate.
	/// </summary>
	/// <param name="reason">The reason.</param>
	public delegate void ConnectionClosedHandler(string reason);

	/// <summary>
	/// IConnection interface.
	/// </summary>
	public interface IConnection : IDisposable
	{
		/// <summary>
		/// Event that is raised when the connection gets closed. Useful when passing the connection to other threads that should be made aware when
		/// the connection is closed so that pending operations can be aborted.
		/// </summary>
		event ConnectionClosedHandler OnClose;

		/// <summary>
		/// Handles the specified message.
		/// </summary>
		/// <param name="msg">The message to handle.</param>
		/// <returns>The response message(s).</returns>
		DMSMessage[] HandleMessage(DMSMessage msg);

		/// <summary>
		/// Handles the specified messages.
		/// </summary>
		/// <param name="msgs">The message to handle.</param>
		/// <returns>The response message(s).</returns>
		DMSMessage[] HandleMessages(DMSMessage[] msgs);

		/// <summary>
		/// Handles the specified message.
		/// </summary>
		/// <param name="msg">The message to handle.</param>
		/// <returns>The response message.</returns>
		DMSMessage HandleSingleResponseMessage(DMSMessage msg);

		/// <summary>
		/// Creates a subscription using the specified subscription filters.
		/// </summary>
		/// <param name="filters">The subscription filters.</param>
		/// <returns>The subscription response message.</returns>
		CreateSubscriptionResponseMessage Subscribe(params SubscriptionFilter[] filters);

		/// <summary>
		/// Clears the subscriptions.
		/// </summary>
		/// <remarks>This method differs from <see cref="IConnection.ClearSubscriptions(string)"/> in that it will also stop the callback or polling. Typically, you will never need to call this method directly.</remarks>
		void Unsubscribe();

		/// <summary>
		/// Adds the specified subscription filters to the specified set.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		/// <param name="newFilters">The subscription filters to add.</param>
		void AddSubscription(string setID, params SubscriptionFilter[] newFilters);

		/// <summary>
		/// Removes the specified subscription filters from the specified set.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		/// <param name="deletedFilters">The subscription filters to remove.</param>
		void RemoveSubscription(string setID, params SubscriptionFilter[] deletedFilters);

		/// <summary>
		/// Replaces the subscriptions of the specified set with the specified subscription filters.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		/// <param name="newFilters">The subscription filters.</param>
		void ReplaceSubscription(string setID, params SubscriptionFilter[] newFilters);

		/// <summary>
		/// Clears the subscriptions for the specified set.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		void ClearSubscriptions(string setID);

		/// <summary>
		/// Tracks the specified subscription.
		/// </summary>
		/// <param name="filters">The subscription filters.</param>
		/// <returns>The tracked subscription update.</returns>
		ITrackedSubscriptionUpdate TrackSubscribe(params SubscriptionFilter[] filters);

		/// <summary>
		/// Tracks the add subscription.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		/// <param name="newFilters">The new filters.</param>
		/// <returns>The tracked subscription update.</returns>
		ITrackedSubscriptionUpdate TrackAddSubscription(string setID, params SubscriptionFilter[] newFilters);

		/// <summary>
		/// Tracks the remove subscription.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		/// <param name="deletedFilters">The deleted filters.</param>
		/// <returns>The tracked subscription update.</returns>
		ITrackedSubscriptionUpdate TrackRemoveSubscription(string setID, params SubscriptionFilter[] deletedFilters);

		/// <summary>
		/// Tracks the replace subscriptions.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		/// <param name="newFilters">The new filters.</param>
		/// <returns>The tracked subscription update.</returns>
		ITrackedSubscriptionUpdate TrackReplaceSubscription(string setID, params SubscriptionFilter[] newFilters);

		/// <summary>
		/// Tracks clear subscription.
		/// </summary>
		/// <param name="setID">The set ID.</param>
		/// <returns>The tracked subscription update.</returns>
		ITrackedSubscriptionUpdate TrackClearSubscriptions(string setID);

		/// <summary>
		/// Tracks the update subscription.
		/// </summary>
		/// <param name="multi">The subscription message.</param>
		/// <returns>The tracked subscription update.</returns>
		ITrackedSubscriptionUpdate TrackUpdateSubscription(UpdateSubscriptionMultiMessage multi);

		/// <summary>
		/// Occurs when a new message arrives. Main handler for incoming events.
		/// </summary>
		event NewMessageEventHandler OnNewMessage;

		/// <summary>
		/// Occurs on an abnormal close.
		/// </summary>
		event AbnormalCloseEventHandler OnAbnormalClose;

		/// <summary>
		/// Called when the server has dropped a series of events for a client. This happens when the server is unable to get the events to the client fast enough and typically indicates a problem on the server. The dropping of events does not close the connection. Instead, the Connection object is still valid. When this event has been fired on a connection, Cube will show a pop-up indicating that the state is incomplete.
		/// </summary>
		event EventsDroppedEventHandler OnEventsDropped;

		/// <summary>
		/// Fired after the server has completed applying a subscription update. If the client has launched multiple subscription updates after each other, there is no reference to which update is completed. Receiving this event also does not mean that all initial events from the cluster have been received by the client. It mainly means that the DataMiner Agent to which the client is directly connected is now aware of the subscription.
		/// </summary>
		event SubscriptionCompleteEventHandler OnSubscriptionComplete;

		/// <summary>
		/// Used internally for the Subscription Stages functionality. Using the TrackSubscribe API is preferred to using this event.
		/// </summary>
		event EventHandler<SubscriptionStateEventArgs> OnSubscriptionState;

		/// <summary>
		/// Gets the user domain name.
		/// </summary>
		/// <value>The user domain name.</value>
		string UserDomainName { get; }

		/// <summary>
		/// Gets the connection ID.
		/// </summary>
		/// <value>The connection ID.</value>
		Guid ConnectionID { get; }

		/// <summary>
		/// Gets a value indicating whether the connection is shutting down.
		/// </summary>
		/// <value><c>true</c> after the connection has been destroyed and during the destruction; otherwise, <c>false</c>.</value>
		/// <remarks>Once <c>true</c>, this connection object should no longer be used.</remarks>
		bool IsShuttingDown { get; }

		///// <summary>
		///// Supports sending asynchronous messages, waiting for responses on these
		///// as well as aborting them.
		///// </summary>
		//IAsyncMessageHandler Async { get; }

		/// <summary>
		/// Gets a value indicating whether the receiving thread is active
		/// </summary>
		/// <value>
		/// <c>true</c> if the receiving thread is active; otherwise, <c>false</c>.
		/// </value>
		bool IsReceiving { get; }

		/// <summary>
		/// Gets the server details.
		/// </summary>
		/// <value>The server details.</value>
		/// <remarks>Once authenticated, contains some details about the DataMiner Agent to which
		/// this object is connected (name, cluster, etc.).</remarks>
		ServerDetails ServerDetails { get; }

		///// <summary>
		///// Retrieves a value indication whether the specified feature is supported.
		///// </summary>
		///// <param name="flags">The feature.</param>
		///// <returns><c>true</c> if the feature is supported; otherwise, <c>false</c>.</returns>
		//bool SupportsFeature(CompatibilityFlags flags);

		///// <summary>
		///// Retrieves a value indication whether the specified feature is supported.
		///// </summary>
		///// <param name="name">The name of the feature.</param>
		///// <returns><c>true</c> if the feature is supported; otherwise, <c>false</c>.</returns>
		//bool SupportsFeature(string name);

		///// <summary>
		///// Retrieves the protocol of the specified element.
		///// </summary>
		///// <param name="dmaid">The Agent ID of the element.</param>
		///// <param name="eid">The element ID of the element.</param>
		///// <returns>The protocol of the specified element.</returns>
		//GetElementProtocolResponseMessage GetElementProtocol(int dmaid, int eid);

		/// <summary>
		/// Retrieves information about the specified protocol.
		/// </summary>
		/// <param name="name">The name of the protocol.</param>
		/// <param name="version">The version of the protocol.</param>
		/// <returns>A message containing the protocol info.</returns>
		GetProtocolInfoResponseMessage GetProtocol(string name, string version);

		//void FireOnAsyncResponse(AsyncResponseEvent responseEvent, ref bool handled);

		//DMSMessage[] UnPack(DMSMessage[] messages);

		//void SafeWait(int timeout);
	}
}
