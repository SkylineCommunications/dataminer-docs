namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Defines methods to support the comparison of DataMiner views for equality.
	/// </summary>
	public class DmsViewEqualityComparer : EqualityComparer<IDmsView>
    {
		/// <summary>
		/// Determines whether the specified view objects are equal.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns><c>true</c> if the specified views have the same ID; otherwise, <c>false</c>.</returns>
		public override bool Equals(IDmsView x, IDmsView y)
        {
			if (x == null && y == null)
			{
				return true;
			}

			if (x == null || y == null)
			{
				return false;
			}

            return x.Id == y.Id;
        }

		/// <summary>
		/// Returns a hash code for the specified object.
		/// </summary>
		/// <param name="obj">The object for which to get a hash code.</param>
		/// <exception cref="ArgumentNullException"><paramref name="obj"/> is <see langword="null"/>.</exception>
		/// <returns>A hash code for the specified object.</returns>
		public override int GetHashCode(IDmsView obj)
        {
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}

            return obj.Id.GetHashCode();
        }
    }
}
