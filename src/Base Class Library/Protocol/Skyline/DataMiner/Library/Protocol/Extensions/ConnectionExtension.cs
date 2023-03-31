namespace Skyline.DataMiner.Library.Protocol
{
	using System;

	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Scripting;

	/// <summary>
	/// Defines extension methods on the SLProtocol interface.
	/// </summary>
	public static class SlProtocolExtensions
	{
#pragma warning disable S1104 // Fields should not have public accessibility
#pragma warning disable S2223 // Non-constant static fields should not be visible

		/// <summary>
		/// Allows an override of the behavior of GetDms to return a Fake or Mock of <see cref="IDms"/>.
		/// Important: When this is used, unit tests should never be run in parallel.
		/// </summary>
		public static Func<SLProtocol, IDms> OverrideGetDms = protocol => { return null; };

#pragma warning restore S2223 // Non-constant static fields should not be visible
#pragma warning restore S1104 // Fields should not have public accessibility

		/// <summary>
		/// Gets an object implementing the <see cref="IDms"/> interface using an instance of the SLProtocol class.
		/// </summary>
		/// <param name="protocol">The SLProtocol instance.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null" />.</exception>
		/// <returns>Object implementing the <see cref="IDms"/> interface.</returns>
		public static IDms GetDms(this Skyline.DataMiner.Scripting.SLProtocol protocol)
		{
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			return OverrideGetDms(protocol);
		}
	}
}