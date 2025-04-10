---
uid: About_SRM
---

# About DataMiner Service & Resource Management

DataMiner Service and Resource Management (SRM) is a versatile toolset that can be tailored to your orchestration and automation needs. It integrates the [Profiles](xref:The_Profiles_module), [Resources](xref:The_Resources_module), [Services](xref:The_Services_module), and [Bookings](xref:The_Bookings_module) modules, and includes a [Booking Manager app](xref:Booking_Manager_user_interface) for easy creation and management of bookings.

Four different [SRM use cases](xref:srm_use_cases) are supported, which can flexibly be combined within or across workflows.

If you are just getting started with SRM, first take a look at the different [SRM framework concepts](xref:srm_concepts), and then follow our [getting started guide](xref:srm_getting_started).

There are a great many possibilities for fine-tuning the SRM deployment so that it fits exactly with your needs. Check out the [advanced configuration](xref:SRM_user_interface_customization) to find out more.

> [!TIP]
> See also: [SRM project configuration using CI/CD](xref:SRM_project_config_using_CICD)

> [!NOTE]
>
> - DataMiner SRM requires [STaaS](xref:STaaS) (recommended) or a [self-managed DataMiner storage setup](xref:Supported_system_data_storage_architectures) with Cassandra-compatible database and indexing database, as well as the necessary licenses depending on your SRM use case. For more information, contact the Skyline Sales department.
> - DataMiner SRM log information can be found in the *SLResourceManager*, *SLServiceManager* and *SLFunctionManager* log file.
> - Redundancy groups cannot be integrated with DataMiner Service and Resource Management (SRM).
