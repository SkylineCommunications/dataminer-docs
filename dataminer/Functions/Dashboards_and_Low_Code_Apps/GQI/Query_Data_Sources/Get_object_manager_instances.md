---
uid: Get_object_manager_instances
---

# Get object manager instances

The *Get object manager instances* data source retrieves [DOM instances](xref:DomInstance). To use this data source, an indexing database is required and you need to have at least one [DOM](xref:DOM) module defined in your DMS. When you configure the data source, you will first need to select the module the instance belongs to.<!-- RN 36124 -->

> [!NOTE]
> Prior to DataMiner 10.3.6, this query data source is only available if the [soft-launch option](xref:SoftLaunchOptions) *GenericInterface* is enabled.

## Updates

[Real-time updates](xref:Query_updates) are available for this data source from DataMiner 10.5.0/10.5.7 onwards when using the [GQI DxM](xref:GQI_DxM)<!-- RN 42530 -->.

For a more detailed explanation on the different ways you can have a query result updated automatically, refer to [query updates](xref:Query_updates#query-update-support).

> [!TIP]
> [Filters](xref:GQI_Filter) applied directly on this data source will also support real-time updates.
