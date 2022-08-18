namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;

	using Net.Messages;

	using Skyline.DataMiner.Scripting;

	/// <summary>
	/// Represents a matrix UI control in a DataMiner protocol. To be used when the protocol has matrix and table measurement type parameters to represent the connections.
	/// </summary>
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedScripting.dll")]
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
	public class MatrixHelperForMatrixAndTables : MatrixHelper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForMatrixAndTables"/> class.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="matrixConnectionsBufferParameterId">The parameter ID of the single parameter that contains all the matrix crosspoint connections in one string.</param>
		/// <param name="matrixReadParameterId">The parameter ID of the matrix read parameter.</param>
		/// <param name="discreetInfoParameterId">The parameter ID of the discrete info type parameter.</param>
		/// <param name="inputsTableParameterId">The parameter ID of the table that represents the inputs.</param>
		/// <param name="outputsTableParameterId">The parameter ID of the table that represents the outputs.</param>
		/// <param name="matrixSerializedParameterId">The parameter ID of the single parameter that contains all the matrix content in one JSON serialized string.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.
		/// -or-
		/// GetElementProtocolResponseMessage is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ArgumentException">Invalid <paramref name="matrixConnectionsBufferParameterId"/>.
		/// -or-
		/// Invalid <paramref name="matrixSerializedParameterId"/>.
		/// -or-
		/// Invalid <paramref name="discreetInfoParameterId"/>.
		/// -or-
		/// Invalid <paramref name="matrixReadParameterId"/>.
		/// -or-
		/// The specified <paramref name="matrixReadParameterId"/> does not have a corresponding matrix parameter of type write with the same name.
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
		/// </exception>
		public MatrixHelperForMatrixAndTables(SLProtocol protocol, int matrixConnectionsBufferParameterId, int matrixReadParameterId, int discreetInfoParameterId, int inputsTableParameterId, int outputsTableParameterId, int matrixSerializedParameterId) : base(
			protocol: protocol,
			maxInputCount: 0,
			maxOutputCount: 0,
			matrixHelperParameters: null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForMatrixAndTables"/> class with all parameter IDs specified, except the matrixSerializedParameterId. It is the intention that this parameter is always filled in, however the possibility has been offered to skip this in case of a large table that would be causing performance issues.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="matrixConnectionsBufferParameterId">The parameter ID of the single parameter that contains all the matrix crosspoint connections in one string.</param>
		/// <param name="matrixReadParameterId">The parameter ID of the matrix read parameter.</param>
		/// <param name="discreetInfoParameterId">The parameter ID of the discrete info type parameter.</param>
		/// <param name="inputsTableParameterId">The parameter ID of the table that represents the inputs.</param>
		/// <param name="outputsTableParameterId">The parameter ID of the table that represents the outputs.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.
		/// -or-
		/// GetElementProtocolResponseMessage is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ArgumentException">Invalid <paramref name="matrixConnectionsBufferParameterId"/>.
		/// -or-
		/// Invalid <paramref name="discreetInfoParameterId"/>.
		/// -or-
		/// Invalid <paramref name="matrixReadParameterId"/>.
		/// -or-
		/// The specified <paramref name="matrixReadParameterId"/> does not have a corresponding matrix parameter of type write with the same name.
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
		/// </exception>
		public MatrixHelperForMatrixAndTables(SLProtocol protocol, int matrixConnectionsBufferParameterId, int matrixReadParameterId, int discreetInfoParameterId, int inputsTableParameterId, int outputsTableParameterId) : base(
			protocol: protocol,
			maxInputCount: 0,
			maxOutputCount: 0,
			matrixHelperParameters: null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForMatrixAndTables"/> class with automatic detection of the matrix parameters.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="discreetInfoParameterId">The parameter ID of the discreet info type parameter.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.
		/// -or-
		/// GetElementProtocolResponseMessage is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ArgumentException">Invalid parameter for virtual sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by the found outputsTableParameter appended with "VirtualSets".
		/// -or-
		/// The parameter for serialized sets cannot be found. This needs to be a displayed write string parameter with the same parameter name as the parameter name referred to by the found outputsTableParameter appended with "SerializedSets".
		/// </exception>
		public MatrixHelperForMatrixAndTables(SLProtocol protocol, int discreetInfoParameterId) : base(
			protocol: protocol,
			maxInputCount: 0,
			maxOutputCount: 0,
			matrixHelperParameters: null)
		{
		}

		/// <summary>
		/// Gets or sets the DisplayType. This defines if the matrix parameter and/or the table parameters are filled in.
		/// </summary>
		/// <value>The <see cref="MatrixDisplayType"/> to be displayed.</value>
		/// <exception cref="ArgumentOutOfRangeException">Unknown <see cref="MatrixDisplayType"/> was provided.</exception>
		public MatrixDisplayType DisplayType
		{
			get
			{
				return GetDisplayType();
			}

			set
			{
				SetDisplayType(value);
			}
		}
	}
}