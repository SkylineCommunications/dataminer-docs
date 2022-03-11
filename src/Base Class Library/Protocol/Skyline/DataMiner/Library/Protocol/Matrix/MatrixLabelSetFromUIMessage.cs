namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;

	/// <summary>
	/// Provides data for the event that is raised when a label of a matrix input or output has changed.
	/// </summary>
	[Serializable]
	public class MatrixLabelSetFromUIMessage
	{
		private readonly int index;
		private readonly MatrixIOType type;
		private readonly string label;


		/// <summary>
		/// Gets the zero-based port number of the changed label.
		/// </summary>
		/// <value>Zero-based port number.</value>
		public int Index
		{
			get { return index; }
		}

		/// <summary>
		/// Gets the <see cref="MatrixIOType"/> to determine if the changed label is on an output or input port.
		/// </summary>
		/// <value><see cref="MatrixIOType"/> that determines if it is an output or input port.</value>
		public MatrixIOType Type
		{
			get { return type; }
		}

		/// <summary>
		/// Gets the changed label of this port.
		/// </summary>
		/// <value>The changed label of this port.</value>
		public string Label
		{
			get { return label; }
		}
	}
}
