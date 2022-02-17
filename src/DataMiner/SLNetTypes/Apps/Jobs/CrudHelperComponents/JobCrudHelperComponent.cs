using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.Apps.Utils;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;
using SLDataGateway.API.Types.Querying;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Job CRUD helper component class.
	/// </summary>
	public class JobCrudHelperComponent : CrudHelperComponent<Job>
    {
		/// <summary>
		/// The job attachments folder name.
		/// </summary>
        public static readonly string JobAttachmentFolderName = "JOB_ATTACHMENTS";

		/// <summary>
		/// The job attachments file path.
		/// </summary>
        public static readonly string JobAttachmentFilePath = $@"C:\Skyline DataMiner\Documents\{JobAttachmentFolderName}";

		/// <summary>
		/// Gets the attachments helper.
		/// </summary>
        public AttachmentsHelper Attachments { get; private set; }


		/// <summary>
		/// Retrieves suggestions for the specified query limited to the specified limit.
		/// </summary>
		/// <param name="query">The query string provided by the user that will be used to search the jobs.</param>
		/// <param name="amount">The suggestion limit.</param>
		/// <returns>The suggested items.</returns>
		/// <example>
		/// <code>
		/// JobManagerHelper jobManagerHelper = new JobManagerHelper(msg => protocol.SLNet.RawConnection.HandleMessages(msg));
		/// 
		/// var suggestions = jobManagerHelper.Jobs.Suggest("MyJobName", 5);
		/// 
		/// foreach (var suggestion in suggestions)
		/// {
		///		var fieldDescriptorId = suggestion.MatchedField; // This will be the DefaultJobSectionDefinition.NameFieldDescriptorID descriptor ID.
		///		var fieldValue = suggestion.MatchedValue;
		///		// ...
		/// }
		/// </code>
		/// </example>
		/// <exception cref="DataMinerException">An unexpected error occurred while retrieving suggestions.</exception>
		public List<JobSuggestion> Suggest(string query, int amount)
        {
			return null;
		}

		/// <summary>
		/// Retrieves suggestions for the specified query limited to the specified limit.
		/// </summary>
		/// <param name="query">The query string provided by the user that will be used to search the jobs.</param>
		/// <param name="amount">The suggestion limit.</param>
		/// <param name="fieldIds">The IDs of the fields on which suggestions should be searched. Defaults to only the Name field of the job.</param>
		/// <param name="filter">The filter defining restrictions that a job should comply with to be included in the suggestions. Usually used to specify start/end time restrictions for the jobs.</param>
		/// <returns>The suggested items.</returns>
		/// <exception cref="DataMinerException">An unexpected error occurred while retrieving suggestions.</exception>
		/// <remarks>
		/// <list type="bullet">
		/// <item><description>Each returned suggestion has the field that matched, the value that matched and the score. (The score indicates the quality of the match.)</description></item>
		/// <item><description>The query must be at least 3 characters long.</description></item>
		/// <item><description>Only fields of type "string" will be used to test the query against.</description></item>
		/// <item><description>This method obtains suggestions based on string fields of the job.</description></item>
		/// </list>
		/// <example>
		/// <code>
		/// JobManagerHelper jobManagerHelper = new JobManagerHelper(msg => protocol.SLNet.RawConnection.HandleMessages(msg));
		/// 
		/// var suggestions = jobManagerHelper.Jobs.Suggest("myQuery", 2, new List&lt;FieldDescriptorID&gt;() { fieldDescriptor.ID }, JobExposers.FieldValues.JobField(DefaultJobSectionDefinition.NameFieldDescriptorID).Contains("MyNameFilter"));
		/// 
		/// foreach (var suggestion in suggestions)
		/// {
		///		var fieldDescriptorId = suggestion.MatchedField; // This will be the field descriptor ID of the matching field.
		///		var fieldValue = suggestion.MatchedValue;
		///		// ...
		/// }
		/// </code>
		/// </example>
		/// </remarks>
		public List<JobSuggestion> Suggest(string query, int amount, List<FieldDescriptorID> fieldIds, FilterElement<Job> filter)
        {
			return null;
		}

		/// <summary>
		/// Allows searching jobs using the specified query and filter in a paged manner.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <param name="preferredPageSize">The preferred page size.</param>
		/// <param name="filter">The filter elements.</param>
		/// <returns>The paging helper instance.</returns>
		/// <remarks>
		/// <list type="bullet">
		/// <item><description>The query must be at least 3 characters long.</description></item>
		/// <item><description>Only fields of type "string" will be used to test the query against.</description></item>
		/// </list>
		/// </remarks>
		/// <example>
		/// <code>
		/// JobManagerHelper jobManagerHelper = new JobManagerHelper(msg => protocol.SLNet.RawConnection.HandleMessages(msg));
		/// 
		/// var searchPaging = jobManagerHelper.Jobs.PrepareSearchPaging("myQuery", 1, JobExposers.FieldValues.JobField(DefaultJobSectionDefinition.NameFieldDescriptorID).Contains("myNameFilter"));
		/// </code>
		/// </example>
		public PagingHelper<Job> PrepareSearchPaging(string query, long preferredPageSize, FilterElement<Job> filter)
        {
			return null;
		}

		/// <summary>
		/// Allows searching jobs using the specified query and filter in a paged manner.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <param name="preferredPageSize">The preferred page size.</param>
		/// <param name="filter">The filter.</param>
		/// <returns>The paging helper instance.</returns>
		public PagingHelper<Job> PrepareSearchPaging(string query, long preferredPageSize, IQuery<Job> filter)
        {
			return null;
		}

		/// <summary>
		/// Adds a new attachment to the <see cref="Job"/> with the ID <paramref name="jobID"/>.
		/// </summary>
		/// <param name="jobID">The ID of the <see cref="Job"/> to add the attachment to.</param>
		/// <param name="fileName">The name of the attachment.</param>
		/// <param name="fileBytes">The contents of the attachment.</param>
		/// <exception cref="ArgumentNullException"><paramref name="jobID"/>, <paramref name="fileName"/> or <paramref name="fileBytes"/> is <see langword="null"/>.</exception>
		/// <exception cref="DataMinerException">
		/// <para>
		/// The <see cref="Exception.InnerException"/> will be an <see cref="ArgumentException"/> if the <paramref name="jobID"></paramref> does not refer to an existing job.
		/// </para>
		/// <para>
		/// The <see cref="Exception.InnerException"/> will be <see langword="null"/> if something went wrong during communication with the server.
		/// </para>
		/// </exception>
		/// <exception cref="DataMinerCOMException">
		/// The provided file name contains a relative path (e.g. '../file.txt').
		/// </exception>
		/// <exception cref="DataMinerSecurityException">
		/// The user does not have edit permissions for this job.
		/// </exception>
		/// <remarks>
		/// <para>Please note the following regarding job attachments:</para>
		/// <list type="bullet">
		/// <item><description>The size limit of job attachments depends on the Documents.MaxSize setting in the file MaintenanceSettings.xml. By default, this is 20 MB.</description></item>
		/// <item><description>Deleting a job will remove all attachments of this job from the system. These cannot be recovered afterwards.</description></item>
		/// <item><description>Adding job attachments requires the Jobs > UI available and Jobs > Add/Edit user permissions.</description></item>
		/// <item><description>Job attachments are backed up with the backup option All documents located on this DMA.</description></item>
		/// <item><description>Job attachments are synced in a cluster.</description></item>
		/// </list>
		/// <para>Available from DataMiner 10.0.5 (RN 24791) onwards.</para>
		/// </remarks>
		public void AddJobAttachment(JobID jobID, string fileName, byte[] fileBytes)
        {
        }

		/// <summary>
		/// Retrieves the names of the files attached to the job with ID <paramref name="jobID"/>.
		/// </summary>
		/// <param name="jobID">The ID of the <see cref="Job"/> to retrieve the attachment names for.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="jobID"/> is <see langword="null"/>.</exception>
		/// <exception cref="DataMinerException">
		/// <para>
		/// <see cref="Exception.InnerException"/> will be an <see cref="ArgumentException"/> if the job with <paramref name="jobID"/> could not be found.
		/// </para>
		/// </exception>
		/// <exception cref="DataMinerSecurityException">The user does not have read permissions on the specified job.</exception>
		/// <returns>
		/// The names of the attachments. An empty list if the <paramref name="jobID"/> does not have attachments.
		/// </returns>
		/// <remarks>
		/// <para>Please note the following regarding job attachments:</para>
		/// <list type="bullet">
		/// <item><description>The size limit of job attachments depends on the Documents.MaxSize setting in the file MaintenanceSettings.xml. By default, this is 20 MB.</description></item>
		/// <item><description>Deleting a job will remove all attachments of this job from the system. These cannot be recovered afterwards.</description></item>
		/// <item><description>Managing job attachments requires the Jobs > UI available and Jobs > Add/Edit user permissions.</description></item>
		/// <item><description>Job attachments are backed up with the backup option All documents located on this DMA.</description></item>
		/// <item><description>Job attachments are synced in a cluster.</description></item>
		/// </list>
		/// <para>Available from DataMiner 10.0.5 (RN 24791) onwards.</para>
		/// </remarks>
		public List<string> GetJobAttachmentFileNames(JobID jobID)
        {
			return null;
		}

		/// <summary>
		/// Deletes the attachment with name <paramref name="attachmentName"/> from the job with ID <paramref name="jobID"/>.
		/// </summary>
		/// <exception cref="ArgumentNullException"><paramref name="jobID"/> or <paramref name="attachmentName"/> is <see langword="null"/>.</exception>
		/// <exception cref="DataMinerException">
		/// <para>
		/// <see cref="Exception.InnerException"/> will be an <see cref="ArgumentException"/> if the job could not be found.
		/// </para>
		/// </exception>
		/// <exception cref="DataMinerSecurityException">The user does not have edit permissions for the specified job.</exception>
		/// <param name="jobID">The ID of the <see cref="Job"/> to delete the attachment from.</param>
		/// <param name="attachmentName">The name of the attachment to delete.</param>
		/// <remarks>
		/// <para>Available from DataMiner 10.0.5 (RN 24791) onwards.</para>
		/// <para>This method does not throw an exception if an attachment with the given name could not be found for the job.</para>
		/// <para>Please note the following regarding job attachments:</para>
		/// <list type="bullet">
		/// <item><description>The size limit of job attachments depends on the Documents.MaxSize setting in the file MaintenanceSettings.xml. By default, this is 20 MB.</description></item>
		/// <item><description>Deleting a job will remove all attachments of this job from the system. These cannot be recovered afterwards.</description></item>
		/// <item><description>Deleting job attachments requires the Jobs > UI available and Jobs > Delete user permissions.</description></item>
		/// <item><description>Job attachments are backed up with the backup option All documents located on this DMA.</description></item>
		/// <item><description>Job attachments are synced in a cluster.</description></item>
		/// </list>
		/// </remarks>
		public void DeleteJobAttachment(JobID jobID, string attachmentName)
        {
        }

		/// <summary>
		/// Gets the contents of the attachment with name <paramref name="attachmentName"/> for job with ID <paramref name="jobID"/>.
		/// </summary>
		/// <param name="jobID">The ID of the job to find the attachment for.</param>
		/// <param name="attachmentName">The name of the attachment to find.</param>
		/// <returns>The contents of the attachment.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="jobID"/> or <paramref name="attachmentName"/> is <see langword="null"/>.</exception>
		/// <exception cref="DataMinerCOMException">If the attachment could not be found.</exception>
		/// <exception cref="DataMinerException">
		/// <para>
		/// The inner exception will be an <see cref="ArgumentException"/> if the Job could not be found.
		/// </para>
		/// </exception>
		/// <exception cref="DataMinerSecurityException">The user does not have read permissions for the specified job.</exception>
		/// <remarks>
		/// <para>Please note the following regarding job attachments:</para>
		/// <list type="bullet">
		/// <item><description>The size limit of job attachments depends on the Documents.MaxSize setting in the file MaintenanceSettings.xml. By default, this is 20 MB.</description></item>
		/// <item><description>Deleting a job will remove all attachments of this job from the system. These cannot be recovered afterwards.</description></item>
		/// <item><description>Deleting job attachments requires the Jobs > UI available and Jobs > Delete user permissions.</description></item>
		/// <item><description>Job attachments are backed up with the backup option All documents located on this DMA.</description></item>
		/// <item><description>Job attachments are synced in a cluster.</description></item>
		/// </list>
		/// </remarks>
		public byte[] GetJobAttachment(JobID jobID, string attachmentName)
        {
			return null;
		}
    }
}
