---
uid: Script_condition_functions
---

# Script condition functions

Below, you find a list of functions you can use in a Correlation script condition.

These functions can also be used as placeholders, for instance in parameters used in correlation rules. In that case they should be placed between brackets, e.g., \[field(elementname)\].

## field

Retrieves one of the following fields from a base alarm.

| Field | Description |
|--|--|
| rawvalue | Raw alarm value |
| value |  |
| dmaid | DataMiner ID |
| eid | Element ID |
| pid | Parameter ID |
| idx | Display key of table row |
| pk | Primary key of table row |
| severity | (as ID) |
| severityrange | (as ID) |
| status | (as ID) |
| type | (as ID) |
| source | (as ID) |
| elementrca |  |
| parameterrca |  |
| servicerca |  |
| rootkey | Root alarm ID |
| id | Alarm ID |
| userstatus | (as ID) |
| owner |  |
| elementname |  |
| parametername |  |
| previous | ID of previous alarm in tree |
| category |  |
| keypoint |  |
| componentinfo |  |
| hostingdmaid |  |
| viewname | Name of the view containing the element that generated the alarm. If the element can be found in more than one view, then a random name is used. |
| elementkey | The DmaID/ElementID |

## property

Retrieves a property of a base alarm.

When used outside the min/max/avg aggregated functions context, the value will be retrieved from one of the alarms in the bucket only. This will typically be the triggering alarm or the most recent one in the rule bucket.

Syntax:

```txt
property([datatype].[property name])
```

\[datatype\] can have one of the following values:

- view

- element

- service

- alarm

Example:

```txt
property(view.location)
```

## parameter

Retrieves a parameter value.

Examples:

```txt
Parameter(DMAID, elementID, parameterID)
parameter(7,59,350)

Parameter(DMAID, elementID, parameterID, rowindex)
parameter(7,56,110,SLDataMiner)
```

## count

Returns the number of base alarms.

Example:

```txt
count(*)
```

## min

Determines the minimum value among all alarm events in the rule bucket.

Example:

```txt
min(field(value))
```

## max

Determines the maximum value among all alarm events in the rule bucket.

Example:

```txt
max(field(value))
```

## avg

Determines the average value among all alarm events in the rule bucket.

Example:

```txt
avg(field(value))
```

## round

Rounds the value to a certain amount of digits after the comma.

Example:

```txt
round(avg(field(value),3)
```
