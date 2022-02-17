using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.Net.SLDataGateway.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Defines job template exposers.
	/// </summary>
	/// <remarks>
	/// <para>Feature introduced in DataMiner 9.6.6 (RN 21380).</para>
	/// </remarks>
	public static class JobTemplateExposers
    {
		/// <summary>
		/// Exposes the <see cref="JobTemplate.ID"/> property of the <see cref="JobTemplate"/> instance.
		/// </summary>
		public static readonly Exposer<JobTemplate, Guid> ID;

		/// <summary>
		/// Exposes the <see cref="JobTemplate.Name"/> property of the <see cref="JobTemplate"/> instance.
		/// </summary>
		public static readonly Exposer<JobTemplate, string> Name;

		/// <summary>
		/// Exposes the full object.
		/// </summary>
		internal static readonly FullObjectExposer<JobTemplate> FullObject;

		/// <summary>
		/// Creates a full table definition.
		/// </summary>
		/// <returns>The full table definition.</returns>
		public static FullTableDefinition<JobTemplate> CreateFullTableDefinition()
        {
			return null;
		}

        /// <summary>
        /// Initializes all static fields.
        /// </summary>
        public static void Initialize()
        {
        }
    }

	/// <summary>
	/// Defines extension methods on Exposer.
	/// </summary>
	/// <remarks>Feature introduced in DataMiner 9.6.6 (RN 21380).</remarks>
	public static class JobTemplateExposerExtensions
    {
		/// <summary>
		/// Allows filtering on ID without having to use ID.Id
		/// </summary>
		/// <param name="idExposer">ID exposer.</param>
		/// <param name="id">The ID.</param>
		/// <returns>The ID filter.</returns>
		public static ManagedFilter<JobTemplate, Guid> Equal(this Exposer<JobTemplate, Guid> idExposer, JobTemplateID id)
        {
			return null;
		}
    }
}