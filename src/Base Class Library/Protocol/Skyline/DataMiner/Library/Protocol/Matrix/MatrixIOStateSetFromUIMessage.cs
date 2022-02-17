namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;

	/// <summary>
	/// Provides data for the event that is raised when the state of a matrix input or output has changed.
	/// </summary>
	[Serializable]
	public class MatrixIOStateSetFromUIMessage
	{
		private readonly int index;
		private readonly MatrixIOType type;
		private readonly bool isEnabled;

		internal MatrixIOStateSetFromUIMessage(int index, MatrixIOType type, bool isEnabled)
		{
			this.index = index;
			this.type = type;
			this.isEnabled = isEnabled;
		}

		/// <summary>
		/// Gets the zero-based port number of the changed state.
		/// </summary>
		/// <value>Zero-based port number.</value>
		public int Index
		{
			get { return index; }
		}

		/// <summary>
		/// Gets the <see cref="MatrixIOType"/> to determine if the changed state is on an output or input port.
		/// </summary>
		/// <value><see cref="MatrixIOType"/> that determines if it is an output or input port.</value>
		public MatrixIOType Type
		{
			get { return type; }
		}

		/// <summary>
		/// Gets a value indicating whether this port is enabled.
		/// </summary>
		/// <value><c>true</c> if the port is enabled; otherwise, <c>false</c>.</value>
		public bool IsEnabled
		{
			get { return isEnabled; }
		}
	}
}
