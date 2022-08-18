namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;

	using Net.Messages;

	using Skyline.DataMiner.Scripting;

	/// <summary>
	/// Represents a matrix UI control in a DataMiner protocol. To be used when the protocol only has a matrix measurement type parameter to represent the connections.
	/// </summary>
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedScripting.dll")]
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
	public class MatrixHelperForMatrix : MatrixHelper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForMatrix"/> class with all parameter IDs specified.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="matrixConnectionsBufferParameterId">The parameter ID of the single parameter that contains all the matrix crosspoint connections in one string.</param>
		/// <param name="matrixReadParameterId">The parameter ID of the matrix read parameter.</param>
		/// <param name="discreetInfoParameterId">The parameter ID of the discreet info type parameter.</param>
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
		/// </exception>
		public MatrixHelperForMatrix(SLProtocol protocol, int matrixConnectionsBufferParameterId, int matrixReadParameterId, int discreetInfoParameterId, int matrixSerializedParameterId) : base(
			protocol: protocol,
			maxInputCount: 0,
			maxOutputCount: 0,
			matrixHelperParameters: null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForMatrix"/> class with all parameter IDs specified, except the matrixSerializedParameterId. It is the intention that this parameter is always filled in, however the possibility has been offered to skip this in case of a large table that would be causing performance issues.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="matrixConnectionsBufferParameterId">The parameter ID of the single parameter that contains all the matrix crosspoint connections in one string.</param>
		/// <param name="matrixReadParameterId">The parameter ID of the matrix read parameter.</param>
		/// <param name="discreetInfoParameterId">The parameter ID of the discreet info type parameter.</param>
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
		/// </exception>
		public MatrixHelperForMatrix(SLProtocol protocol, int matrixConnectionsBufferParameterId, int matrixReadParameterId, int discreetInfoParameterId) : base(
			protocol: protocol,
			maxInputCount: 0,
			maxOutputCount: 0,
			matrixHelperParameters: null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MatrixHelperForMatrix"/> class with automatic detection of the matrix parameters.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <param name="discreetInfoParameterId">The parameter ID of the discreet info type parameter.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.
		/// -or-
		/// GetElementProtocolResponseMessage is <see langword="null"/>.
		/// </exception>
		/// <exception cref="ArgumentException">The driver does not have one matrix parameter of type read and write.
		/// -or-
		/// Invalid <paramref name="discreetInfoParameterId"/>.
		/// </exception>
		public MatrixHelperForMatrix(SLProtocol protocol, int discreetInfoParameterId) : base(
			protocol: protocol,
			maxInputCount: 0,
			maxOutputCount: 0,
			matrixHelperParameters: null)
		{
		}
	}
}
