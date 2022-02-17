using Newtonsoft.Json;
using Skyline.DataMiner.Net.IManager.Objects;
//using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
//using Skyline.DataMiner.Net.Messages.SLDataGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Records
{
	/// <summary>
	/// Defines the cells of record, defining the name and type of each cell.
	/// </summary>
	[Serializable]
	//[DataContract]
	public sealed class RecordDefinition : CustomDataType, IEquatable<RecordDefinition>, IManagerIdentifiableObject<RecordDefinitionID>, ITrackLastModified
	{
		/// <summary>
		/// Gets or sets the record definition ID.
		/// </summary>
		/// <value>The record definition ID.</value>
		public RecordDefinitionID ID
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the record definition name.
		/// </summary>
		/// <value>The record definition name.</value>
		//[DataMember(Name = "Name")]
        public string Name { get; set; }

		/// <summary>
		/// Gets the record cell definitions.
		/// </summary>
		/// <value>The record cell definitions.</value>
		//[DataMember(Name = "CellDefinitions")]
        public List<RecordCellDefinition> CellDefinitions { get; private set; }

		/// <summary>
		/// Gets the last modifcation time.
		/// </summary>
		/// <value>The last modification time.</value>
		//[DataMember(Name = "SyncLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }

        static RecordDefinition()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="RecordDefinition"/> class.
		/// </summary>
		public RecordDefinition()
        {
        }

		/// <summary>
		/// Retrieves the JSON representation of this object.
		/// </summary>
		/// <returns>The JSON representation of this object.</returns>
		public string ToJson()
        {

            return "";
        }

		/// <summary>
		/// Deserializes the specified JSON string into a new instance of this class.
		/// </summary>
		/// <param name="json">The JSON string.</param>
		/// <returns>The deserialized object.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="json"/> is <see langword="null"/>.</exception>
		public static RecordDefinition FromJson(string json)
        {
			return null;
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
		public bool Equals(RecordDefinition other)
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

        //[IgnoreDataMember]
        bool DataType.FromMigration { get; set; }

		//[IgnoreDataMember]
		string DataType.DataTypeID => "";

		/// <summary>
		/// Converts this record definition to an ID-based filter of the specified type.
		/// </summary>
		/// <typeparam name="T">The filter element type.</typeparam>
		/// <returns>The created filter element of the specified type.</returns>
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
	}
}
