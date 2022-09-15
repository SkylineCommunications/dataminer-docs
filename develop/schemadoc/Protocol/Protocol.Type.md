---
uid: Protocol.Type
---

# Type element

Specifies the protocol type. In multi-connection protocols, it specifies the type of the main connection.

## Type

[EnumProtocolType](xref:Protocol-EnumProtocolType)

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[advanced](xref:Protocol.Type-advanced)|string||Specifies additional connections.|
|[communicationOptions](xref:Protocol.Type-communicationOptions)|string||Specifies a number of communication options.|
|[databaseOptions](xref:Protocol.Type-databaseOptions)|string||Specifies a number of database options.|
|[options](xref:Protocol.Type-options)|string||Specifies a number of options.|
|[overrideTimeoutDVE](xref:Protocol.Type-overrideTimeoutDVE)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the DVE will go into timeout when the main element is in timeout.|
|[relativeTimers](xref:Protocol.Type-relativeTimers)|[EnumProtocolTypeRelativeTimers](xref:Protocol-EnumProtocolTypeRelativeTimers)||*** No documentation available yet. ***|

## Remarks

Contains one of the values detailed below.

### gpib

This type of protocol, built like a "Serial" protocol, will allow DataMiner to communicate with GPIB gateways.

### http

This type specifies that the HTTP protocol is used for communication.

### opc

This type of protocol, built like a "Serial" protocol, will allow DataMiner to communicate with elements using OPC (OLE Process Control).

### serial

Used for standard serial protocols (e.g. RS232, RS485, etc.).

DataMiner will act as a master, and will continuously send commands to the elements. Elements will only respond after having received a valid command from DataMiner.

> [!NOTE]
> Serial protocols will combine all connections into one connection towards the device. When the device allows multiple clients to be connected, this can be disabled by changing the protocol type to "Serial single".

*Feature introduced in DataMiner 7.5.5.4.*

### serial single

Same as "Serial", but results in a dedicated connection to the device instead of a shared connection.

*Feature introduced in DataMiner 7.5.5 (RN 5353).*

### service

TBD

### sla

A special type of protocol that represents a Service Level Agreement.

### smart-serial

Used for more advanced serial protocols (e.g. RS232, RS485) using a dedicated serial port.

Elements can send messages to DataMiner, without DataMiner having to first send a command (unlike a protocol of type "Serial", where elements only send messages after having received a command from DataMiner). Typically, this type of protocol allows more advanced features to be implemented, such as automatic detection and alarm limit download to the device level.

> [!NOTE]
>
> - When a smart-serial protocol fails to send data, it will retry up to 5 times.
> - Smart-serial protocols will combine all connections into one connection towards the device. When the device allows multiple clients to be connected, this can be disabled by changing the protocol type to "Smart-serial single". Feature introduced in DataMiner 7.5.5.4.

### smart-serial single

Same as "smart-serial", but results in a dedicated connection to the device instead of a shared connection.

Feature introduced in DataMiner 7.5.5 (RN 5353).

### snmp

Used for protocols that comply with the SNMPv1 standard.

DataMiner will interrogate SNMP agents using the SNMPv1 protocol.

### snmpv2

Used for protocols that comply with the SNMPv2 standard.

DataMiner will interrogate SNMP agents using the SNMPv2 protocol.

### snmpv3

Used for protocols that comply with the SNMPv3 standard.

DataMiner will interrogate SNMP agents using the SNMPv3 protocol.

> [!NOTE]
> From DataMiner version 8.5.7.1 (RN 9964) onwards, it is possible to retrieve SNMPv3 traps on port 362. This avoids conflicts with traps of SNMPv2 on port 162. However, note that the firewall needs to be reconfigured in order to enable the reception of these traps.

### virtual

A dummy protocol that does not require any communication settings.

Used for connections to, for example, databases.
