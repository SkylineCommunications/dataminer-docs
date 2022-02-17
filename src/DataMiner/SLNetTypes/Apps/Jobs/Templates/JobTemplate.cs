using System;

using Newtonsoft.Json;

using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a job template.
	/// </summary>
	/// <remarks>
	/// <para>An existing job can be saved as a job template. This job template can then be applied on other jobs.</para>
	/// <para>This is done using the ApplyTo(Job) method. This will override all the existing data in the specified job with the data from the template.</para>
	/// <para>Feature introduced in DataMiner 9.6.6 (RN 21380).</para>
	/// </remarks>
	[Serializable]
    //[DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class JobTemplate : IEquatable<JobTemplate>, ICloneable, CustomDataType, IManagerIdentifiableObject<JobTemplateID>, ITrackLastModified
    {
        #region Properties & Fields

        //[DataMember(Name = "ID")]
        private JobTemplateID _ID;

		/// <summary>
		/// Gets or sets the job template ID.
		/// </summary>
		/// <value>The job template ID.</value>
		public JobTemplateID ID
        {
			get;
			set;
        }

		/// <summary>
		/// Gets or sets the last modification time.
		/// </summary>
		/// <value>The last modification time.</value>
		//[DataMember(Name = "SyncLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }

		/// <summary>
		/// Gets or sets the job template name.
		/// </summary>
		/// <value>The job template name.</value>
		//[DataMember(Name = "Name")]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the job template data.
		/// </summary>
		/// <value>The job template data.</value>
		//[DataMember(Name = "Job")]
        public Job TemplateData { get; set; }

		#endregion Properties & Fields

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="JobTemplate"/> class.
		/// </summary>
		public JobTemplate()
        {
        }


		#endregion Constructor

		#region Public Methods
		/// <summary>
		/// Converts this job template to an ID-based filter of the specified type.
		/// </summary>
		/// <typeparam name="T">The filter element type.</typeparam>
		/// <returns>The created filter element of the specified type.</returns>
		public FilterElement<T> ToFilter<T>()
        {
			return null;
		}

		#endregion Public Methods

		#region JSON Serialization
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
		public static JobTemplate FromJson(string json)
        {
			return null;
		}
		#endregion JSON Serialization

		#region Equals & HashCode & ToString
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
		public bool Equals(JobTemplate other)
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
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
			return null;
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		#endregion Equals & HashCode & ToString

		#region DataType

		bool DataType.FromMigration { get; set; }

		string DataType.DataTypeID => ID.SafeId().ToString();

		string[] DataType.ToStringArray()
		{
			throw new NotSupportedException();
		}

		object[] DataType.ToInterOp()
		{
			throw new NotSupportedException();
		}

		DataType DataType.toType(string[] data)
		{
			throw new NotSupportedException();
		}

		#endregion DataType
	}
}