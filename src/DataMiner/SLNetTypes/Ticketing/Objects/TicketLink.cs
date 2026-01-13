using System;

using Newtonsoft.Json;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

using SLNetTypes.DataMiner.Net;

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// Represents a generic ticket link. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class TicketLink<T> : TicketLink
        where T : class
    {
        #region Properties & Fields

		/// <summary>
		/// Gets or sets the linked object.
		/// </summary>
		/// <value>The linked object.</value>
		[JsonProperty]
        public new T Value
        {
			get; set;
        }
		#endregion

		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="TicketLink{T}" /> class.
		/// </summary>
		public TicketLink()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketLink{T}" /> class using the specified linked object.
		/// </summary>
		/// <param name="Value">The linked object.</param>
		public TicketLink(T value)
        {
        }
        #endregion
    }

	/// <summary>
	/// Represents a link between a ticket and a DataMiner object. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	/// <remarks>
	/// <para>Currently, you can link to the following objects:</para>
	/// <list type="bullet">
	/// <item><description><see cref="AlarmID"/></description></item>
	/// <item><description><see cref="ElementID"/></description></item>
	/// <item><description><see cref="ParameterID"/></description></item>
	/// <item><description><see cref="ProtocolID"/></description></item>
	/// <item><description><see cref="RedundancyGroupID"/></description></item>
	/// <item><description><see cref="ServiceID"/></description></item>
	/// <item><description><see cref="ViewID"/></description></item>
	/// </list>
	/// </remarks>
	[Serializable]
    public abstract class TicketLink
    {
		/// <summary>
		/// Gets or sets the linked object.
		/// </summary>
		/// <value>The linked object.</value>
		public object Value
        {
			get; set;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketLink" /> class.
		/// </summary>
		protected TicketLink()
        {
        }

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="AlarmID"/> object.
		/// </summary>
		/// <param name="id">The alarm ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(AlarmID id)
        {
			return null;
		}

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="ElementID"/> object.
		/// </summary>
		/// <param name="id">The element ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(ElementID id)
        {
			return null;
		}

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="ServiceID"/> object.
		/// </summary>
		/// <param name="id">The service ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(ServiceID id)
        {
			return null;
		}

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="RedundancyGroupID"/> object.
		/// </summary>
		/// <param name="id">The redundancy group ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(RedundancyGroupID id)
        {
			return null;
		}

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="ParameterID"/> object.
		/// </summary>
		/// <param name="id">The parameter ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(ParameterID id)
        {
			return null;
		}

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="ViewID"/> object.
		/// </summary>
		/// <param name="id">The view ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(ViewID id)
        {
			return null;
		}

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="ProtocolID"/> object.
		/// </summary>
		/// <param name="id">The protocol ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(ProtocolID id)
        {
			return null;
		}

		/// <summary>
		/// Creates a <see cref="TicketLink"/> object that links to the specified <see cref="ReservationInstanceID"/> object.
		/// </summary>
		/// <param name="id">The reservation instance ID.</param>
		/// <returns>The created <see cref="TicketLink"/> object.</returns>
		public static TicketLink Create(ReservationInstanceID id)
        {
			return null;
		}

		/// <summary>
		/// Parses the specified JSON string and creates a <see cref="TicketLink"/> object.
		/// </summary>
		/// <param name="json">The JSON string from which to create a <see cref="TicketLink"/>.</param>
		/// <exception cref="DataMinerJsonDeserializationException">Invalid JSON string.</exception>
		/// <returns>The <see cref="TicketLink"/> object.</returns>
		public static TicketLink FromJson(string json)
        {
			return null;
		}

		/// <summary>
		/// Creates a JSON string representation of this <see cref="TicketLink"/> object.
		/// </summary>
		/// <returns>The JSON string representation of this <see cref="TicketLink"/> object.</returns>
		public string ToJson()
        {
			return null;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
			return false;
		}

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
			return 1;
		}
    }
}
