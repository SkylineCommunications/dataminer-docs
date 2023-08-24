---
uid: GQI_Filter
---

# Filter

The *Filter* query operator filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

From DataMiner 10.2.0/10.1.3 onwards, instead of specifying an exact filter value, use one of the available feeds in the dashboard as the column filter. Prior to DataMiner 10.3.5/10.4.0<!--  RN 35837 -->, you can do so using the *Use feed* checkbox. In more recent DataMiner versions, you can instead click the link icon to the right of the value box. Depending on the type of data in the feed, you will then need to specify the following information:

- *Feed*: The name of the feed that should provide the data. If only one feed is available, it will automatically be selected.

- *Type*: The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected. The type *Query rows* (available from DataMiner 10.2.0 [CU2]/10.2.4 onwards) allows you to link the filter to rows from another query, if a compatible query is available.

- *Property*: The property by which the column will be filtered (depending on the type of data).

  If *Type* is set to *Query rows*, instead of a property, you can select the columns from the table containing the query rows. However, note that you will only be able to select columns that are compatible with the type of column you are filtering.

From DataMiner 10.2.10/10.3.0 onwards, an additional option, *When feed is empty, show* is available, which allows you to select what should be shown in case the field is empty: nothing, empty values only, or the full table ("*everything*"). Prior to this, from DataMiner 10.1.11 onwards, instead the option *Return no rows when feed is empty* is available. When you select this option, in case the feed is empty, an empty table will be returned instead of the entire table.

> [!NOTE]
>
> - Index feeds are only supported from DataMiner 10.2.0/10.1.5 onwards.
> - If the *regex* or *not regex* filter method is used, and a feed is used, from DataMiner 10.1.2/10.1.5 onwards, if the feed contains multiple values, these are combined with an "or" operator.
