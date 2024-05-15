using System;

using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.MediationSnippets;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.ServiceProfiles;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Profile helper.
	/// </summary>
	/// <remarks>
	/// Available from DataMiner 10.0.8 (RN 25515) onwards.
	/// </remarks>
	public class ProfileHelper : BaseManagerHelper
	{
		/// <summary>
		/// Gets the profile definition CRUD helper.
		/// </summary>
		/// <value>The profile definition CRUD helper.</value>
		public ProfileDefinitionCrudHelperComponent ProfileDefinitions { get; private set; }

		/// <summary>
		/// Gets the profile instance CRUD helper.
		/// </summary>
		/// <value>The profile instance CRUD helper.</value>
		public ProfileInstanceCrudHelperComponent ProfileInstances { get; private set; }

		/// <summary>
		/// Gets the profile parameter CRUD helper.
		/// </summary>
		/// <value>The profile parameter CRUD helper.</value>
		public ProfileParameterCrudHelperComponent ProfileParameters { get; private set; }

		/// <summary>
		/// Gets the service profile definition CRUD helper.
		/// </summary>
		/// <value>The service profile definition CRUD helper.</value>
		public ServiceProfileDefinitionCrudHelperComponent ServiceProfileDefinitions { get; private set; }

		/// <summary>
		/// Gets the service profile instance CRUD helper.
		/// </summary>
		/// <value>The service profile instance CRUD helper.</value>
		public ServiceProfileInstanceCrudHelperComponent ServiceProfileInstances { get; private set; }

		/// <summary>
		/// Gets the mediation snippets CRUD helper.
		/// </summary>
		/// <value>The mediation snippets CRUD helper.</value>
		public MediationSnippetCrudHelperComponent MediationSnippets { get; private set; }

		/// <summary>
		/// Gets the profile manager configuration helper.
		/// </summary>
		/// <value>The profile manager configuration helper.</value>
		public ProfileManagerConfigurationHelper Config { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileHelper"/> class.
		/// </summary>
		/// <param name="messageHandler">The message handler.</param>
		/// <example>
		/// <para>Automation script object instantiation.</para>
		/// <code>
		/// public void Run(Engine engine) 
		/// {
		/// 	var profileHelper = new ProfileHelper(engine.SendSLNetMessages);
		/// 	// do CRUD operations on profile definitions, profile instances, etc.
		/// }
		/// </code>
		/// </example>
		public ProfileHelper(Func<DMSMessage[], DMSMessage[]> messageHandler) : base(messageHandler)
		{
		}
	}
}