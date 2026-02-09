using Newtonsoft.Json;
using Skyline.DataMiner.Net.Ticketing.Interfaces;
using System;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a generic enum validator. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	/// <typeparam name="T">The underlying type of the generic enum to validate.</typeparam>
	[JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    public class EnumValidator<T> : ITicketFieldValidator
    {
		/// <summary>
		/// Gets the generic enum this validator corresponds with.
		/// </summary>
		[JsonProperty]
        public GenericEnum<T> genericEnum { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumValidator{T}"/> class.
		/// </summary>
		public EnumValidator()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumValidator{T}"/> class with the specified generic enum.
		/// </summary>
		/// <param name="genericEnum">The generic enum.</param>
		public EnumValidator(GenericEnum<T> genericEnum)
        {
        }

		/// <summary>
		/// Verifies whether the specified object is known by the corresponding generic enum.
		/// </summary>
		/// <param name="ticket">A <see cref="Ticket"/> instance.</param>
		/// <param name="obj">The object to be verified.</param>
		/// <returns>
		/// <para><c>true</c> if <paramref name="obj"/> is of type <see cref="GenericEnumEntry{T}"/> and this entry is defined in the generic enum; otherwise, <c>false</c>.</para>
		/// <para><c>true</c> if <paramref name="obj"/> is of type <typeparamref name="T"/> and this value is defined in the generic enum; otherwise, <c>false</c>.</para>
		/// </returns>
		public bool Validate(Ticket ticket, object obj)
        {
            return false;
        }
    }
}
