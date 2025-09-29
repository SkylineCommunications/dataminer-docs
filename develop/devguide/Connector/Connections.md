---
uid: Connections
---

# Connections

A protocol typically defines one or more connections through which the element running the protocol communicates with the device (or multiple devices). DataMiner supports different types of connections, such as SNMP, serial, HTTP, etc. A protocol can define multiple connections of different types (e.g. an HTTP connection and two SNMP connections).

With the [Type](xref:Protocol.Type) tag, the protocol connections can be defined. The main connection is specified as the value of the `Type` tag, e.g. `<Type relativeTimers="true">snmp</Type>`. In case multiple connections are used, the additional connections need to be defined in the [advanced](xref:Protocol.Type-advanced) attribute of the Type tag, indicating the type and name of each additional connection:

```xml
<Type relativeTimers="true" options="unicode" communicationOptions="smartIPHeader" advanced="smart-serial:IP Connection - POST Messages;http:HTTP Connection - Master">http</Type>
```

In the connector logic, it is sometimes necessary to specify to which connection particular functionality relates. This is done using an integer value denoting the connection ID. The main connection has ID 0, and every additional connection defined in the protocol corresponds to an incremented ID. (For the example above, this means that the main HTTP connection has ID 0, the smart-serial connection has ID 1, and the second HTTP connection has ID 2.)

By default, groups and actions that involve a connection always use the main connection (connection ID 0). In case another connection should be used, this must be specified in the protocol.

You can specify a connection on group level by using the [connection](xref:Protocol.Groups.Group-connection) attribute in the Group tag.

```xml
<Groups>
  <Group id="1" connection="2">
    <Name>getXmlFile</Name>
    <Description>Get XML File</Description>
    <Content>
      <Session>1</Session>
    </Content>
  </Group>
</Groups>
```

For some actions, you can for example use the [Type@nr](xref:Protocol.Actions.Action.Type-nr) attribute to specify the connection.

```xml
<Actions>
  <Action id="402">
    <On id="402" nr="1">parameter</On>
    <Type>set</Type>
  </Action>
</Actions>
```

> [!NOTE]
> An example protocol "SLC SDF Multiple Connections" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## Configuring port settings

A connection has a number of configurable port settings. It is possible to define default settings for connections. It is also possible to restrict the capabilities of a device port, and to define the format and range of the bus address, if any.

> [!NOTE]
> We recommend specifying as many port settings as possible, because it greatly enhances the user-friendliness of the protocol during element creation.

The [PortSettings](xref:Protocol.PortSettings) tag allows the configuration of the main connection. Using the [Ports/PortSettings](xref:Protocol.Ports.PortSettings) tag, the port settings of each additional connection can be configured.

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
> The order in which the port settings are defined in the parent Ports tag determines which connections these port settings apply to. The [name](xref:Protocol.PortSettings-name) attribute of the PortSettings tag has no influence on this.

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

- Serial, when using SSH: "Serial" and "UDP/IP" need to be disabled in the protocol
- Smart-serial: "Serial" needs to be disabled in the protocol
- Smart-serial single: "Serial" needs to be disabled in the protocol
- HTTP: "Serial" and "UDP/IP" need to be disabled in the protocol

## See also

Coding guidelines:

- [Default settings](xref:Default_settings)
- [Communication](xref:Communication1)
- [Points of Attention](xref:Skyline_Driver_Passport_Platform)

DataMiner Protocol Markup Language:

- [Protocol.Groups.Group@connection](xref:Protocol.Groups.Group-connection)
- [Protocol.Actions.Action](xref:Protocol.Actions.Action)
- [Protocol.PortSettings](xref:Protocol.PortSettings)
- [Protocol.Ports.PortSettings](xref:Protocol.Ports.PortSettings)

Other:

- [Connection names](xref:Connection_names)
- [bypassProxy](xref:ConnectionsHttpElementConfiguration)
