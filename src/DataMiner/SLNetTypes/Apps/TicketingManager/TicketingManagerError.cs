using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Tickets
{
	/// <summary>
	/// Represents an error that occurred during CRUD operations with the Ticketing manager. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	[Serializable]
    public class TicketingManagerError : ErrorData
    {
        public enum Reason
        {
            /// <summary>
            /// The TicketFieldResolver still has tickets linked to it.
            ///
            /// <see cref="RelatedTickets"/> contains the ticket IDs
            /// </summary>
            TicketFieldResolverInUseByTickets = 1,
            
            /// <summary>
            /// The manager has not been initialized.
            /// </summary>
            NotInitialized = 2,

            /// <summary>
            /// Error reason for legacy error messages.
            ///
            /// <see cref="LegacyErrorMessage"/> contains the error message
            /// </summary>
            LegacyError = 3,

            /// <summary>
            /// The ticket that is created/updated has a link to
            /// a TicketFieldResolver that does not exist
            ///
            /// <see cref="TicketFieldResolverId"/> contains the ID of
            /// the nonexistent TicketFieldResolver
            /// </summary>
            TicketLinkedToNonExistingTicketFieldResolver = 4,

            /// <summary>
            /// The TicketFieldResolver that was tried to be removed
            /// does not exist, or is not masked
            /// </summary>
            TicketFieldResolverIsUnknownOrNotMasked = 5,

            /// <summary>
            /// An unexpected exception occurred.
            ///
            /// <see cref="Exception"/> contains the exception
            /// </summary>
            UnexpectedException = 6,

            /// <summary>
            /// The ticket that is created/updated has a link to
            /// a TicketFieldResolver that is masked
            /// </summary>
            TicketLinkedToMaskedTicketFieldResolver = 7,

            /// <summary>
            /// The ticket is linked to a TicketFieldResolver that defines a StateFieldDescriptor,
            /// but no field for this descriptor was found on the ticket, or the value was null for this field.
            /// </summary>
            TicketDoesNotContainStateField = 8,

            /// <summary>
            /// The FieldName of a TicketFieldDescriptor contains invalid characters. 
            /// <see cref="InvalidTicketFieldDescriptorNames"/> contains the invalid TicketFieldDescriptor names
            /// </summary>
            TicketFieldDescriptorNamesContainInvalidCharacters = 9
        }

		/// <summary>
		/// Gets or sets the error reason.
		/// </summary>
		/// <value>The error reason.</value>
		public Reason ErrorReason { get; set; }

		/// <summary>
		/// Gets or sets the related tickets.
		/// </summary>
		/// <value>The related tickets.</value>
		public List<Guid> RelatedTickets { get; set; }

		/// <summary>
		/// Gets or sets the ticket field resolver ID.
		/// </summary>
		/// <value>The ticket field resolver ID.</value>
        public Guid TicketFieldResolverId { get; set; }

		/// <summary>
		/// Gets or sets the legacy error message.
		/// </summary>
		/// <value>The legacy error message.</value>
		public string LegacyErrorMessage { get; set; }

		/// <summary>
		/// Gets or sets the exception.
		/// </summary>
		/// <value>The exception.</value>
        public string Exception { get; set; }

		/// <summary>
		/// Gets or sets the invalid ticket field descriptor names.
		/// </summary>
		/// <value>The invalid ticket field descriptor names.</value>
		public List<string> InvalidTicketFieldDescriptorNames { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingManagerError"/> class with the specified error reason and the related tickets.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="relatedTickets">The related tickets.</param>
		public TicketingManagerError(Reason errorReason, List<Guid> relatedTickets)
            : this(errorReason)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingManagerError"/> class with the specified error reason and the ticket field resolver ID.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="ticketFieldResolverId">The ticket field resolver ID.</param>
		public TicketingManagerError(Reason errorReason, Guid ticketFieldResolverId)
            : this(errorReason)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingManagerError"/> class with the specified legacy error message.
		/// </summary>
		/// <param name="legacyErrorMessage">The legacy error message.</param>
		public TicketingManagerError(string legacyErrorMessage)
            : this(Reason.LegacyError)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingManagerError"/> class with the specified error reason.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		public TicketingManagerError(Reason errorReason)
            : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingManagerError"/> class.
		/// </summary>
		public TicketingManagerError() 
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingManagerError"/> class with the specified error reason invalid characters.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="ticketsInvalidCharacters">The invalid characters.</param>
		public TicketingManagerError(Reason errorReason, List<string> ticketsInvalidCharacters)
           : this(errorReason)
        {
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

