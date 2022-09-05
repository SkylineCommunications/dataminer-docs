---
uid: Dynamic_table_filter_syntax
---

# Dynamic table filter syntax

For the **SubscriptionFilter**, **ParameterSubscriptionFilter** and **TableRowFilter** components, it is possible to configure a dynamic table filter. This filter can consist of the following components, separated by semicolons.

## VALUE=

Specify a value filter with the structure “ParameterID Operator Value”. For example, to only include rows where the column with parameter ID 51 contains the value “3”, specify *VALUE=51 == 3*.

The parameter ID can be:

- A parameter of the same table

- A parameter from a linked table that is linked via relations and foreign keys as defined in the protocol.

- *PK* to filter on primary keys

- *DK* to filter on display keys

A filtering string can contain multiple value filters. By default, multiple value filters on the same column will be combined as OR, whereas multiple value filters on different columns will be combined as AND. You can also the following operators:

- For all parameter types: *==* and *!=*

- For numeric and string values: *\>*, *\>=*, *\<*, *\<=,* *in_range*, *out_range*

In addition, string values can use the wildcards *\** and *?* if the *==* or *!=* operator is used.

The value can be:

- A single value

- In case the *in_range* or *out_range* operator is used, two values separated by a forward slash (/)

- A value enclosed within single quotation marks (')

  > [!NOTE]
  > - If this value contains semicolons, these will be interpreted as separators in Visual Overview. To avoid having a semicolon interpreted as a separator, specify a different separator using the \[sep:XY\] option. See [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters).
  > - If a view table has a column with view options configured in the format view=:x:y:z or view=a:b:c:z, the VALUE= filter is supported from DataMiner 10.1.9/10.2.0 onwards. However, only filters of type VALUE=5 == abc are supported, and no AND/OR combinations are supported. From DataMiner 10.1.11/10.2.0 onwards, this support is further extended to also include filters on view table columns that refer to other view table columns.

Examples:

```txt
value=1005 == xyz
value=PK == xyz
value=1006 == ??snmp*
value=1007 > 100
value=114 in_range 5/10
value=PK == abc
value=DK == def
```

> [!NOTE]
> The correct use of spaces in the filters is very important. If you leave out the spaces around the operator, the filter will not work.

## FK=

This filter is similar in structure to the VALUE= filter, and is used to resolve foreign key relations to other tables or recursively. Only the == operator is allowed.

For example, to only include rows that have a relation path to the row in table 2000 with primary key “xyz”, specify *fk=2000 == xyz*. You can also specify a column parameter ID from the target table instead.

## PK=

Primary key filter, for example *pk=xyz*.

## DK=

Display key filter, to be used for tables that have a display color or for which advanced naming is active. For example, *dk=xyz*.

## CHAIN=

This filter can be used to pass along a custom table relation chain (affects FK filters). Normally, the rows are implicitly joined together and resolved for tables based on the chains defined in the protocol.

## PAGE=

This filter should be followed by an integer, and determines which page is retrieved (with 1 being the first page).

## SORT=

This filter determines how to sort the filter results. It should be followed by one or more parameter IDs, separated by pipe characters (“\|”). The default order is ascending, but DESC can be added in the filter to apply descending sort order instead. For example, *SORT=12502\|DESC*.

From DataMiner 10.0.0/10.0.2 onwards, you can also specify *SORT=NONE*, to avoid any kind of sorting of the results, which may improve performance.

> [!NOTE]
> Sorting direct view tables that combine data from different elements is only possible from DataMiner 9.6.11 onwards. However, note that it is not possible to sort by a column that is not part of the result set.

## RESOLVE=

The resolve filter will substitute values of foreign key columns with the display key of the linked table.

This filter should be followed by a comma-separated string containing the parameter IDs to resolve. If all parameter IDs should be resolved, “*all*” can be specified instead.

For example, if *resolve=1005,2000* is specified, the value in column 1005 (which should be a primary key of table 2000), will be replaced by the display key of that row in table 2000.

## NONRECURSIVE

This filter determines whether the filters need to be resolved non-recursively, in case a table has a relation to itself. In that case only links outside the table will be included.

## RECURSIVE

While dynamic table queries on tables follow recursive links by default, they do not do so automatically when the filtered table directly has a foreign key to itself and it is not being filtered on columns from other linked tables. From DataMiner 9.5.3 onwards, you can use the “recursive” option to force recursion in this scenario. For example: *value=201 == XXXXX;recursive*.

When combined with NONRECURSIVE in the same query, NONRECURSIVE takes precedence.

From DataMiner 9.6.5 onwards, the following recursion modes can be specified:

- *recursive=none*, *recursive=false*, or *nonrecursive*: No recursion.

- *recursive=up*: Follows recursion only from child nodes up to parent nodes (following the foreign key in the direction it is in).

- *recursive=down*, *recursive=true*, or *recursive*: Follows recursion only from parent nodes down to all of their direct and indirect children (following the foreign key in the reverse direction).

- *recursive=upDown*: Follows recursion both upwards and downwards.

- *recursive=upDownNoLocal*, *recursive=upNoLocal* or *recursive=downNoLocal*: Enforce recursion on the table that is being queried directly. Adding the “NoLocal” suffix allows you to specify a recursion mode without enforcing local recursion.

In case no recursion mode is specified, *recursive=downNoLocal* is applied.

## TREND=

This filter is used to filter results based on whether items are trended. It should be followed by one or more parameter IDs combined with the type of trending. Each parameter ID and trend type should be separated by a comma, and the different parameter IDs should be separated by pipe ("\|") characters.

Examples:

```txt
trend=avg,1005
trend=rt,1005
trend=avg,1005|rt,1005
```

## ALARM=

This filter should be followed by a comma-separated string of parameter IDs. Only rows for which the specified columns are in alarm state will be retrieved.

Example:

```txt
alarm=1005,1006,1022
```

## COLUMNS=

This filter is used to filter on particular columns and should be followed by a comma-separated string of parameter IDs. The PK column is always included.

Example:

```txt
columns=1005,1006,1022
```

> [!NOTE]
> This type of filter is supported for (direct) view tables from DataMiner 9.6.0/9.6.3 onwards.

From DataMiner 9.6.4 onwards, it is possible to include additional columns that retrieve data from a table that is linked via relations (i.e. left join). To do so, add a "$" prefix to the parameter IDs of the external columns. For example:

```txt
columns=123,456,$567
```

> [!NOTE]
> - A foreign key relation path must exist between the table being queried and the linked data table.
> - The result set will not be updated when the data in the external table changes.

## FULLFILTER=

This is an expanded form of the VALUE= filter, which can contain brackets and logical operators.

The following operators can be used: ==, !=, \>=, \<=, \<, \>, IS, ===, IN_RANGE, OUT_RANGE, AND, OR.

For example:

```txt
fullFilter=((PK >= 5) AND ((101 IN_RANGE 0/10) OR (102 == 50))) OR (103 IS true)
```

From DataMiner 9.6.6 onwards, several of these filters can be combined, and it is also possible to combine a FULLFILTER= type filter with a VALUE= type filter. The resulting query will be an AND combination of the filters.

From DataMiner 10.2.0/10.2.2 onwards, it is possible to use regular expressions in this type of filter. For this purpose, use the REGEX keyword to indicate that the next part of the filter, enclosed in single quotation marks, is a regular expression.

For example:

```txt
fullFilter=(512 REGEX '^(?:Zand|Ambachten)[\'\\\\]+straat' AND 510 == 1000)
```

In the example above, the regular expression contains a single quotation mark and a backslash character that are part of the query. Since the "fullfilter" syntax requires these characters to be escaped, they have been escaped with an additional backslash character, and as a backslash character in a regular expression also needs to be escaped, four backslash characters are needed here.

> [!NOTE]
> - String values should be enclosed in single quotation marks (').
> - Prior to DataMiner 9.0.1, *AND* and *OR* operators in the filter are applied from left to right in one accumulated result, which can potentially lead to unexpected results. To avoid this, if there is a single *AND* value, place this at the end of the filter.
> - If you encounter issues with this type of filter after an upgrade to 9.0.1 because of the changed behavior, you can revert to the old behavior by specifying *\<SLElement fallback="true" />* in *MaintenanceSettings.xml*. See [Filtering.SlElement](xref:MaintenanceSettings_xml#filteringslelement).
> - This type of filter is not supported to filter the list of elements from which a direct view retrieves data.

## RECURSIVEFULLFILTER

Available from DataMiner 10.0.3 onwards. This filter uses the same syntax as the fullfilter component, but is applied to all keys found through recursive links when requesting a table with the recursive option.

For example:

```txt
recursivefullfilter=(1002 > 0)
```

> [!NOTE]
> This filter component can also be used in table filters specified in a DataMiner Maps configuration file. See [Configuring the DataMiner Maps](xref:Configuring_the_DataMiner_Maps).

## NODIRECTVIEW=

This filter should be followed by true or false, and determines whether the direct view option is applied on the filter result. For more information on this option, refer to the protocol development documentation.

## FORCEFULLTABLE=

This filter can be used on [partial tables](xref:Table_parameters#partial-tables) to force the filter to go through all the pages rather than just the first. The filter should be followed by true or false.
