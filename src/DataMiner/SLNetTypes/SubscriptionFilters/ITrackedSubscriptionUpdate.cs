using Skyline.DataMiner.Net.Messages;

using System;

namespace Skyline.DataMiner.Net
{
	/// <summary>
	/// Tracked subscription update interface.
	/// </summary>
	/// <remarks>Allows adding handlers on specific events before launching the update.</remarks>
	public interface ITrackedSubscriptionUpdate
	{

		ITrackedSubscriptionUpdate OnStage(SubscriptionStage stage, Action action);

		/// <summary>
		/// Before updating subscription. Any events received via OnNewMessage up to this point are for the previous set of subscriptions.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns>Tracked subscription update.</returns>
		ITrackedSubscriptionUpdate OnStartUpdating(Action action);

		/// <summary>
		/// After updating subscription (before initial events from local cache have been received by the client). After this event, you can expect events for the subscription to come in via OnNewMessage.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns>Tracked subscription update.</returns>
		ITrackedSubscriptionUpdate OnEndUpdating(Action action);

		/// <summary>
		/// After initial events for the subscription have been received from the local event cache.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns>Tracked subscription update.</returns>
		ITrackedSubscriptionUpdate OnAfterInitialEvents(Action action);

		/// <summary>
		/// Update completed.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns>Tracked subscription update.</returns>
		ITrackedSubscriptionUpdate OnFinished(Action action);

		/// <summary>
		/// Executes this instance.
		/// </summary>
		/// <returns>DMS messages.</returns>
		DMSMessage[] Execute();

		/// <summary>
		/// Executes this instance and waits.
		/// </summary>
		/// <param name="timeout">The timeout.</param>
		/// <returns>DMS messages.</returns>
		DMSMessage[] ExecuteAndWait(TimeSpan? timeout = null);

		/// <summary>
		/// Gets the marker identifier.
		/// </summary>
		/// <value>
		/// The marker identifier.
		/// </value>
		int MarkerID { get; }
	}
}
