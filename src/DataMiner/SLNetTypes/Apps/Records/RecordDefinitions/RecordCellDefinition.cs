using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Records
{
	/// <summary>
	/// Represents a record cell definition.
	/// </summary>
	//[DataContract]
    [Serializable]
    public sealed class RecordCellDefinition : IEquatable<RecordCellDefinition>
    {
		/// <summary>
		/// List of the supported types. The supported types are: <see cref="String"/>, <see cref="Double"/>, <see cref="long"/>, <see cref="DateTime"/>.
		/// </summary>
		public static readonly IReadOnlyList<Type> SupportedTypes;

		/// <summary>
		/// Gets or sets the record cell definition ID.
		/// </summary>
		/// <value>The record cell definition ID.</value>
		public RecordCellDefinitionID ID
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the record cell definition name.
		/// </summary>
		/// <value>The record cell definition name.</value>
		//[DataMember(Name = "Name")]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the cell type.
		/// </summary>
		/// <value>The cell type.</value>
		//[DataMember(Name = "CellType")]
        public Type CellType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordCellDefinition"/> class.
		/// </summary>
		public RecordCellDefinition()
        {
        }

        internal string GetDictFieldName()
        {
            return "";
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
            return true;
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(RecordCellDefinition other)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 1;
        }
    }
}
