---
uid: SRM
---

# Service and Resource Management

DataMiner Service & Resource Management (SRM) is available from DataMiner 9.5.4 onwards.

This framework integrates the previously available Profiles and Resources modules with the additional Services and Bookings modules, in order to allow you to virtualize your system resources, get an overview of which resources are booked and when, and more.

The following topics provide more information on this module:

- [Concepts](xref:Concepts1#concepts)

- [Functions XML files](xref:Functions_XML_files)

- [The Profiles module](xref:The_Profiles_module)

- [The Resources module](xref:The_Resources_module)

- [The Bookings module](xref:The_Bookings_module)

- [The Services module](xref:The_Services_module)

- [SRM code snippets](xref:SRM_code_snippets)

- [Advanced SRM settings](xref:Advanced_SRM_settings)

- [SRM reporting](xref:SRM_reporting)

> [!NOTE]
> - DataMiner SRM requires a general database of type Cassandra as well as the following licenses:
>     - ResourceManager: Grants access to the *Resources* or *Resource Manager* module.
>     - ServiceManager: Grants access to the *Services* or *Service Manager* module.
>     - SRM Concurrency: Determines the maximum number of concurrent bookings. If no SRM Concurrency license is present, there is no limit to the possible number of concurrent bookings.
> - From DataMiner 10.0.0/10.0.2 onwards, DataMiner SRM also requires DataMiner Indexing. See [DataMiner Indexing Engine](xref:DataMiner_Indexing_Engine).
> - DataMiner SRM log information can be found in the *SLResourceManager*, *SLServiceManager* and (from DataMiner 9.5.7 onwards) *SLFunctionManager* log file.
> - A standard app is available to create and manage bookings using SRM. For more information, see [Booking Manager app](xref:SolSRM#booking-manager-app).

> [!TIP]
> See also:
> - [Embedding a Service Manager component](xref:Embedding_a_Service_Manager_component)
>
