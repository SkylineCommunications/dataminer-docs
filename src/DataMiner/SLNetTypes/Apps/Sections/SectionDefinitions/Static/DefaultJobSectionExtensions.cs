using System;

using Skyline.DataMiner.Net.Jobs;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Defines extension methods on <see cref="ISectionContainer"/>.
	/// </summary>
	/// <example>
	/// <para>The following example retrieves the name of the Job with the specified Job ID.</para>
	/// <code>
	/// private string GetJobNameByID(JobManagerHelper helper, Guid jobId)
	/// {
	///		var jobs = helper.Jobs.Read(JobExposers.ID.Equal(jobId));
	///		
	///		if (jobs.Count == 0)
	///		{
	///			return null;
	///		}
	///		
	///		Job job = jobs.First();
	///
	///		return job.GetJobName();
	/// }
	/// </code>
	/// </example>
	public static class DefaultJobSectionExtensions
    {
		/// <summary>
		/// Gets the job name that is set in the default job section definition of the specified section container.
		/// </summary>
		/// <param name="job">The job.</param>
		/// <returns>The job name or an empty string.</returns>
		public static string GetJobName(this Job job)
        {
            return string.Empty;
        }

		/// <summary>
		/// Gets the start time that is set in the default job section definition of the specified section container.
		/// </summary>
		/// <param name="job">The job.</param>
		/// <returns>The start time or <see langword="null"/>.</returns>
		public static DateTime? GetJobStartTime(this Job job)
        {
            return null;
        }

		/// <summary>
		/// Gets the end time that is set in the default job section definition of the specified section container.
		/// </summary>
		/// <param name="job">The job.</param>
		/// <returns>The end time or <see langword="null"/>.</returns>
		public static DateTime? GetJobEndTime(this Job job)
        {
            return null;
        }

		/// <summary>
		/// Sets the job name of the section container to the specified string.
		/// </summary>
		/// <param name="job">The job.</param>
		/// <param name="name">The job name.</param>
		public static void SetJobName(this Job job, string name)
        {
        }

		/// <summary>
		/// Sets the job start time of the section container to the specified string.
		/// </summary>
		/// <param name="job">The job.</param>
		/// <param name="start">The start time.</param>
		public static void SetJobStartTime(this Job job, DateTime start)
        {
        }

		/// <summary>
		/// Sets the job end time of the section container to the specified string.
		/// </summary>
		/// <param name="job">The job.</param>
		/// <param name="end">The end time.</param>
		public static void SetJobEndTime(this Job job, DateTime end)
        {
        }
    }
}
