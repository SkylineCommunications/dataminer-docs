using System;
using System.ComponentModel;
#if NETFRAMEWORK
using System.Drawing.Design;
#endif

namespace Skyline.DataMiner.Net.Ticketing.Objects
{
	/// <summary>
	/// Represents a ticket field of a <see cref="Ticket"/> instance.
	/// </summary>
	/// <remarks>Used by a ticket to define what exactly the field contains.</remarks>
	[Serializable]
//#if NETFRAMEWORK
//    [Editor(typeof(ObjectEditor<TicketField>), typeof(UITypeEditor))]
//#endif
    public class TicketField : IEquatable<TicketField>
    {
		#region Properties & Fields
		/// <summary>Gets or sets the name of the field.</summary>
		/// <value>The name of the field.</value>
		public string FieldName { get; set; }

		/// <summary>Gets or sets the value of the field.</summary>
		/// <value>The value of the field.</value>
		public object Value { get; set; }


		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="TicketField"/> class.
		/// </summary>
		public TicketField()
        {
        }

		/// <summary>
		/// Determines whether the specified <see cref="TicketField"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// </remarks>
		public bool Equals(TicketField other)
        {
            return true;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
			return null;
		}
    }
}
