---
uid: Protocol.PortSettings
---

# PortSettings element

Defines the default port settings of the main device port. It also allows you to restrict the capabilities of the main device port, and to define the format and range of the bus address, if any.

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[name](xref:Protocol.PortSettings-name)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)|Yes|Specifies the name of the additional protocol type as specified in the [Protocol.Type@advanced](xref:Protocol.Type-advanced) attribute.|
|[visibleInUi](xref:Protocol.Ports.PortSettings-visibleInUi)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If set to “false”, users cannot see or change the port settings for this additional protocol type when creating or editing an element.\*|

\* *Not applicable for the main connection (Protocol.PortSettings), only for additional connections (Protocol.Ports.PortSettings).*

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Baudrate](xref:Protocol.PortSettings.Baudrate)|[0, 1]|Allows to limit baud rate settings and to define a default value.|
|&nbsp;&nbsp;[BusAddress](xref:Protocol.PortSettings.BusAddress)|[0, 1]|Allows to limit bus address settings and to define a default value.|
|&nbsp;&nbsp;[Databits](xref:Protocol.PortSettings.Databits)|[0, 1]|Allows to limit bus databit settings and to define a default value.|
|&nbsp;&nbsp;[Flowcontrol](xref:Protocol.PortSettings.Flowcontrol)|[0, 1]|Allows to limit flow control settings and to define a default value.|
|&nbsp;&nbsp;[FlushPerDatagram](xref:Protocol.PortSettings.FlushPerDatagram)|[0, 1]|When set to true, any datagram received on the connection will be forwarded to SLProtocol immediately, which will then store it in the response parameter.|
|&nbsp;&nbsp;[GetCommunity](xref:Protocol.PortSettings.GetCommunity)|[0, 1]|Specifies the GetCommunity string of an SNMP protocol.|
|&nbsp;&nbsp;[IPport](xref:Protocol.PortSettings.IPport)|[0, 1]|Specifies the IP port configuration.|
|&nbsp;&nbsp;[LocalIPport](xref:Protocol.PortSettings.LocalIPport)|[0, 1]|Specifies the local IP port configuration.|
|&nbsp;&nbsp;[Parity](xref:Protocol.PortSettings.Parity)|[0, 1]|Allows to limit parity settings and to define a default value.|
|&nbsp;&nbsp;[PingInterval](xref:Protocol.PortSettings.PingInterval)|[0, 1]|Configures the ping interval.|
|&nbsp;&nbsp;[PortTypeIP](xref:Protocol.PortSettings.PortTypeIP)|[0, 1]|Specifies settings related to the TCP/IP port type.|
|&nbsp;&nbsp;[PortTypeSerial](xref:Protocol.PortSettings.PortTypeSerial)|[0, 1]|Specifies settings related to the serial port type.|
|&nbsp;&nbsp;[PortTypeUDP](xref:Protocol.PortSettings.PortTypeUDP)|[0, 1]|Specifies settings related to the UDP/IP port type.|
|&nbsp;&nbsp;[Retries](xref:Protocol.PortSettings.Retries)|[0, 1]|Configures the number of retries.|
|&nbsp;&nbsp;[SetCommunity](xref:Protocol.PortSettings.SetCommunity)|[0, 1]|Specifies the SNMP set community string.|
|&nbsp;&nbsp;[SlowPoll](xref:Protocol.PortSettings.SlowPoll)|[0, 1]|Specifies the slow poll configuration.|
|&nbsp;&nbsp;[SlowPollBase](xref:Protocol.PortSettings.SlowPollBase)|[0, 1]|Specifies the slow poll base settings.|
|&nbsp;&nbsp;[SSH](xref:Protocol.PortSettings.SSH)|[0, 1]|Specifies the SSH settings.|
|&nbsp;&nbsp;[Stopbits](xref:Protocol.PortSettings.Stopbits)|[0, 1]|Specifies the stop bits settings.|
|&nbsp;&nbsp;[TimeoutTimeElement](xref:Protocol.PortSettings.TimeoutTimeElement)|[0, 1]|Specifies settings related to the element timeout.|
|&nbsp;&nbsp;[TimeoutTime](xref:Protocol.PortSettings.TimeoutTime)|[0, 1]|Specifies settings related to the timeout of a command/request.|
|&nbsp;&nbsp;[Type](xref:Protocol.PortSettings.Type)|[0, 1]|Specifies the port type settings.|

## Remarks

It is advised to always use this tag, because it greatly enhances the user-friendliness of the protocol. When users add new elements, the port values of those elements will by default be correct, and the process of configuring a new element will be far less error-prone.

The following table gives an overview of all tags that can be inserted into the /Protocol/PortSettings element.

For each of those tags, it also indicates the child elements that are allowed.

|Setting|Value|DefaultValue|Range.From|Range.To|Disabled|
|--- |--- |--- |--- |--- |--- |
|Baudrate|X|X|X|X|X|
|Busaddress|X|X|X|X|X|
|Databits|X|X|X|X|X|
|Flowcontrol|X|X|X|X|X|
|GetCommunity||X|||X|
|IPport||X|||X|
|LocalIPport||X|||X|
|Parity||X|X|X|X|
|PingInterval||X|||X|
|PortTypeIP|||||X|
|PortTypeSerial|||||X|
|PortTypeUDP|||||X|
|Retries||X|||X|
|SetCommunity||X|||X|
|SlowPoll||X|||X|
|SlowPollBase||X|||X|
|Stopbits||X|X|X|X|
|TimeoutTime||X|||X|
|TimeoutElement||X|||X|
|Type||X||||
