using Skyline.DataMiner.Net.IManager.Helper;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a Profile Manager profile definition.
	/// </summary>
	/// <example>
	/// <para>Creating, retrieving, updating and deleting a profile definition.</para>
	/// <code>
	/// using Skyline.DataMiner.Automation;
	/// using Skyline.DataMiner.Net.IManager.Helper;
	/// using Skyline.DataMiner.Net.Profiles;
	/// using System;
	/// using System.Linq;
	/// 
	/// public class Script
	/// {
	///		//We will be using the ProfileManagerHelper object to communicate with the ProfileManager Module. This is our API.
	///		ProfileManagerHelper Helper;
	///		
	///		public Script()
	///		{
	///			//Initialize the ProfileManagerHelper
	///			Helper = new ProfileManagerHelper();
	///			
	///			//Handling the RequestResponseEvent gives the ProfileManagerHelper connection with SLNet.
	///			Helper.RequestResponseEvent += Helper_RequestResponseEvent;
	///		}
	///		
	///		// Handles the RequestResponseEvent. Any server call the Helper makes behind the scenes calls this method.
	///		private void Helper_RequestResponseEvent(object sender, IManagerRequestResponseEventArgs e)
	///		{
	///			e.responseMessage = Engine.SLNet.SendSingleResponseMessage(e.requestMessage);
	///		}
	///		
	///		public void Run(Engine engine)
	///		{
	///			var profiledefinition = CreateProfileDefinition();
	///			profiledefinition = RetrieveProfileDefinition(profiledefinition.ID);
	///			profiledefinition = UpdateProfileDefinition(profiledefinition);
	///			profiledefinition = DeleteProfileDefinition(profiledefinition.ID);
	///		}
	///		
	///		private ProfileDefinition DeleteProfileDefinition(Guid iD)
	///		{
	///			return Helper.RemoveProfileDefinitions(new ProfileDefinition(iD)).FirstOrDefault();
	///		}
	///		
	///		private ProfileDefinition UpdateProfileDefinition(ProfileDefinition profiledefinition)
	///		{
	///			profiledefinition.Description = "Another Description";
	///			profiledefinition.Parameters.Add(CreateParameter()); // Created a new parameter linked to the ProfileDefinition (same method as in Profile Parameter code sample)
	///			
	///			return Helper.AddOrUpdateProfileDefinition(profiledefinition);
	///		}
	///		
	///		private ProfileDefinition RetrieveProfileDefinition(Guid iD)
	///		{
	///			return Helper.GetProfileDefinitions(new ProfileDefinition(iD)).FirstOrDefault();
	///		}
	///		
	///		private ProfileDefinition CreateProfileDefinition()
	///		{
	///			ProfileDefinition def = new ProfileDefinition();
	///			
	///			//def.BasedOn.Add(...) ProfileDefinition can be based upon another ProfileDefinition (inheritance)
	///			def.Description = "Description";
	///			def.Name = "Name";
	///			def.Parameters.Add(CreateParameter()); // Created a new parameter linked to the ProfileDefinition (same method as in Profile Parameter code sample)
	///			def.Scripts = new ScriptEntry[]
	///			{
	///				new ScriptEntry()
	///				{
	///					Description = "Script Description",
	///					Name = "Script Name",
	///					Script = "Script:ScriptToRun|||||"
	///				}
	///			};
	///
	///			return Helper.AddOrUpdateProfileDefinition(def);
	///		}
	///	}
	/// </code>
	/// </example>
	[Serializable]
//#if NETFRAMEWORK
//    [Editor(typeof(ObjectEditor<ProfileDefinition>), typeof(UITypeEditor))]
//#endif
    //[DataContract(Name = "ProfileDefinition")]
    public class ProfileDefinition : DocumentBase, IEquatable<ProfileDefinition>, IEqualityComparer<ProfileDefinition>, CustomDataType, ITrackLastModified
    {
		#region Properties & fields
		/// <summary>
		/// Gets or sets the profile definition ID.
		/// </summary>
		/// <value>The profile definition ID.</value>
		public ProfileDefinitionID ProfileDefinitionId { get; set; }

		/// <summary>
		/// Gets or sets the ID of this profile definition.
		/// </summary>
		/// <value>The ID of this profile definition.</value>
		public override Guid ID
        {
			get; set;
        }

		/// <summary>
		/// Gets the profile definitions this profile definition is based on.
		/// </summary>
		/// <value>The profile definitions this profile definition is based on.</value>
		[XmlIgnore]
        public ICollection<ProfileDefinition> BasedOn
        {
			get; set;
        }

		/// <summary>
		/// Gets the IDs of the profile definitions this profile definition is based on.
		/// </summary>
		/// <value>The IDs of the profile definitions this profile definition is based on.</value>
		//[DataMember(Name = "BasedOn")]
        public  ICollection<Guid> BasedOnIDs
        {
			get; private set;
        }

		/// <summary>
		/// Gets the parameters that are part of this profile definition.
		/// </summary>
		/// <value>The parameters that are part of this profile definition.</value>
		[XmlIgnore]
        public ICollection<Parameter> Parameters
        {
			get; private set;
        }

		/// <summary>
		/// Gets or sets the IDs of the parameters that are part of this profile definition.
		/// </summary>
		/// <value>The IDs of the parameters that are part of this profile definition.</value>
		//[DataMember(Name = "Parameters")]
        //Only filled in through xml serialization
        public ICollection<Guid> ParameterIDs
        {
			get;
			private set;
        }

		/// <summary>
		/// Gets or sets the scripts used by this profile definition.
		/// </summary>
		/// <value>The scripts used by this profile definition.</value>
		//[DataMember(Name = "Scripts")]
        public ScriptEntry[] Scripts { get; set; }

        [field: NonSerialized]
        public event EventHandler<IManagerRequestResponseEventArgs> RequestResponseEvent;

		/// <summary>
		/// Gets or sets the service profile definition ID.
		/// </summary>
		/// <value>The service profile definition ID.</value>
		//[DataMember(Name = "ServiceProfileDefinitionID")]
        public Guid ServiceProfileDefinitionID { get; set; }

		/// <summary>
		/// Gets or sets the last modification date.
		/// </summary>
		/// <value>The last modification date.</value>
		//[DataMember(Name = "TrackLastModified")]
        DateTime ITrackLastModified.LastModified { get; set; }
        
		/// <summary>
		/// Gets or sets the table definitions.
		/// </summary>
		/// <value>The table definitions.</value>
        public List<TableProfileDefinition> TableDefinitions
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the parameter settings.
		/// </summary>
		/// <value>The parameter settings.</value>
        //[DataMember(Name = "ParameterSettings")]
        private Dictionary<Guid, ParameterSettings> _parameterSettings;
        public Dictionary<Guid, ParameterSettings> ParameterSettings
        {
			get; set;
        }

		#endregion

		#region Construction
		
		static ProfileDefinition()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileDefinition"/> class using the specified GUID.
		/// </summary>
		/// <param name="g">The GUID.</param>
		public ProfileDefinition(Guid g) : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileDefinition"/> class.
		/// </summary>
		public ProfileDefinition() : base()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileDefinition"/> class using the specified profile definition.
		/// </summary>
		/// <param name="pd">The profile definition.</param>
		public ProfileDefinition(ProfileDefinition pd) : this(pd.ID)
        {
        }
		#endregion

		/// <summary>
		/// Returns a value indicating whether the parameter IDs should be serialized.
		/// </summary>
		/// <returns><c>true</c> if the parameter IDs should be serialized; otherwise, <c>false</c>.</returns>
		public bool ShouldSerializeParameterIDs()
        {
            return true;
        }

		/// <summary>
		/// Returns a value indicating whether the basedOn IDs should be serialized.
		/// </summary>
		/// <returns><c>true</c> if the basedOn IDs should be serialized; otherwise, <c>false</c>.</returns>
		public bool ShouldSerializeBasedOnIDs()
        {
            return true;
        }

		#region Methods
		/// <summary>
		/// Returns a value indicating whether it is consistent.
		/// </summary>
		/// <returns><c>true</c> if it is consistent; otherwise, <c>false</c>.</returns>
		public bool IsConsistent()
        {
			return true;
        }

		/// <summary>
		/// Retrieves the inconsistent parameter IDs.
		/// </summary>
		/// <returns>The inconsistent parameter IDs.</returns>
		public IEnumerable<Guid> GetInconsistentParameterIDs()
        {
			return null;
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
		/// Retrieves all the ancestors, in top-to-bottom order (i.e. the current profile definition "this" is the last item in the returned object).
		/// </summary>
		/// <returns>The ancestors, in top-to-bottom order (i.e. the current profile definition "this" is the last item in the returned object).</returns>
		public IList<ProfileDefinition> GetAncestralSet()
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
		/// Retrieves a value indicating whether this profile definition matches the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns><c>true</c> if this profile definition matches the specified filter; otherwise, <c>false</c>.</returns>
		public bool FiltersTo(ProfileDefinition filter)
        {
            return true;
        }

        /// <summary>
        /// Gets all the parameters of the current definition and all the <see cref="BasedOn"/> definitions.
        /// </summary>
        /// <returns></returns>
        internal List<Parameter> SearchAllParameters()
        {
			return null;
		}

		/// <summary>
		///  Determines whether the specified <see cref="ProfileDefinition"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		#endregion
		#region Inherited methods
		bool IEquatable<ProfileDefinition>.Equals(ProfileDefinition other)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the specified objects are equal.
		/// </summary>
		/// <param name="one">The first object of type <see cref="ProfileDefinition"/>  to compare.</param>
		/// <param name="other">The second object of type <see cref="ProfileDefinition"/> to compare.</param>
		/// <returns><c>true</c> if the specified objects are equal; otherwise, <c>false</c>.</returns>
		bool IEqualityComparer<ProfileDefinition>.Equals(ProfileDefinition one, ProfileDefinition other)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		int IEqualityComparer<ProfileDefinition>.GetHashCode(ProfileDefinition obj)
        {
            return 0;
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
            return "";
        }
#endregion


        [OnDeserialized()]
        internal void OnDeserialized(StreamingContext context)
        {
        }

        public void SetParameterRetrievalFunc(Func<IEnumerable<Guid>, IEnumerable<Parameter>> retrieveAllFunc)
        {
        }

        public void SetProfileDefinitionRetrievalFunc(Func<IEnumerable<Guid>, IEnumerable<ProfileDefinition>> retrieveAllFunc)
        {
        }

        public void ResetAutoSyncCache()
        {
        }

        public TableProfileDefinition GetTableDefinitionById(Guid tableId)
        {
                return null;
        }    

		/// <summary>
		/// Returns an XML representation of this object.
		/// </summary>
		/// <returns>An XML representation of this object.</returns>
		public string ToXml()
        {
            return null;
        }

		/// <summary>
		/// Returns an instance of this class from the specified XML representation.
		/// </summary>
		/// <returns>An instance of this class from the specified XML representation.</returns>
		public static ProfileDefinition FromXml(string xml)
        {
            return null;
        }

		bool DataType.FromMigration { get; set; }

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
