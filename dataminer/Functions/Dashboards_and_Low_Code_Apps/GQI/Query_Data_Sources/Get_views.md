---
uid: Get_views
---

# Get views

Available from DataMiner 10.2.0/10.1.4 onwards. The *Get views* data source retrieves a list of the views in the DMS. By default, only the columns *View ID* and *Name* are included, but you can include additional columns using a [*Select* operator](xref:GQI_Select).

From DataMiner Web 10.6.6 [CU0] (MR 10.5.0 CU15/10.6.0 [CU3]) onwards, property columns for views will be linked to the underlying property by name instead of by ID. This allows queries to be reused across DataMiner systems where the same property can have a different ID. Existing queries will still reference properties by ID to remain backwards compatible. The existing property columns will be marked as legacy columns in the query builder and can be updated manually when necessary. <!-- RN 45085 -->

## Updates

From DataMiner 10.3.10/10.4.0 onwards<!-- RN 36789 -->, this data source supports [real-time updates](xref:Query_updates).

> [!NOTE]
>
> - Real-time updates are not yet supported for views that are deleted. This means that rows for deleted views will not be removed automatically until the query is executed again.
> - There is no metadata yet for views added through real-time updates, so you will not be able to use those as view data.
