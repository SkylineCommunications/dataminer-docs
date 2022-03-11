using Skyline.DataMiner.Net.Records;
using Skyline.DataMiner.Net.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a record definition error.
	/// </summary>
	[Serializable]
    public class RecordDefinitionError : ErrorData
    {
        public enum Reason
        {
			/// <summary>
			/// Record definition type not supported.
			/// </summary>
			/// <remarks>
			/// While creating or updating a <see cref="RecordDefinition"/>, not all the types specified in the <see cref="RecordCellDefinition"/> are supported.
			/// <para><see cref="RecordDefinition"/> contains the invalid record definition</para>
			/// <para><see cref="RecordCellDefinition"/> contains the invalid record cell definition</para>
			/// <para><see cref="InvalidType"/> contains the invalid type</para>
			/// <para><see cref="SupportedTypes"/> contains the supported types type</para>
			/// </remarks>
			RecordDefinitionTypeNotSupported = 1,

			/// <summary>
			/// Record definition has records.
			/// </summary>
			/// <remarks>
			/// While updating or deleting a <see cref="RecordDefinition"/>, the given <see cref="RecordDefinition"/> has exising <see cref="Record"/>s, which block the operation.
			/// <para><see cref="RecordDefinition"/> contains the reoord definition</para>
			/// <para><see cref="RecordIDs"/> contains the record ids</para>
			/// </remarks>
			RecordDefintionHasRecords = 2,
        }

		/// <summary>
		/// Gets or sets the error reason.
		/// </summary>
		/// <value>The error reason.</value>
		public Reason ErrorReason { get; set; }

		/// <summary>
		/// Gets or sets the record definition this error relates to.
		/// </summary>
		/// <value>The record definition this error relates to.</value>
		public RecordDefinition RecordDefinition { get; set; }

		/// <summary>
		/// Gets or sets the record cell definition this error relates to.
		/// </summary>
		/// <value>The record cell definition this error relates to.</value>
		public RecordCellDefinition RecordCellDefinition { get; set; }

		/// <summary>
		/// Gets or sets the invalid type.
		/// </summary>
		/// <value>The invalid type.</value>
		public Type InvalidType { get; set; }

		/// <summary>
		/// Gets or sets the supported types.
		/// </summary>
		/// <value>The supported types.</value>
		public List<Type> SupportedTypes { get; set; } = new List<Type>();

		/// <summary>
		/// Gets or sets the record IDs.
		/// </summary>
		/// <value>The record IDs.</value>
		public List<RecordID> RecordIDs { get; set; } = new List<RecordID>();

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordDefinitionError"/> class.
		/// </summary>
		public RecordDefinitionError()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordDefinitionError"/> class using the specified error reason, record definition and record IDs.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="recordDefinition">The record definition.</param>
		/// <param name="recordIDs">The record IDs.</param>
		public RecordDefinitionError(Reason errorReason, RecordDefinition recordDefinition, List<RecordID> recordIDs)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordDefinitionError"/> class using the specified error reason, record definition and record IDs.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="recordDefinition">The record definition.</param>
		/// <param name="recordCellDefinition">The record cell definition.</param>
		/// <param name="invalidType">The invalid type.</param>
		/// <param name="supportedTypes">The supported types.</param>
		public RecordDefinitionError(Reason errorReason, RecordDefinition recordDefinition, RecordCellDefinition recordCellDefinition, Type invalidType, List<Type> supportedTypes)
        {
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {

            return "";
        }
    }
}