using System;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a required field validator. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
	/// <typeparam name="T">The type to validate against.</typeparam>
	[Serializable]
    public class RequiredTypeValidator<T> : TypeValidator<T>
    {
        protected bool required;

		/// <summary>
		/// Initializes a new instance of the <see cref="RequiredTypeValidator{T}"/> class.
		/// </summary>
		/// <remarks>Creates a generic type validator that rejects <see langword="null"/> values.</remarks>
		public RequiredTypeValidator() : this(true) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="RequiredTypeValidator{T}"/> class using a Boolean to indicate whether null reference values are allowed .
		/// </summary>
		/// <param name="required"><c>true</c> if the field is required (value must not be <see langword="null"/>, <c>false</c> if the field is not required (<see langword="null"/> value is allowed).</param>
		/// <remarks>Creates a generic type validator where you can specify whether <see langword="null"/> values are allowed.</remarks>
		public RequiredTypeValidator(bool required)
        {
        }

		/// <summary>
		/// Verifies whether the specified value is allowed.
		/// </summary>
		/// <param name="ticket">The ticket.</param>
		/// <param name="obj">The item to validate.</param>
		/// <returns>
		/// <para><c>false</c> if the value is <see langword="null"/> and the field is required.</para>
		/// <para>If the value is not <see langword="null"/>, the value is validated against the expected type <typeparamref name="T"/>.</para>
		/// </returns>
		public override bool Validate(Ticket ticket, object obj)
        {
			return false;
        }
    }
}
