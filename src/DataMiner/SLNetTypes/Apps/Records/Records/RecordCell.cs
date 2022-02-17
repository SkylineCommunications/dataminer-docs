using System;

using Skyline.DataMiner.Net.Sections;

namespace Skyline.DataMiner.Net.Records
{
	/// <summary>
	/// Represents a record cell.
	/// </summary>
	[Serializable]
    //[DataContract]
    public sealed class RecordCell : IEquatable<RecordCell>
    {
		/// <summary>
		/// Gets or sets the cell definition ID.
		/// </summary>
		/// <value>The cell definition ID.</value>
		public RecordCellDefinitionID CellDefinitionID
        {
			get; set;
        }

		/// <summary>
		/// Gets the cell value.
		/// </summary>
		/// <value>The cell value.</value>
		//[DataMember(Name = "Value")]
        public IValueWrapper Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordCell"/> class.
		/// </summary>
		public RecordCell()
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

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
            return false;
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(RecordCell other)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 0;
        }
    }
}
