using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.GenericEnums;
using Skyline.DataMiner.Net.Jobs;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a section definition error.
	/// </summary>
	[Serializable]
    public class SectionDefinitionError //: ErrorData
    {
		/// <summary>
		/// Defines the section definition error reason.
		/// </summary>
		public enum Reason
        {
			/// <summary>
			/// Static section definitions cannot be changed.
			/// </summary>
			/// <remarks>
			/// <see cref="SectionDefinition"/> of sub-type <see cref="StaticSectionDefinition"/>s can never be created/updated/deleted.
			/// </remarks>
			StaticSectionDefinitionsCantBeChanged = 1,
			/// <summary>
			/// Field type not supported.
			/// </summary>
			/// <remarks>
			/// A given type <see cref="NotSupportedType"/> was used as a <see cref="FieldDescriptor.FieldType"/> in <see cref="SectionDefinition"/>,
			/// but it is not one of the <see cref="SupportedTypes"/>.
			/// 
			/// <para><see cref="NotSupportedType"/> contains the type that is not supported</para>
			/// <para><see cref="SupportedTypes"/> contains the supported types</para>
			/// </remarks>
			FieldTypeNotSupported = 2,
			/// <summary>
			/// Section definition in use by jobs.
			/// </summary>
			/// <remarks>
			/// The <see cref="SectionDefinition"/> could not be updated because it is being used by some <see cref="JobIDs"/>.
			/// /// 
			/// <para><see cref="SectionDefinition"/> contains the requested change to the section definitions</para>
			/// <para><see cref="OriginalSectionDefinition"/> contains the original section definitions</para>
			/// <para><see cref="JobIDs"/> contains the job ids</para>
			/// </remarks>
			SectionDefinitionInUseByJobs = 3,
			/// <summary>
			/// Section definition in use by job domains.
			/// </summary>
			/// <remarks>
			/// The <see cref="SectionDefinition"/> could not be deleted because it is used by at least one JobDomain.
			///
			/// <para><see cref="SectionDefinition"/> contains the SectionDefinition that could not be deleted</para>
			/// <para><see cref="JobDomainIDs"/> contains the IDs of the JobDomains that use this SectionDefinition</para>
			/// </remarks>
			SectionDefinitionInUseByJobDomains = 4,
			/// <summary>
			/// Generic enum entry in use by jobs.
			/// </summary>
			/// <remarks>
			/// The <see cref="GenericEnumEntry"/> could not be deleted or updated because it is used by at least one Job.
			///
			/// <para><see cref="GenericEnumEntry"/> contains the GenericEnumEntry that could not be deleted or updated</para>
			/// <para><see cref="JobIDs"/> contains the IDs of the Jobs that could use this GenericEnumEntry</para>
			/// </remarks>
			GenericEnumEntryInUseByJobs = 5,
			/// <summary>
			/// Section definition in use by DOM instance.
			/// </summary>
			/// <remarks>
			/// The <see cref="Sections.SectionDefinition"/> could not be updated because it is being used by at least one DomInstance.
			/// /// 
			/// <para><see cref="SectionDefinition"/> contains the <see cref="Sections.SectionDefinition"/> that could not be updated</para>
			/// <para><see cref="OriginalSectionDefinition"/> contains the original <see cref="Sections.SectionDefinition"/></para>
			/// <para><see cref="SectionDefinitionError.DomInstanceIds"/> contains the IDs of the DomInstances that use this <see cref="Sections.SectionDefinition"/></para>
			/// </remarks>
			SectionDefinitionInUseByDomInstances = 6,
			/// <summary>
			/// Section definition in use by DOM definitions.
			/// </summary>
			/// <remarks>
			/// The <see cref="Sections.SectionDefinition"/> could not be deleted because it is used by at least one DomDefinition.
			///
			/// <para><see cref="SectionDefinition"/> contains the <see cref="Sections.SectionDefinition"/> that could not be deleted</para>
			/// <para><see cref="SectionDefinitionError.DomDefinitionIds"/> contains the IDs of the DomDefinitions that use this <see cref="Sections.SectionDefinition"/></para>
			/// </remarks>
			SectionDefinitionInUseByDomDefinitions = 7,
			/// <summary>
			/// Generic enum entry in use by DOM instances.
			/// </summary>
			/// <remarks>
			/// The <see cref="GenericEnumEntry"/> could not be deleted or updated because it is used by at least one DomInstance.
			///
			/// <para><see cref="GenericEnumEntry"/> contains the <see cref="IGenericEnumEntry"/> that could not be deleted or updated</para>
			/// <para><see cref="SectionDefinitionError.DomInstanceIds"/> contains the IDs of the DomInstances that use this <see cref="IGenericEnumEntry"/></para>
			/// </remarks>
			GenericEnumEntryInUseByDomInstances = 8
        }

		/// <summary>
		/// Gets or sets the section definition error reason.
		/// </summary>
		/// <value>The section definition error reason.</value>
		public Reason ErrorReason { get; set; }

		/// <summary>
		/// Gets or sets the section definition ID.
		/// </summary>
		/// <value>The section definition ID.</value>
		public SectionDefinitionID SectionDefinitionID { get; set; }

		/// <summary>
		/// Gets or sets the section definition.
		/// </summary>
		/// <value>The section definition.</value>
		public SectionDefinition SectionDefinition { get; set; }

		/// <summary>
		/// Gets or sets the generic enum entry.
		/// </summary>
		/// <value>The generic enum entry.</value>
        public IGenericEnumEntry GenericEnumEntry { get; set; }

		/// <summary>
		/// Gets or sets the original section definition.
		/// </summary>
		/// <value>The original section definition.</value>
		public SectionDefinition OriginalSectionDefinition { get; set; }

		/// <summary>
		/// Gets or sets the unsupported type.
		/// </summary>
		/// <value>The unsupported type.</value>
		public Type NotSupportedType { get; set; }

		/// <summary>
		/// Gets or sets the field descriptors.
		/// </summary>
		/// <value>The field descriptors.</value>
		public List<FieldDescriptor> FieldDescriptors { get; set; } = new List<FieldDescriptor>();

		/// <summary>
		/// Gets or sets the supported types.
		/// </summary>
		/// <value>The supported types.</value>
		public List<Type> SupportedTypes { get; set; } = new List<Type>();

		/// <summary>
		/// Gets or sets the job IDs.
		/// </summary>
		/// <value>The job IDs.</value>
		public List<JobID> JobIDs { get; set; } = new List<JobID>();

		/// <summary>
		/// Gets or sets the job domain IDs.
		/// </summary>
		/// <value>The job domain IDs.</value>
        public List<JobDomainID> JobDomainIDs { get; set; } = new List<JobDomainID>();

		/// <summary>
		/// Gets or sets the DOM instance IDs.
		/// </summary>
		/// <value>The job DOM instance IDs.</value>
		public List<DomInstanceId> DomInstanceIds { get; set; } = new List<DomInstanceId>();

		/// <summary>
		/// Gets or sets the DOM definition IDs.
		/// </summary>
		/// <value>The job DOM definition IDs.</value>
		public List<DomDefinitionId> DomDefinitionIds { get; set; } = new List<DomDefinitionId>();

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class with the specified error reason and section definition ID.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="id">The section definition ID.</param>
		public SectionDefinitionError(Reason errorReason, SectionDefinitionID id)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class with the specified error reason, the unsupported type and the supported types.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="notSupportedType">The unsupported type.</param>
		/// <param name="supportedTypes">The supported types.</param>
		public SectionDefinitionError(Reason errorReason, Type notSupportedType,
            List<Type> supportedTypes)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class using the specified error reason, section definition and jobs.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="sectionDefinition">The section definition.</param>
		/// <param name="jobs">The jobs.</param>
		public SectionDefinitionError(Reason errorReason, SectionDefinition sectionDefinition, List<JobID> jobs)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class.
		/// </summary>
		public SectionDefinitionError()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class using the specified error reason.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		public SectionDefinitionError(Reason errorReason)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class with the specified error reason, the original section definition, the section definition and jobs.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="originalSectionDefinition">The original section definition.</param>
		/// <param name="sectionDefinition">The section definition.</param>
		/// <param name="jobs">The jobs.</param>
		public SectionDefinitionError(Reason errorReason, SectionDefinition originalSectionDefinition, SectionDefinition sectionDefinition, List<JobID> jobs)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class with the specified error reason, section definition and job domain IDs.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="sectionDefinition">The section definition.</param>
		/// <param name="jobDomainIDs">The job domain IDs.</param>
		public SectionDefinitionError(Reason errorReason, SectionDefinition sectionDefinition, List<JobDomainID> jobDomainIDs)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinitionError"/> class with the specified error reason, generic enum entry and job IDs.
		/// </summary>
		/// <param name="errorReason">The error reason.</param>
		/// <param name="genericEnumEntry">The generic enum entry.</param>
		/// <param name="jobIds">The job IDs.</param>
		public SectionDefinitionError(Reason errorReason, IGenericEnumEntry genericEnumEntry, List<JobID> jobIds)
        {
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return string.Empty;
        }
    }
}