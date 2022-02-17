using System;
using Skyline.DataMiner.Net.Exceptions;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a value wrapper factory.
	/// </summary>
	public static class ValueWrapperFactory
    {
		/// <summary>
		/// Creates a value wrapper out of the specified object.
		/// </summary>
		/// <param name="value">The object to wrap.</param>
		/// <returns>The wrapped value object.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
		/// <exception cref="DataMinerException">Failed to create a wrapped value object from the specified object.</exception>
		public static IValueWrapper Create(object value)
        {
			return null;
		}
    }
}
