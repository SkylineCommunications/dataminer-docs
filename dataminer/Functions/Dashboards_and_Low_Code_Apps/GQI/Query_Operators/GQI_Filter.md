---
uid: GQI_Filter
---

# Filter

The *Filter* query operator filters the dataset.

When you select this option, follow the steps below:

1. Select the column to filter.

1. Specify the filter method (e.g. equals, greater than, etc.).

   The available filter methods depend on the type of data in the selected column.

1. Specify the value to use as a filter. You have two options:

   - Enter an exact filter value manually in the *Value* field.

   - Link to data by clicking the ![Link to data](~/dataminer/images/Link_to_Data.png) icon (previously called *Use feed*<!--  RN 35837 -->).

     This lets you use available data from the dashboard or app as the column filter. Depending on the type of data, you will need to specify the following information:

     - *Data*<!--RN 41141-->/*Feed*: The name of the data (component, URL, variable, etc.). If only one data entry is available, it will automatically be selected.

     - *Type*: The type of data that needs to be selected. If only one type of data is provided, it will automatically be selected. The type *Tables* (previously known as *Query rows*<!--RN 41075-->) allows you to link the filter to rows from another query, if a compatible query is available.

     - *Property*: The property by which the column will be filtered (depending on the type of data).

       If *Type* is set to *Tables*/*Query rows*, instead of a property, you can select the columns from the table containing the query rows. However, note that you will only be able to select columns that are compatible with the type of column you are filtering.

     - *Empty data shows*: Select what should be shown in case the field is empty: nothing, empty values, or everything (i.e. the full table). Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this option is called *When feed is empty, show*.

1. Optionally refine the results by applying another operator, such as an additional filter.

> [!NOTE]
> If the *regex* or *not regex* filter method is used and the data contains multiple values, these are combined with an "or" operator.
