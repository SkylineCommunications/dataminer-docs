using Newtonsoft.Json;
using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a section definition. A section definition defines which fields belong to a section.
	/// </summary>
	[Serializable]
    //[DataContract]
    public class SectionDefinition : CustomDataType, IEquatable<SectionDefinition>, IManagerIdentifiableObject<SectionDefinitionID>, ITrackLastModified
    {
		/// <summary>
		/// Gets the section definition ID.
		/// </summary>
		/// <value>The section definition ID.</value>
		#region Public properties
		SectionDefinitionID IManagerIdentifiableObject<SectionDefinitionID>.ID => null;

		/// <summary>
		/// Gets or sets the time this definition was modified.
		/// </summary>
		/// <value>The time this definition was modified.</value>
		//[DataMember(Name = "SyncLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }

		#endregion Public properties

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinition"/> class.
		/// </summary>
		public SectionDefinition()
        {
        }

        static SectionDefinition()
        {
        }

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Retrieves the section definition ID.
		/// </summary>
		/// <returns>The section definition ID.</returns>
		public virtual SectionDefinitionID GetID()
        {
            throw new NotSupportedException();
        }

		/// <summary>
		/// Retrieves the name of this custom section definition.
		/// </summary>
		/// <returns>The name of this custom section definition.</returns>
		public virtual string GetName()
        {
            throw new NotSupportedException();
        }

		/// <summary>
		/// Retrieves the reservation link info.
		/// </summary>
		/// <returns>The reservation link info.</returns>
		public virtual ReservationLinkInfo GetReservationLinkInfo()
        {
            throw new NotSupportedException();
        }

		/// <summary>
		/// Retrieves a value indicating whether this section definition is hidden.
		/// </summary>
		/// <returns><c>true</c> if this section definition is hidden; otherwise, <c>false</c>.</returns>
		public virtual bool GetIsHidden()
        {
            throw new NotSupportedException();
        }

		/// <summary>
		/// Retrieves all field descriptors.
		/// </summary>
		/// <returns>The field descriptors.</returns>
		public virtual IReadOnlyList<FieldDescriptor> GetAllFieldDescriptors()
        {
            throw new NotSupportedException();
        }

		/// <summary>
		/// Retrieves all section validators.
		/// </summary>
		/// <returns>The section validators.</returns>
		public virtual IReadOnlyList<ISectionValidator> GetAllSectionValidators()
        {
            throw new NotSupportedException();
        }

		/// <summary>
		/// Retrieves the field descriptor with the specified ID.
		/// </summary>
		/// <param name="id">The field descriptor ID.</param>
		/// <returns>The field descriptor that corresponds with the specified ID or <see langword="null"/> if no field descriptor with the specified ID was found.</returns>
		public FieldDescriptor GetFieldDescriptorById(FieldDescriptorID id)
        {
            return null;
        }

		#endregion Public Methods

		#region JSON Serialization
		/// <summary>
		/// Retrieves the JSON representation of this <see cref="SectionDefinition"/> object.
		/// </summary>
		/// <returns>The JSON representation of this <see cref="SectionDefinition"/> object.</returns>
		public string ToJson()
        {
			return "";
        }

		/// <summary>
		/// Deserializes the specified JSON string into a new instance of the <see cref="SectionDefinition"/> class.
		/// </summary>
		/// <param name="json">The JSON string.</param>
		/// <returns>The deserialized object.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="json"/> is <see langword="null"/>.</exception>
		public static SectionDefinition FromJson(string json)
        {
			return null;
		}

		#endregion JSON Serialization

		#region Equals & HashCode
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
		public bool Equals(SectionDefinition other)
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

		#endregion Equals & HashCode

		#region CustomDataType
		bool DataType.FromMigration { get; set; }

		string DataType.DataTypeID => GetID().Id.ToString();

		/// <summary>
		/// Creates a <see cref="FilterElement{T}"/> instance for this object.
		/// </summary>
		/// <typeparam name="T">The type of the filter element.</typeparam>
		/// <returns>The created <see cref="FilterElement{T}"/> instance.</returns>
		public FilterElement<T> ToFilter<T>()
        {
			return null;
		}

        string[] DataType.ToStringArray()
        {
            throw new NotImplementedException();
        }

        object[] DataType.ToInterOp()
        {
            throw new NotImplementedException();
        }

        DataType DataType.toType(string[] data)
        {
            throw new NotImplementedException();
        }

        #endregion CustomDataType
    }
}