---
uid: LogicActionMerge
---

# merge

This action must be executed on protocol.

With a "merge" action, you can aggregate data from tables across different protocols.

The action itself is defined in the protocol that contains the table in which the merged data will be stored.

## Attributes

### Type@options

Different options can be specified in this attribute.

The following options are available:

- destination
- defaultValue
- defaultIf
- deleteHistory
- destinationfindpk
- limitresult
- mergeResult
- remoteElements
- resolve
- trigger
- type

#### destination

Parameter ID(s) of the column(s) in which the retrieved data has to be stored. If you specify more than one parameter ID, separate them by commas. Note that if this destination column has to be displayed, the type attribute of its ColumnOption tag has to be set to “retrieved”.

#### defaultValue

Option to define a default value if no result was returned for a certain row.

Format: Column Parameter Id , Value

In the following example, the parameter with ID 1002 is set to 6:

```xml
options="defaultValue:1002,6"
```

#### defaultIf

Option to define a condition when to fill in the defaultValue.

Format: Column Idx (0-based) , Value

In the following example, the parameter with ID 1002 is set to 6 only if value in column 3 (0-based) equals 1:

```xml
options="defaultValue:1002,6;defaultIf:3,1"
```

#### deleteHistory

Removes existing lines in the destination table for which there is no merge result.

#### destinationfindpk

Parameter ID(s) of the column(s) containing the primary key(s) of the destination table. If you specify more than one parameter ID, separate them by commas.

#### limitresult

Option to filter out certain results.

Example (see DataMiner 8.0.0 – RN 5071):

```xml
<Type options="limitresult:x">merge</Type>
```

x is the ID of a parameter holding the grouped rows you want in your result set. The parameter can be a regular parameter or a table parameter.

#### mergeResult

Merges the data together. If you do not use this option, in the destination table, a row containing the results will be added per protocol. Only use this option if the primary keys are unique.

#### remoteElements

Parameter ID of the column containing the element IDs (DmaId/ElementId combinations) of all the elements from which data has to be merged. This column is usually filled in automatically thanks to the DataMiner Data Distribution feature.

#### resolve

Parameter ID(s) of the column(s) containing the primary key(s) of the source table(s). If you specify more than one parameter ID, separate them by commas.

#### trigger

ID of the parameter that fires the trigger leading to an aggregate action on a table column of the remote element.

#### type

The type of merge (average, sum, count, percentage, etc.)

Example (see DataMiner 8.0.0 – RN 5071):

```xml
<Type options="type:avg extended;destination:a,b,c,d">merge</Type>
```

This action will produce a result set that has to be put in four columns. These columns have to specified in the destination option:

- a: avg
- b: weight
- c: min
- d: max

## Examples

Suppose you have a School protocol with a table that contains all average percentages per teacher, and a number of class protocols, each with a table containing all points per teacher.

The element IDs of all Class protocols (retrieved by means of data distribution) are stored in column 2403 of the School protocol.

The table in the School protocol (parameter ID 1000) has two columns: column 1001 contains the names of the teachers and column 1002 contains the average values. The ColumnOption of the latter column must have its type set to “retrieved”!

The table in each of the Class protocols (parameter ID 500) has four columns: column 501 contains the row indexes, column 502 contains the names of the student, column 503 contains the points of the students and column 504 contains the names of the teachers.

The School protocol will contain the “merge” action:

```xml
<Action id="1">
  <On>protocol</On>
  <Type options="remoteElements:2403;trigger:15300;destination:1002;type:avg; destinationfindpk=1001;resolve:504">merge</Type>
</Action>
<Action id="15300">
  <On id="503">parameter</On>
  <Type options="groupby:3;type:avg;status:5301">aggregate</Type>
</Action>
```

Trigger 15300, found in the Class protocols, calls action 15300, which is an “aggregate” action. Parameter 5301 is a status parameter.

> [!NOTE]
>
> - When using a write parameter on the child element that will be executing an “aggregate” action, do not set RTDisplay to true. When this is done, it will be processed by SLElement and this will generate an error in the log file even when the merge action was correctly done. The error will look like this:
>   ```bash
>   SLElement.exe|11040|CElement::NotifyFunc|ERR|0|!! Generating alarm on an unknown parameter (0)
>   alarm info: VT_ARRAY|VT_VARIANT (4) ~ 0 VT_UI4 : 236844 ~ 1 VT_I4 : 0 ~ 2 VT_BSTR :
>   SLProtocol - Elementname ~ 3 VT_ARRAY|VT_BSTR (16) : 16;2014/06/19 12:08:23;13;5;;0;5;11;2910;;0;;;;16;
>   ```
> - The type options PCT, COUNT and PCT TOTAL are not supported for actions of type merge.

Only the following combinations of merge actions that trigger an aggregate action are supported:

|Aggregate Type> Merge Type V|PCT|AVG|AVG EXTENDED|MAX|MIN|COUNT|SUM|PCT TOTAL|
|--- |--- |--- |--- |--- |--- |--- |--- |--- |
|AVG|&#10004;|&#10004;|&#10004;**|&#10004;*|&#10004;*|&#10004;*,**|&#10004;*,**|&#10004;|
|AVG EXTENDED|&#10004;|&#10004;**|&#10004;|&#10004;*|&#10004;*|&#10004;*,**|&#10004;*,**|&#10004;|
|MAX|&#10004;|&#10004;|&#10004;**|&#10004;|&#10004;|&#10004;|&#10004;|&#10004;|
|MIN|&#10004;|&#10004;|&#10004;**|&#10004;|&#10004;|&#10004;|&#10004;|&#10004;|
|SUM|&#10004;|&#10004;|&#10004;**|&#10004;|&#10004;|&#10004;|&#10004;|&#10004;|

\*: Averaging a MIN, MAX, COUNT or SUM averages the aggregated value over the different data elements.

**: Only supported from DataMiner 9.0.0 CU5/9.0.3 onwards (RN 13206).

From DataMiner 9.0.0 CU5/9.0.3 onwards (RN 13206), the following improvements are implemented:

- "merge" actions now support configurations that have an incorrect number of destination columns specified. If not enough columns are specified, only the specified columns are filled in. If too many columns are specified, the excess ones are left untouched. This way, you can have an "avg extended" merge action that only outputs the "avg" (by omitting the weight, min and max columns).
- On "merge" actions other than "avg extended", it is now possible to also include the weight column next to the value. In earlier DataMiner versions, only the aggregated value can be added to the output.
- In earlier DataMiner versions, if the group keys for a merge/aggregate action appear in multiple casing variants (e.g. upper and lower case), the aggregated result is limited to only one of these groups. Now the aggregated value takes all group values into account, regardless of the casing of the groupby fields.
