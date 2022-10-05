---
uid: Linking_a_shape_to_a_calculation_involving_multiple_parameters
---

# Linking a shape to a calculation involving multiple parameters

Using a shape data field of type **ParametersSummary**, you can link a shape to a calculation involving multiple parameters, followed by one or more actions to be performed.

Possible actions include: displaying the minimum, maximum, sum or average of a series of parameter values, coloring a shape with the minimum or maximum alarm severity, coloring a shape with the latched minimum or maximum alarm severity, and flipping, hiding, showing or rotating a shape based on the result of a min, max, sum or avg calculation.

> [!NOTE]
>
> - This feature only works in DataMiner Cube.
> - All parameter values used in a **ParametersSummary** field must be of type "double".
> - By default, the summary value is calculated when all parameter values are available. However, if you add a shape data field of type **Options** and set its value to "IgnoreUnsetValues", the summary value will appear as soon as one of the values is available.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > SUM]* page.

## Configuring the shape data field

Add a shape data field of type **ParametersSummary** to the shape, and set its value to:

```txt
[|]Operation|Param1|Param2|...|ParamZ|Actions
```

> [!NOTE]
> Do not combine this shape data field with an **Element** shape data field on the same shape, as the defined actions may not work correctly in that case.

## Syntax of the ParametersSummary value

The value of a **ParametersSummary** shape data field has to consist of a number of delimited sections:

```txt
Operation|Param1|Param2|...|ParamZ|Actions
```

- **Operation**: The operation to be performed with the specified parameters:

  | Operation | Description                     |
  | --------- | ------------------------------- |
  | Min       | Minimum value                   |
  | Max       | Maximum value (default)         |
  | Sum       | Sum of all parameter values     |
  | Avg       | Average of all parameter values |

- **Param1 \> ParamZ**: The list of parameters on which the specified operation has to be performed.

  See [Syntax of a Parameter section](#syntax-of-a-parameter-section).

- **Actions**: The list of actions to be performed.

  See [Syntax of the Actions section](#syntax-of-the-actions-section).

> [!NOTE]
> By default, a pipe character ("\|") is used as the separator between the sections. However, it is possible to specify an alternative separator in a \[sep:XY\] tag. See [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters).

### Syntax of a Parameter section

The string specified in a Parameter section has to consist of a number of delimited sections:

```txt
Element:Parameter:Index
```

- **Element**: The element

  - DMAID/ElementID
  - Element name
  - Element name filter (containing "?" and/or "\*" wildcards)

- **Parameter**: The parameter

  - Parameter ID
  - Parameter name (can also be the parameter alias specified in *informations.xml* or *description.xml*)
  - Parameter name filter (containing "?" and/or "\*" wildcards)

- **Index**: The table index (in case of a dynamic table parameter)

  - From DataMiner 10.2.1/10.3.0 onwards, you can refer to the index using a subscription filter. This can be any filter that can be passed to a parameter change subscription (e.g. "VALUE=\<PID> == \<value>", "fullFilter=(...)", etc.). For more information, see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

  - From DataMiner 9.6.7 onwards, it is possible to refer to several rows, a column, or a full table. For instance, to refer to all rows that start with "SL", you can specify "101/201:500:SL\*\|". To refer to a column, specify the column parameter, e.g. "101/201:501". To refer to an entire table, specify the table parameter, e.g. "101/201:500".

  - Up to DataMiner 9.6.0, if you specify a table parameter, only one row is allowed to match the filter.

> [!NOTE]
>
> - By default, a colon (":") is used as the separator within a Parameter section. However, it is possible to specify an alternative separator in a \[sep:XY\] tag. See [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters).
> - From DataMiner 10.2.11/10.3.0 onwards, session variables are supported in a Parameter section.

### Syntax of the Actions section

In the Actions section, you can specify the actions to be performed. If you specify multiple actions, separate them with a colon (":"):

```txt
Action:Action:Action:...
```

- **ALARM**: The shape will be filled with the maximum (default) or minimum alarm severity color. If you want to display the latch color, add a **Latch** shape data field next to the **ParametersSummary** field and set it to TRUE.

- **FLIPX;condition1;condition2;...** : The shape will be flipped on its X-axis if one of the conditions is true.

- **FLIPY;condition1;condition2;...** : The shape will be flipped on its Y-axis if one of the conditions is true.

- **HIDE;condition1;condition2;...** : The shape will be hidden if one of the conditions is true.

- **SHOW;condition1;condition2;...** : The shape will be shown if one of the conditions is true.

- **ROTATE;condition1,angle;condition2,angle;...** : The shape will be rotated by the specified angle if one of the conditions is true.

- NONE: No action will be performed.

> [!NOTE]
>
> - If the shape text contains a "\*" character, it will be replaced by the Min, Max, Avg or Sum value.
> - In all sections of the ParametersSummary value, you can use \[Property:...\] placeholders.
> - The conditions you specify in case of FLIPX, FLIPY, HIDE, SHOW or ROTATE will be evaluated against the result of the operation on the specified parameters (Min, Max, Avg or Sum).
> - In conditions, both single equal signs ("=") and double equal signs ("==") are supported.

## Examples of ParametersSummary values

Here are a few examples of **ParametersSummary** values:

```txt
Min|6/97148:176|6/97149:176|6/97150:176|
Max|6/97148:176|6/97149:176|6/97150:176|ALARM
Sum|6/97148:176|6/97149:176|6/97150:176|ROTATE;>10,25
Sum|6/97160:114:row1|6/97160:114:row2|FLIPX;>10
Min|6/97148:*custom description|[property:Element in vdx]:176|6/97150:176|
```
