namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// Represents the matrix inputs.
	/// </summary>
	public class MatrixInputs : IEnumerable<MatrixInput>
	{
		private readonly MatrixPortState portState;
		private readonly Dictionary<int, MatrixInput> ports;

		internal MatrixInputs(MatrixPortState portState)
		{
			this.portState = portState;
			ports = new Dictionary<int, MatrixInput>();
		}

		/// <summary>
		/// Gets the specified input port.
		/// </summary>
		/// <param name="index">The zero-based index of the input port.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.
		/// -or-
		/// <paramref name="index"/> is equal to or greater than <see cref="MatrixHelper.MaxInputs"/>.</exception>
		/// <returns>The input port at the specified index.</returns>
		public MatrixInput this[int index]
		{
			get
			{
				if (index < 0 || index >= portState.MaxInputs)
				{
					throw new ArgumentOutOfRangeException("index", "The specified index must be in the range [0," + (portState.MaxInputs - 1) + "].");
				}

				MatrixInput port;
				if (!ports.TryGetValue(index, out port))
				{
					port = new MatrixInput(portState, index);
					ports[index] = port;
				}

				return port;
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<MatrixInput> GetEnumerator()
		{
			for (int i = 0; i < portState.MaxInputs; i++)
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
