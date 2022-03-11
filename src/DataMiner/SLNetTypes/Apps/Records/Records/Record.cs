using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.Net.ToolsSpace.Collections;

namespace Skyline.DataMiner.Net.Records
{
	/// <summary>
	/// Represents a record consisting of cell values complying with its corresponding record definition.
	/// </summary>
	//[DataContract]
    [Serializable]
    public sealed class Record : CustomDataType, IEquatable<Record>, IManagerIdentifiableObject<RecordID>, ITrackLastModified
    {
		/// <summary>
		/// Gets or sets the record ID.
		/// </summary>
		/// <value>The record ID.</value>
		public RecordID ID
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the record definition ID.
		/// </summary>
		/// <value>The record definition ID.</value>
		public RecordDefinitionID RecordDefinitionID
        {
			get; set;
        }

		/// <summary>
		/// Gets the record cells.
		/// </summary>
		/// <value>The record cells.</value>
		//[DataMember(Name = "Cells")]
        public List<RecordCell> Cells { get; private set; }

		/// <summary>
		/// Gets or sets the last modification time.
		/// </summary>
		/// <value>The last modification time.</value>
		//[DataMember(Name = "SyncLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }

        static Record()
        {
            
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Record"/> class.
		/// </summary>
		public Record()
        {
        }

		/// <summary>
		/// Returns this Job as a JSON serializable dictionary.
		/// </summary>
		/// <returns>The JSON serializable dictionary representation of this Job.</returns>
		///// <remarks>
		///// Will convert all the cells to a JSONSerializableDictionary.
		///// They are mapped RecordCellDefinition GUID -> value object (note: not <see cref="ValueWrapper{T}"/>)
		///// If there are multiple RecordCells for the same RecordCellDefinition, only one of them is put in the dictionary.
		///// RecordCells with a type that is not allowed in a JSONSerializableDictionary are added using their .ToString() method
		///// </remarks>
		///// <returns>never null</returns>
		public JSONSerializableDictionary AsJsonSerializableDictionary()
        {
			return null;
		}

		/// <summary>
		/// Retrieves the JSON representation of this object.
		/// </summary>
		/// <returns>The JSON representation of this object.</returns>
		public string ToJson()
        {
			return null;
		}

		/// <summary>
		/// Deserializes the specified JSON string into a new instance of this class.
		/// </summary>
		/// <param name="json">The JSON string.</param>
		/// <returns>The deserialized object.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="json"/> is <see langword="null"/>.</exception>
		public static Record FromJson(string json)
        {
			return null;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
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
		public bool Equals(Record other)
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

		/// <summary>
		/// Creates a <see cref="FilterElement{T}"/> instance for this object.
		/// </summary>
		/// <typeparam name="T">The type of the filter element.</typeparam>
		/// <returns>The created <see cref="FilterElement{T}"/> instance.</returns>
		public FilterElement<T> ToFilter<T>()
        {
            return null;
        }

		bool DataType.FromMigration { get; set; }

		
		string DataType.DataTypeID => null;

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
	}
}
