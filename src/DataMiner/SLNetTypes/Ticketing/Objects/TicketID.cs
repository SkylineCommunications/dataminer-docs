using System;
using System.ComponentModel;

namespace Skyline.DataMiner.Net.Ticketing
{
	/// <summary>
	/// Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	public class TicketIDConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
			return true;
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
			return true;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
			return null;
		}
    }

	/// <summary>
	/// Represents a ticket ID. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	[Serializable]
    [TypeConverter(typeof(TicketIDConverter)),
    Description("Expand to see the IDs")]
    public class TicketID : DMAObjectRef, IEquatable<TicketID>, IComparable<TicketID>, IComparable, ICloneable, IDMAObjectRef
    {
		/// <summary>
		/// Gets or sets the DataMiner Agent ID.
		/// </summary>
		/// <value>The DataMiner Agent ID.</value>
		public int DataMinerID { get; set; }

		/// <summary>
		/// Gets or sets the ticket ID.
		/// </summary>
		/// <value>The ticket ID.</value>
		public int TID { get; set; }

		/// <summary>
		/// Gets a new <see cref="TicketID"/> instance.
		/// </summary>
		/// <value>A new <see cref="TicketID"/> instance.</value>
		public static TicketID Default;

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketID"/> class.
		/// </summary>
		public TicketID() 
            : this(-1, -1)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketID"/> class using the specified ticket ID.
		/// </summary>
		/// <param name="tid">The ticket ID.</param>
		/// <remarks><see cref="DataMinerID"/> and <see cref="TID"/> are set to -1.</remarks>
		public TicketID(TicketID tid)
            : this(tid.DataMinerID, tid.TID)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketID"/> class using the specified DataMiner Agent ID and ticket ID.
		/// </summary>
		/// <param name="dataMinerId">The DataMiner Agent ID.</param>
		/// <param name="tid">The ticket ID.</param>
		public TicketID(int dataMinerId, int tid)
        {
        }

		/// <summary>
		///  Determines whether the specified <see cref="TicketID"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Tickets are considered equal if their Agent ID and ticket ID are the same.</para>
		/// </remarks>
		public bool Equals(TicketID other)
        {
            return false;
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
            return 0;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

		/// <summary>
		/// Creates a <see cref="TicketID"/> instance based on the specified string.
		/// </summary>
		/// <param name="strTicketID">The string representing a ticket ID.</param>
		/// <returns>The <see cref="TicketID"/> instance or <see langword="null"/> if the provided string was invalid.</returns>
		/// <remarks><paramref name="strTicketID"/> should have the following format: "DataMinerAgentID/TicketID".</remarks>
		public static TicketID FromString(string strTicketID)
        {
			return null;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value can have the following meanings:
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description>This instance precedes <paramref name="other"/> in the sort order.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description>This instance occurs in the same position in the sort order as <paramref name="other"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description>This instance follows <paramref name="other"/> in the sort order.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int CompareTo(TicketID other)
        {
			return 1;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value can have the following meanings:
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description>This instance precedes <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description>This instance occurs in the same position in the sort order as <paramref name="obj"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description>This instance follows <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int CompareTo(object obj)
        {
            return 1;
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		/// <summary>
		/// Returns a file-friendly string that represents the current object.
		/// </summary>
		/// <returns>A file-friendly string that represents the current object.</returns>
		public override string ToFileFriendlyString()
        {
            return "";
        }

		/// <summary>
		/// Returns a string that is formatted as follows: "{DataMinerID}_{TID}".
		/// </summary>
		/// <returns>A string that is formatted as follows: "{DataMinerID}_{TID}".</returns>
		public override string ToAttachmentString()
        {
            return "";
        }

        /// <summary>
        /// Returns a Guid that is build using the <see cref="DataMinerID"/> and
        /// the <see cref="TID"/> integers
        /// </summary>
        internal Guid GetGuid()
        {
			return default(Guid);
		}
    }
}
