using System;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a time range validator. This validator defines that there are two <see cref="DateTime"/> fields in the <see cref="SectionDefinition"/>, where one represents the start time and the other the end time. This validator validates whether the end time is always later than the start time.
	/// </summary>
	[Serializable]
    //[DataContract]
    public sealed class TimeRangeSectionValidator : ISectionValidator, IEquatable<TimeRangeSectionValidator>
    {
		/// <summary>
		/// Gets or sets the field descriptor ID of the start time field.
		/// </summary>
		/// <value>The field descriptor ID of the start time field.</value>
		//[DataMember(Name = "StartTimeID")]
        public FieldDescriptorID StartTimeID { get; set; }

		/// <summary>
		/// Gets or sets the field descriptor ID of the end time field.
		/// </summary>
		/// <value>The field descriptor ID of the end time field.</value>
		//[DataMember(Name = "EndTimeID")]
        public FieldDescriptorID EndTimeID { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeRangeSectionValidator"/> class.
		/// </summary>
		public TimeRangeSectionValidator()
            : this(null, null)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TimeRangeSectionValidator"/> class with the specified start and end time.
		/// </summary>
		/// <param name="startTimeID">The field descriptor ID of the start time field.</param>
		/// <param name="endTimeID">The field descriptor ID of the end time field.</param>
		public TimeRangeSectionValidator(FieldDescriptorID startTimeID, FieldDescriptorID endTimeID)
        {
        }

		/// <summary>
		/// Validates the specified section.
		/// </summary>
		/// <param name="section">The section to validate.</param>
		/// <returns><c>true</c> if the specified section validates against this validator; otherwise, <c>false</c>.</returns>
		public bool Validate(Section section)
        {
			return false;
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
		public bool Equals(TimeRangeSectionValidator other)
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
