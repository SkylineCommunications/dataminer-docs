---
uid: Query_operators
---

# Query operators

When you create a query, you can use the operators detailed below.

> [!NOTE]
> Selecting an operator is optional. If you do not select an operator, the data set will be returned untouched.

## Aggregate

Allows you to aggregate data from the data source. After you have selected this option, first select the aggregation column, and the method that should be used. Depending on the type of data available in the selected column, different methods are available, e.g. Average, Count, Distinct Count, Maximum, Median, Minimum, Percentile 90/95/98 or Standard deviation.

You can then further filter the result by applying another operator. An additional *Group by* operator is available for this, which will display the result of the aggregation operation for each different item in the column selected in the *Group by column* box.

> [!NOTE]
>
> - From DataMiner 10.3.3/10.4.0 onwards, after an aggregation operation, you can apply multiple *GroupBy* operations.
> - From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account, except for the Count and Distinct Count methods. <!-- RN35355 -->

## Column manipulations

Creates a new column based on existing columns. When you select this option, you also need to select a manipulation method:

If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

## Filter

Filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

From DataMiner 10.2.0/10.1.3 onwards, instead of specifying an exact filter value, you can select *Use feed* to use one of the available feeds in the dashboard as the column filter. Depending on the type of data in the feed, you will then need to specify the following information:

- *Feed*: The name of the feed that should provide the data. If only one feed is available, it will automatically be selected.

- *Type*: The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected. The type *Query rows* (available from DataMiner 10.2.0 [CU2]/10.2.4 onwards) allows you to link the filter to rows from another query, if a compatible query is available.

- *Property*: The property by which the column will be filtered (depending on the type of data).

  If *Type* is set to *Query rows*, instead of a property, you can select the columns from the table containing the query rows. However, note that you will only be able to select columns that are compatible with the type of column you are filtering.

From DataMiner 10.2.10/10.3.0 onwards, an additional option, *When feed is empty, show* is available, which allows you to select what should be shown in case the field is empty: nothing, empty values only, or the full table ("*everything*"). Prior to this, from DataMiner 10.1.11 onwards, instead the option *Return no rows when feed is empty* is available. When you select this option, in case the feed is empty, an empty table will be returned instead of the entire table.

> [!NOTE]
>
> - Index feeds are only supported from DataMiner 10.2.0/10.1.5 onwards.
> - If the *regex* or *not regex* filter method is used, and *Use feed* is selected, from DataMiner 10.1.2/10.1.5 onwards, if the feed contains multiple values, these are combined with an "or" operator.

## Join

Joins two tables together. When you select this option, in the *Type* dropdown box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

From DataMiner 10.3.3/10.4.0 onwards, the *Row by row* option allows you to first execute the query for the first table, and then execute the query for the other table for each row that matches the join condition. This option is only available if you add the `showAdvancedSettings=true` option to the dashboard URL. If the *Row by row* option is not enabled, the join will execute both tables once and directly combine their results. <!-- RN 35565 + 35057 -->

> [!NOTE]
> The *Row by row* option is only supported for *Inner* and *Left* type of joins.

## Select

Displays the selected columns only. When you have selected the columns to display, you can apply another operator to refine the query.

From DataMiner 10.1.0\[CU1\]/10.1.3 onwards, up and down arrow buttons in the list of columns allow you to modify the order in which the columns are loaded. Click an arrow button to make a column switch places with the column below or above it in the list. Press Ctrl while clicking an arrow button to make the column switch places with the previous or next selected column instead.

From DataMiner 10.2.0/10.1.5 onwards, a *Use feed* checkbox is available that allows you to add parameters from an existing feed in the dashboard to the selectable items.

## Sort

Available from DataMiner 10.2.11 to 10.3.4 and in DataMiner 10.3.0. From DataMiner 10.3.5/10.4.0 onwards, this operator is replaced by the [Sort by](#sort-by) and [Then sort by](#then-sort-by) operators.

Sorts the data based on a specific column. When you select this operator, you will need to select the column to sort by. By default, sorting happens in descending order. To sort in ascending order instead, select the *Ascending* checkbox.

> [!NOTE]
> If you want to sort by multiple columns, the order in which you need to add the Sort operators may seem counter-intuitive. For example, if you want to first sort by column A and then by column B, you have to create your query as follows:
>
> 1. Data source
> 1. Sort by B
> 1. Sort by A
>
> or
>
> 1. Query X (i.e. Data Source, sorted by B)
> 1. Sort by A
>
> DataMiner 10.3.5/10.4.0 introduces the [Sort by](#sort-by) and [Then sort by](#then-sort-by) operators to allow more intuitive sorting. When you upgrade to this version, the behavior of existing queries (using e.g. *Sort by B* followed by *Sort by A*) will not be altered. Their syntax will automatically be adapted when they are migrated to the most recent GQI version.

## Sort by

Available from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35807 & 35834 -->. Sorts the data based on a specific column. When you select this operator, you will need to select the column to sort by. By default, sorting happens in descending order. To sort in ascending order instead, select the *Ascending* checkbox.

> [!NOTE]
> If you want to sort by another column after you have used this operator, use the [Then sort by](#then-sort-by) operator. If you use *Sort by* again, this will nullify the result of the previous sorting operation.

## Then sort by

Available from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35807 & 35834 -->. Sorts the data based on a specific column, after it has already been sorted based on another column.  When you select this operator, you will need to select the column to sort by. By default, sorting happens in descending order. To sort in ascending order instead, select the *Ascending* checkbox.

## Top X

Displays the top or bottom items of a specific column, with X being the number of items to display. When you select this option, you will need to specify the column from which items should be displayed and the number of items that should be displayed. By default, the top items are displayed. To display the bottom items instead, select the *Ascending* checkbox.

> [!NOTE]
> From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account by this operator.
