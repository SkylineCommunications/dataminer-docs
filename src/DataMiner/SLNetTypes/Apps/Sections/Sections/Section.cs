using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security;
using Newtonsoft.Json;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.IManager.Objects;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a Job section. A section is a grouping of fields.
	/// </summary>
	/// <remarks>A section has a reference to its corresponding <see cref="SectionDefinition"/>, which defines which fields (<see cref="FieldValue"/>) can or must go in the section.</remarks>
	/// <example>
	/// <code>
	/// JobManagerHelper jobManagerHelper = new JobManagerHelper(msg => protocol.SLNet.RawConnection.HandleMessages(msg));
	/// 
	/// var sectionDefinition = jobManagerHelper.SectionDefinitions.Read(SectionDefinitionExposers.Name.Equal("MyCustomSectionDefinition")).FirstOrDefault() as CustomSectionDefinition;
	/// var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors().FirstOrDefault(x => x.Name == "MyStringField");
	/// 
	/// var section = new Section(sectionDefinition);
	/// section.AddOrUpdateValue(fieldDescriptor, "My field value.");
	/// </code>
	/// </example>
	[Serializable]
    //[DataContract]
    [JsonObject(MemberSerialization.OptIn)]// this is required so that the JSON serialization doesn't use the ISerializable interface implementation
    public class Section : IEquatable<Section>, ICloneable, IManagerIdentifiableObject<SectionID>
    {
		/// <summary>
		/// Gets or sets the section ID.
		/// </summary>
		/// <value>The section ID.</value>
		public SectionID ID
        {
			get; set;
        }

		/// <summary>
		/// Gets the field values.
		/// </summary>
		/// <value>The field values.</value>
		public IReadOnlyList<FieldValue> FieldValues { get; }


		/// <summary>
		/// Gets or sets the section definition ID.
		/// </summary>
		/// <value>The section definition ID.</value>
		public SectionDefinitionID SectionDefinitionID
        {
			get; set;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Section"/> class.
		/// </summary>
		public Section()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Section"/> class using the specified section definition.
		/// </summary>
		/// <param name="existingSectionDefinition">The section definition.</param>
		/// <exception cref="ArgumentNullException"><paramref name="existingSectionDefinition"/> is <see langword="null"/>.</exception>
		/// <remarks>As the corresponding section definition is provided, this section will be already stitched.</remarks>
		public Section(SectionDefinition existingSectionDefinition)
            : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Section"/> class using the specified section definition ID.
		/// </summary>
		/// <param name="sectionDefinitionID">Section definition ID.</param>
		public Section(SectionDefinitionID sectionDefinitionID)
            : this()
        {
        }

		/// <summary>
		/// Retrieves the section definition.
		/// </summary>
		/// <returns>The section definition.</returns>
		/// <exception cref="DataMinerException">This section was not yet stitched to a section definition.</exception>
		public SectionDefinition GetSectionDefinition()
        {
			return null;
		}

		/// <summary>
		/// Retrieves the field value of the field with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the field descriptor.</param>
		/// <returns>The field value or <see langword="null"/> if no field with the specified ID is found.</returns>
		public FieldValue GetFieldValueById(FieldDescriptorID id)
        {
			return null;
		}

		/// <summary>
		/// Removes all field values with the specified field descriptor ID.
		/// </summary>
		/// <param name="id">The field descriptor ID.</param>
		/// <returns><c>true</c> if field values have been removed; otherwise, <c>false</c>.</returns>
		public bool RemoveFieldValueById(FieldDescriptorID id)
        {
			return false;
		}

		/// <summary>
		/// Adds or replaces the specified field value.
		/// </summary>
		/// <param name="value">The field value to add or replace.</param>
		public void AddOrReplaceFieldValue(FieldValue value)
        {
        }

		/// <summary>
		/// Stitches this section with the corresponding section definition.
		/// </summary>
		/// <param name="sectionDefinitionProvider">A section definition provider.</param>
		/// <remarks>This method call will also stitch all field values of the corresponding field descriptors.</remarks>
		public void Stitch(Func<SectionDefinitionID, SectionDefinition> sectionDefinitionProvider)
        {
        }

		/// <summary>
		/// Retrieves the JSON representation of this <see cref="Section"/> object.
		/// </summary>
		/// <returns>The JSON representation of this <see cref="Section"/> object.</returns>
		public string ToJson()
        {
			return "";
        }

		/// <summary>
		/// Deserializes the specified JSON string into a new instance of the <see cref="Section"/> class.
		/// </summary>
		/// <param name="json">The JSON string.</param>
		/// <returns>The deserialized object.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="json"/> is <see langword="null"/>.</exception>
		public static Section FromJson(string json)
        {
			return null;
		}

		/// <summary>
		/// Populates a <see cref="SerializationInfo"/>  with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
		/// <exception cref="SecurityException">The caller does not have the required permission.</exception>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Section"/> class using the specified serialization info and streaming context.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		public Section(SerializationInfo info, StreamingContext context)
        {
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(Section other)
        {
            return true;
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
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 1;
        }
    }
}