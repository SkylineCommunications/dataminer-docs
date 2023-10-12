using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Delegate used for the <see cref="IConnection.OnSubscriptionComplete"/> event of the <see cref="IConnection"/> interface.
    /// </summary>
    public delegate void SubscriptionCompleteEventHandler(Object sender, SubscriptionCompleteEventArgs e);

    /// <summary>
    /// Event arguments for use with <see cref="SubscriptionCompleteEventHandler"/>.
    /// </summary>
    /// <remarks>
    /// <seealso cref="IConnection.OnSubscriptionComplete"/>
    /// </remarks>
    public class SubscriptionCompleteEventArgs : EventArgs
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="SubscriptionCompleteEventArgs"/> class.
		/// </summary>
		/// <param name="setID">ID of the subscription set that was updated.</param>
		public SubscriptionCompleteEventArgs(String setID)
        {
            this.SetID = setID;
        }

		/// <summary>
		/// Gets the ID of the subscription set that was updated.
		/// </summary>
		/// <value>The ID of the subscription set that was updated.</value>
		public string SetID { get; private set; }
    }

}
