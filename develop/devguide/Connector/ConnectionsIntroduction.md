---
uid: ConnectionsIntroduction
---

# Introduction

A protocol typically defines one or more connections through which the element running the protocol communicates with the device (or multiple devices). DataMiner supports different types of connections, such as SNMP, serial, HTTP, etc. A protocol can define multiple connections of different types (e.g. an HTTP connection and two SNMP connections).

With the Type tag, the protocol connections can be defined. In case multiple connections are used, the additional connections need to be defined in the advanced attribute of the Type tag, indicating the type and name of each additional connection.

```xml
<Type advanced="snmp:ConnectionName">serial</Type>
```

It can sometimes be necessary to specify which connection a particular functionality relates to in a protocol. This is done using an integer value denoting the connection ID. The main connection always has ID 0, and every additional connection defined in the protocol corresponds to an incremented ID (For the example above, this means the serial connection has ID 0 and the SNMP connection has ID 1).

By default, groups and actions that involve a connection always use the main connection (connection ID 0). In case another connection should be used, this must be specified in the protocol.

```xml
<Groups>
  <Group id="" connection="0" />
  <Group id="" connection="1" />
</Groups>
<Actions>
  <Action id="" options="connection:0"/>
  <Action id="" options="connection:1"/>
</Actions>
```

By default, you only need to specify a connection on group level by using the connection attribute in the Group tag. In case you need to perform an SNMP Set command, specify the connection to be used in the action.

## Element Wizard

A connection has a number of configurable port settings. It is possible to define default settings for connections. It is also possible to restrict the capabilities of a device port, and to define the format and range of the bus address, if any.

> [!NOTE]
> It is advised to always specify as many port settings as possible, because it greatly enhances the user-friendliness of the protocol during element creation.

The PortSettings tag allows the configuration of the main connection. Using the Ports tag, the port settings of each additional connection can be configured using the name of the connection.

```xml
<PortSettings>
   <!- Port settings for main protocol type (serial). -->
  ...
</PortSettings>
<Ports>
   <PortSettings name="ConnectionName">
  <!- Port settings for additional protocol type (SNMP). -->
  ...
  </PortSettings>
</Ports>
```

For example, when an element is created or edited in DataMiner, the bus address field allows the user to provide input for the configuration of the element. In most cases, this bus address will be a slot number of a chassis. In case no bus parameter is used in the protocol, it should be disabled.

> [!NOTE]
> The order in which the port settings are defined in the parent Ports tag determines which connections these port settings apply to. The "name" attribute of the PortSettings tag has no influence on this.

```xml
<PortSettings>
  <BusAddress>
     <Disabled>true</Disabled>
  </BusAddress>
</PortSettings>
```

The following table provides an overview of the port types DataMiner supports for the different connection types:

|Connection type|TCP/IP|UDP/IP|Serial|
|--- |--- |--- |--- |
|virtual||||
|snmp||&#10004;||
|snmpv2||&#10004;||
|snmpv3||&#10004;||
|serial|&#10004;|&#10004;|&#10004;|
|serial single|&#10004;|&#10004;|&#10004;|
|smart-serial|&#10004;|&#10004;||
|smart-serial single|&#10004;|&#10004;||
|http|&#10004;|||
|gpib|&#10004;|||
|opc|&#10004;|||
|sla||||

Port types that are not supported can be hidden from the "Type of port" box in the element editor using the *Disabled* child tag of the *PortTypeIP*, *PortTypeUDP*, and *PortTypeSerial* tag for TCP, UDP, and serial, respectively.

For example, for an HTTP connection, UDP and Serial should be disabled:

```xml
<PortSettings name="HTTP Connection">
   <BusAddress>
      <DefaultValue>bypassProxy</DefaultValue>
      <Disabled>false</Disabled>
   </BusAddress>
   <IPport>
      <DefaultValue>80</DefaultValue>
   </IPport>
   <PortTypeUDP>
      <Disabled>true</Disabled>
   </PortTypeUDP>
   <PortTypeSerial>
      <Disabled>true</Disabled>
   </PortTypeSerial>
</PortSettings>
```

For several connection types, some port types are already disabled by the client. The following connection types, however, require configuration in the protocol to disable a port type:

- Serial – when using SSH: "Serial" and "UDP/IP" need to be disabled in the protocol
- Smart-serial: "Serial" needs to be disabled in the protocol
- Smart-serial single:  "Serial" needs to be disabled in the protocol
- HTTP: "Serial" and "UDP/IP" need to be disabled in the protocol

## See also

- [bypassProxy](xref:ConnectionsHttpElementConfiguration)

DataMiner Protocol Markup Language:

- [Protocol.Groups.Group@connection](xref:Protocol.Groups.Group-connection)
- [Protocol.Actions.Action](xref:Protocol.Actions.Action)
- [Protocol.PortSettings](xref:Protocol.PortSettings)
- [Protocol.Ports.PortSettings](xref:Protocol.Ports.PortSettings)
