using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// This message contains information about a subscriber. It gets returned in this case:
	/// - After sending a CreateSubscriptionMessage or UpdateSubscriptionMessage, a CreateSubscriptionResponse 
	///   with info on the subscription is returned.
	/// </summary>
	[Serializable]
	public class CreateSubscriptionResponseMessage : ResponseMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CreateSubscriptionResponseMessage"/> class.
		/// </summary>
		public CreateSubscriptionResponseMessage()
		{
			this.Filters = new SubscriptionFilter[0];
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateSubscriptionResponseMessage"/> class.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		public CreateSubscriptionResponseMessage(Guid guid)
		{
			this.Guid = guid;
		}

		/// <summary>
		/// Client GUID. This identifier is used to uniquely identify the client. It needs to be passed
		/// along with all messages that inherit from ClientRequestMessage.
		/// </summary>
		public Guid Guid;

		/// <summary>
		/// Username with which the client subscribed.
		/// </summary>
		public string UserName;

		/// <summary>
		/// Computer name from where the client made the connection.
		/// </summary>
		public string ComputerName;

		/// <summary>
		/// Domain name to which the user name belongs. When no domain is used, the domain name is ".".
		/// </summary>
		public string DomainName;

		/// <summary>
		/// The set of subscription filters that defines which messages the client will receive.
		/// </summary>
		public SubscriptionFilter[] Filters;

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