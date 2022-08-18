namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	/// <summary>
	/// Represents a matrix input.
	/// </summary>
	public class MatrixInput : MatrixPort
	{
		internal MatrixInput() : base(0) { }

		/// <summary>
		/// Gets or sets a value indicating whether this matrix input is enabled.
		/// </summary>
		/// <value><c>true</c> if this matrix input is enabled; otherwise, <c>false</c>.</value>
		public override bool IsEnabled
		{
			get; set;

		}

		/// <summary>
		/// Gets or sets a value indicating whether this matrix input is locked.
		/// </summary>
		/// <value><c>true</c> if the matrix input is locked; otherwise, <c>false</c>.</value>
		public override bool IsLocked
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the label of this matrix input.
		/// </summary>
		/// <value>The label of this matrix input.</value>
		public override string Label
		{
			get; set;
		}
	}
}
