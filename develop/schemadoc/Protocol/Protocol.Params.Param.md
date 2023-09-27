---
uid: Protocol.Params.Param
---

# Param element

Defines a parameter.

## Parent

[Params](xref:Protocol.Params)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[confirmPopup](xref:Protocol.Params.Param-confirmPopup)|[EnumParamConfirmPopup](xref:Protocol-EnumParamConfirmPopup)||Overrides the "*Never ask for confirmation after setting parameter value*" setting in DataMiner Cube.|
|[duplicateAs](xref:Protocol.Params.Param-duplicateAs)|[TypeCommaSeparatedNumbers](xref:Protocol-TypeCommaSeparatedNumbers)||Takes the value of another parameter and displays it in a column of a view table.|
|[export](xref:Protocol.Params.Param-export)|string||Allows exporting a parameter to an exported protocol used by a dynamic virtual element (DVE).|
|[historySet](xref:Protocol.Params.Param-historySet)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies that this parameter is a history set parameter.|
|[id](xref:Protocol.Params.Param-id)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the ID of the parameter.|
|[level](xref:Protocol.Params.Param-level)|unsignedInt||Specifies the security level of this parameter.|
|[options](xref:Protocol.Params.Param-options)|string||Specifies the options applied to this parameter.|
|[pollingInterval](xref:Protocol.Params.Param-pollingInterval)|unsignedInt||Specifies the polling interval (ms) as a hint for the real-time trend graph.|
|[save](xref:Protocol.Params.Param-save)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the parameter has to be saved each time its value changes.|
|[saveInterval](xref:Protocol.Params.Param-saveInterval)|duration||Specifies that only one save operation must be executed per interval.|
|[setter](xref:Protocol.Params.Param-setter)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the value of the write parameter will be copied to the corresponding read parameter (without the need to add a trigger or an action).|
|[snapshot](xref:Protocol.Params.Param-snapshot)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies the offload of snapshots of a parameter to the central database.|
|[snmpSetAndGet](xref:Protocol.Params.Param-snmpSetAndGet)|string||Performs a set and get on a "write" parameter.|
|[trending](xref:Protocol.Params.Param-trending)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the parameter supports trending.|
|[verificationTimeout](xref:Protocol.Params.Param-verificationTimeout)|unsignedInt||Overrides the default verification timeout (or the verification timeout value set in MaintenanceSettings.xml) for this parameter with the specified value (in milliseconds).|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Alarm](xref:Protocol.Params.Param.Alarm)|[0, 1]|Specifies the default parameter alarming configuration.|
|&nbsp;&nbsp;[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)|[0, 1]|Defines all table columns.|
|&nbsp;&nbsp;[CRC](xref:Protocol.Params.Param.CRC)|[0, 1]|If /Protocol/Params/Param/Type is set to "CRC", then this CRC element allows you to define the CRC used in the communication with the device.|
|&nbsp;&nbsp;[CrossDriverOptions](xref:Protocol.Params.Param.CrossDriverOptions)|[0, 1]|Allows the creation of a direct view table using multiple columns from multiple different protocols.|
|&nbsp;&nbsp;[Dashboard](xref:Protocol.Params.Param.Dashboard)|[0, 1]|Specifies the configuration for use in dashboards.|
|&nbsp;&nbsp;[Database](xref:Protocol.Params.Param.Database)|[0, 1]|Specifies database-related configuration options.|
|&nbsp;&nbsp;[Dependencies](xref:Protocol.Params.Param.Dependencies)|[0, 1]|Allows you to link one or more parameters.|
|&nbsp;&nbsp;[Description](xref:Protocol.Params.Param.Description)|[0, 1]|Specifies the description of the parameter.|
|&nbsp;&nbsp;[Display](xref:Protocol.Params.Param.Display)|[0, 1]|Defines if and how a parameter will be displayed on the user interface.|
|&nbsp;&nbsp;[HyperLinks](xref:Protocol.Params.Param.HyperLinks)|[0, 1]|Contains the custom commands (i.e. "hyperlinks") that have to appear on the shortcut menu when users right-click an alarm of this parameter.|
|&nbsp;&nbsp;[Icon](xref:Protocol.Params.Param.Icon)|[0, 1]|Specifies the icon to be shown in a tree control, either by referring to a predefined icon using the ref attribute or by providing XAML content.|
|&nbsp;&nbsp;[Information](xref:Protocol.Params.Param.Information)|[0, 1]|Specifies additional information about the parameter.|
|&nbsp;&nbsp;[Interprete](xref:Protocol.Params.Param.Interprete)|[0, 1]|Specifies how a parameter value is processed.|
|&nbsp;&nbsp;[Length](xref:Protocol.Params.Param.Length)|[0, 1]|Specifies the length of the command/response.|
|&nbsp;&nbsp;[Matrix](xref:Protocol.Params.Param.Matrix)|[0, 1]|If /Protocol/Params/Param/Type is set to "matrix", this will allow you to define the matrix control. Feature introduced in DataMiner 10.3.1/10.4.0 (RN 34661).|
|&nbsp;&nbsp;[Measurement](xref:Protocol.Params.Param.Measurement)|[0, 1]|Specifies how the parameter has to be displayed on the user interface (depending on the parameter type).|
|&nbsp;&nbsp;[Mediation](xref:Protocol.Params.Param.Mediation)|[0, 1]|Contains the links between parameters of a base protocol and parameters of this protocol.|
|&nbsp;&nbsp;[Message](xref:Protocol.Params.Param.Message)|[0, 1]|Specifies a message to be displayed when users change the parameter on the user interface.|
|&nbsp;&nbsp;[Name](xref:Protocol.Params.Param.Name)||Specifies the name of the parameter.|
|&nbsp;&nbsp;[Replication](xref:Protocol.Params.Param.Replication)|[0, 1]|Used to replicate specific parameters from another element.|
|&nbsp;&nbsp;[SNMP](xref:Protocol.Params.Param.SNMP)|[0, 1]|Specifies SNMP related functionality for this parameter.|
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.Type)||Specifies the parameter type.|
