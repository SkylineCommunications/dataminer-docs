---
uid: UIComponentsTableColumnOptionTypes
---

# Column option types

The following table provides an overview of the possible column option types:

|Type|Description|
|--- |--- |
|[autoincrement](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#autoincrement)|Used to automatically create a unique value.|
|[concatenation](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#concatenation)|Values in this column are the result of a concatenation of other columns.|
|[custom](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#custom)|Indicates that the content of the column will be managed in the protocol.|
|[displaykey](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#displaykey)|Column showing the display keys, automatically filled in by the SLElement process.|
|[index](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#index)|Used when retrieving SNMP or WMI tables. It contains the row number.|
|[retrieved](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#retrieved)|Indicates that the content of the column will be managed in the protocol.|
|[snmp](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#snmp)|Used for columns that contain data retrieved via SNMP.|
|[state](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#state)|Used when retrieving SNMP or WMI tables.|
|[viewTableKey](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type#viewtablekey)|Used for direct view columns containing primary keys, so that a prefix is added to them, referring to the source element that supplied the data. See viewTableKey.|

> [!NOTE]
> The usage of retrieved is preferred over custom. For more information, see <xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type>.
