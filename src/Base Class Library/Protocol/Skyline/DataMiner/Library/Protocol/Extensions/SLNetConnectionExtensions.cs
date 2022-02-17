namespace Skyline.DataMiner.Library.Protocol
{
	using Scripting;

	using Skyline.DataMiner.Library.Common;

	using System;

	/// <summary>
	/// Defines extension methods on the <see cref="SLNetConnection"/> class.
	/// </summary>
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedScripting.dll")]
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
	public static class SLNetConnectionExtensions
	{
#pragma warning disable S1104 // Fields should not have public accessibility
#pragma warning disable S2223 // Non-constant static fields should not be visible

		/// <summary>
		/// Allows an override of the behavior of GetDms to return a Fake or Mock of <see cref="IDms"/>.
		/// Important: When this is used, unit tests should never be run in parallel.
		/// </summary>
		public static Func<SLNetConnection, IDms> OverrideGetDms = connection => { return new Dms(new Communication(connection)); };

#pragma warning restore S2223 // Non-constant static fields should not be visible
#pragma warning restore S1104 // Fields should not have public accessibility

		/// <summary>
		/// Gets an object implementing the <see cref="IDms"/> interface using an instance of the <see cref="SLNetConnection"/> class.
		/// </summary>
		/// <param name="connection">The <see cref="SLNetConnection"/> connection.</param>
		/// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null" />.</exception>
		/// <returns>Object implementing the <see cref="IDms"/> interface.</returns>
		public static IDms GetDms(this SLNetConnection connection)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}

			return OverrideGetDms(connection);
		}
	}
}