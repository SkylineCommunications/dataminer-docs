---
uid: LogicActionAggregate
---

# aggregate

This action can be executed on parameters only.

This action aggregates data from one table into another table.

## Attributes

### On@id

Specifies the ID(s) of the table column parameter(s) containing the values to be aggregated.

### Type@options

Specifies the aggregation options.

The following options are available:

- [allowValues/ignoreValues](#allowvaluesignorevalues)
- [avoidZeroInResult](#avoidzeroinresult)
- [defaultIf](#defaultif)
- [defaultValue](#defaultvalue)
- [equation](#equation)
- [equationvalue](#equationvalue)
- [filter](#filter)
- [groupby](#groupby)
- [groupbyTable](#groupbytable)
- [join](#join)
- [return](#return)
- [status](#status)
- [threaded](#threaded)
- [type](#type)
- [weight](#weight)

#### allowValues/ignoreValues

Comma-separated list of values that have to be either included in or excluded from the aggregate action.

There are two ways to specify a value:

- Plain value (e.g., -1)
- 0-based column position, followed by a slash and a value: All values in the specified column that are equal to the value after the slash will be either allowed or ignored.

If you define multiple items, they will be combined in a logical OR expression.

For example, if you specify ignoreValues:2/4,3/5, the row will be ignored if column 2 has value 4 OR column 3 has value 5. Same for allowValues:6/7,8/9. In that case, the row will only be taken in account if column 6 has value 7 or column 8 has value 9. allowValues and ignoreValues are combined in a logical AND expression: allowValues:6/7,8/9;ignoreValues:2/4,3/5 will only take rows in account where (column 6 has value 7 OR column 8 has value 9) AND NOT where (column 2 has value 4 OR column 3 has value 5).

> [!NOTE]
>
> Suppose that groupby column 8 contains an exception key "-1" for special rows (e.g., parent not found) you do not want to aggregate, and that the aggregate action is groupby:8;count;ignoreValues:8/-1. In the parent table, this will return a row with key "-1" and value 0 (if there is at least one row in the source table that contains "-1").
>
> This is the case for aggregate actions of type count, sum and pct. When type is avg, no row will be created and no value will be returned in the parent table.
>
> To avoid the creation of the undesired "-1" key row in the parent table, you have a number of options:
>
> - Use limitresult (In that case, only the rows of the parent will be taken into account), or
> - Specify "avoidZeroInResult" in the aggregate action. In that case, the row will not be included. To see the valid zero results in the parent table, you can use the defaultValue option. For more information, see [avoidZeroInResult](#avoidzeroinresult).

#### avoidZeroInResult

The default behavior of an aggregate action of type "count", "sum", or "pct" is to include an entry in the result table for each value found in the column specified by the "groupBy" option.

> [!NOTE]
> When type is avg, no row will be created and no value will be returned in the parent table.

By default, in case none of the grouped rows meet the condition for inclusion (specified by the "allowValues" and "ignoreValues" option), the result table will contain a row for this "groupBy" item with value zero as the aggregation result value.

In case this behavior is undesired, specify the "avoidZeroInResult" option.

Note that if this primary key is already present in the result table from a previous aggregation run, the old value will remain unchanged. Use the "defaultValue" attribute to change this old value for existing rows in the result table.

The following examples illustrate the behavior. The example performs aggregation on the following table:

| Primary Key | GroupBy column (IDX 1) | Value Column                                             |
|-------------|------------------------|----------------------------------------------------------|
| 1           | 2                      | -1 (This is typically implemented as an exception value) |

- **Example 1**: groupby:1;type:sum;ignoreValues:-1;return:3103

The grouping for rows that have value 2 results in a single row to be taken into account (row with PK 1). The value for this row is -1, which matches the value specified in the "ignoreValue" option. Therefore, the aggregation result will be zero. In the table that holds the aggregation results, a row will be added (or updated in case there was already a row with primary key "2" as a result of a previous aggregation) with value zero as the aggregation result.

Result table:

| Primary Key | Aggregation Result Value (pid 3103) |
|-------------|-------------------------------------|
| 2           | 0                                   |

- **Example 2**: groupby:1;type:sum;ignoreValues:-1;return:3103;avoidZeroInResult

In case the result table did not already contain a row with primary key "2", the updated aggregation result table will also not include a row with primary key 2.

In case the result table did already contain a row with primary key "2" (e.g., with aggregation result value 20), the value will remain unchanged for that row.

Result table:

| Primary Key | Aggregation Result Value (pid 3103) |
|-------------|-------------------------------------|
| 2           | 20                                  |

- **Example 3**: groupby:1;type:sum;ignoreValues:-1;return:3103;avoidZeroInResult;defaultValue:3103,-1

In case the previous aggregation result did not include a row with primary key 2, the new result table will also not include a row with primary key 2.

In case the result table did already contain a row with primary key "2" (e.g., with aggregation result value 20), the value will be updated to the specified default value.

Result table:

| Primary Key | Aggregation Result Value (pid 3103) |
|-------------|-------------------------------------|
| 2           | -1                                  |

#### defaultIf

Possibility to define a condition to fill in the defaultValue.

Format: Column Idx (0-based),Value

In the following example, the parameter with ID 1002 will be set to 6 only if the value in column 3 (0-based) equals 1:

```xml
options="defaultValue:1002,6;defaultIf:3,1"
```

#### defaultValue

Possibility to define a default value if no result was returned for a certain row.

Format: Column Parameter Id , Value

In the following example, the parameter with ID 1002 will be set to 6:

```xml
options="defaultValue:1002,6"
```

#### equation

If you want to only aggregate values that meet a specific condition, use the equation option to specify that condition.

Format: `<operator>,<PID>`

- Possible operators:
  - &lt;
  - &gt;
  - !=
  - ==
  - &lt;=
  - &gt;=
  - regex (see [aggregate](#aggregate))<!-- RN 30199 -->
- PID: ID of the parameter containing the value to which to compare the values to be aggregated

Example:

```xml
equation:&lt;,1250

<Action id="2">
   <Name>Regex aggregate with equation in parameter</Name>
   <On id="304">parameter</On>
   <Type options="groupby:2;type:count;equation:regex,3120;return:3102">aggregate</Type>
</Action>
```

For the regex operator, instead of specifying a parameter ID, the regex can be provided through the regex attribute:

```xml
<Action id="1">
   <Name>Regex aggregate with static equation</Name>
   <On id="304">parameter</On>
   <Type options="groupby:2;type:count;equation:regex,;return:3002" regex="^[a-zA-Z]{2}$">aggregate</Type>
</Action>
```

#### equationvalue

<!-- RN 6557 -->

Filter on value (param or instances of a table)

```xml
<Type options= "threaded;type:count;equationvalue:a,b,c,d;avoidzeroinresult;">
  aggregate
</Type>
```

- a = equation type,
  - ==
  - &gt;=
  - &lt;=
  - &lt;
  - &gt;
  - !=
  - regex (see [aggregate](#aggregate))<!-- RN 30199 -->

For all equation types except for regex, the parts b, c and d specify the following:

- b = value to compare to
- c = parameter ID
- d = instance

  This is the PK value.

  - If an instance is specified, that instance from the table will always be used to compare.
  - If there is no instance and a parameter ID of that same table is set in "c", the compare is done cell by cell.
  - If a column parameter ID of a remote table is set in "c", it is used to filter only the linked rows.

For equation type regex, the parts b, c and d specify the following, depending on how the regular expression is defined:

- Equation value with a regular expression defined in a parameter:
  - b: The ID of the parameter containing the regular expression.
  - c: The ID of the column parameter to which the equation must be applied.
  - d: The row index. If this argument is not specified, the matching will be done on a row-by-row basis.

  Example:

  ```xml
  <Action id="4">
     <Name>Regex aggregate with equation value in parameter</Name>
     <On id="306">parameter</On>
     <Type options="groupby:2;type:avg;equationvalue:regex,3120,304,;return:3302">aggregate</Type>
  </Action>
  ```

  > [!NOTE]
  > When you opt to store a regular expression in a parameter, then this parameter should be a standalone, single-value parameter of type string.

- Equation value with a regular expression defined in a regex attribute:
  - b: Empty when regular expression is specified in a separate regex attribute.
  - c: The ID of the column parameter to which the equation has to be applied.
  - d: The row index. If this argument is not specified, the matching will be done on a row-by-row basis.

  Example

  ```xml
  <Action id="3">
     <Name>Regex aggregate with static equation value</Name>
     <On id="306">parameter</On>
     <Type options="groupby:2;type:avg;equationvalue:regex,,304,;return:3202" regex="^[a-zA-Z]{2}$">aggregate</Type>
  </Action>
  ```

#### filter

undefined

#### groupby

The (0-based) ID(s) of the column(s) by which to group the data. If you specify more than one ID, separate the IDs by commas. If there are multiple IDs used in combination with the return option, then these columns will also have to be part of the destination table:

Specify these destination columns by:

- Adding a colon in the groupby items, e.g., groupby:3:1103,2:1104;return:1105
- OR adding the destination columns in the return, e.g., groupby:3,2;return:1103,1104,1105

The first possibility is the preferred one as it gives a clearer indication of where a certain group by column will be written to. Using e.g., "groupby:3,2;return:1105" will result in unexpected behavior, as the first group by column will be placed in destination column 1105 instead of the expected result of the aggregate action.

The groupby column of the source table is preferably of type string. When using a parameter of type signed number with a fixed length of 4 bytes and value "-1", then in the result table this key will not be "-1" but 4294967295 (or 2^32 -1). No problems will occur if you use positive numbers or string parameters with value "-1".

#### groupbyTable

The parameter ID of the table containing the values by which to group the data.

```xml
<Action id="212">
  <On id="402">parameter</On>
  <Type options="groupbyTable:200;type:sum;return:212;allowValues:;ignoreValues:">
    aggregate
  </Type>
</Action>
```

#### join

Use this option to join a number of columns.

Specify the parameter IDs of the columns, separated by commas.

#### return

The destination parameter IDs of the table or columns in which the results of the aggregate action must be stored. The returned result will contain multiple items; the number of items depends on the aggregation type.

You can configure where the result should be placed by specifying comma-separated parameter IDs, e.g., "return:1105,1106".

It is not mandatory to put all returned result columns into parameters; you could choose to only retrieve the calculated value and omit the weight, e.g., "return:1105".

Suppose, for example, you have a PID table listing the details of all PIDs across a number of services, and you want to aggregate the bandwidth values of those PIDs per service in a separate Services table.

The following code will take all values from the bandwidth column of the PID table (parameter ID 103), group them by the second column in the PID table (containing for example the service ID), count them together (per service), and store them in the total bandwidth column of the Services table (parameter ID 203).

```xml
<On id="103">parameter</On>
<Type options="type:sum;groupby:1;return:203">aggregate</Type>
```

The table must at least have three columns:

- one for the groupby key

  > [!NOTE]
  > In case of a multiple groupby, extra columns are needed. If you have e.g., a groupby=1,2, then you must have three groupby columns: one for the 1, one for the 2, and one for the 1.2.

- one for the aggregated value
- one for the weight

> [!NOTE]
> All columns of the "return table" must have the type attribute of their ColumnOption tag set to "retrieved".

#### status

If you want the aggregate function to return its status, use this option, followed by the ID of the parameter in which the status has to be stored.

Possible status values:

- 0: Finished
- 1: Busy
- 2: Finished with failure

#### threaded

Specify this option if you want the aggregate function to be executed in a separate thread.

#### type

The type of aggregate action to be performed on the source data:

- PCT

  Used in combination with an equation. Produces the percentage for each groupby that meets the equation.

  This will return 2 columns: percentage and weight.

    > [!NOTE]
    > When this is used in combination with ignoreValues:
    >
    > - If only the value to be ignored is specified, the ignored row will still count as total. For example, 3 rows with value 50,70,-1 with pct equation > 60 ignoreValues:-1 will result in 33.33%, weight 3.
    > - If a column to be ignored is specified, the ignored row will not count in the percentage calculation. For example, 3 rows with value 50,70,-1 with pct equation > 60 ignoreValues:5/-1 will result in 50%, weight 2.

- PCT TOTAL

  Total percentage: calculates the percentage relative to the total number of rows in the table.

- AVG

  This will return 2 columns: average and weight.

- AVG EXTENDED

  This will return 4 columns: average, weight, min value and max value.

- MAX

  This will return 2 columns: maximum and weight. The weight will be value 1, so this column can be omitted

- MIN

  This will return 2 columns: minimum and weight. The weight will be value 1, so this column can be omitted

- COUNT

  This will return 2 columns: count and weight. The weight value will be the same as the count, so this column can be omitted.

- SUM

  This will return 2 columns: sum and weight.

In the following example, the result values of the avg extended will be placed in separate columns:

```xml
<Action id="1">
  <On id="102">parameter</On>
  <Type options="groupby:2;type:avg extended;return:202,203,204,205">aggregate</Type>
</Action>
```

#### weight

The weight option is used when the value column represents an average with an associated weight. This weight adjusts the relative significance of each row in the final result, ensuring accurate aggregation.

Alternatively, the weight can represent the frequency of occurrences, acting as a multiplier to indicate that some rows may represent more items than others.

Example:

```xml
<Action id="1">
  <On id="102">parameter</On>
  <Type options="groupby:3;weight:103;type:avg;return:202">aggregate</Type>
</Action>
```

In this case, the weight is defined by column 103, which represents how many times the corresponding value in column 102 occurs.

| PK (101) | Value (102) | Weight (103) | Group (104) |
|----------|-------------|--------------|-------------|
| 1        | 10          | 50           | 1           |
| 2        | 2           | 5            | 1           |

Results in:

| PK (201) | Value (202) |
|----------|-------------|
| 1        | 9           |

### Type@regex

(optional): Specifies the regular expression to use.<!-- RN 30199 -->

## Examples

```xml
<Type options="groupby:1:202,2:203;type:count;return:204">aggregate</Type>
```

| PK (101) | Group1 (102) | Group2 (103) |
|----------|--------------|--------------|
| 11.12.1  | 11           | 12           |
| 11.12.2  | 11           | 12           |
| 11.12.3  | 11           | 12           |

This results in:

| PK (201) | Group1 (202) | Group2 (203) | Value (204) |
|----------|--------------|--------------|-------------|
| 11.12 11 | 1            | 2            | 3           |

The Groupby will create a row with a PK and the values of the groupby separated by a dot. But it is also possible to put the values in separate columns.

**To aggregate a recursive table:**

It is best not to use the recursive table as the base table for a normal aggregate action.

For example, with a parent table (300), recursive table (200), and a child table (100):

- To aggregate the recursive table, start at the child table, but do not use the groupby option.

  ```xml
  <On id="101">parameter</On>
  <Type options="type:count;return:203;defaultvalue:203,0;threaded">aggregate</Type>
  ```

- To aggregate the parent table, also start at the child table and do not use the groupby option.

  ```xml
  <On id="101">parameter</On>
  <Type options="type:count;return:303;defaultvalue:303,0;threaded">aggregate</Type>
  ```

- It is also possible to aggregate in the other direction, e.g., if you want to see how many rows there are above. For example, if table 100 contains customers, 200 contains amplifiers, and 300 contains nodes, you can count how many amplifiers are above a customer before being connected to a node.

  ```xml
  <On id="201">parameter</On>
  <Type options="type:count;return:103;defaultvalue:103,0;threaded">aggregate</Type>
  ```

**Example using regex:**

```xml
<Action id="3">
  <Name>Regex aggregate with static equation value</Name>
  <On id="306">parameter</On>
  <Type options="groupby:2;type:avg;equationvalue:regex,,304,;return:3202" regex="^[a-zA-Z]{2}$">>aggregate</Type>
</Action>
```
