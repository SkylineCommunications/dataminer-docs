namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	/// <summary>
	/// Represents a matrix input.
	/// </summary>
	public class MatrixInput : MatrixPort
	{
		internal MatrixInput(MatrixPortState portState, int index) : base(index)
		{
			PortState = portState;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this matrix input is enabled.
		/// </summary>
		/// <value><c>true</c> if this matrix input is enabled; otherwise, <c>false</c>.</value>
		public override bool IsEnabled
		{
			get
			{
				return PortState.InputStates[Index];
			}

			set
			{
				PortState.InputStates[Index] = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this matrix input is locked.
		/// </summary>
		/// <value><c>true</c> if the matrix input is locked; otherwise, <c>false</c>.</value>
		public override bool IsLocked
		{
			get
			{
				return PortState.InputLocks[Index];
			}

			set
			{
				PortState.InputLocks[Index] = value;
			}
		}

		/// <summary>
		/// Gets or sets the label of this matrix input.
		/// </summary>
		/// <value>The label of this matrix input.</value>
		public override string Label
		{
			get
			{
				return PortState.InputLabels[Index];
			}

			set
			{
				PortState.InputLabels[Index] = value;
			}
		}
	}
}
