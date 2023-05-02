using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Net.Messages
{
    /// <summary>
    /// Updates multiple subscription sets in one go.
    /// </summary>
    [Serializable]
    public class UpdateSubscriptionMultiMessage : ClientRequestMessage
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateSubscriptionMultiMessage"/> class.
		/// </summary>
		public UpdateSubscriptionMultiMessage()
        {
            this.Updates = new UpdateSubscriptionMessage[0];
        }

		/// <summary>
		/// Gets or sets the updates.
		/// </summary>
		/// <value>
		/// The updates.
		/// </value>
		public UpdateSubscriptionMessage[] Updates { get; set; }

        /// <summary>
        /// Gets or sets the marker ID.
        /// </summary>
        /// <value>The marker ID.</value>
        public int MarkerID { get; internal set; }

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
}
