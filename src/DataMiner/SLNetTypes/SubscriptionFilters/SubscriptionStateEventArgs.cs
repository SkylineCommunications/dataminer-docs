using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Event arguments for use with <see cref="IConnection.OnSubscriptionState"/>.
    /// </summary>
    public class SubscriptionStateEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new <see cref="SubscriptionCompleteEventArgs"/> instance.
        /// </summary>
        /// <param name="rawEvent"></param>
        public SubscriptionStateEventArgs(SubscriptionStateEventMessage rawEvent)
        {
            RawEvent = rawEvent ?? throw new ArgumentNullException(nameof(rawEvent));
        }

		/// <summary>
		/// Gets the stage.
		/// </summary>
		/// <value>
		/// The stage.
		/// </value>
		public SubscriptionStage Stage { get { return RawEvent.Stage; } }

		/// <summary>
		/// Gets the marker IDs.
		/// </summary>
		/// <value>
		/// The marker IDs.
		/// </value>
		public int[] MarkerIDs {  get { return RawEvent.MarkerIDs; } }

		/// <summary>
		/// Gets the raw event.
		/// </summary>
		/// <value>
		/// The raw event.
		/// </value>
		public SubscriptionStateEventMessage RawEvent { get; }

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
        {
            return RawEvent.ToString();
        }
    }
}
