---
uid: Get_parameter_table_by_ID
---

# Get parameter table by ID

The *Get parameter table by ID* data source retrieves the selected parameter table from the element with the specified DataMiner ID and element ID.

From DataMiner 10.2.0/10.1.5 onwards, you can retrieve a parameter table from existing data in the dashboard. Prior to DataMiner 10.3.5/10.4.0<!--  RN 35837 -->, you can do so using the *Use feed* checkbox. In more recent DataMiner versions, you can instead click the link icon to the right of the relevant selection box.

From DataMiner 10.2.0/10.2.1 onwards, an *Update data* option is available in the *Settings* pane if you use this data source. When you enable this, the component will automatically refresh the data when changes are detected.

> [!TIP]
> If you encounter problems with protocol changes not appearing in the query results, please refer to the following troubleshooting steps: [What should I do if I do not see my protocol changes applied in a GQI query result?](xref:Dashboards_and_Low_Code_Apps_FAQ#what-should-i-do-if-i-do-not-see-my-protocol-changes-applied-in-a-gqi-query-result)

## Updates

[Real-time updates](xref:Query_updates) are available for this data source from DataMiner 10.3.10/10.4.0 onwards<!-- RN 36789 -->.

For a more detailed explanation on the different ways you can have a query result updated automatically, refer to [query updates](xref:Query_updates#query-update-support).

> [!TIP]
> [Filters](xref:GQI_Filter) applied directly on this data source will also support real-time updates.

> [!NOTE]
>
> - Real-time updates are not yet supported for **partial** tables and **view** tables.
> - There is no metadata yet for added rows, so you will not be able to use those as parameter or index data.
