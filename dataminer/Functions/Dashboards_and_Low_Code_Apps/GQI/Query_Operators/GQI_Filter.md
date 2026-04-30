---
uid: GQI_Filter
---

# Filter

The *Filter* query operator filters the dataset.

When you select this option, follow the steps below:

1. Select the column to filter.

1. Choose one of the available filter methods (depending on the type of data in the selected column):

   - *Contains*: Returns rows where the column value includes the specified value.

   - *Equals*: Returns rows where the column value exactly matches the specified value.

   - *Is one of*: Available from DataMiner 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 onwards<!--RN 45164 + 45255-->, on systems using the GQI DxM. Returns rows where the column value matches at least one of the specified values.

   - *Is none of*: Available from DataMiner 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 onwards<!--RN 45164 + 45255-->, on systems using the GQI DxM. Returns rows where the column value does not match at least one of the specified values.

   - *Not contains*: Returns rows where the column value does not include the specified value.

   - *Not equals*: Returns rows where the column value does not exactly match the specified value.

   - *Regex*: Returns rows where the column value matches the specified regular expression.

   - *Not regex*: Returns rows where the column value does not match the specified regular expression.

   - *Greater than*: Returns rows where the column value is greater than the specified value.

   - *Greater than or equals*: Returns rows where the column value is greater than or equal to the specified value.

   - *Less than*: Returns rows where the column value is less than the specified value.

   - *Less than or equals*: Returns rows where the column value is less than or equal to the specified value.

1. Specify the value to use as a filter. You have two options:

   - Enter an exact filter value manually in the *Value* field.

   - Link to data by clicking the ![Link to data](~/dataminer/images/Link_to_Data.png) icon (previously called *Use feed*<!--  RN 35837 -->).

     This lets you use available data from the dashboard or app as the column filter. Depending on the type of data, you will need to specify the following information:

     - *Data*<!--RN 41141-->/*Feed*: The name of the data (component, URL, variable, etc.). If only one data entry is available, it will automatically be selected.

     - *Type*: The type of data that needs to be selected. If only one type of data is provided, it will automatically be selected. The type *Tables* (previously known as *Query rows*<!--RN 41075-->) allows you to link the filter to rows from another query, if a compatible query is available.

     - *Property*: The property by which the column will be filtered (depending on the type of data).

       If *Type* is set to *Tables*/*Query rows*, instead of a property, you can select the columns from the table containing the query rows. However, note that you will only be able to select columns that are compatible with the type of column you are filtering.

     - *Empty data shows*: Select what should be shown in case the data used as a filter has no valid values: nothing, empty values, or everything (i.e., the full table). Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this option is called *When feed is empty, show*. Note that an empty string is considered a valid value. If an empty string is provided, it will be used as the filter value.

1. Optionally refine the results by applying another operator, such as an additional filter.

> [!NOTE]
> Prior to DataMiner 10.5.0 [CU13]/10.6.0 [CU1]/10.6.4<!--RN 44714-->, or when the SLHelper process is used for GQI operations instead of the GQI DxM, multiple filter values are not handled as a true "or" filter:
>
> - If the *regex* or *not regex* filter method is used and the data contains multiple values, these values are combined into a single regular expression using an "or" operator. This only works for string values.
> - Other filter methods (for example *contains* or *equals*) only apply the first value. Any additional values are ignored.
