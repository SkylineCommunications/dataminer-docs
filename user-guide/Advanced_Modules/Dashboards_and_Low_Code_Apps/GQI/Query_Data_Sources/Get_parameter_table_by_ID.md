---
uid: Get_parameter_table_by_ID
---

# Get parameter table by ID

The *Get parameter table by ID* data source retrieves the selected parameter table from the element with the specified DataMiner ID and element ID.

From DataMiner 10.2.0/10.1.5 onwards, you can retrieve a parameter table from an existing feed in the dashboard. Prior to DataMiner 10.3.5/10.4.0<!--  RN 35837 -->, you can do so using the *Use feed* checkbox. In more recent DataMiner versions, you can instead click the link icon to the right of the relevant selection box.

From DataMiner 10.2.0/10.2.1 onwards, an *Update data* option is available in the *Settings* pane if you use this data source. When you enable this, the component will automatically refresh the data when changes are detected.

## Updates

From DataMiner 10.3.10/10.4.0 onwards<!-- RN 36789 -->, this data source supports real-time updates.

Refer to [query updates](xref:Query_updates#query-update-support) for a more detailed explanation on the different ways you can have your query result updated automatically.

> [!NOTE]
>
> Real-time updates are not yet supported for **partial** tables and **view** tables.
> There is no metadata yet for added rows, so you will not be able to use those as a parameter or index feed.

> [!TIP]
> [Filters](xref:GQI_Filter) applied directly on this data source will also support real-time updates.
