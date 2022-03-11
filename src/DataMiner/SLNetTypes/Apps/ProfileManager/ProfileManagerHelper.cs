using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

using Skyline.DataMiner.Net.IManager.Helper;
using Skyline.DataMiner.Net.IManager.Messages;
using Skyline.DataMiner.Net.MediationSnippets;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.ProfileManager.Export;
using Skyline.DataMiner.Net.ProfileManager.Export.Exceptions;
using Skyline.DataMiner.Net.ProfileManager.Import;
using Skyline.DataMiner.Net.ProfileManager.Import.Exceptions;
using Skyline.DataMiner.Net.Profiles.Events;
using Skyline.DataMiner.Net.ServiceProfiles;
using Skyline.DataMiner.Net.SRM.Capabilities;
using Skyline.DataMiner.Net.SRM.Capacities;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a helper for interacting with Profile Manager.
	/// </summary>
	/// <remarks>This class has become obsolete with the introduction of the <see cref="ProfileHelper"/> class in DataMiner 10.0.8 (RN 25515). Please use the new <see cref="ProfileHelper"/> class instead.</remarks>
	[Serializable]
    [Obsolete("Please use the new ProfileHelper instead.")]
    public class ProfileManagerHelper //: IManagerEventRaiser, IManagerHelper<Guid>, IProfileManagerHelper
    {
        #region Properties & Fields

		/// <summary>
		/// Gets or sets a value indicating whether to use caching.
		/// </summary>
		/// <value><c>true</c> if caching is used; otherwise, <c>false</c>.</value>
        [Obsolete("No more caching will be used, get calls will always go to server")]
        public bool UseCaching { get; set; }

		/// <summary>
		/// Occurs when the Helper wants to send a message to the server and expects a response.
		/// </summary>
		///// <remarks>
		///// Subscription to this event should always be done when using the Helper for client-server communication.
		///// Implementation of the subscription function should look something like this:
		///// <code>
		///// void OnRequestResponseEvent(object sender, IManagerRequestResponseEventArgs e)
		///// {
		/////     e.responseMessage = SLNet.SendSingleResponseMessage(e.requestMessage);
		///// }
		///// </code>
		///// </remarks>
		[field: NonSerialized]
        public event EventHandler<IManagerRequestResponseEventArgs> RequestResponseEvent;

        ///// <summary>
        ///// This event never fires. DO NOT USE.
        ///// </summary>
        [field: NonSerialized]
        [Obsolete("RequestResponseEvent is now used for all communication to server", true)]
        public event EventHandler<ProfileManagerEventArgs> SendEvent;

		/// <summary>
		/// Occurs when an error or notification should get logged.
		/// </summary>
		[field: NonSerialized]
        public event EventHandler<IManagerErrorEventArgs> LoggingEvent;

        [Obsolete("This helper does not handle events anymore, so this boolean is useless")]
        public bool HandleEventsInBackgroundThread { get; set; }

        [Obsolete("This helper does not handle events anymore, so this boolean is useless")]
        public bool HandleEventsAsync { get; set; }

		/// <summary>
		/// Gets the service profile definitions CRUD helper.
		/// </summary>
		/// <value>The service profile definitions CRUD helper.</value>
		public ServiceProfileDefinitionCrudHelperComponent ServiceProfileDefinitions { get; private set; }

		/// <summary>
		/// Gets the service profile definitions CRUD helper.
		/// </summary>
		/// <value>The service profile definitions CRUD helper.</value>
		public ServiceProfileInstanceCrudHelperComponent ServiceProfileInstances { get; private set; }

		/// <summary>
		/// Gets the mediation snippet CRUD helper.
		/// </summary>
		/// <value>The mediation snippet CRUD helper.</value>
		public MediationSnippetCrudHelperComponent MediationSnippets { get; private set; }

		/// <summary>
		/// Gets the Profile Manager configuration CRUD helper.
		/// </summary>
		/// <value>The Profile Manager configuration CRUD helper.</value>
		/// <remarks>Feature introduced in DataMiner 10.0.8 (RN 25758).</remarks>
		public ProfileManagerConfigurationHelper Config { get; private set; }

		#endregion

		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileManagerHelper"/> class.
		/// </summary>
		public ProfileManagerHelper()
        {
        }

        [Obsolete("This constructor is no longer useful. No more caching will be done.")]
        public ProfileManagerHelper(Dictionary<Guid, Parameter> parameters, Dictionary<Guid, ProfileDefinition> profileDefinitions, Dictionary<Guid, ProfileInstance> profileInstances)
            //: this(new ConcurrentDictionary<Guid, Parameter>(parameters), new ConcurrentDictionary<Guid, ProfileDefinition>(profileDefinitions), new ConcurrentDictionary<Guid, ProfileInstance>(profileInstances))
        {
        }

        [Obsolete]
        public ProfileManagerHelper(bool handleEventsAsync) 
            : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileManagerHelper"/> class using the specified event handler.
		/// </summary>
		/// <param name="requestResponseEvent">The request-response event handler.</param>
		public ProfileManagerHelper(EventHandler<IManagerRequestResponseEventArgs> requestResponseEvent)
            : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileManagerHelper"/> class using the specified message callback.
		/// </summary>
		/// <param name="messagesCallback">The message callback.</param>
		public ProfileManagerHelper(Func<DMSMessage[], DMSMessage[]> messagesCallback)
        {
		}

        #endregion


        #region Methods
		/// <summary>
		/// Returns a value indicating whether this profile manager helper is initialized.
		/// </summary>
		/// <returns><c>true</c> if initialized; otherwise, <c>false</c>.</returns>
        public bool IsInitialized()
        {
            return true;
        }

		#region ProfileDefinitions

		#region Get
		/// <summary>
		/// Retrieves the profile definitions from the server matching the specified filters.
		/// </summary>
		/// <param name="filters">The filters.</param>
		/// <returns>The profile definitions from the server matching the specified filters.</returns>
		protected IEnumerable<ProfileDefinition> GetProfileDefinitionsFromServer(params ProfileDefinition[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile definitions from the server matching the specified filters.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>The profile definitions from the server matching the specified filters.</returns>
		protected IEnumerable<ProfileDefinition> GetProfileDefinitionsFromServer(FilterElement<ProfileDefinition> filter)
        {
			return null;
		}

        private IEnumerable<ProfileDefinition> GetProfileDefinitionsFromServerInner(GetProfileDefinitionMessage reqMsg)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile definitions matching any of the specified filters.
		/// </summary>
		/// <param name="filters">The profile definition filters.</param>
		/// <returns>The profile definitions that match at least one of the specified filters.</returns>
		/// <remarks>This method is obsolete from DataMiner 10.0.4 (RN 24552) onwards. Please use <see cref="GetProfileDefinitionsWithFilter"/> instead</remarks>
		[Obsolete("Please use GetProfileDefinitionsWithFilter instead")]
        public IEnumerable<ProfileDefinition> GetProfileDefinitions(params ProfileDefinition[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile definitions matching the specified filter.
		/// </summary>
		/// <param name="filter">The profile definition filter.</param>
		/// <returns>The profile definitions that match the specified filter.</returns>
		/// <remarks>Feature introduced in DataMiner 9.6.4 (RN 20761).</remarks>
		/// <example>
		/// <code>
		/// var result = helper.GetProfileDefinitionsWithFilter(ProfileDefinitionExposers.Name.Contains("A"));
		/// </code>
		/// </example>
		public IEnumerable<ProfileDefinition> GetProfileDefinitionsWithFilter(FilterElement<ProfileDefinition> filter)
        {
			return null;
		}

		/// <summary>
		/// Retrieves <see cref="ProfileDefinition"/> , using a Message as input.
		/// </summary>
		/// <param name="msg">GetProfileDefinitionMessage to process.</param>
		/// <param name="context">The context.</param>
		/// <returns>ProfileManagerResponseMessage containing the requested objects.</returns>
		[Obsolete("Please use GetProfileDefinitionsWithFilter instead.")]
        public ProfileManagerResponseMessage GetProfileDefinitions(GetProfileDefinitionMessage msg, object context = null)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile definition with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the profile definition to retrieve.</param>
		/// <returns>The profile definition with the specified ID or <see langword="null"/> if no definition with the specified ID exists.</returns>
		public ProfileDefinition GetProfileDefinition(Guid id)
        {
			return null;
		}

		#endregion

		#region Set
		/// <summary>
		/// Adds or updates the specified profile definitions.
		/// </summary>
		/// <param name="definitions">The profile definitions.</param>
		/// <returns>The updated profile definitions.</returns>
		public ProfileDefinition[] AddOrUpdateProfileDefinitions(params ProfileDefinition[] definitions)
        {
			return null;
		}

		/// <summary>
		/// Adds or updates the specified profile definition.
		/// </summary>
		/// <param name="definition">The profile definition.</param>
		/// <returns>The updated profile definition.</returns>
		public ProfileDefinition AddOrUpdateProfileDefinition(ProfileDefinition definition)
        {
			return null;
		}

		/// <summary>
		/// Removes the specified profile definitions.
		/// </summary>
		/// <param name="definitions">The profile definitions to remove.</param>
		/// <returns>The removed profile definitions.</returns>
		public ProfileDefinition[] RemoveProfileDefinitions(params ProfileDefinition[] definitions)
        {
			return null;
		}

		/// <summary>
		/// Removes the specified profile definitions.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="definitions">The profile definitions that should be removed.</param>
		/// <returns><c>true</c> if the profile definition removal succeeded; otherwise, <c>false</c>.</returns>
		public bool RemoveProfileDefinitions(out string error, params ProfileDefinition[] definitions)
        {
			error = "";
			return true;
		}

		/// <summary>
		/// Adds or edits the specified profile definitions.
		/// </summary>
		/// <param name="definitions">The profile definitions to add or edit.</param>
		/// <param name="success"><c>true</c> if the profile definitions were added/edited successfully; otherwise, <c>false</c>.</param>
		/// <param name="isDelete"><c>true</c> if the specified profile definitions should be deleted; otherwise, <c>false</c>.</param>
		/// <returns>The added/edited profile definitions.</returns>
		public IEnumerable<ProfileDefinition> SetProfileDefinitions(IEnumerable<ProfileDefinition> definitions, ref bool success, bool isDelete)
        {
			return null;
		}

		/// <summary>
		/// Adds or edits the specified profile definitions.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="definitions">The profile definitions to add or edit.</param>
		/// <returns><c>true</c> if the profile definitions were added/edited successfully; otherwise, <c>false</c>.</returns>
		public bool SetProfileDefinitions(out string error, params ProfileDefinition[] definitions)
        {
			error = "";
			return true;
		}

		/// <summary>
		/// Adds or edits the specified profile definitions.
		/// </summary>
		/// <param name="msg">The profile definition message.</param>
		/// <returns>The profile manager response message.</returns>
		public ProfileManagerResponseMessage SetProfileDefinitions(SetProfileDefinitionMessage msg)
        {
			return null;
		}

		/// <summary>
		/// Adds or edits the specified profile definitions.
		/// </summary>
		/// <param name="definitions">The profile definitions to add or edit.</param>
		/// <param name="success"><c>true</c> if the profile definitions were added/edited successfully; otherwise, <c>false</c>.</param>
		/// <param name="isDelete"><c>true</c> if the specified profile definitions should be deleted; otherwise, <c>false</c>.</param>
		/// <returns>The added/edited profile definitions.</returns>
		protected IEnumerable<ProfileDefinition> SetProfileDefinitionsOnServer(IEnumerable<ProfileDefinition> definitions, ref bool success, bool isDelete, bool isSyncMessage = false, object context = null)
        {
			return null;
		}


		#endregion

		#endregion

		#region ProfileInstances

		#region Get
		/// <summary>
		/// Retrieves the profile instances form the server matching the specified filters.
		/// </summary>
		/// <param name="filters">The filters.</param>
		/// <returns>The profile instances form the server matching the specified filters.</returns>
		protected IEnumerable<ProfileInstance> GetProfileInstancesFromServer(params ProfileInstance[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile instances form the server matching the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>The profile instances form the server matching the specified filter.</returns>
		protected IEnumerable<ProfileInstance> GetProfileInstancesFromServer(FilterElement<ProfileInstance> filter)
        {
			return null;
		}

        private IEnumerable<ProfileInstance> GetProfileInstancesFromServerInner(GetProfileInstanceMessage reqMsg)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile instances matching any of the specified filters.
		/// </summary>
		/// <param name="filters">The profile instance filters.</param>
		/// <returns>The profile instances that match at least one of the specified filters.</returns>
		/// <remarks>This method is obsolete from DataMiner 10.0.4 (RN 24552) onwards. Please use <see cref="GetProfileInstancesWithFilter"/> instead.</remarks>
		[Obsolete("Please use GetProfileInstancesWithFilter instead")]
        public IEnumerable<ProfileInstance> GetProfileInstances(params ProfileInstance[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile instances matching the specified filter.
		/// </summary>
		/// <param name="filter">The profile instance filter.</param>
		/// <returns>The profile instances that the specified filter.</returns>
		/// <remarks>Feature introduced in DataMiner 9.6.4 (RN 20761).</remarks>
		/// <example>
		/// <code>
		/// var result = helper.GetProfileInstancesWithFilter(ProfileInstanceExposers.Name.Contains("A"));
		/// </code>
		/// </example>
		public IEnumerable<ProfileInstance> GetProfileInstancesWithFilter(FilterElement<ProfileInstance> filter)
        {
			return null;
		}

        /// <summary>
        /// Retrieve ProfileInstances, using a Message as input
        /// </summary>
        /// <param name="msg">GetProfileInstanceMessage to process</param>
        /// <param name="context"></param>
        /// <returns>ProfileManagerResponseMessage containing the objects requested.</returns>
        [Obsolete("Please use GetProfileInstancesWithFilter instead.")]
        public ProfileManagerResponseMessage GetProfileInstances(GetProfileInstanceMessage msg, object context = null)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile instance with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the profile instance to retrieve.</param>
		/// <returns>The profile instance with the specified ID or <see langword="null"/> if no profile instance with the specified ID exists.</returns>
		public ProfileInstance GetProfileInstance(Guid id)
        {
			return null;
		}
		#endregion

		#region Set
		/// <summary>
		/// Adds or updates the specified profile instances.
		/// </summary>
		/// <param name="instances">The profile instances.</param>
		/// <returns>The updated profile instances.</returns>
		public ProfileInstance[] AddOrUpdateProfileInstances(params ProfileInstance[] instances)
        {
			return null;
		}

        /// <summary>
        /// If this call is used, the ByReference <see cref="MultiResourceCapacityUsage"/> and <see cref="ResourceCapabilityUsage"/> of the ReservationInstances will
        /// be updated with the values from the <see cref="ProfileInstance"/>.
        /// If there are conflicting changes in usage, other ReservationInstance will be quarantined if <paramref name="conflictsToQuarantine"/> is set to true.
        /// If <paramref name="conflictsToQuarantine"/> is set to false, then the reservationInstances that would be quarantined are returned instead.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="conflictsToQuarantine"></param>
        public ProfileInstance UpdateAndApplyProfileInstance(ProfileInstance instance, bool conflictsToQuarantine)
        {
			return null;
		}

		/// <summary>
		/// Adds or updates the specified profile instance.
		/// </summary>
		/// <param name="instance">The profile instance.</param>
		/// <returns>The updated profile instance.</returns>
		public ProfileInstance AddOrUpdateProfileInstance(ProfileInstance instance)
        {
			return null;
		}

		/// <summary>
		/// Removes the specified profile instances.
		/// </summary>
		/// <param name="instances">The profile instances to remove.</param>
		/// <returns>The removed profile instances.</returns>
		public ProfileInstance[] RemoveProfileInstances(params ProfileInstance[] instances)
        {
			return null;
		}

		/// <summary>
		/// Removes the specified profile instances.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="instances">The profile instances to remove.</param>
		/// <returns><c>true</c> if the profile definition removal succeeded; otherwise, <c>false</c>.</returns>
		public bool RemoveProfileInstances(out string error, params ProfileInstance[] instances)
        {
			error = "";
			return true;
		}

		/// <summary>
		/// Adds or edits the specified profile instances.
		/// </summary>
		/// <param name="instances">The profile instances to add/edit.</param>
		/// <param name="success"><c>true</c> if the profile instances were added/edited successfully; otherwise, <c>false</c>.</param>
		/// <param name="isDelete"><c>true</c> if the specified profile definitions should be deleted; otherwise, <c>false</c>.</param>
		/// <returns>The added/edited profile instances.</returns>
		public IEnumerable<ProfileInstance> SetProfileInstances(IEnumerable<ProfileInstance> instances, ref bool success, bool isDelete)
        {
			return null;
		}

		/// <summary>
		/// Adds or edits the specified profile instances.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="instances">The profile instances to add/edit.</param>
		/// <returns><c>true</c> if the profile instances were added/edited successfully; otherwise, <c>false</c>.</returns>
		public bool SetProfileInstances(out string error, params ProfileInstance[] instances)
        {
			error = "";
			return true;
		}
        
        [Obsolete("Use the AddOrUpdate methods that don't use messages instead")]
        public ProfileManagerResponseMessage SetProfileInstances(SetProfileInstanceMessage msg)
        {
			return null;
		}

        protected IEnumerable<ProfileInstance> InnerSetProfileInstances(IEnumerable<ProfileInstance> instances, ref bool success, bool isDelete)
        {
			return null;
		}

        protected IEnumerable<ProfileInstance> SetProfileInstancesOnServer(IEnumerable<ProfileInstance> instances, ref bool success, bool isDelete, bool doApply = false, bool doApplyQuarantine = false)
        {
			return null;
		}
		#endregion Set

		#endregion

		#region ProfileParameters

		#region Get
		/// <summary>
		/// Retrieves the parameters from the server matching the specified filters.
		/// </summary>
		/// <param name="filters">The filters.</param>
		/// <returns>The parameters from the server matching the specified filters.</returns>
		protected IEnumerable<Parameter> GetParametersFromServer(params Parameter[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the parameters from the server matching the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>The parameters from the server matching the specified filter.</returns>
		protected IEnumerable<Parameter> GetParametersFromServer(FilterElement<Parameter> filter)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile parameters matching any of the specified filters.
		/// </summary>
		/// <param name="filters">Profile parameter filters.</param>
		/// <returns>The profile parameters that match at least one of the specified filters.</returns>
		/// <remarks>Obsolete, use <see cref="GetParametersWithFilter"/> instead.</remarks>
		[Obsolete("Please use GetParametersWithFilter instead.")]
        public IEnumerable<Parameter> GetParameters(params Parameter[] filters)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the profile parameters matching the specified filter.
		/// </summary>
		/// <param name="filter">Profile parameter filter.</param>
		/// <returns>The profile parameters that match the specified filter.</returns>
		/// <remarks>Feature introduced in DataMiner 9.6.4 (RN 20761).</remarks>
		/// <example>
		/// <code>
		/// var result = helper.GetParametersWithFilter(ParameterExposers.Name.Contains("A"));
		/// </code>
		/// </example>
		public IEnumerable<Parameter> GetParametersWithFilter(FilterElement<Parameter> filter)
        {
			return null;
		}

		/// <summary>
		/// Retrieves the parameter with the specified ID.
		/// </summary>
		/// <param name="id">The ID of the parameter.</param>
		/// <returns>The parameter with the specified ID.</returns>
		public Parameter GetParameter(Guid id)
        {
			return null;
		}

        /// <summary>
        /// Retrieves parameters using the message.
        /// </summary>
        /// <param name="msg">GetProfileManagerParameterMessage to process</param>
        /// <param name="context"></param>
        /// <returns>ProfileManagerResponseMessage containing the objects requested.</returns>
        [Obsolete("Please use GetParametersWithFilter instead.")]
        public ProfileManagerResponseMessage GetParameters(GetProfileManagerParameterMessage msg, object context = null)
        {
			return null;
		}

		#endregion

		#region Set
		/// <summary>
		/// Adds or updates the specified profile parameters.
		/// </summary>
		/// <param name="parameters">The profile parameters.</param>
		/// <returns>The updated profile parameters.</returns>
		public Parameter[] AddOrUpdateParameters(params Parameter[] parameters)
        {
			return null;
		}

		/// <summary>
		/// Adds or updates the specified profile parameter.
		/// </summary>
		/// <param name="parameter">The profile parameter.</param>
		/// <returns>The updated profile parameter.</returns>
		public Parameter AddOrUpdateParameter(Parameter parameter)
        {
			return null;
		}

		/// <summary>
		/// Removes the specified profile parameters.
		/// </summary>
		/// <param name="parameters">The profile parameters to remove.</param>
		/// <returns>The removed parameters.</returns>
		public Parameter[] RemoveParameters(params Parameter[] parameters)
        {
			return null;
		}

		/// <summary>
		/// Removes the specified profile parameters.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="parameters">The profile parameters to remove.</param>
		/// <returns><c>true</c> if the profile parameter removal succeeded; otherwise, <c>false</c>.</returns>
		public bool RemoveParameters(out string error, params Profiles.Parameter[] parameters)
        {
			error = "";
			return false;
        }

		/// <summary>
		/// Adds or edits the specified profile parameters.
		/// </summary>
		/// <param name="parameters">The profile parameters to add or edit.</param>
		/// <param name="success"><c>true</c> if the parameters were added/edited successfully; otherwise, <c>false</c>.</param>
		/// <param name="isDelete"><c>true</c> if the specified profile parameters should be deleted; otherwise, <c>false</c>.</param>
		/// <returns>The add/edited parameters.</returns>
		public IEnumerable<Parameter> SetParameters(IEnumerable<Parameter> parameters, ref bool success, bool isDelete)
        {
			return null;
        }

		/// <summary>
		/// Adds or edits the specified profile parameters.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="parameters">The profile parameters to add or edit.</param>
		/// <returns><c>true</c> if the profile parameters were added/edited successfully; otherwise, <c>false</c>.</returns>
		public bool SetParameters(out string error, params Profiles.Parameter[] parameters)
        {
			error = "";
			return false;
        }

		/// <summary>
		/// Adds or edits the specified profile parameter.
		/// </summary>
		/// <param name="msg">The message.</param>
		/// <returns>The profile parameter response message.</returns>
		public ProfileManagerResponseMessage SetParameters(SetProfileManagerParameterMessage msg)
        {
			return null;
        }

        protected IEnumerable<Parameter> InnerSetParameters(IEnumerable<Parameter> parameters, ref bool success, bool isDelete)
        {
			return null;
		}

        protected IEnumerable<Parameter> SetParametersOnServer(IEnumerable<Parameter> parameters, ref bool success, bool isDelete)
        {
			return null;
		}
		#endregion

		#endregion

		#region import/export
		/// <summary>
		/// Exports the <see cref="Parameter"/>s with the given ids together with any <see cref="MediationSnippet"/> these parameters are linked to. 
		/// </summary>
		/// <param name="ids">The IDs of the <see cref="Parameter"/>s to export.</param>
		/// <returns>A <see cref="ProfileParameterExportResult"/> with the result of the export.</returns>
		/// <exception cref="ProfileParameterNotFoundException"><paramref name="ids"/> contains an ID for which no profile parameter could be found.</exception>
		/// <exception cref="MediationSnippetNotFoundException">A profile parameter to export has a link to a MediationSnippet that could not be found.</exception>
		public ProfileParameterExportResult Export(List<Guid> ids)
        {
			return null;
		}

		/// <summary>
		/// Imports the <see cref="Skyline.DataMiner.Net.Profiles.Parameter"/> in the passed file.
		/// </summary>
		/// <param name="file">The file to import.</param>
		/// <returns>The import result.</returns>
		/// <exception cref="InvalidDataException">If the passed <paramref name="file"/> is not a valid import file.</exception>
		/// <exception cref="InvalidProfileParameterException">If the passed <paramref name="file"/> contains a profile parameter that could not be imported.</exception>
		/// <exception cref="InvalidMediationSnippetException">If the passed <paramref name="file"/> contains a mediation snippet that could not be imported.</exception>
		/// <remarks>
		/// <para>If you export a profile parameter, all the mediation snippets linked to that parameter will also be exported.</para>
		/// <para>If any parameters in the import would already exist on the system they will be overwritten by the value in the import package.</para>
		/// </remarks>
		public ProfileParameterImportResult Import(byte[] file)
        {
			return null;

		}
		#endregion
		/// <summary>
		/// Retrieves the trace data of the last call.
		/// </summary>
		/// <returns>The trace data of the last call.</returns>
		public TraceData GetTraceDataLastCall()
        {
			return null;
		}
        

		/// <summary>
		/// Populates a SerializationInfo with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion
    }
}