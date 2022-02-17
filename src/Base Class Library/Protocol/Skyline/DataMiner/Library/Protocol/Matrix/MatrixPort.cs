namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	/// <summary>
	/// Represents a matrix input or output port.
	/// </summary>
	public abstract class MatrixPort
	{
		private readonly int index; // zero-based index.

		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixPort"/> class.
		/// </summary>
		/// <param name="index">Zero-based index.</param>
		protected MatrixPort(int index)
		{
			this.index = index;
		}

		/// <summary>
		/// Gets the zero-based index of this matrix port.
		/// </summary>
		/// <value>The zero-based index of this matrix port.</value>
		public int Index
		{
			get { return index; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this matrix port is enabled.
		/// </summary>
		/// <value><c>true</c> if this matrix port is enabled; otherwise, <c>false</c>.</value>
		public abstract bool IsEnabled { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this matrix port is locked.
		/// </summary>
		/// <value><c>true</c> if the matrix port is locked; otherwise, <c>false</c>.</value>
		public abstract bool IsLocked { get; set; }

		/// <summary>
		/// Gets or sets the label of this matrix port.
		/// </summary>
		/// <value>The label of this matrix port.</value>
		public abstract string Label { get; set; }
	}
}
