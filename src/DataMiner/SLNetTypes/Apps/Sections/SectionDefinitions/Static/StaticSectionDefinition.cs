using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a section definition that can only be changed under certain conditions.
	/// </summary>
	/// <remarks>
	/// Most of the structure of these section definitions is enforced by the server.
	/// The allowed changes on these section definitions are:
	/// <list type="bullet">
	/// <item>
	///    <description>The name of the section definition</description>
	/// </item>
	/// <item>
	///    <description>The name of its fields</description>  
	/// </item>
	/// </list>
	/// </remarks>
	[Serializable]
    //[DataContract]
    public abstract class StaticSectionDefinition : SectionDefinition, IEquatable<StaticSectionDefinition>
    {
		/// <summary>
		/// Gets the custom field names.
		/// </summary>
		/// <value>The custom field names.</value>
		protected Dictionary<Guid, string> CustomFieldNames;

		/// <summary>
		/// Gets the static section definition registry.
		/// </summary>
		/// <value>The static section definition registry.</value>
		public static IReadOnlyList<StaticSectionDefinition> Registry { get; }

		/// <summary>
		/// Retrieves all field descriptors of this section definition.
		/// </summary>
		/// <returns>All field descriptors of this section definition.</returns>
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
		/// Retrieves the name of this section definition.
		/// </summary>
		/// <returns>The name of this section definition.</returns>
		/// <remarks>This call returns the custom name. If no custom name was specified, the default name is returned.</remarks>
		public override string GetName()
        {
			return null;
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
		public override bool GetIsHidden()
        {
            return false;
        }

		/// <summary>
		/// Retrieves the default section definition ID.
		/// </summary>
		/// <returns>The default section definition ID.</returns>
		protected abstract SectionDefinitionID GetDefaultID();

		/// <summary>
		/// Retrieves the default name.
		/// </summary>
		/// <returns>The default name.</returns>
		protected abstract string GetDefaultName();

		/// <summary>
		/// Retrieves the default field descriptors.
		/// </summary>
		/// <returns>The default field descriptors.</returns>
		protected abstract List<FieldDescriptor> GetDefaultFieldDescriptors();

		/// <summary>
		/// Retrieves the default section validators.
		/// </summary>
		/// <returns>The default section validators.</returns>
		protected abstract List<ISectionValidator> GetDefaultSectionValidators();

		/// <summary>
		/// Sets the custom name of the specified field descriptor.
		/// </summary>
		/// <param name="fieldDescriptor">The field descriptor for which the custom name should be set.</param>
		/// <param name="name">The custom name.</param>
		/// <exception cref="ArgumentNullException">if <paramref name="name"/> is null, empty or whitespace</exception>
		public void SetCustomFieldName(FieldDescriptorID fieldDescriptor, string name)
        {
        }

		/// <summary>
		/// Removes the custom field name of the specified field descriptor.
		/// </summary>
		/// <param name="fieldDescriptor">The field descriptor for which to remove the custom name.</param>
		public void RemoveCustomFieldName(FieldDescriptorID fieldDescriptor)
        {
        }

		/// <summary>
		/// Sets the custom name of this section definition.
		/// </summary>
		/// <param name="customName">The custom name.</param>
		public void SetCustomName(string customName)
        {
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(StaticSectionDefinition other)
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