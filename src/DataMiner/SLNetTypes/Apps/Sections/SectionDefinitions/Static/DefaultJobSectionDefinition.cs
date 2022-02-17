using Skyline.DataMiner.Net.Jobs;
using Skyline.DataMiner.Net.Time;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a default Job section definition containing the fields "Name", "Start Time" and "End Time".
	/// </summary>
	/// <remarks>Every <see cref="Job"/> is required to have exactly one section that uses this section definition.</remarks>
	[Serializable]
    //[DataContract]
    public sealed class DefaultJobSectionDefinition : StaticSectionDefinition, IEquatable<DefaultJobSectionDefinition>
    {
		/// <summary>
		/// The descriptor ID of the name field.
		/// </summary>
		public static readonly FieldDescriptorID NameFieldDescriptorID;
		/// <summary>
		/// The descriptor ID of the start time field.
		/// </summary>
		public static readonly FieldDescriptorID StartTimeFieldDescriptorID;
		/// <summary>
		/// The descriptor ID of the end time field.
		/// </summary>
		public static readonly FieldDescriptorID EndTimeFieldDescriptorID;
		/// <summary>
		/// The section definition ID of the default Job section.
		/// </summary>
		public static readonly SectionDefinitionID DefaultJobSectionID;

		/// <summary>
		/// Gets a new instance of <see cref="DefaultJobSectionDefinition"/>.
		/// </summary>
		public static DefaultJobSectionDefinition Instance { get; } = new DefaultJobSectionDefinition();

		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultJobSectionDefinition"/> class.
		/// </summary>
		public DefaultJobSectionDefinition()
            : base()
        {
        }

		/// <summary>
		/// Retrieves the default section ID.
		/// </summary>
		/// <returns>The default section ID.</returns>
		protected override SectionDefinitionID GetDefaultID()
        {
            return null;
        }

		/// <summary>
		/// Retrieves the default name.
		/// </summary>
		/// <returns>The default name.</returns>
		protected override string GetDefaultName()
        {
            return "";
        }

		/// <summary>
		/// Retrieves the default field descriptors.
		/// </summary>
		/// <returns>The default field descriptors.</returns>
		/// <remarks>The default field descriptors are "Name", "Start Time" and "End Time".</remarks>
		protected override List<FieldDescriptor> GetDefaultFieldDescriptors()
        {
            return null;
        }

		/// <summary>
		/// Retrieves the default section validators.
		/// </summary>
		/// <returns>The default section validators.</returns>
		/// <remarks>The default validators consist of a <see cref="TimeRangeSectionValidator"/> for validating the start time and end time.</remarks>
		protected override List<ISectionValidator> GetDefaultSectionValidators()
        {
            return null;
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
		public bool Equals(DefaultJobSectionDefinition other)
        {
            return false;
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