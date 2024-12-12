---
uid: AdvancedDcfTables
---

# DataMiner DCF tables

The general parameters have been extended with four tables to store the DCF information.

- \[Interfaces\]
- \[Interface Properties\]
- \[Connections\]
- \[Connection Properties\]

## Interfaces

The Interfaces table contains the DCF interfaces of the element.

For standalone interfaces, the key used in the Interfaces table corresponds with the ID of the corresponding Group.

The key of dynamic interfaces is an autoincremented value starting from 10 001 (prior DataMiner 9.0.4) or 100 001 (since DataMiner 9.0.4).

![alt text](~/develop/images/DcfInterfacesTable.png "DataMiner Connectivity Framework - Interfaces table.")

Note that it is also possible to give a custom name to an interface.

The Interfaces table parameter has ID 65049.

|ID|Name|Description|
|--- |--- |--- |
|65050|__Interface_ID|[Interface ID]|
|65051|__Interface_Name|[Interface Name]|
|65093|__Custom_Name|[Custom Name]|
|65052|__Interface_Type|[Interface Type]|
|65053|__Interface_Alarm_State|[Interface Alarm State]|
|65095|__Interface_Dynamic_Link|[Interface Dynamic Link]|

## Interface Properties

The Interface Properties table contains the DCF interface properties of the element.

![alt text](~/develop/images/DcfInterfacePropertiesTable.png "DataMiner Connectivity Framework - Interface Properties table.")

The Interface Properties table parameter has ID 65054.

|ID|Name|Description|
|--- |--- |--- |
|65082|__Interface_Property_ID|[Interface Property ID]|
|65055|__Interface_Property_name|[Interface Property name]|
|65056|__Interface_Property_type|[Interface Property type]|
|65057|__Interface_Property_value|[Interface Property value]|
|65059|__Interface_Property_link|[Interface Property link]|

## Connections

The Connections table contains the DCF connections of the element.

![alt text](~/develop/images/DcfConnectionsTable.png "DataMiner Connectivity Framework - Connections table.")

The Connections table parameter has ID 65060.

|ID|Name|Description|
|--- |--- |--- |
|65061|__Connections_ID|[Connections ID]|
|65096|__Connections_Name|[Connections Name]|
|65062|__Source_Interface|[Source Interface]|
|65089|__Destination_DataMiner/Element|[Destination DataMiner/Element]|
|65064|__Destination_Interface|[Destination Interface]|
|65101|__Connections_Filter|[Connections Filter]|

## Connection Properties

The Connection Properties table contains the DCF connection properties of the element.

![alt text](~/develop/images/DcfConnectionPropertiesTable.png "DataMiner Connectivity Framework - Connection Properties table.")

The Connection Properties table parameter has ID 65068.

|ID|Name|Description|
|--- |--- |--- |
|65083|__Connection_Property_ID|[Connection Property ID]|
|65069|__Connection_Property_name|[Connection Property name]|
|65070|__Connection_Property_type|[Connection Property type]|
|65071|__Connection_Property_value|[Connection Property value]|
|65073|__Connection_Property_link|[Connection Property link]|
