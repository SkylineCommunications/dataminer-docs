namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;
	using Net.Messages;
	using Skyline.DataMiner.Scripting;

	/// <summary>
	/// Represents a matrix UI control in a DataMiner protocol. To be used when the protocol only has table measurement type parameters to represent the connections.
	/// </summary>
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedScripting.dll")]
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
	public class MatrixHelperForTables : MatrixHelper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForTables"/> class.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="matrixConnectionsBufferParameterId">The parameter ID of the single parameter that contains all the matrix crosspoint connections in one string.</param>
		/// <param name="inputsTableParameterId">The parameter ID of the table that represents the inputs.</param>
		/// <param name="outputsTableParameterId">The parameter ID of the table that represents the outputs.</param>
		/// <param name="maxInputCount">The maximum amount of inputs. The <see cref="MatrixHelper.DisplayedInputs"/> property cannot be larger than this value.</param>
		/// <param name="maxOutputCount">The maximum amount of outputs. The <see cref="MatrixHelper.DisplayedOutputs"/> property cannot be larger than this value.</param>
		/// <param name="matrixSerializedParameterId">The parameter ID of the single parameter that contains all the matrix content in one JSON serialized string.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.
		/// -or-
		/// GetElementProtocolResponseMessage is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ArgumentException">Invalid <paramref name="matrixConnectionsBufferParameterId"/>.
		/// -or-
		/// Invalid <paramref name="matrixSerializedParameterId"/>.
		/// -or-
		/// The specified <paramref name="inputsTableParameterId"/> does not contain the valid read and/or write columns.
		/// -or-
		/// The specified <paramref name="outputsTableParameterId"/> does not contain the valid read and/or write columns.
		/// -or-
		/// The parameter for virtual sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by <paramref name="outputsTableParameterId"/> appended with "VirtualSets".
		/// -or-
		/// The parameter for serialized sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by <paramref name="outputsTableParameterId"/> appended with "SerializedSets".
		/// -or-
		/// The specified <paramref name="inputsTableParameterId"/> or <paramref name="outputsTableParameterId"/> is not valid.
		/// -or-
		/// A valid <paramref name="maxInputCount"/> and <paramref name="maxOutputCount"/> need to be provided when there is no matrix parameter.
		/// </exception>
		public MatrixHelperForTables(SLProtocol protocol, int matrixConnectionsBufferParameterId, int inputsTableParameterId, int outputsTableParameterId, int maxInputCount, int maxOutputCount, int matrixSerializedParameterId) : base(
			protocol: protocol,
			maxInputCount: maxInputCount,
			maxOutputCount: maxOutputCount,
			matrixHelperParameters: null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForTables"/> class with all parameter IDs specified, except the matrixSerializedParameterId. It is the intention that this parameter is always filled in, however the possibility has been offered to skip this in case of a large table that would be causing performance issues.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="matrixConnectionsBufferParameterId">The parameter ID of the single parameter that contains all the matrix crosspoint connections in one string.</param>
		/// <param name="inputsTableParameterId">The parameter ID of the table that represents the inputs.</param>
		/// <param name="outputsTableParameterId">The parameter ID of the table that represents the outputs.</param>
		/// <param name="maxInputCount">The maximum amount of inputs. The <see cref="MatrixHelper.DisplayedInputs"/> property cannot be larger than this value.</param>
		/// <param name="maxOutputCount">The maximum amount of outputs. The <see cref="MatrixHelper.DisplayedOutputs"/> property cannot be larger than this value.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.
		/// -or-
		/// GetElementProtocolResponseMessage is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ArgumentException">Invalid <paramref name="matrixConnectionsBufferParameterId"/>.
		/// -or-
		/// The specified <paramref name="inputsTableParameterId"/> does not contain the valid read and/or write columns.
		/// -or-
		/// The specified <paramref name="outputsTableParameterId"/> does not contain the valid read and/or write columns.
		/// -or-
		/// The parameter for virtual sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by <paramref name="outputsTableParameterId"/> appended with "VirtualSets".
		/// -or-
		/// The parameter for serialized sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by <paramref name="outputsTableParameterId"/> appended with "SerializedSets".
		/// -or-
		/// The specified <paramref name="inputsTableParameterId"/> or <paramref name="outputsTableParameterId"/> is not valid.
		/// -or-
		/// A valid <paramref name="maxInputCount"/> and <paramref name="maxOutputCount"/> need to be provided when there is no matrix parameter.
		/// </exception>
		public MatrixHelperForTables(SLProtocol protocol, int matrixConnectionsBufferParameterId, int inputsTableParameterId, int outputsTableParameterId, int maxInputCount, int maxOutputCount) : base(
			protocol: protocol,
			maxInputCount: maxInputCount,
			maxOutputCount: maxOutputCount,
			matrixHelperParameters: null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForTables"/> class with automatic detection of the table parameters.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="maxInputCount">The maximum amount of inputs. The <see cref="MatrixHelper.DisplayedInputs"/> property cannot be larger than this value.</param>
		/// <param name="maxOutputCount">The maximum amount of outputs. The <see cref="MatrixHelper.DisplayedOutputs"/> property cannot be larger than this value.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.
		/// -or-
		/// GetElementProtocolResponseMessage is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ArgumentException">A valid <paramref name="maxInputCount"/> and <paramref name="maxOutputCount"/> needs to be provided when there is no matrix parameter.
		/// -or-
		/// The parameter for virtual sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by the found outputsTableParameter appended with "VirtualSets".
		/// -or-
		/// The parameter for serialized sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by the found outputsTableParameter appended with "SerializedSets".
		/// </exception>
		public MatrixHelperForTables(SLProtocol protocol, int maxInputCount, int maxOutputCount) : base(
			protocol: protocol,
			maxInputCount: maxInputCount,
			maxOutputCount: maxOutputCount,
			matrixHelperParameters: null)
		{
		}
	}
}
