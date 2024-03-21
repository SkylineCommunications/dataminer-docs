using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.IManager.Helper;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.SRM.Capabilities;
using Skyline.DataMiner.Net.SRM.Capacities;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a Profile Helper profile instance.
	/// </summary>
	/// <example>
	/// <para>Creating, retrieving, updating and deleting a profile instance.</para>
	/// <code>
	/// using System;
    /// using System.Linq;
    /// using Skyline.DataMiner.Automation;
    /// using Skyline.DataMiner.Net.Messages.SLDataGateway;
    /// using Skyline.DataMiner.Net.Profiles;
    /// using Parameter = Skyline.DataMiner.Net.Profiles.Parameter;
	/// 
	/// public class Script
    /// {
    ///    private ProfileHelper helper;
    ///
    ///    public void Run(Engine engine)
    ///    {
    ///        helper = new ProfileHelper(engine.SendSLNetMessages);
    ///        ProfileInstance pi = CreateProfileInstance();
    ///        pi = RetrieveProfileInstance(pi.ID);
    ///        pi = UpdateProfileInstance(pi);
    ///        pi = DeleteProfileInstance(pi.ID);
    ///    }
    ///
    ///    private ProfileInstance DeleteProfileInstance(Guid iD)
    ///    {
    ///        var profileInstance = RetrieveProfileInstance(iD);
    ///        helper.ProfileInstances.Delete(profileInstance);
    ///
    ///        return profileInstance;
    ///    }
    ///
    ///    private ProfileInstance UpdateProfileInstance(ProfileInstance pi)
    ///    {
    ///        pi.Name = "Another Name";
    ///        pi.Description = "Another Description";
    ///
    ///        return helper.ProfileInstances.Update(pi);
    ///    }
    ///
    ///    private ProfileInstance RetrieveProfileInstance(Guid iD)
    ///    {
    ///        var exposer = ProfileInstanceExposers.ID.Equal(iD);
    ///        var profileInstance = helper.ProfileInstances.Read(exposer);
    ///        return profileInstance.FirstOrDefault();
    ///    }
    ///
    ///    private ProfileInstance CreateProfileInstance()
    ///    {
    ///        ProfileInstance pi = new ProfileInstance();
    ///        pi.AppliesTo = new ProfileDefinition();
    ///        // pi.BasedOn.Add(...); ProfileInstance can be based upon another ProfileInstance (inheritance)
    ///
    ///        pi.Description = "A description";
    ///        pi.Name = "A Name";
    ///        pi.Values = new ProfileParameterEntry[]
    ///        {
    ///               new ProfileParameterEntry
    ///               {
    ///                   Parameter = new Parameter(),
    ///                   Remarks = "Example double parameter",
    ///                   Value = new ParameterValue
    ///                   {
    ///                       DoubleValue = 12345,
    ///                       Type = ParameterValue.ValueType.Double,
    ///                   },
    ///               },
    ///        };
    ///
    ///        return helper.ProfileInstances.Create(pi);
    ///    }
	/// </code>
	/// </example>
	[Serializable]
    //[DataContract(Name = "ProfileInstance")]
    public class ProfileInstance : DocumentBase, IEquatable<ProfileInstance>, CustomDataType, ITrackLastModified
    {
		#region Properties & Field
		/// <summary>
		/// Gets or sets the profile instance ID.
		/// </summary>
		/// <value>The profile instance ID.</value>
		public ProfileInstanceID ProfileInstanceId { get; set; }

		/// <summary>
		/// Gets or sets the ID of this profile instance.
		/// </summary>
		/// <value>The ID of this profile instance.</value>
		public override Guid ID
        {
			get; set;
        }

        /// <summary>
        /// Event that is generated when this ProfileInstance wants to request data from SLNet itself (see: <see cref="GenerateSets(out string, ElementInfoEventMessage[])"/>)
        /// </summary>
        [field: NonSerialized]
        public event EventHandler<IManagerRequestResponseEventArgs> RequestResponseEvent;

        [XmlIgnore]
        public bool RequestResponseEventHasSubscribers
        {
			get;
        }

		/// <summary>
		/// Gets or sets a value indicating whether this is a temporary profile instance copy or profile instance template.
		/// </summary>
		/// <value><c>true</c> if this is a value copy; otherwise, <c>false</c>.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.8 (RN 21797).</remarks>
		//[DataMember(Name = "IsValueCopy")]
        public bool IsValueCopy { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="ProfileDefinition"/> object to which this profile instance is linked.
		/// </summary>
		/// <value>The <see cref="ProfileDefinition"/> object to which this profile instance is linked.</value>
		/// <remarks>
		/// <para>An instance must always be linked to a definition. It will not be possible to save the instance unless a definition has been selected.</para>
		/// <para>An instance always has to be linked to the same definition as the instance it is based on.</para>
		/// </remarks>
		[XmlIgnore]
        public ProfileDefinition AppliesTo
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the <see cref="Guid"/> of the profile definition to which this profile instance is linked.
		/// </summary>
		/// <value>The <see cref="Guid"/> of the profile definition to which this profile instance is linked.</value>
		//[DataMember(Name = "AppliesTo")]
        public Guid AppliesToID
        {
			get; set;
        }
        
		/// <summary>
		/// Gets or sets the service profile instance ID.
		/// </summary>
		/// <value>The service profile instance ID.</value>
        //[DataMember(Name = "ServiceProfileInstanceID")]
        public Guid ServiceProfileInstanceID { get; set; }

		/// <summary>
		/// Gets or sets the profile parameter entries of this profile instance.
		/// </summary>
		/// <value>The profile parameter entries of this profile instance.</value>
		/// <remarks>This can for example be used to override one or more values from a base instance.</remarks>
		//[DataMember(Name = "Values")]
        public ProfileParameterEntry[] Values { get; set; }

		/// <summary>
		/// Gets the profile instances on which this profile instance is based.
		/// </summary>
		/// <value>The profile instances on which this profile instance is based.</value>
		[XmlIgnore]
        public ICollection<ProfileInstance> BasedOn
        {
			get; private set;
        }

		/// <summary>
		/// Gets the GUIDs of the profile instances this profile instance is based on.
		/// </summary>
		/// <value>The GUIDs of the profile instances this profile instance is based on.</value>
		//[DataMember(Name = "BasedOn")]
        public ICollection<Guid> BasedOnIDs
        {
			get; private set;
        }


        //[DataMember(Name = "TrackLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }

        #endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileInstance"/> class.
		/// </summary>
		public ProfileInstance() : base() 
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileInstance"/> class using the specified GUID.
		/// </summary>
		/// <param name="g">The GUID of this profile instance.</param>
		public ProfileInstance(Guid g) : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileInstance"/> class using the specified profile instance.
		/// </summary>
		/// <param name="pi">The profile instance.</param>
		public ProfileInstance(ProfileInstance pi) : this(pi.ID)
        {
        }

		/// <summary>
		/// Returns a value indicating whether it is consistent.
		/// </summary>
		/// <returns><c>true</c> if it is consistent; otherwise, <c>false</c>.</returns>
		public bool IsConsistent()
        {
			return true;
        }

		/// <summary>
		/// Returns a value indicating whether appliesTo is consistent.
		/// </summary>
		/// <returns><c>true</c> if it is consistent; otherwise, <c>false</c>.</returns>
		public bool IsAppliesToConsistent()
        {
			return true;
        }

		/// <summary>
		/// Retrieves the inconsistent basedOn IDs.
		/// </summary>
		/// <returns>The inconsistent basedOn IDs.</returns>
		public IEnumerable<Guid> GetInconsistentBasedOnIDs() 
        {
			return null;
        }

		/// <summary>
		/// Retrieves the inconsistent parameter values.
		/// </summary>
		/// <returns>The inconsistent parameter values.</returns>
		public IEnumerable<Guid> GetInconsistentParameterValues()
        {
            return null;
        }

		/// <summary>
		/// Returns a value indicating whether there is recursive inheritance.
		/// </summary>
		/// <returns><c>true</c> if there is recursive inheritance; otherwise, <c>false</c>.</returns>
		[Obsolete("Please use HasCyclicDependency method instead.")]
        public bool HasRecursiveInheritance(ref HashSet<Guid> output)
        {
            return true;
        }

		/// <summary>
		/// Returns a value indicating whether there is a cyclic dependency.
		/// </summary>
		/// <returns><c>true</c> if there is a cyclic dependency; otherwise, <c>false</c>.</returns>
		public bool HasCyclicDependency()
        {
			return true;
        }

		/// <summary>
		/// Returns a value indicating whether the basedOn IDs should be serialized.
		/// </summary>
		/// <returns><c>true</c> if the basedOn IDs should be serialized; otherwise, <c>false</c>.</returns>
		public bool ShouldSerializeBasedOn()
        {
            return true;
        }

		/// <summary>
		/// Returns a value indicating whether the applies to ID should be serialized.
		/// </summary>
		/// <returns><c>true</c> if the applies to ID should be serialized; otherwise, <c>false</c>.</returns>
		public bool ShouldSerializeAppliesToID()
        {
            return true;
        }

		/// <summary>
		/// Retrieves all profile instance parameter entries, including the profile parameter entries of the profile instances this profile instance is based on.
		/// </summary>
		/// <returns>All profile instance parameter entries, including the profile parameter entries of the profile instances this profile instance is based on.</returns>
		public IEnumerable<ProfileParameterEntry> FindAllParameters()
        {
			return null;
		}

		/// <summary>
		/// Generates <see cref="ProfileParameterEntry" /> instances for all parameters that have default values defined and that are not present in the specified list.
		/// </summary>
		/// <param name="allExistingParameterEntries">List of <see cref="ProfileParameterEntry" />  instances for which no default parameter entries should be created.</param>
		/// <returns>The <see cref="ProfileParameterEntry" /> instances for all parameters that have default values defined and that are not present in the specified list.</returns>
		public List<ProfileParameterEntry> GenerateDefaultParameterEntries(List<ProfileParameterEntry> allExistingParameterEntries)
        {
			return null;
		}

		/// <summary>
		/// Applies this profile instance to the specified elements.
		/// </summary>
		/// <param name="error">Output string that will contain any errors that occurred.</param>
		/// <param name="info"> Elements on which this profile instance needs to be applied.</param>
		public void ApplyInstance(out string error, params ElementInfoEventMessage[] info)
        {
			error = "";
        }

		/// <summary>
		/// Generates the SetParameterMessages required when trying to apply this ProfileInstance on one or more elements.
		/// </summary>
		/// <param name="error">Output string that contains any errors that occurred.</param>
		/// <param name="info">Elements on which this ProfileInstance needs to be applied.</param>
		/// <returns>The <see cref="SetParameterMessage"/> messages.</returns>
		public IEnumerable<SetParameterMessage> GenerateSets(out string error, params ElementInfoEventMessage[] info)
        {
			error = "";
			return null;
        }

		/// <summary>
		/// Generate the SetMessages required when trying to apply this ProfileInstance on one or more elements.
		/// </summary>
		/// <param name="info">Elements on which this ProfileInstance needs to be applied.</param>
		/// <param name="error">Output string that contains any errors that occurred.</param>
		/// <returns>The <see cref="SetParameterMessage"/> messages.</returns>
		public IEnumerable<SetParameterMessage> GenerateSets(out string error, params Tuple<ElementInfoEventMessage, GetProtocolInfoResponseMessage>[] info)
        {
			error = "";
			return null;
		}

        protected void RaiseEvent<T>(EventHandler<T> handler, T args) where T : EventArgs
        {
        }

        /// <summary>
        /// This variant of the GenerateRequiredCapas method can be used to more efficiently calculate the required usages
        /// by providing funcs that should return the objects from an existing cache managed by the calling script.
        /// </summary>
        /// <param name="parameterResolver">Func that returns the linked <see cref="Parameter"/> for the given <see cref="ProfileParameterEntry"/></param>
        public Tuple<List<MultiResourceCapacityUsage>, List<ResourceCapabilityUsage>> GenerateRequiredCapas(
            Func<ProfileParameterEntry, Parameter> parameterResolver)
        {
			return null;
		}

        /// <summary>
        /// </summary>
        /// <exception cref="DataMinerException">if one of the linked profile parameters could not be resolved</exception>
        /// <returns></returns>
        public Tuple<List<MultiResourceCapacityUsage>, List<ResourceCapabilityUsage>> GenerateRequiredCapas()
        {
			return null;
		}

		/// <summary>
		/// Determines whether this profile instance matches the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns><c>true</c> if this profile instance matches the specified filter; otherwise, <c>false</c>.</returns>
		public bool FiltersTo(ProfileInstance filter)
        {
            return true;
        }

        public void SetProfileInstanceRetrievalFunc(Func<IEnumerable<Guid>, IEnumerable<ProfileInstance>> retrieveAllFunc)
        {
        }

        public void SetProfileDefinitionRetrievalFunc(Func<Guid, ProfileDefinition> func)
        {
        }

        public void ResetAutoSyncCache()
        {
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(ProfileInstance other)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return ID.GetHashCode();
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
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

		/// <summary>
		/// Returns an XML representation of this object.
		/// </summary>
		/// <returns>An XML representation of this object.</returns>
		public string ToXml()
        {
            return "";
        }

		/// <summary>
		/// Returns an instance of this class from the specified XML representation.
		/// </summary>
		/// <returns>An instance of this class from the specified XML representation.</returns>
		public static ProfileInstance FromXml(string xml)
        {
            return null;
        }

		[XmlIgnore]
		bool DataType.FromMigration { get; set; }

		[XmlIgnore]
		string DataType.DataTypeID => ID.ToString();

		FilterElement<T> DataType.ToFilter<T>()
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


