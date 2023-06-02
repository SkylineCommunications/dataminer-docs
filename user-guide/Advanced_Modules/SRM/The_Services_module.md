---
uid: The_Services_module
---

# The Services module

From DataMiner 9.5.4 onwards, on a system with the proper licenses, the *Services* module is available in the apps list in Cube. Prior to DataMiner 9.6.4, it is listed under the name *Service Manager*.

This module is used to configure service definitions, which determine the number and type of virtual functions included in a service and the way these virtual functions are connected within that service.

The layout of the module is different depending on the DataMiner version:

## [From DataMiner 10.0.8 onwards](#tab/10-0-8)

From DataMiner **10.0.8** onwards, the module consists of the following tabs:

- The *overview* tab, containing an overview of all services in the system. This tab is displayed by default. See [Using the overview tab](xref:SRM_Services_overview).

- The *definitions* tab, containing an overview of all service definitions and service definition templates, with the possibility to configure them. This tab is selected by default. See [Using the definitions tab](xref:SRM_Services_definitions).

- The *profiles* tab, containing an overview of all service profile definitions and service profile instances, with the possibility to configure them. See [Using the profiles tab](xref:SRM_Services_profiles).

## [Earlier DataMiner versions](#tab/earlier)

From DataMiner **9.6.4** up to DataMiner 10.0.7, the module consists of two tabs:

- The *definitions* tab, containing an overview of all service definitions and service definition templates, with the possibility to configure them. This tab is selected by default. See [Using the definitions tab](xref:SRM_Services_definitions).

- The *services* tab, containing an overview of all services in the system. See [Using the overview tab](xref:SRM_Services_overview).

***

> [!NOTE]
> From DataMiner 10.0.0 onwards, if [Elasticsearch](xref:Elasticsearch_database) is not installed, only the *services* or *overview* tab of this module is available.

> [!TIP]
> See also: [Embedding a Service Manager component](xref:Embedding_a_Service_Manager_component)
