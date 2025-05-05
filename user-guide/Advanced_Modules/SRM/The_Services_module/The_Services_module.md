---
uid: The_Services_module
---

# About the Services module

The Services module provides an overview of all the services in the system. It is also typically used as part of the [Service & Resource Management Framework](xref:About_SRM) to configure [service definitions](xref:srm_definitions#service-definition), which determine the number and type of virtual functions included in a service and the way these virtual functions are connected within that service.

You can find this module in DataMiner Cube by selecting *Apps* > *Modules* > *Services* in the sidebar.

The module consists of the following tabs:

- The [*overview* tab](xref:SRM_Services_overview), containing an overview of all services in the system. This tab is displayed by default.

- The [*definitions* tab](xref:SRM_Services_definitions), containing an overview of all service definitions and service definition templates, with the possibility to configure them.

- The [*profiles* tab](xref:SRM_Services_profiles), containing an overview of all service profile definitions and service profile instances, with the possibility to configure them.

> [!NOTE]
> This module requires [STaaS](xref:STaaS) (recommended) or a [self-managed DataMiner storage setup](xref:Supported_system_data_storage_architectures) with Cassandra-compatible database and indexing database. If a self-managed setup without indexing database is used, only the *services* or *overview* tab of this module is available.

> [!TIP]
> See also: [Embedding a Service Manager component](xref:Embedding_a_Service_Manager_component)
