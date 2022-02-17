namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	/// <summary>
	/// Class used when serializing the matrix class to JSON. Could also be used to deserialize a matrix status on a remote element. The setter in the properties are to be able to fill in the values when (de)serializing, this cannot be used to modify the real matrix parameter (i.e. changing a label in this class object will not change it in the original matrix parameter).
	/// </summary>
	public class MatrixStatus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixStatus"/> class.
		/// </summary>
		public MatrixStatus(MatrixInputs inputs, MatrixOutputs outputs)
		{
			Inputs = new System.Collections.Generic.List<MatrixInput>(inputs);
			Outputs = new System.Collections.Generic.List<MatrixOutput>(outputs);
		}

		/// <summary>
		/// Gets or sets the number of displayed inputs.
		/// </summary>
		public int DisplayedInputs { get; set; }

		/// <summary>
		/// Gets or sets the number of displayed outputs.
		/// </summary>
		public int DisplayedOutputs { get; set; }

		/// <summary>
		/// Gets or sets the DisplayType. This defines if the matrix parameter and/or the table parameters are filled in.
		/// </summary>
		public MatrixDisplayType DisplayType { get; set; }

		/// <summary>
		/// Gets or sets the DataMiner id of the element.
		/// </summary>
		public int DmaId { get; set; }

		/// <summary>
		/// Gets or sets the id of the element.
		/// </summary>
		public int ElementId { get; set; }

		/// <summary>
		/// Gets or sets the name of the element.
		/// </summary>
		public string ElementName { get; set; }

		/// <summary>
		/// Gets or sets the input ports of the matrix.
		/// </summary>
		public System.Collections.Generic.List<MatrixInput> Inputs { get; private set; }

		/// <summary>
		/// Gets or sets the write parameter id of the matrix.
		/// </summary>
		public int MatrixWritePid { get; set; }

		/// <summary>
		/// Gets or sets the maximum number of connected inputs per output.
		/// </summary>
		public int MaxConnectedInputsPerOutput { get; set; }

		/// <summary>
		/// Gets or sets the maximum number of connected outputs per input.
		/// </summary>
		public int MaxConnectedOutputsPerInput { get; set; }

		/// <summary>
		/// Gets or sets the maximum amount of inputs of the matrix.
		/// </summary>
		public int MaxInputs { get; set; }

		/// <summary>
		/// Gets or sets the maximum amount of outputs of the matrix.
		/// </summary>
		public int MaxOutputs { get; set; }

		/// <summary>
		/// Gets or sets the minimum number of connected inputs per output.
		/// </summary>
		public int MinConnectedInputsPerOutput { get; set; }

		/// <summary>
		/// Gets or sets the minimum number of connected outputs per input.
		/// </summary>
		public int MinConnectedOutputsPerInput { get; set; }

		/// <summary>
		/// Gets or sets the output ports of the matrix.
		/// </summary>
		public System.Collections.Generic.List<MatrixOutput> Outputs { get; private set; }
	}
}
