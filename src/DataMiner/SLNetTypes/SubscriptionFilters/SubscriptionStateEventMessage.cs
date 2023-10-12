using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Subscription state event message.
	/// </summary>
	[Serializable]
    public class SubscriptionStateEventMessage
    {
		/// <summary>
		/// Prevents a default instance of the <see cref="SubscriptionStateEventMessage"/> class from being created.
		/// </summary>
		private SubscriptionStateEventMessage()
        {
            MarkerIDs = new int[0];
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SubscriptionStateEventMessage"/> class.
		/// </summary>
		/// <param name="markerIDs">The marker IDs.</param>
		/// <param name="stage">The stage.</param>
		public SubscriptionStateEventMessage(int[] markerIDs, SubscriptionStage stage)
        {
        }

		/// <summary>
		/// Gets the IDs matching the ones from SubscriptionUpdateResponseMessage
		/// </summary>
		/// <value>The IDs matching the ones from SubscriptionUpdateResponseMessage</value>
		public int[] MarkerIDs { get; }

		/// <summary>
		/// Gets the stage the subscription update is in.
		/// </summary>
		/// <value>The stage the subscription update is in.</value>
		public SubscriptionStage Stage { get; }

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
        {
            return String.Empty;
        }
    }

	/// <summary>
	/// Subscription stage
	/// </summary>
	[Serializable]
    public enum SubscriptionStage
    {
		/// <summary>
		/// Undefined.
		/// </summary>
		Undefined,

        /// <summary>
        /// Before starting the update of the registered filters for the connection.
        /// </summary>
        StartUpdating,

        /// <summary>
        /// All registered filters have been updated. 
        /// Before sending initial events
        /// </summary>
        EndUpdating,

        /// <summary>
        /// All initial events have been sent.
        /// </summary>
        AfterInitialEvents,

        /// <summary>
        /// Last subscription state that will be sent for an update.
        /// </summary>
        Finished
    }
}
