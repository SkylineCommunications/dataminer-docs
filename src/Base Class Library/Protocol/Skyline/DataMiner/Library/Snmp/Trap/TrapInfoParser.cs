namespace Skyline.DataMiner.Library.Protocol.Snmp.Trap
{
	using System;
    using System.Globalization;
    using System.Net;

	internal class TrapInfoParser
	{
		private TrapInfoParser()
		{
		}

		/// <summary>
		/// Parses the object returned from SLProtocol when using allBindingInfo on a parameter in a DataMiner Protocol.
		/// </summary>
		/// <param name="trapInfo">The object returned from SLProtocol when using allBindingInfo on a parameter in a DataMiner Protocol.</param>
		/// <exception cref="ArgumentNullException"><paramref name="trapInfo"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="trapInfo"/> is invalid.</exception>
		/// <exception cref="FormatException"><paramref name="trapInfo"/>Source is not a valid IP address.</exception>
		/// <returns>An instance of the <see cref="TrapInfo"/> class.</returns>
		/// <example>
		/// <code>TrapInfo trap = TrapInfoParser.Parse(trapInfo);</code>
		/// </example>
		public static TrapInfo Parse(object trapInfo)
		{
			return null;
		}
	}
}