---
uid: Protocol-EnumColumnOptionType
---

# EnumColumnOptionType simple type

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|autoincrement|Auto-incremented value.|
|&nbsp;&nbsp;Enumeration|concatenation|Concatenates the values of the columns specified in the values attribute.|
|&nbsp;&nbsp;Enumeration|custom|Indicates that the content of the column will be managed in the protocol.|
|&nbsp;&nbsp;Enumeration|displaykey|DataMiner will automatically fill in this column with the display key.|
|&nbsp;&nbsp;Enumeration|index|Used when retrieving SNMP or WMI tables. It contains the row number.|
|&nbsp;&nbsp;Enumeration|retrieved|This type is used to populate a column with a call to DataMiner using NotifyProtocol type 220 call (<xref:NT_FILL_ARRAY_WITH_COLUMN>), to perform a merge action, to perform an aggregate action, or to perform a swap action.|
|&nbsp;&nbsp;Enumeration|snmp|Represents an SNMP column.|
|&nbsp;&nbsp;Enumeration|state|The state column is a column that can be used when retrieving SNMP or WMI tables, or tables consisting of retrieved columns. When, for example, a row is removed between two get operations, this cell will be set to "deleted". Possible values for this cell are: Updated (1), Equal (2), New (3), Deleted (4), Recreated (5). With this column type, you can extend the options attribute with the value "delete". If you do so, deleted rows will be automatically removed from the dynamic table. When you do not specify the "delete" option, deleted rows will stay in the table.|
|&nbsp;&nbsp;Enumeration|viewTableKey|If a direct view column containing primary keys is of type "viewTableKey", then those primary keys will be added a ‘DataMinerAgentID_ElementID_’ prefix referring to the source element that supplied the data. This allows to retrieve the correct data from a direct view table if the tables in the source elements do not have unique primary keys.<!-- RN 13582 -->|
