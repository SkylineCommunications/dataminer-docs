using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Jobs;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a custom section definition. This type of section definition can be created and updated by the user. The fields and validators are chosen freely.
	/// </summary>
	/// <example>
	/// <code>
	/// JobManagerHelper jobManagerHelper = new JobManagerHelper(msg => protocol.SLNet.RawConnection.HandleMessages(msg));
	///
	/// var sectionDefinition = new CustomSectionDefinition
	/// {
	/// Name = "MyCustomSectionDefinition"
	/// };
	///
	/// var fieldDescriptor = new FieldDescriptor
	/// {
	///		Name = "MyStringField",
	///		FieldType = typeof(string),
	/// 	IsOptional = true,
	/// };
	///
	/// sectionDefinition.AddOrReplaceFieldDescriptor(fieldDescriptor);
	/// sectionDefinition = jobManagerHelper.SectionDefinitions.Create(sectionDefinition) as CustomSectionDefinition;
	/// </code>
	/// </example>
	[Serializable]
    //[DataContract]
    public class CustomSectionDefinition : SectionDefinition, IEquatable<CustomSectionDefinition>
    {

		/// <summary>
		/// Gets or sets the section definition ID.
		/// </summary>
		/// <value>The section definition ID.</value>
		public SectionDefinitionID ID
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
        {
			get; set;
        }

		/// <summary>
		/// Gets the section validators.
		/// </summary>
		/// <value>The section validators.</value>
		/// <remarks>
		/// <para>The section validators define certain restrictions or relations between fields of this section definition which that be kept valid.</para>
		/// </remarks>
		//[DataMember(Name = "SectionValidators")]
        public List<ISectionValidator> SectionValidators { get; private set; }

		/// <summary>
		/// Gets or sets the reservation link info.
		/// </summary>
		/// <value>The reservation link info.</value>
		//[DataMember(Name = "ReservationLinkInfo")]
        public ReservationLinkInfo ReservationLinkInfo { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this section definition is hidden.
		/// </summary>
		/// <value><c>true</c> if this section definition is hidden; otherwise, <c>false</c>.</value>
		/// <remarks>If <c>true</c>, the sections that use this section definition will not be displayed when a <see cref="Job"/> is viewed.</remarks>
		[Obsolete("Use IsSoftDeleted on the SectionDefinitionLink of a JobDomain")]
        //[DataMember(Name = "IsHidden")]
        public bool IsHidden { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomSectionDefinition"/> class.
		/// </summary>
		public CustomSectionDefinition()
            : base()
        {
        }

		/// <summary>
		/// Sets the section definition ID.
		/// </summary>
		/// <param name="id">The section definition ID.</param>
		public void SetID(SectionDefinitionID id)
        {
        }

		/// <summary>
		/// Retrieves the section definition ID.
		/// </summary>
		/// <returns>The section definition ID.</returns>
		public override SectionDefinitionID GetID()
        {
            return null;
        }

		/// <summary>
		/// Retrieves the name of this custom section definition.
		/// </summary>
		/// <returns>The name of this custom section definition.</returns>
		public override string GetName()
        {
            return "";
        }

		/// <summary>
		/// Retrieves all field descriptors.
		/// </summary>
		/// <returns>The field descriptors.</returns>
		public override IReadOnlyList<FieldDescriptor> GetAllFieldDescriptors()
        {
            return null;
        }

		/// <summary>
		/// Retrieves all section validators.
		/// </summary>
		/// <returns>The section validators.</returns>
		public override IReadOnlyList<ISectionValidator> GetAllSectionValidators()
        {
            return null;
        }

		/// <summary>
		/// Retrieves the reservation link info.
		/// </summary>
		/// <returns>The reservation link info.</returns>
		public override ReservationLinkInfo GetReservationLinkInfo()
        {
            return null;
        }

		/// <summary>
		/// Retrieves a value indicating whether this section definition is hidden.
		/// </summary>
		/// <returns><c>true</c> if this section definition is hidden; otherwise, <c>false</c>.</returns>
		[Obsolete("Use IsSoftDeleted on the SectionDefinitionLink of a JobDomain")]
        public override bool GetIsHidden()
        {
            return true;
        }

		/// <summary>
		/// Adds or replaces the specified field descriptor.
		/// </summary>
		/// <param name="descriptor">The field descriptor to add or replace.</param>
		public void AddOrReplaceFieldDescriptor(FieldDescriptor descriptor)
        {
        }

		/// <summary>
		/// Removes the field descriptor with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the field descriptor to remove.</param>
		public void RemoveFieldDescriptor(FieldDescriptorID id)
        {
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(CustomSectionDefinition other)
        {
            return true;
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
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 1;
        }
    }
}