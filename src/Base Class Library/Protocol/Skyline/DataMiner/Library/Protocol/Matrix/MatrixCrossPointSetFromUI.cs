namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;

	/// <summary>
	/// Represents information about a matrix cross point update.
	/// </summary>
	[Serializable]
	public class MatrixCrossPointSetFromUI
	{
		private readonly int input;
		private readonly int output;
		private readonly MatrixCrossPointConnectionState state;

		internal MatrixCrossPointSetFromUI(int input, int output, MatrixCrossPointConnectionState state)
		{
			this.input = input;
			this.output = output;
			this.state = state;
		}

		/// <summary>
		/// Gets the zero-based input port number of the changed crosspoint.
		/// </summary>
		/// <value>Zero-based input port number.</value>
		public int Input
		{
			get { return input; }
		}

		/// <summary>
		/// Gets the zero-based output number of the changed crosspoint.
		/// </summary>
		/// <value>Zero-based output port number.</value>
		public int Output
		{
			get { return output; }
		}

		/// <summary>
		/// Gets the <see cref="MatrixCrossPointConnectionState"/> of the changed crosspoint to know if the crosspoint is connected or disconnected.
		/// </summary>
		/// <value><see cref="MatrixCrossPointConnectionState"/> of the changed crosspoint.</value>
		public MatrixCrossPointConnectionState State
		{
			get { return state; }
		}
	}
}
