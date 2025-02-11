---
uid: Protocol.Params.Param.ArrayOptions-deleteRow
---

# deleteRow attribute

<!-- RN 10007 -->

Specifies how non-existing rows should be handled.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

This attribute is used in combination with snmpSetAndGet or dynamicSnmpGet functionality on tables. By default it is set to "true", in which case it will remove non-existing rows on a Get after Set:

- If a cell is requested and the Get does not receive it, the cell in the table is set to "not initialized".
- If a column is requested and a cell is empty, but the instance of the row still exists, the cell is set to "not initialized".
- If a column is requested and a cell is empty, and the instance of the row does not exist anymore, the row is deleted.

If a State column exists, the rows stays in the table, but the state is set to "Deleted"

If a row is requested with no State column:

- deleteRow="true" will delete the row.
- deleteRow="false" will set all the cells of that row to "not initialized".

If a row is requested =(MultipleGetNext / MultipleGetBulk) on a table with State column:

- deleteRow="true" will update the State to "Deleted".
- deleteRow="false" will set all the cells of that row to "not initialized" and set the State to "Updated".

## Examples

In the example below, param 100 is the table, and param 202 is the Write column using a Get of the cell after the Set. The group that will do the Get added to the queue via an executeNext.

```xml
<Param id="100" trending="false">
   <Name>Table 1</Name>
   <Description>Table 1</Description>
   <Type>array</Type>
   <ArrayOptions index="0" deleteRow="true">
   ...
 
<Param id="202" snmpSetAndGet="executeNext">
   <Name>snmpSetAndGet True (cell)</Name>
   <Description>snmpSetAndGet Cell</Description>
   <Type>write</Type>
```
