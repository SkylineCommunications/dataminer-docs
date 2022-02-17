using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Sections;
using System;
using System.Collections.Generic;
using System.Linq;

using Skyline.DataMiner.Net.Records;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Job manager helper class for the Jobs API.
	/// </summary>
	/// <example>
	/// <code>
	/// public static SectionDefinition CreateProductSectionDefinition(JobManagerHelper helper)
	/// {
	///		// Creation of a job section "ProductSection" which will define that a job needs information about a product.
	///		var productSectionDefinition = new CustomSectionDefinition()
	///		{
	///			Name = "ProductSection"
	///		};
	///
	///		// The ProductSection gets two fields, a reference number and a description.
	///		var referenceNumberField = new FieldDescriptor()
	///		{
	///			FieldType = typeof(long),
	///			Name = "Product Reference",
	///			// Optionally add validators here.
	///		};
	///		
	///		var productDescriptionField = new FieldDescriptor()
	///		{
	///			FieldType = typeof(string),
	///			Name = "Product Description"
	///			// Optionally add validators here.
	///		};
	///		
	///		productSectionDefinition.AddOrReplaceFieldDescriptor(referenceNumberField);
	///		productSectionDefinition.AddOrReplaceFieldDescriptor(productDescriptionField);
	///
	///		// Save the job section to the server.
	///		try
	///		{
	///			productSectionDefinition = helper.SectionDefinitions.Create(productSectionDefinition) as CustomSectionDefinition;
	///		}
	///		catch (CrudFailedException e)
	///		{
	///			// The operation failed, this can be handled with the information in the <see cref="CrudFailedException.TraceData"/> of the exception.
	///			return null;
	///		}
	///		
	///		return productSectionDefinition;
	/// }
	/// 
	/// public static void CreateOperatorSectionDefinition(JobManagerHelper helper)
	/// {
	///		// Creation for a job section "OperatorSection" which will define that a job needs information about the operator that is responsible for the Job.
	///		var operatorSectionDefinition = new CustomSectionDefinition()
	///		{
	///			Name = "OperatorSection",
	///		};
	///		
	///		// The ProductSection one field, a list of operator names.
	///		var operatorNameField = new FieldDescriptor()
	///		{
	///			FieldType = typeof(string),
	///			Name = "OperatorName",
	///			// Optionally add validators here.
	///		};
	///		
	///		var operatorContactField = new FieldDescriptor()
	///		{
	///			FieldType = typeof(string),
	///			Name = "PhoneNumber",
	///			// Optionally add validators here.
	///		};
	///		
	///		operatorSectionDefinition.AddOrReplaceFieldDescriptor(operatorNameField);
	///		
	///		// Save the job section to the server.
	///		try
	///		{
	///			operatorSectionDefinition = helper.SectionDefinitions.Create(operatorSectionDefinition) as CustomSectionDefinition;
	///		}
	///		catch (CrudFailedException e)
	///		{
	///			// The operation failed, this can be handled with the information in the <see cref="CrudFailedException.TraceData"/> of the exception.
	///			Assert.Fail(e.ToString());
	///		}
	/// }
	/// 
	/// public static void CreateJobWithOperatorAndProductSection(JobManagerHelper helper)
	/// {
	///		// First we get the sections and their field descriptors that we want to add to the job.
	///		var productSectionDefinition = helper.SectionDefinitions.Read(SectionDefinitionExposers.Name.Equal("ProductSection")).FirstOrDefault();
	///		var productReferenceField = productSectionDefinition.GetAllFieldDescriptors().First(d => d.Name.Contains("Reference"));
	///		var productDescriptionField = productSectionDefinition.GetAllFieldDescriptors().First(d => d.Name.Contains("Description"));
	///		var operatorSectionDefinition = helper.SectionDefinitions.Read(SectionDefinitionExposers.Name.Equal("OperatorSection")).FirstOrDefault();
	///		var operatorNameField = operatorSectionDefinition.GetAllFieldDescriptors().First();
	///		var operatorContactField = operatorSectionDefinition.GetAllFieldDescriptors().First();
	///		
	///		var job = new Job();
	///		job.SetJobName("The general name of the job");
	///		job.SetJobStartTime(DateTime.UtcNow);
	///		job.SetJobEndTime(job.GetJobStartTime().Value.AddHours(2));
	///		
	///		// Add a section to the Job about the operator.
	///		var operatorSection = new Section(operatorSectionDefinition);
	///		
	///		operatorSection.AddOrReplaceFieldValue(new FieldValue(operatorNameField)
	///		{
	///			Value = new ValueWrapper&lt;string&gt;("Bob Driver")
	///		});
	///		
	///		operatorSection.AddOrReplaceFieldValue(new FieldValue(operatorContactField)
	///		{
	///			Value = new ValueWrapper&lt;string&gt;("+32400000000")
	///		});
	///		
	///		job.Sections.Add(operatorSection);
	///		
	///		// Add a section to the Job about the product.
	///		var productInfo = new Section(productSectionDefinition);
	///		
	///		productInfo.AddOrReplaceFieldValue(new FieldValue(productReferenceField)
	///		{
	///			Value = new ValueWrapper&lt;long&gt;(13248)
	///		});
	///		
	///		productInfo.AddOrReplaceFieldValue(new FieldValue(productDescriptionField)
	///		{
	///			Value = new ValueWrapper&lt;string&gt;("Some extra comment that is relevant to the product"),
	///		});
	///		
	///		job.Sections.Add(productInfo);
	///		
	///		// Save the job to the server.
	///		try
	///		{
	///			job = helper.Jobs.Create(job);
	///		}
	///		catch (CrudFailedException e)
	///		{
	///			// The operation failed, this can be handled with the information in the <see cref="CrudFailedException.TraceData"/> of the exception.
	///			Assert.Fail(e.ToString());
	///		}
	/// }
	/// </code>
	/// </example>s
	public class JobManagerHelper : BaseManagerHelper
    {
		/// <summary>
		/// Gets the section definitions.
		/// </summary>
		/// <value>The section definitions.</value>
		/// <remarks>
		/// <para>Make sure to adhere to the following restrictions:</para>
		/// <list type="bullet">
		/// <item>
		///		<description>Create, Delete: The <see cref="DefaultJobSectionDefinition"/> cannot ever be created or deleted, it always exists on a system.</description>
		/// </item>
		/// <item>
		///		<description>Update: For <see cref="StaticSectionDefinition"/>s only the name of the section definition and the name of its field descriptors may be updated.</description>
		/// </item>
		/// <item>
		///		<description>Delete: A <see cref="SectionDefinition"/> can only be deleted if no jobs are using it.</description>
		/// </item>
		/// <item>
		///		<description>Update: No <see cref="FieldDescriptor"/>s can be removed from a <see cref="SectionDefinition"/> if any jobs are using it.</description>
		/// </item>
		/// <item>
		///		<description>Update: The BookingElement in the <see cref="ReservationLinkInfo"/> cannot be changed if there are jobs using it. </description>
		/// </item>
		/// <item>
		///		<description>
		///			<para>Update: If jobs are using the <see cref="SectionDefinition"/>, the <see cref="FieldDescriptor"/>s can only be updated in a safe way:</para>
		///			<list type="bullet">
		///				<item>
		///					<description>The <see cref="FieldDescriptor.IsOptional"/> flag must stay the same.</description>
		///				</item>
		///				<item>
		///					<description>The <see cref="FieldDescriptor.FieldType"/> must stay the same.</description>
		///				</item>
		///				<item>
		///					<description>The validators must stay the same.</description>
		///				</item>
		///				<item>
		///					<description>(<see cref="AutoIncrementFieldDescriptor"/>) The referenced <see cref="AutoIncrementFieldDescriptor.AutoIncrementerID"/> must stay the same.</description>
		///				</item>
		///				<item>
		///					<description>(<see cref="AutoIncrementFieldDescriptor"/>) The IDFormat must stay the same.</description>
		///				</item>
		///				<item>
		///					<description>(<see cref="GenericEnumFieldDescriptor"/>) Only GenericEnum display &lt;-&gt;key pairs can be added, no pairs should be deleted. The IsHidden tag can be changed freely.</description>
		///				</item>
		///				<item>
		///					<description>(<see cref="RecordFieldDescriptor"/>) The referenced <see cref="RecordFieldDescriptor.RecordDefinitionID"/> must stay the same.</description>
		///				</item>
		///				<item>
		///					<description>The kind of <see cref="FieldDescriptor"/> must stay the same (<see cref="AutoIncrementFieldDescriptor"/>, <see cref="GenericEnumFieldDescriptor"/>, etc.).</description>
		///				</item>
		///			</list>
		///		</description>
		/// </item>
		/// <item>
		///		<description>Create, Update: The specific field value type in the descriptor must be a supported type by the kind of <see cref="FieldDescriptor"/>.</description>
		/// </item>
		/// </list>
		/// </remarks>
		public SectionDefinitionCrudHelperComponent SectionDefinitions { get; private set; }

		/// <summary>
		/// Gets the Jobs.
		/// </summary>
		/// <value>The Jobs.</value>
		/// <remarks>
		/// <para>Make sure to adhere to the following restrictions:</para>
		/// <list type="bullet">
		/// <item>
		///		<description>Create, Update: Every job must have exactly one <see cref="DefaultJobSectionDefinition"/>.</description>
		/// </item>
		/// <item>
		///		<description>Create, Update: All the <see cref="SectionDefinition"/>s used in the <see cref="Job"/> must exist.</description>
		/// </item>
		/// <item>
		///		<description>Create, Update: Every <see cref="FieldValue"/> must have a value type that matches with the value type of the corresponding <see cref="FieldDescriptor"/>.</description>
		/// </item>
		/// <item>
		///		<description>Create, Update: Every <see cref="FieldDescriptor"/> must have a <see cref="FieldValue"/> in the <see cref="Job"/>, unless the <see cref="FieldDescriptor"/> has <see cref="FieldDescriptor.IsOptional"/> set to <c>true</c>.</description>
		/// </item>
		/// <item>
		///		<description>Create, Update: If there are <see cref="FieldValue"/>s missing for any <see cref="AutoIncrementFieldDescriptor"/>, then the next ID is retrieved using the AutoIncrementer API and the field value is added to the job.</description>
		/// </item>
		/// </list>
		/// </remarks>
		public JobCrudHelperComponent Jobs { get; private set; }

		/// <summary>
		/// Gets the records.
		/// </summary>
		/// <value>The records.</value>
		/// <remarks>
		/// <para>Make sure to adhere to the following restrictions:</para>
		/// <list type="bullet">
		/// <item>
		///		<description>Create, Update: Every <see cref="RecordCellDefinition"/> in the <see cref="RecordDefinition"/> must have a <see cref="RecordCell"/> in the <see cref="Record"/>.</description>
		/// </item>
		/// <item>
		///		<description>Create, Update: Every value in the <see cref="RecordCell"/> must match the <see cref="RecordCellDefinition.CellType"/> specified in its <see cref="RecordCellDefinition"/>.</description>
		/// </item>
		/// <item>
		///		<description>Delete: The <see cref="Record"/> may not be referenced in any <see cref="Job"/>s.</description>
		///	</item>
		/// </list>
		/// </remarks>
		public RecordCrudHelperComponent Records { get; private set; }

		/// <summary>
		/// Gets the record definitions.
		/// </summary>
		/// <value>The record definitions.</value>
		/// <remarks>
		/// <para>Make sure to adhere to the following restrictions:</para>
		/// <list type="bullet">
		/// <item>
		///		<description><see cref="CrudHelperComponent{RecordDefinition}.Create"/>, <see cref="CrudHelperComponent{RecordDefinition}.Update"/>: The specified value types of each <see cref="RecordCellDefinition"/> must be a supported type.</description>
		/// </item>
		/// <item>
		///		<description><see cref="CrudHelperComponent{RecordDefinition}.Delete"/>: There may not be any <see cref="Record"/>s using the <see cref="RecordDefinition"/>.</description>
		/// </item>
		/// </list>
		/// </remarks>
		public RecordDefinitionCrudHelperComponent RecordDefinitions { get; private set; }

		/// <summary>
		/// Gets the job templates.
		/// </summary>
		/// <value>The job templates.</value>
		public JobTemplateCrudHelperComponent JobTemplates { get; private set; }

		/// <summary>
		/// Gets the job domains.
		/// </summary>
		/// <value>The job domains.</value>
		public JobDomainCrudHelperComponent JobDomains { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="JobManagerHelper"/> class.
		/// </summary>
		/// <param name="messageHandler">The message handler.</param>
		/// <exception cref="ArgumentNullException"><paramref name="messageHandler"/> is <see langword="null" /></exception>
		public JobManagerHelper(Func<DMSMessage[], DMSMessage[]> messageHandler)
            : base(messageHandler)
        {
		}

		/// <summary>
		/// Stitches the <see cref="Job"/>s to its <see cref="SectionDefinition"/> and <see cref="FieldDescriptor"/> by retrieving those from the server.
		/// </summary>
		/// <param name="jobs">The Jobs to stitch.</param>
		public void StitchJobs(List<Job> jobs)
        {
        }

		/// <summary>
		/// Stitches the <see cref="Job"/>s to its <see cref="SectionDefinition"/> and <see cref="FieldDescriptor"/> by using the specified <paramref name="existingSectionDefinitions"/>.
		/// </summary>
		/// <param name="jobs">The Jobs to stitch.</param>
		/// <param name="existingSectionDefinitions">The existing section definitions.</param>
		[Obsolete("Please use StitchJobs with JobDomains")]
        public void StitchJobs(List<Job> jobs, List<SectionDefinition> existingSectionDefinitions)
        {
        }

        /// <summary>
        /// Stitches the <see cref="Job"/>s to its  <see cref="SectionDefinition"/> and <see cref="FieldDescriptor"/> by
        /// using the provided <paramref name="existingSectionDefinitions"/>.
        /// Also assigns the <see cref="JobDomain"/>s using <paramref name="existingJobDomains"/>.
        /// </summary>
        public void StitchJobs(List<Job> jobs, List<SectionDefinition> existingSectionDefinitions, List<JobDomain> existingJobDomains)
        {
        }

        [Obsolete("Please use StitchJobsHelper with JobDomains")]
        public static void StitchJobsHelper(List<Job> jobs, List<SectionDefinition> existingSectionDefinitions)
        {
        }

        /// <summary>
        /// Stitches the <see cref="Job"/>s to its  <see cref="SectionDefinition"/> and <see cref="FieldDescriptor"/> by
        /// using the provided <paramref name="existingSectionDefinitions"/>.
        /// Also assigns the <see cref="JobDomain"/>s using <paramref name="existingJobDomains"/>.
        /// </summary>
        /// <param name="jobs">The Jobs that need to be stitched</param>
        /// <param name="existingSectionDefinitions">A list of SectionDefinitions that will be used for stitching the Sections</param>
        /// <param name="existingJobDomains">A list of JobDomains that will be used to assign the JobDomains</param>
        public static void StitchJobsHelper(List<Job> jobs, List<SectionDefinition> existingSectionDefinitions,
            List<JobDomain> existingJobDomains)
        {
        }
    }

	/// <summary>
	/// Defines Job Manager helper extensions.
	/// </summary>
	public static class JobManagerHelperExtensions
    {
		/// <summary>
		/// Stitches the specified Job.
		/// </summary>
		/// <param name="helper">The <see cref="JobManagerHelper"/> instance.</param>
		/// <param name="job">The Job to stitch.</param>
		/// <remarks>
		/// <see cref="JobManagerHelper.StitchJobs(List{Job})"/>
		/// </remarks>
		public static void StitchJob(this JobManagerHelper helper, Job job)
        {
        }

		/// <summary>
		/// Stitches the specified Job using the specified existing section definitions.
		/// </summary>
		/// <param name="helper">The <see cref="JobManagerHelper"/> instance.</param>
		/// <param name="job">The Job to stitch.</param>
		/// <param name="existingSectionDefinitions">The existing section definitions.</param>
		/// <remarks>
		/// <see cref="JobManagerHelper.StitchJobs(List{Job}, List{SectionDefinition})"/>
		/// </remarks>
		[Obsolete("Please use StitchJob with JobDomains")]
        public static void StitchJob(this JobManagerHelper helper, Job job, List<SectionDefinition> existingSectionDefinitions)
        {
        }

		/// <summary>
		/// Stitches the specified Job using the specified existing section definitions and job domains.
		/// </summary>
		/// <param name="helper">The <see cref="JobManagerHelper"/> instance.</param>
		/// <param name="job">The Job to stitch.</param>
		/// <param name="existingSectionDefinitions">The existing section definitions.</param>
		/// <param name="existingJobDomains">The existing job domains.</param>
		/// <remarks>
		/// <see cref="JobManagerHelper.StitchJobs(List{Job}, List{SectionDefinition}, List{JobDomain})"/>
		/// </remarks>
		public static void StitchJob(this JobManagerHelper helper, Job job, List<SectionDefinition> existingSectionDefinitions, List<JobDomain> existingJobDomains)
        {
        }
    }
}