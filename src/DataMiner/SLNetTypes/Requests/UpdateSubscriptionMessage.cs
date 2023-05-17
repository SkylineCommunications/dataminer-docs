using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Updates the previous set of subscription filters for a client  with a new set.
	/// </summary>
	[Serializable]
	public class UpdateSubscriptionMessage : ClientRequestMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateSubscriptionMessage"/> class.
		/// </summary>
		public UpdateSubscriptionMessage()
        {
            this.Filters = new SubscriptionFilter[0];
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateSubscriptionMessage"/> class.
		/// </summary>
		/// <param name="filters">The filters.</param>
		public UpdateSubscriptionMessage(params SubscriptionFilter[] filters) 
			: this(SubscriptionUpdateType.Replace, null, filters) {}

		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateSubscriptionMessage"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="filters">The filters.</param>
		public UpdateSubscriptionMessage(SubscriptionUpdateType type, params SubscriptionFilter[] filters) 
			: this(type, null, filters) {}

		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateSubscriptionMessage"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="setID">The set identifier.</param>
		/// <param name="filters">The filters.</param>
		public UpdateSubscriptionMessage(SubscriptionUpdateType type, string setID, params SubscriptionFilter[] filters) 
			: base()
		{
			this.Filters = filters;
			this.SetID = setID;
			this.UpdateType = type;
		}

		/// <summary>
		/// Adds the specified filters.
		/// </summary>
		/// <param name="filters">The filters.</param>
		/// <returns>Subscription update message.</returns>
		public static UpdateSubscriptionMessage Add(params SubscriptionFilter[] filters) { return Add(null, filters); }

		/// <summary>
		/// Adds the specified set identifier.
		/// </summary>
		/// <param name="setID">The set identifier.</param>
		/// <param name="filters">The filters.</param>
		/// <returns>Subscription update message.</returns>
		public static UpdateSubscriptionMessage Add(string setID, params SubscriptionFilter[] filters)
		{
			return new UpdateSubscriptionMessage(SubscriptionUpdateType.Add, setID, filters);
		}

		/// <summary>
		/// Removes the specified filters.
		/// </summary>
		/// <param name="filters">The filters.</param>
		/// <returns>Subscription update message.</returns>
		public static UpdateSubscriptionMessage Remove(params SubscriptionFilter[] filters) { return Remove(null, filters); }

		/// <summary>
		/// Removes the specified set identifier.
		/// </summary>
		/// <param name="setID">The set identifier.</param>
		/// <param name="filters">The filters.</param>
		/// <returns>Subscription update message.</returns>
		public static UpdateSubscriptionMessage Remove(string setID, params SubscriptionFilter[] filters)
		{
			return new UpdateSubscriptionMessage(SubscriptionUpdateType.Remove, setID, filters);
		}

		/// <summary>
		/// Replaces the specified filters.
		/// </summary>
		/// <param name="filters">The filters.</param>
		/// <returns>Subscription update message.</returns>
		public static UpdateSubscriptionMessage Replace(params SubscriptionFilter[] filters) { return Replace(null, filters); }

		/// <summary>
		/// Replaces the specified set identifier.
		/// </summary>
		/// <param name="setID">The set identifier.</param>
		/// <param name="filters">The filters.</param>
		/// <returns>Subscription update message.</returns>
		public static UpdateSubscriptionMessage Replace(string setID, params SubscriptionFilter[] filters)
		{
			return new UpdateSubscriptionMessage(SubscriptionUpdateType.Replace, setID, filters);
		}

        /// <summary>
        /// Gets the marker ID.
        /// </summary>
		/// <value>The marker ID.</value>
        public int MarkerID { get; internal set; }

        /// <summary>
        /// New set of subscriptions
        /// </summary>
        public SubscriptionFilter[] Filters;

		/// <summary>
		/// Gets or sets the type of update operation to execute (default: replace all existing subscriptions).
		/// </summary>
		/// <value>The type of update operation to execute (default: replace all existing subscriptions).</value>
		public SubscriptionUpdateType UpdateType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the ID of the subscription set to update (default: <c>null</c> = default set).
		/// </summary>
		/// <value>The ID of the subscription set to update (default: <c>null</c> = default set).</value>
		public string SetID
		{
			get;
			set;
		}

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

        /// <summary>
        /// Tries to merge another update into this one. Modified this object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Merge(UpdateSubscriptionMessage other)
        {
			return false;
        }
	}

	/// <summary>
	/// Describes the type of update to be executed by a <see cref="UpdateSubscriptionMessage"/>.
	/// </summary>
	public enum SubscriptionUpdateType
	{
		/// <summary>
		/// Replaces the entire set of subscriptions.
		/// </summary>
		Replace,

		/// <summary>
		/// Adds a set of subscriptions to the existing subscription set.
		/// </summary>
		Add,

		/// <summary>
		/// Removes some subscriptions from the existing subscription set. The client
		/// remains subscribed to the remaining message types.
		/// </summary>
		Remove
	}
}
