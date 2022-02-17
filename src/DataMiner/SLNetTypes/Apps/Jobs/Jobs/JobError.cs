using Skyline.DataMiner.Net.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a job error.
	/// </summary>
	[Serializable]
    public class JobError : ErrorData
    {

        public enum Reason
        {
            /// <summary>
            /// Attempted to create or updated a <see cref="Job"/> with a <see cref="FieldValue"/> that does not match the type of its <see cref="FieldDescriptor"/>.
            /// </summary>
            JobSectionInvalidFieldValueTypes = 1,

            /// <summary>
            /// The given <see cref="Job"/> did not contain exactly one <see cref="Section"/> for the <see cref="DefaultJobSectionDefinition"/>.
            /// </summary>
            JobRequiresOneDefaultJobSection = 2,

            /// <summary>
            /// The given <see cref="Job"/> had a <see cref="Section"/> which did not contain a <see cref="FieldValue"/>.
            /// </summary>
            JobDoesNotContainAllRequiredFieldsForSectionDefinition = 3,

            /// <summary>
            /// You are not allowed to do the create, update or delete operation because of the <see cref="Job.SecurityViewIDs"/> configured on the job.
            /// </summary>
            NotAllowed = 4,

            /// <summary>
            /// The <see cref="Job"/> has no valid and/or existing JobDomainID configured.
            /// </summary>
            JobRequiresValidJobDomain = 5,

            /// <summary>
            /// The Job does not contain at least one Section for each SectionDefinition defined on the <see cref="JobDomain"/>
            /// or contains Sections for SectionDefinitions that are not defined on that domain.
            /// </summary>
            SectionsUsedInJobDoesNotMatchRequirementsOfJobDomain = 6,


            /// <summary>
            /// The <see cref="Job"/> contains a <see cref="Section"/> that does not refer to an existing <see cref="SectionDefinition"/>.
            /// </summary>
            SectionUsedInJobLinksToNonExistingSectionDefinition = 7
        }

		/// <summary>
		/// Gets or sets the error reason.
		/// </summary>
		/// <value>The error reason.</value>
		public Reason ErrorReason { get; set; }

		/// <summary>
		/// Gets or sets the job this error relates to.
		/// </summary>
		/// <value>The job this error relates to.</value>
		public Job Job { get; set; }

		/// <summary>
		/// Gets or sets the section this error relates to.
		/// </summary>
		/// <value>The section this error relates to.</value>
		public Section Section { get; set; }

		/// <summary>
		/// Gets or sets the field descriptor this error relates to.
		/// </summary>
		/// <value>The field descriptor this error relates to.</value>
		public FieldDescriptor FieldDescriptor { get; set; }

		/// <summary>
		/// Gets or sets the field value this error relates to.
		/// </summary>
		/// <value>The field value this error relates to.</value>
		public FieldValue FieldValue { get; set; }

		/// <summary>
		/// Gets or sets the job domain.
		/// </summary>
		/// <value>The job domain.</value>
        public JobDomain JobDomain { get; set; }

		/// <summary>
		/// Gets or sets the missing sections.
		/// </summary>
		/// <value>The missing sections.</value>
        public List<SectionDefinitionID> MissingSections { get; set; } = new List<SectionDefinitionID>();

		/// <summary>
		/// Gets or sets the invalid sections.
		/// </summary>
		/// <value>The invalid sections.</value>
        public List<SectionDefinitionID> InvalidSections { get; set; } = new List<SectionDefinitionID>();

		/// <summary>
		/// Initializes a new instance of the <see cref="JobError"/> class using the specified error reason, job, job domain, missing sections and invalid sections.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="job">The job.</param>
		/// <param name="jobDomain">The job domain.</param>
		/// <param name="missingSections">The missing sections.</param>
		/// <param name="invalidSections">The invalid sections.</param>
		public JobError(Reason errorReason, Job job, JobDomain jobDomain, List<SectionDefinitionID> missingSections,
            List<SectionDefinitionID> invalidSections) : this(errorReason, job)
        {
            JobDomain = jobDomain;
            MissingSections = missingSections;
            InvalidSections = invalidSections;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="JobError"/> class using the specified error reason, Job section, field descriptor and field value.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="job">The job.</param>
		/// <param name="section">The section.</param>
		/// <param name="fieldDescriptor">The field descriptor.</param>
		/// <param name="fieldValue">The field value.</param>
		public JobError(Reason errorReason, Job job, Section section, FieldDescriptor fieldDescriptor, FieldValue fieldValue)
        {
            ErrorReason = errorReason;
            Job = job;
            Section = section;
            FieldDescriptor = fieldDescriptor;
            FieldValue = fieldValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JobError"/> class using the specified error reason and Job, Job section and field descriptor.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="job">The job.</param>
		/// <param name="section">The job section.</param>
		/// <param name="fieldDescriptor">The field descriptor.</param>
		public JobError(Reason errorReason, Job job, Section section, FieldDescriptor fieldDescriptor) : this(errorReason, job)
        {
            Section = section;
            FieldDescriptor = fieldDescriptor;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="JobError"/> class using the specified error reason and Job.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="job">The job.</param>
		public JobError(Reason errorReason, Job job)
        {
            ErrorReason = errorReason;
            Job = job;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="JobError"/> class using the specified error reason.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		public JobError(Reason errorReason)
        {
            ErrorReason = errorReason;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="JobError"/> class.
		/// </summary>
		public JobError()
        {
        }
    }
}