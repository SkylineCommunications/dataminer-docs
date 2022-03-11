using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.SLDataGateway.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Defines section definition exposers that can be used to create SectionDefinition filters.
	/// </summary>
	public static class SectionDefinitionExposers
    {
		/// <summary>
		/// ID exposer.
		/// </summary>
		public static readonly Exposer<SectionDefinition, Guid> ID;

		/// <summary>
		/// Name exposer.
		/// </summary>
		public static readonly Exposer<SectionDefinition, string> Name;

		/// <summary>
		/// Field descriptor IDs exposer.
		/// </summary>
		public static readonly Exposer<SectionDefinition, List<Guid>> FieldDescriptorIDs;

		/// <summary>
		/// Field descriptor names exposer.
		/// </summary>
		public static readonly Exposer<SectionDefinition, List<string>> FieldDescriptorNames;

		/// <summary>
		/// The table name.
		/// </summary>
        public static string TableName = "cjobsectiondefinition2";

		/// <summary>
		/// Creates a full table definition.
		/// </summary>
		/// <returns>The full table definition.</returns>
		public static FullTableDefinition<SectionDefinition> CreateFullTableDefinition()
        {
            return null;
        }

		/// <summary>
		/// Create a full table definition for DOM manager.
		/// </summary>
		/// <param name="moduleId">The module ID.</param>
		/// <returns>The full table definition for DOM manager.</returns>
		public static FullTableDefinition<SectionDefinition> CreateFullTableDefinitionForDomManager(string moduleId)
        {
			return null;
        }

		/// <summary>
		/// Create a full table definition using the specified table name..
		/// </summary>
		/// <param name="tableName">The table name.</param>
		/// <returns>The full table definition.</returns>
		public static FullTableDefinition<SectionDefinition> CreateFullTableDefinition(string tableName)
        {
			return null;
		}

		/// <summary>
		/// Initializes the exposers.
		/// </summary>
		public static void Initialize()
        {
        }
    }

	/// <summary>
	/// Defines extension methods for <see cref="Exposer{SectionDefinition, Guid}"/>.
	/// </summary>
	public static class SectionDefinitionExposerExtensions
    {
		/// <summary>
		/// Equal exposer extension.
		/// </summary>
		/// <param name="idExposer">The ID exposer.</param>
		/// <param name="id">The section definition ID.</param>
		/// <returns>A ManagedFilter&lt;SectionDefinition, Guid&gt; instance.</returns>
		/// <example>
		/// <code>
		/// JobManagerHelper jobManagerHelper = new JobManagerHelper(msg => protocol.SLNet.RawConnection.HandleMessages(msg));
		/// 
		/// var sectionDefinition = jobManagerHelper.SectionDefinitions.Read(SectionDefinitionExposers.Name.Equal("MyCustomSectionDefinition")).FirstOrDefault() as CustomSectionDefinition;
		/// </code>
		/// </example>
		public static ManagedFilter<SectionDefinition, Guid> Equal(this Exposer<SectionDefinition, Guid> idExposer, SectionDefinitionID id)
        {
            return null;
        }
    }
}