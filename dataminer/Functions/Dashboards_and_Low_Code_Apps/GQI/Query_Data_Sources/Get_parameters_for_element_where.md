---
uid: Get_parameters_for_element_where
---

# Get parameters for element where

The *Get parameters for element where* data source retrieves the selected parameters for the specified protocol or the parameters linked to the specified profile definition. Note that if parameters are displayed based on a specific protocol, it is not possible to combine a table parameter with other parameters, and only column parameters from the same table can be displayed in the same query.

From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44553-->, this data source can also query indexed logger tables that are stored in an Elasticsearch or OpenSearch database.

If a protocol and version have been specified, you can retrieve parameters from existing data in the dashboard. Prior to DataMiner 10.3.5/10.4.0<!--  RN 35837 -->, you can do so using the *Use feed* checkbox. In more recent DataMiner versions, you can instead click the link icon to the right of the relevant selection box.

> [!TIP]
> If you encounter problems with protocol changes not appearing in the query results, please refer to the following troubleshooting steps: [What should I do if I do not see my protocol changes applied in a GQI query result?](xref:Dashboards_and_Low_Code_Apps_FAQ#what-should-i-do-if-i-do-not-see-my-protocol-changes-applied-in-a-gqi-query-result)
