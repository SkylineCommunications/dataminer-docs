using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.Net.SLDataGateway.Types;
using System;
using System.Collections.Generic;
using System.Linq;
#pragma warning disable 618

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Defines job exposers that can be used to create job filters.
	/// </summary>
	/// <example>
	/// <code>
	/// var jmHelper = new JobManagerHelper(msg => Engine.SLNetRaw.HandleMessages(msg));
	/// 
	/// var templates = jmHelper.JobTemplates.Read(JobTemplateExposers.Name.Equal("MyJobTemplate"));
	/// </code>
	/// </example>
	public static class JobExposers
    {
		/// <summary>
		/// Exposes the <see cref="JobTemplate.ID"/> property of the <see cref="Job"/> instance.
		/// </summary>
		public static readonly Exposer<Job, Guid> ID;

		/// <summary>
		/// Exposes the section definition IDs.
		/// </summary>
		public static readonly Exposer<Job, List<Guid>> SectionDefinitionIDs;

		/// <summary>
		/// Exposes the section IDs.
		/// </summary>
		public static readonly Exposer<Job, List<Guid>> SectionIDs;

		/// <summary>
		/// Exposes the field values.
		/// </summary>
		public static readonly Exposer<Job, IDictionary<string, dynamic>> FieldValues;

		/// <summary>
		/// Exposes the security view ID.
		/// </summary>
        public static readonly Exposer<Job, int> SecurityViewID;

		/// <summary>
		/// Exposes the security view IDs.
		/// </summary>
		public static readonly  Exposer<Job, List<int>> SecurityViewIDs;

		/// <summary>
		/// Exposes the job domain ID.
		/// </summary>
		public static readonly Exposer<Job, Guid> JobDomainID;

		/// <summary>
		/// Exposes the full object.
		/// </summary>
		internal static readonly FullObjectExposer<Job> FullObject;

		/// <summary>
		/// The table name.
		/// </summary>
        public static readonly string TableName;

		/// <summary>
		/// Creates a full table definition.
		/// </summary>
		/// <returns>The full table definition.</returns>
		public static FullTableDefinition<Job> CreateFullTableDefinition()
        {
			return null;
		}

		/// <summary>
		/// Creates a full table definition with the specified name.
		/// </summary>
		/// <returns>The full table definition.</returns>
		public static FullTableDefinition<Job> CreateFullTableDefinition(string tableName)
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
	/// Defines job exposer extensions.
	/// </summary>
	public static class JobExposerExtensions
    {
		/// <summary>
		/// Retrieves the filter for checking for job ID equality.
		/// </summary>
		/// <param name="idExposer">The ID exposer.</param>
		/// <param name="id">Type: Skyline.DataMiner.Net.Jobs.JobID</param>
		/// <returns>The filter.</returns>
		public static ManagedFilter<Job, Guid> Equal(this Exposer<Job, Guid> idExposer, JobID id)
        {
			return null;
		}

		/// <summary>
		/// Exposes the field with the specified field descriptor ID.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The fields exposer.</param>
		/// <param name="fieldSubName">The field name.</param>
		/// <returns>The exposed field.</returns>
		public static DynamicListExposer<T, object> JobField<T>(this Exposer<T, IDictionary<string, dynamic>> field, string fieldSubName)
        {
			return null;
		}

		/// <summary>
		/// Exposes the field with the specified field descriptor ID.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The fields exposer.</param>
		/// <param name="fieldDescriptorId">The field descriptor ID.</param>
		/// <returns>The exposed field.</returns>
		/// <example>
		/// <para>The following example finds the jobs that match the specified job name.</para>
		/// <code>
		/// var jobNameFieldId = DefaultJobSectionDefinition.NameFieldDescriptorID;
		/// var jobsMatchingName = helper.Jobs.Read(JobExposers.FieldValues.JobField(jobNameFieldId).Equal("SomeJobNameToMatchOn"));
		/// </code>
		/// </example>
		public static DynamicListExposer<T, object> JobField<T>(this Exposer<T, IDictionary<string, dynamic>> field, FieldDescriptorID fieldDescriptorId)
        {
			return null;
		}

		/// <summary>
		/// Exposes the field with the specified field descriptor.
		/// </summary>
		/// <typeparam name="T">The type for which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="fieldDescriptor">The field descriptor.</param>
		/// <returns>The exposed field.</returns>
		public static DynamicListExposer<T, object> JobField<T>(this Exposer<T, IDictionary<string, dynamic>> field, FieldDescriptor fieldDescriptor)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have a start time less than the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the start time field of the default section definition of the Job must be lower than.</param>
		/// <returns>A filter that filters jobs keeping only those that have a start time less than the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobStartLessThan(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobStartLessThan<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have a start time less than or equal to the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the start time field of the default section definition of the Job must be lower than or equal to.</param>
		/// <returns>A filter that filters jobs keeping only those that have a start time less than or equal to the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobStartLessThanOrEqual(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobStartLessThanOrEqual<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have a start time greater than the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the start time field of the default section definition of the job must be greater than.</param>
		/// <returns>A filter that filters jobs keeping only those that have a start time greater than the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobStartGreaterThan(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobStartGreaterThan<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have a start time greater than or equal to the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the start time field of the default section definition of the job must be greater than or equal to.</param>
		/// <returns>A filter that filters jobs keeping only those that have a start time greater than or equal to the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobStartGreaterThanOrEqual(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobStartGreaterThanOrEqual<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have an end time less than the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the end time field of the default section definition of the job must be lower than.</param>
		/// <returns>A filter that filters jobs keeping only those that have an end time less than the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobEndLessThan(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobEndLessThan<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have an end time less than or equal to the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the end time field of the default section definition of the job must be lower than or equal to.</param>
		/// <returns>A filter that filters jobs keeping only those that have a end time less than or equal to the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobEndLessThanOrEqual(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobEndLessThanOrEqual<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have an end time greater than the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the end time field of the default section definition of the job must be greater than.</param>
		/// <returns>A filter that filters jobs keeping only those that have an end time greater than the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobEndGreaterThan(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobEndGreaterThan<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}

		/// <summary>
		/// Returns a filter that filters jobs keeping only those that have an end time greater than or equal to the specified <see cref="DateTime"/> value.
		/// </summary>
		/// <typeparam name="T">The type from which fields are exposed.</typeparam>
		/// <param name="field">The field exposer.</param>
		/// <param name="time">The <see cref="DateTime"/> value that the end time field of the default section definition of the job must be greater than or equal to.</param>
		/// <returns>A filter that filters jobs keeping only those that have an end time greater than or equal to the specified <see cref="DateTime"/> value.</returns>
		/// <example>
		/// <code>
		/// Job retrievedJob = jobManagerHelper.Jobs.Read(JobExposers.FieldValues.JobEndGreaterThanOrEqual(DateTime.Now)).FirstOrDefault();
		/// </code>
		/// </example>
		public static ManagedFilter<T, System.Collections.IEnumerable> JobEndGreaterThanOrEqual<T>(this Exposer<T, IDictionary<string, dynamic>> field, DateTime time)
        {
			return null;
		}
    }
}