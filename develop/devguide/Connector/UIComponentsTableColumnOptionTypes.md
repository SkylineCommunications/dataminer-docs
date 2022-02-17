---
uid: UIComponentsTableColumnOptionTypes
---

# Column option types

The following table provides an overview of the possible column option types:

|Type|Description|
|--- |--- |
|autoincrement|Used to automatically create a unique value.|
|concatenation|Values in this column are the result of a concatenation of other columns.|
|custom|Indicates that the content of the column will be managed in the protocol.|
|displaykey|Column showing the display keys, automatically filled in by the SLElement process.|
|index|Used when retrieving SNMP or WMI tables. It contains the row number.|
|retrieved|Indicates that the content of the column will be managed in the protocol.|
|snmp|Used for columns that contain data retrieved via SNMP.|
|state|Used when retrieving SNMP or WMI tables.|
|viewTableKey|Used for direct view columns containing primary keys, so that a prefix is added to them, referring to the source element that supplied the data. See viewTableKey.|

> [!NOTE]
> The usage of retrieved is preferred over custom, since this allows, among other things, to set a column at once. For more information, see <xref:Protocol.Params.Param.ArrayOptions.ColumnOptions.ColumnOption>.
