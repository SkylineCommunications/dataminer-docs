using Skyline.DataMiner.Net.Ticketing.Objects;
using Skyline.DataMiner.Net.Ticketing.Validators;
using System;

namespace Skyline.DataMiner.Net.Ticketing.Helpers
{
	/// <summary>
	/// Represents a <see cref="TicketFieldResolver"/> factory. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	public class TicketFieldResolverFactory
    {
		/// <summary>
		/// The default ID.
		/// </summary>
		// <remarks>8813 is the IANA assigned Enterprise Number for Skyline Communications.</remarks>
		public static readonly Guid DefaultID = new Guid(8813, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);


		/// <summary>
		/// Creates a default ticket field resolver.
		/// </summary>
		/// <param name="ID">The ID of the ticket field resolver.</param>
		/// <returns>A default ticket field resolver.</returns>
		public TicketFieldResolver CreateDefaultResolver(Guid ID = default)
        {
			return null;
		}

		/// <summary>
		/// Creates an empty ticket field resolver with the specified name.
		/// </summary>
		/// <param name="name">The name of the ticket field resolver.</param>
		/// <returns>An empty ticket field resolver with the specified name.</returns>
		public TicketFieldResolver CreateEmptyResolver(string name = "")
        {
			return null;
		}
    }
}
