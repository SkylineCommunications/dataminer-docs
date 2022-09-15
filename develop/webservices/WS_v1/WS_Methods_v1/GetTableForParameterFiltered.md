---
uid: GetTableForParameterFiltered
---

# GetTableForParameterFiltered

Use this method to retrieve the rows of a table parameter that match the specified table row filters.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| includeCells | Boolean | If true, all column values will be included in the result. If false, only the primary key and the display key will be included. |
| filters | Array of string | The list of table row filters. You can specify standard DataMiner filters. If you specify e.g. “value=105 == test”, the result will only contain the rows of which the value of the table column with parameter ID 150 equals “test”. Multiple filters can be combined with semicolons (;) as separators. See [Filters](#filters). |

### Filters

The following filters can be specified in the input for this method:

- **VALUE=**

  Specify a value filter with the structure “ParameterID Operator Value”. For example, to only include rows where the column with parameter ID 51 contains the value “3”, specify `VALUE=51 == 3`.

  The parameter ID can be:

  - A parameter of the same table

  - A parameter from a linked table that is linked via relations and foreign keys as defined in the protocol.

  - *PK* to filter on primary keys

  - *DK* to filter on display keys

  A filtering string can contain multiple value filters. By default, multiple value filters on the same column will be combined as OR, whereas multiple value filters on different columns will be combined as AND. You can also the following operators:

  - For all parameter types: *==* and *!=*

  - For numeric and string values: *\>*, *\>=*, *\<*, *\<=,* *in_range*, *out_range*

  In addition, string values can use the wildcards *\** and *?* if the *==* or *!=* operator is used.

  The value can be:

  - A single value

  - In case the *in_range* or *out_range* operator is used, two values separated by a forward slash (/)

  - From DataMiner 9.0.1 onwards, a value enclosed within single quotation marks (‘)

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

- **FK**=

  This filter is similar in structure to the VALUE= filter, and is used to resolve foreign key relations to other tables or recursively. Only the == operator is allowed.

  For example, to only include rows that have a relation path to the row in table 2000 with primary key “xyz”, specify `fk=2000 == xyz`. You can also specify a column parameter ID from the target table instead.

- **PK**=

  Primary key filter, for example `pk=xyz`.

- **DK**=

  Display key filter, to be used for tables that have a display color or for which advanced naming is active. For example, `dk=xyz`.

- **CHAIN**=

  This filter can be used to pass along a custom table relation chain (affects FK filters). Normally, the rows are implicitly joined together and resolved for tables based on the chains defined in the protocol.

- **PAGE**=

  This filter should be followed by an integer, and determines which page is retrieved (with 1 being the first page).

- **SORT**=

  This filter determines how to sort the filter results. It should be followed by one or more parameter IDs, separated by pipe characters (“\|”). The default order is ascending, but DESC can be added in the filter to apply descending sort order instead. For example, `SORT=12502|DESC`.

  From DataMiner 10.0.0 onwards, you can also specify `SORT=NONE`, to avoid any kind of sorting of the results, which may improve performance.

- **RESOLVE**=

  The resolve filter will substitute values of foreign key columns with the display key of the linked table.

  This filter should be followed by a comma-separated string containing the parameter IDs to resolve. If all parameter IDs should be resolved, “*all*” can be specified instead.

  For example, if `resolve=1005,2000` is specified, the value in column 1005 (which should be a primary key of table 2000) will be replaced by the display key of that row in table 2000.

- **NONRECURSIVE**

  This filter determines whether the filters need to be resolved non-recursively, in case a table has a relation to itself. In that case only links outside the table will be included.

- **RECURSIVE**

  While dynamic table queries on tables follow recursive links by default, they do not do so automatically when the filtered table directly has a foreign key to itself, and it is not being filtered on columns from other linked tables. From DataMiner 9.5.3 onwards, you can use the “recursive” option to force recursion in this scenario. For example: `value=201 == XXXXX;recursive`.

  When combined with NONRECURSIVE in the same query, NONRECURSIVE takes precedence.

  From DataMiner 9.6.5 onwards, different recursion modes can be specified, as detailed in the table below. In case no recursion mode is specified, `recursive=downNoLocal` is applied.

  | Recursion mode | Description  |
  |----------------|--------------|
  | recursive=none<br> recursive=false<br> nonrecursive | No recursion. |
  | recursive=up | Follows recursion only from child nodes up to parent nodes (following the foreign key in the direction it is in). |
  | recursive=down<br> recursive=true<br> recursive | Follows recursion only from parent nodes down to all of their direct and indirect children (following the foreign key in the reverse direction). |
  | recursive=upDown | Follows recursion both upwards and downwards. |
  | recursive=upDownNoLocal<br>recursive=upNoLocal<br>recursive=downNoLocal | Enforce recursion on the table that is being queried directly. Adding the “NoLocal” suffix allows you to specify a recursion mode without enforcing local recursion. |

- **TREND**=

  This filter is used to filter results based on whether items are trended. It should be followed by one or more parameter IDs combined with the type of trending. Each parameter ID and trend type should be separated by a comma, and the different parameter IDs should be separated by pipe ("\|") characters.

  Examples:

  ```txt
  trend=avg,1005
  trend=rt,1005
  trend=avg,1005|rt,1005
  ```

- **ALARM**=

  This filter should be followed by a comma-separated string of parameter IDs. Only rows for which the specified columns are in alarm state will be retrieved.

  Example:

  ```txt
  alarm=1005,1006,1022
  ```

- **COLUMNS**=

  This filter is used to filter on particular columns and should be followed by a comma-separated string of parameter IDs. The PK column is always included.

  Example:

  ```txt
  columns=1005,1006,1022
  ```

- **FULLFILTER**=

  This is an expanded form of the VALUE= filter, which can contain brackets and logical operators.

  For example:

  ```txt
  fullFilter=((PK >= 5) AND ((101 IN_RANGE 0/10) OR (102 == 50))) OR (103 IS true)
  ```

  > [!NOTE]
  > -  String values should be enclosed in single quotation marks (').
  > -  Prior to DataMiner 9.0.1, *AND* and *OR* operators in the filter are applied from left to right in one accumulated result, which can potentially lead to unexpected results. To avoid this, if there is a single *AND* value, place this at the end of the filter.

- **RECURSIVEFULLFILTER**

  Available from DataMiner 10.0.3 onwards. This filter uses the same syntax as the fullfilter component, but is applied to all keys found through recursive links when requesting a table with the recursive option.

  For example:

  ```txt
  recursivefullfilter=(1002 > 0)
  ```

- **NODIRECTVIEW**=

  This filter should be followed by true or false, and determines whether the direct view option is applied on the filter result. For more information on this option, refer to the protocol development documentation.

- **FORCEFULLTABLE**=

  This filter can be used on partial tables to force the filter to go through all the pages rather than just the first. The filter should be followed by true or false.

## Output

| Item | Format | Description |
|--|--|--|
| GetTableForParameterFilteredResult | Array of [DMAParameterTableRow](xref:DMAParameterTableRow) | The rows of the specified table parameter that match the specified table row filters. |
