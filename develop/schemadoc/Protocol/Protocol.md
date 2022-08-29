---
uid: Protocol
---

# Protocol element

The root element of a DataMiner protocol.

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[baseFor](xref:Protocol-baseFor)|string||Specifies the type of element for which this protocol serves as a base protocol.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Actions](xref:Protocol.Actions)|[0, 1]|Contains the actions defined in this protocol.|
|&nbsp;&nbsp;[Advanced](xref:Protocol.Advanced)|[0, 1]|Specifies a number of advanced settings with regard to the protocol's commands and responses.|
|&nbsp;&nbsp;[AlarmLevelLinks](xref:Protocol.AlarmLevelLinks)|[0, 1]|Contains the source and the destination of the element in alarm and where the result needs to be placed.|
|&nbsp;&nbsp;[App](xref:Protocol.App)|[0, 1]|If you tag a protocol as "app", all elements based on that protocol will appear in the Apps list of DataMiner Cube (in the Apps tab of the Surveyor).|
|&nbsp;&nbsp;[Chains](xref:Protocol.Chains)|[0, 1]|Contains the chains defined in this protocol, which are represented as tab pages in DataMiner.|
|&nbsp;&nbsp;[Commands](xref:Protocol.Commands)|[0, 1]|Contains all commands defined in the protocol.|
|&nbsp;&nbsp;[Compliancies](xref:Protocol.Compliancies)||Provides compliance information about this protocol.|
|&nbsp;&nbsp;[Description](xref:Protocol.Description)||Contains a description of the protocol.|
|&nbsp;&nbsp;[DeviceOID](xref:Protocol.DeviceOID)||Specifies an OID for the device that will be managed with the protocol.|
|&nbsp;&nbsp;[Display](xref:Protocol.Display)|[0, 1]|Defines the layout and the order of the Data Display pages.|
|&nbsp;&nbsp;[ElementType](xref:Protocol.ElementType)|[0, 1]|Specifies the type of device for which the protocol will be used.|
|&nbsp;&nbsp;[ExportRules](xref:Protocol.ExportRules)|[0, 1]|Defines rules that are used for changing the displayed items in a Dynamic Virtual Element (DVE), for example changing the location of a parameter.|
|&nbsp;&nbsp;[GeneralParameters](xref:Protocol.GeneralParameters)|[0, 1]|Specifies which general parameter groups should be loaded or not.|
|&nbsp;&nbsp;[Groups](xref:Protocol.Groups)|[0, 1]|Contains the groups defined in the protocol.|
|&nbsp;&nbsp;[HTTP](xref:Protocol.HTTP)|[0, 1]|The root of the HTTP-specific features in a protocol.|
|&nbsp;&nbsp;[Icon](xref:Protocol.Icon)|[0, 1]|Defines the icon that is to be used in the Applications list in the DataMiner Cube surveyor.|
|&nbsp;&nbsp;[IntegrationID](xref:Protocol.IntegrationID)||Specifies the integration ID.|
|&nbsp;&nbsp;[InternalLicenses](xref:Protocol.InternalLicenses)|[0, 1]|Configures internal licensing.|
|&nbsp;&nbsp;[Mib](xref:Protocol.Mib)|[0, 1]|Allows providing additional content (conforming the SMI specification) that must be included in the generated MIB.|
|&nbsp;&nbsp;[Name](xref:Protocol.Name)||Defines the name of the protocol.|
|&nbsp;&nbsp;[NoTimeouts](xref:Protocol.NoTimeouts)|[0, 1]|Groups NoTimeout elements.|
|&nbsp;&nbsp;[Ownership](xref:Protocol.Ownership)|[0, 1]|Specifies the level of access users will have to elements, views, services and redundancy groups created by elements based on this protocol.|
|&nbsp;&nbsp;[Pairs](xref:Protocol.Pairs)|[0, 1]|Contains all the pairs defined in the protocol.|
|&nbsp;&nbsp;[ParameterGroups](xref:Protocol.ParameterGroups)|[0, 1]|Defines the DataMiner Connectivity Framework (DCF) interfaces.|
|&nbsp;&nbsp;[Params](xref:Protocol.Params)|[0, 1]|Contains all the parameters defined in the protocol.|
|&nbsp;&nbsp;[Ports](xref:Protocol.Ports)|[0, 1]|Groups the PortSettings elements for the additional protocol connections.|
|&nbsp;&nbsp;[PortSettings](xref:Protocol.PortSettings)|[0, 1]|Defines the default port settings of the main device port. It also allows you to restrict the capabilities of the main device port, and to define the format and range of the bus address, if any.|
|&nbsp;&nbsp;[Provider](xref:Protocol.Provider)||Specifies the protocol provider.|
|&nbsp;&nbsp;[QActions](xref:Protocol.QActions)|[0, 1]|Contains all the QActions defined in the protocol.|
|&nbsp;&nbsp;[RCA](xref:Protocol.RCA)|[0, 1]|Configures Root Cause Analysis (RCA).|
|&nbsp;&nbsp;[Relations](xref:Protocol.Relations)|[0, 1]|Defines relations between tables.|
|&nbsp;&nbsp;[Responses](xref:Protocol.Responses)|[0, 1]|Contains all responses defined in the protocol.|
|&nbsp;&nbsp;[SeverityBubbleUp](xref:Protocol.SeverityBubbleUp)|[0, 1]|Used to pass alarm severities to linked tables.|
|&nbsp;&nbsp;[SNMP](xref:Protocol.SNMP)|[0, 1]|Specifies how the MIB file for the protocol will be created.|
|&nbsp;&nbsp;[SystemOptions](xref:Protocol.SystemOptions)|[0, 1]|Specifies system-related options.|
|&nbsp;&nbsp;[Threads](xref:Protocol.Threads)|[0, 1]|Specifies additional threads that will be used by the protocol. This allows you to separate time-critical actions from device-polling actions.|
|&nbsp;&nbsp;[Timers](xref:Protocol.Timers)|[0, 1]|Contains all timers defined in the protocol.|
|&nbsp;&nbsp;[Topology](xref:Protocol.Topology)|[0, 1]|Defines a topology. In this element, you can specify several Cell elements, each representing a cell in the diagram displayed in the CPE Manager.|
|&nbsp;&nbsp;[Topologies](xref:Protocol.Topologies)|[0, 1]|Contains several Topology tags, each representing the connections in a diagram displayed in a CPE Manager.|
|&nbsp;&nbsp;[TreeControls](xref:Protocol.TreeControls)|[0, 1]|Contains all the tree controls defined in the protocol.|
|&nbsp;&nbsp;[Triggers](xref:Protocol.Triggers)|[0, 1]|Contains the triggers defined in the protocol.|
|&nbsp;&nbsp;[Type](xref:Protocol.Type)||Specifies the protocol type. In multi-connection protocols, it specifies the type of the main connection.|
|&nbsp;&nbsp;[Vendor](xref:Protocol.Vendor)||Specifies the name of the vendor of the monitored device.|
|&nbsp;&nbsp;[VendorOID](xref:Protocol.VendorOID)||Specifies the vendor OID of the monitored device.|
|&nbsp;&nbsp;[Version](xref:Protocol.Version)||Specifies the protocol version.|
|&nbsp;&nbsp;[VersionHistory](xref:Protocol.VersionHistory)|[0, 1]|Contains an overview of the version history of this protocol.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Key |An action must have a unique ID. |Actions/Action |@id |
|Key |A pair must have a unique ID. |Pairs/Pair |@id |
|Key |A parameter must have a unique ID. |Params/Param |@id |
|Key |A session must have a unique ID. |HTTP/Session |@id |
|Key |A trigger must have a unique ID. |Triggers/Trigger |@id |
|Key Reference |The specified pair in a group must exist. |Groups/Group/Content/Pair |. |
|Key Reference |The specified action in a group must exist. |Groups/Group/Content/Action |. |
|Key Reference |The specified session in a group must exist. |Groups/Group/Content/Session |. |
|Key Reference |The specified trigger in a group must exist. |Groups/Group/Content/Trigger |. |
|Key Reference |The parameter that is referred to holding the parameter ID in dynamic parameter replication must exist. |Params/Param/Replication/Parameter |@dynamic |
|Key Reference |The parameter that is referred to holding the element ID in dynamic parameter replication must exist. |Params/Param/Replication/Element |@dynamic |
|Key Reference |The specified parameter in a group must exist. |ParameterGroups/Group/Params/Param |@id |
|Key Reference |The value specified in /Protocol/Display/Pages/Page/Visibility@overridePID must be the ID of a parameter specified in the protocol. |Display/Pages/Page/Visibility |@overridePID |
|Key Reference |The specified parameter holding the SSH user name must exist. |PortSettings/SSH/Credentials/Username |@pid |
|Key Reference |The specified parameter holding the SSH password must exist. |PortSettings/SSH/Credentials/Password |@pid |
|Key Reference |The specified parameter holding the SSH identity must exist. |PortSettings/SSH/Identity |@pid |
|Key Reference |The specified parameter holding the SSH user name must exist. |Ports/PortSettings/SSH/Credentials/Username |@pid |
|Key Reference |The specified parameter holding the SSH password must exist. |Ports/PortSettings/SSH/Credentials/Password |@pid |
|Key Reference |The specified parameter holding the SSH identity must exist. |Ports/PortSettings/SSH/Identity |@pid |
