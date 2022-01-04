# Service and Resource Management

DataMiner Service & Resource Management (SRM) is available from DataMiner 9.5.4 onwards.

This framework integrates the previously available Profiles and Resources modules with the additional Services and Bookings modules, in order to allow you to virtualize your system resources, get an overview of which resources are booked and when, and more.

The following topics provide more information on this module:

- [Concepts](Concepts1.md#concepts)

- [Functions XML files](Functions_XML_files.md)

- [The Profiles module](The_Profiles_module.md)

- [The Resources module](The_Resources_module.md)

- [The Bookings module](The_Bookings_module.md)

- [The Services module](The_Services_module.md)

- [SRM code snippets](SRM_code_snippets.md)

- [Advanced SRM settings](Advanced_SRM_settings.md)

- [SRM reporting](SRM_reporting.md)

> [!NOTE]
> -  DataMiner SRM requires a general database of type Cassandra as well as the following licenses:
>     - ResourceManager: Grants access to the *Resources* or *Resource Manager* module.
>     - ServiceManager: Grants access to the *Services* or *Service Manager* module.
>     - SRM Concurrency: Determines the maximum number of concurrent bookings. If no SRM Concurrency license is present, there is no limit to the possible number of concurrent bookings.
> -  From DataMiner 10.0.0/10.0.2 onwards, DataMiner SRM also requires DataMiner Indexing. See [DataMiner Indexing Engine](../../part_3/databases/DataMiner_Indexing_Engine.md).
> -  DataMiner SRM log information can be found in the *SLResourceManager*, *SLServiceManager* and (from DataMiner 9.5.7 onwards) *SLFunctionManager* log file.
> -  A standard app is available to create and manage bookings using SRM. For more information, see [Booking Manager app](../../part_5/SolSRM/SolSRM.md#booking-manager-app).

> [!TIP]
> See also:
> -  [Embedding a Service Manager component](../../part_2/visio/Embedding_a_Service_Manager_component.md)
>
