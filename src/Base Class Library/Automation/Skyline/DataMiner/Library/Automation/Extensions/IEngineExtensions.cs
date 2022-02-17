namespace Skyline.DataMiner.Library.Automation
{
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Library.Common;

	using System;

	/// <summary>
	/// Defines extension methods on the <see cref="IEngine"/> interface.
	/// </summary>
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedAutomation.dll")]
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
	public static class IEngineExtensions
	{
#pragma warning disable S1104 // Fields should not have public accessibility
#pragma warning disable S2223 // Non-constant static fields should not be visible

		/// <summary>
		/// Allows an override of the behavior of GetDms to return a Fake or Mock of <see cref="IDms"/>.
		/// Important: When this is used, unit tests should never be run in parallel.
		/// </summary>
		public static Func<IEngine, IDms> OverrideGetDms = engine => { return new Dms(new ConnectionCommunication(Engine.SLNetRaw)); };

#pragma warning restore S2223 // Non-constant static fields should not be visible
#pragma warning restore S1104 // Fields should not have public accessibility

		/// <summary>
		/// Retrieves an object implementing the <see cref="IDms"/> interface.
		/// </summary>
		/// <param name="engine">The <see cref="IEngine"/> implementation.</param>
		/// <exception cref="ArgumentNullException"><paramref name="engine"/> is <see langword="null" />.</exception>
		/// <returns>The <see cref="IDms"/> object.</returns>
		public static IDms GetDms(this IEngine engine)
		{
			if (engine == null)
			{
				throw new ArgumentNullException("engine");
			}

			return OverrideGetDms(engine);
		}
	}
}