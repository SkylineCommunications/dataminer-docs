---
uid: Filtering_the_data_of_a_cached_table_parameter
---

# Filtering the data of a cached table parameter

It is possible to configure that certain table parameters have to be cached. Data from the cache can then be used by a *\[Param:\]* placeholder in Visual Overview. See [Configuring caching of specific table parameters](xref:ClientSettings_json#configuring-caching-of-specific-table-parameters).

If different subsets of the same table have to be shown in different places in the UI, this does not mean that the same table has to be cached several times. Instead, it is possible to obtain a table subset by filtering the cached table data on the client.

To filter the data of a cached table parameter, add a shape data item of type **ClientFilter** to the shape using the *\[Param:\]* placeholder, and set its value to the required filter.

Example:

| Shape data   | Value                     |
|--------------|---------------------------|
| ClientFilter | \<A>-A\|Parameter:202\|=2 |

> [!NOTE]
> The subscription filter used for the *\[Param:\]* placeholder needs to match the subscription filter in the *ClientSettings.json* configuration minus any "columns=" options.
