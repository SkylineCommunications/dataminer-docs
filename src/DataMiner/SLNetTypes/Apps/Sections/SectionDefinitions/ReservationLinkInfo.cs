using System;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents reservation link info.
	/// </summary>
	/// <remarks>
	/// If a section contains links to a ReservationInstances using the <see cref="ReservationFieldDescriptor"/>, this object describes
	/// more details about those links.
	/// </remarks>
	[Serializable]
    //[DataContract(Name = "ReservationLinkInfo")]
    public sealed class ReservationLinkInfo : IEquatable<ReservationLinkInfo>
    {
		/// <summary>
		/// Gets or sets the ID of the booking element.
		/// </summary>
		/// <value>The ID of the booking element.</value>
		//[DataMember(Name = "BookingElementID")]
        public ElementID BookingElementID { get; set; }

		/// <summary>
		/// Gets or sets the ID of the booking script.
		/// </summary>
		/// <value>The ID of the booking script.</value>
		//[DataMember(Name = "CreateBookingScript")]
        public AutomationScriptID CreateBookingScript { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ReservationLinkInfo"/> class.
		/// </summary>
		public ReservationLinkInfo()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ReservationLinkInfo"/> class using the specified booking element ID and script.
		/// </summary>
		/// <param name="bookingElementID">The booking element ID.</param>
		/// <param name="createBookingScript">The create booking script.</param>
		public ReservationLinkInfo(ElementID bookingElementID, AutomationScriptID createBookingScript)
        {
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(ReservationLinkInfo other)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 1;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }
    }
}
