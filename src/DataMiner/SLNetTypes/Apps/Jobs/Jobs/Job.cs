using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.Net.ToolsSpace.Collections;
#pragma warning disable 618

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a job.
	/// </summary>
	/// <remarks>
	/// <para>A job consists of a number of sections and each section in turn consists of a number of FieldValues.</para>
	/// <para>A job may contain multiple sections with the same <see cref="SectionDefinition"/>.</para>
	/// <para>The following diagram gives an overview of the different classes in the Jobs API:</para>
	/// <img src="~/develop/images/JobMVP.png" />
	/// </remarks>
	/// <example>
	/// <code>
	/// JobManagerHelper jobManagerHelper = new JobManagerHelper(msg => protocol.SLNet.RawConnection.HandleMessages(msg));
	/// 
	/// var sectionDefinition = jobManagerHelper.SectionDefinitions.Read(SectionDefinitionExposers.Name.Equal("MyCustomSectionDefinition")).FirstOrDefault() as CustomSectionDefinition;
	/// var fieldDescriptor = sectionDefinition.GetAllFieldDescriptors().FirstOrDefault(x => x.Name == "MyStringField");
	/// 
	/// var startTime = DateTime.UtcNow;
	/// var endTime = startTime.AddHours(10);
	/// 
	/// Job job = new Job();
	/// job.SetJobName("MyJob");
	/// job.SetJobStartTime(startTime);
	/// job.SetJobEndTime(endTime);
	/// 
	/// // Add a section to the Job.
	/// var section = new Section(sectionDefinition);
	/// section.AddOrUpdateValue(fieldDescriptor, "My field value.");
	/// 
	/// job.Sections.Add(section);
	/// 
	/// jobManagerHelper.Jobs.Create(job);
	/// </code>
	/// </example>
	[Serializable]
    //[DataContract]
    [JsonObject(MemberSerialization.OptIn)]// this is required so that the JSON serialization doesn't use the ISerializable interface implementation
    public class Job : IEquatable<Job>, ISerializable, ICloneable, CustomDataType, IManagerIdentifiableObject<JobID>, ITrackLastModified, ISectionContainer
    {
        #region Properties & Fields

		/// <summary>
		/// Gets or sets the job ID.
		/// </summary>
		/// <value>The job ID.</value>
		public JobID ID
        {
            get
            {
				return null;
            }
            set
            {
            }
        }

		/// <summary>
		/// Gets the sections of this job.
		/// </summary>
		/// <value>The sections of this job.</value>
		//[DataMember(Name = "Sections")]
        public List<Section> Sections { get; private set; }

		/// <summary>
		/// Gets or sets the security view ID. Available from DataMiner 10.0.5 (RN 24800) onwards.
		/// </summary>
		/// <value>The security view ID.</value>
		/// <remarks>
		/// <para>This property is considered obsolete from DataMiner 10.1.1 (RN 28311) onwards. Use the SecurityViewIDs property instead.</para>
		/// <para>If, for a particular job or booking instance (i.e. ReservationInstance), this property contains a view ID, then the job or booking instance will only be accessible to users who have access to the specified view.</para>
		/// <list type="bullet">
		/// <item><description>Users who display a list of jobs or booking instances will only see the jobs or booking instances associated with a view to which they have read access.</description></item>
		/// <item><description>Users who try to create, update or delete a job or a booking instance will only be able to do so if they have write access to the view associated with that job or booking instance.</description></item>
		/// <item><description>Users who try to create, update or delete a job or a booking instance will only be able to do so if they have write access to the view associated with that job or booking instance.</description></item>
		/// <item><description>When scheduling checks are performed, the booking instances to which a user does not have access will still be taken into account.</description></item>
		/// </list>
		/// <para>Every booking instance (i.e. ReservationInstance) within the same tree must have the same SecurityViewID.</para>
		/// <para>If a view specified in the SecurityViewID property of a job or booking instance is deleted, only Administrators or users with access to all views will have access to that job or booking instance.</para>
		/// </remarks>
		//[DataMember(Name = "SecurityViewID")]
		[Obsolete("Please use SecurityViewIDs")]
        public int? SecurityViewID { get; set; }

        //[DataMember(Name = "SecurityViewIDs")] 
        private List<int> _securityViewIDs = new List<int>();

		/// <summary>
		/// Gets or sets the security view IDs. Available from DataMiner 10.1.1 (RN 28311) onwards.
		/// </summary>
		/// <value>The security view IDs.</value>
		/// <remarks>
		/// <list type="bullet">
		/// <item><description>If, for a particular job or booking instance (i.e. ReservationInstance), this property contains view IDs, then the job or booking instance will only be accessible to users who have access to at least one of the specified views. For example, if you have access to the view with ID 10, and you display a list of jobs or booking instances, it will only contain the jobs or booking instances of which the list of values in the SecurityViewIDs property includes "10" or no IDs at all.</description></item>
		/// <item><description>The values in this property can be filtered using a “Contains” filter. Example: JobExposers.SecurityViewIDs.Contains(136).</description></item>
		/// <item><description>This property renders the <see cref="Job.SecurityViewID"/> property obsolete.</description></item>
		/// </list>
		/// </remarks>
		public List<int> SecurityViewIDs
        {
            get;
            set;
        }

		/// <summary>
		/// Gets or sets the Job domain ID.
		/// </summary>
		/// <value>The Job domain ID.</value>
        //[DataMember(Name = "JobDomainID")]
        public JobDomainID JobDomainID { get; set; }

		//[DataMember(Name = "SyncLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }

		/// <summary>
		/// Gets a value indicating whether this job was stitched.
		/// </summary>
		/// <value><c>true</c> if this job was stitched; otherwise <c>false</c>.</value>
		public bool WasStitched => false;

		#endregion Properties & Fields

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Job"/> class.
		/// </summary>
		public Job()
        {
        }

		#endregion Constructor

		#region Public Methods
		/// <summary>
		/// Stitches this job with the specified section definition provider.
		/// </summary>
		/// <param name="sectionDefinitionProvider">The section definition provider to stitch this job with.</param>
		[Obsolete("Please use Stitch with a JobDomainProvider")]
        public void Stitch(Func<SectionDefinitionID, SectionDefinition> sectionDefinitionProvider)
        {
        }

		/// <summary>
		/// Stitches this job with the specified section definition provider and job domain provider.
		/// </summary>
		/// <param name="sectionDefinitionProvider">The section definition provider to stitch this job with.</param>
		/// <param name="jobDomainProvider">The job domain provider.</param>
		public void Stitch(Func<SectionDefinitionID, SectionDefinition> sectionDefinitionProvider, Func<JobDomainID, JobDomain> jobDomainProvider)
        {
        }

        /// <summary>
        /// Returns the JobDomain when the Job has been stitched
        /// </summary>
        public JobDomain GetJobDomain()
        {
			return null;
		}

		/// <summary>
		/// Converts this job to an ID-based filter of the specified type.
		/// </summary>
		/// <typeparam name="T">The filter element type.</typeparam>
		/// <returns>The created filter element of the specified type.</returns>
		public FilterElement<T> ToFilter<T>()
        {
			return null;
		}

        IReadOnlyList<Section> ISectionContainer.GetSections()
        {
			// Returns a copy of the list
			return null;
		}

        void ISectionContainer.SetSections(IEnumerable<Section> sections)
        {
		}

		/// <summary>
		/// Returns this job as a JSON serializable dictionary.
		/// </summary>
		/// <returns>The JSON serializable dictionary representation of this job.</returns>
		/// <remarks>
		/// <para>Converts all the fields to a JSONSerializableDictionary. These are mapped as follows: FieldDescriptor GUID -> List of value objects. In case there are multiple FieldValues for the same FieldDescriptor, these are merged as a list value.</para>
		/// </remarks>
		public JSONSerializableDictionary AsJsonSerializableDictionary()
        {
			return null;
		}

		/// <summary>
		/// Gets the security view IDs.
		/// </summary>
		/// <returns>The security view IDs.</returns>
        public IReadOnlyCollection<int> GetSecurityViewIds()
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
		public static Job FromJson(string json)
        {
			return null;
		}

		/// <summary>
		/// Populates a SerializationInfo with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The SerializationInfo to populate with data.</param>
		/// <param name="context">The destination for this serialization.</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Job"/> class using the specified serialization info and streaming context.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		public Job(SerializationInfo info, StreamingContext context)
        {
        }

		#endregion JSON Serialization

		#region Equals & HashCode & ToString
		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
			return false;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise <c>false</c>.</returns>
		public bool Equals(Job other)
        {
            return true;
        }

		/// <summary>
		/// Calculates the hash code for this object.
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
            return "";
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