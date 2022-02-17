namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// Represents the matrix outputs.
	/// </summary>
	public class MatrixOutputs : IEnumerable<MatrixOutput>
	{
		/// <summary>
		/// Gets the specified output port.
		/// </summary>
		/// <param name="index">The zero-based index of the output port.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.
		/// -or-
		/// <paramref name="index"/> is equal to or greater than <see cref="MatrixHelper.MaxOutputs"/>.</exception>
		/// <returns>The output port at the specified index.</returns>
		public MatrixOutput this[int index]
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<MatrixOutput> GetEnumerator()
		{
			for (int i = 0; i < portState.MaxOutputs; i++)
			{
				yield return this[i];
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
