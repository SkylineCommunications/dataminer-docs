---
uid: Protocol.Params.Param.ArrayOptions
---

# ArrayOptions element

Defines all table columns.

## Parent

[Param](xref:Protocol.Params.Param)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[deleteRow](xref:Protocol.Params.Param.ArrayOptions-deleteRow)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies how non-existing rows should be handled.|
|[displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn)|unsignedInt||Defines which column is used as an identifier for the user.|
|[index](xref:Protocol.Params.Param.ArrayOptions-index)|unsignedInt|Yes|Defines which column contains the primary keys.|
|[options](xref:Protocol.Params.Param.ArrayOptions-options)|string||Specifies a number of options, separated by semicolons (';').|
|[partial](xref:Protocol.Params.Param.ArrayOptions-partial)|string||If set to "true", the table will be subdivided into multiple pages (default: 1000 rows per page).|
|[snmpIndex](xref:Protocol.Params.Param.ArrayOptions-snmpIndex)|[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)||Defines the columns that are used when retrieving the table via SNMP.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat)|[0, 1]|Defines the structure of the display key.|
|&nbsp;&nbsp;&nbsp;&nbsp;[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)|[1, *]|Defines a table column.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |No duplicate idx values must occur for the different ColumnOption elements. |ColumnOption |@idx |

## Remarks

Each column is defined by one or two parameters

- one for read, and/or
- one for write.
