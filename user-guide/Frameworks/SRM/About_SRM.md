---
uid: About_SRM
keywords: DataMiner SRM
description: DataMiner SRM is a versatile toolset integrating several modules and a standard app for easy creation and management of bookings.
---

# About DataMiner Service & Resource Management

DataMiner Service and Resource Management (SRM) is a **versatile toolset** that can be tailored to your orchestration and automation needs. As there are no one-size-fits-all automation and orchestration solutions, SRM allows DevOps engineers to cherry-pick the right tool for the right job, creating value in the fastest possible manner. Some of these tools are more lightweight and flexible, while others are more powerful but require some engineering.

**Four different [SRM use cases](xref:srm_use_cases)** are supported, which can flexibly be combined within or across workflows: [Resource Scheduling](xref:srm_resource_scheduling), [Resource Automation](xref:srm_resource_automation), [Resource Orchestration](xref:srm_resource_orchestration), and [Service Orchestration](xref:srm_service_orchestration).

Each of the described DataMiner SRM use cases relies on a **combination of different DataMiner modules**. The [SRM stack](xref:srm_stack) consists of several DataMiner modules that are easily deployed on all DataMiner nodes in the system. In DataMiner Cube, you will typically use the [Profiles](xref:The_Profiles_module), [Resources](xref:The_Resources_module), [Services](xref:The_Services_module), and [Bookings](xref:The_Bookings_module) modules to work with SRM, as well as the [Booking Manager app](xref:Booking_Manager_user_interface), for easy creation and management of bookings.

To get started with SRM, first take a look at the different [SRM framework concepts](xref:srm_concepts), and then follow our [getting started guide](xref:srm_getting_started).

> [!TIP]
> See also: [SRM project configuration using CI/CD](xref:SRM_project_config_using_CICD)

> [!NOTE]
>
> - DataMiner SRM requires [STaaS](xref:STaaS) (recommended) or a [self-managed DataMiner storage setup](xref:Supported_system_data_storage_architectures) with Cassandra-compatible database and indexing database, as well as the necessary licenses depending on your SRM use case. For more information, contact the Skyline Sales department.
> - DataMiner SRM log information can be found in the *SLResourceManager*, *SLServiceManager*, and *SLFunctionManager* log file.
> - Redundancy groups cannot be integrated with DataMiner Service and Resource Management (SRM).
