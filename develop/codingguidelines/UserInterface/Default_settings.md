---
uid: Default_settings
---

# Default settings

The port settings must contain as many default settings as possible and must be as strict as possible. This also includes disabling options that are not applicable (e.g., disabling irrelevant options: in case of an HTTP connector, users should not be able to select type of port as "Serial").

In connectors of type HTTP, the default bus address "bypassProxy" must be used.

Recommended port support per type:

| Type                | TCP | UDP | Serial |
|---------------------|-----|-----|--------|
| SNMP                |     | X   |        |
| SNMPv1              |     | X   |        |
| SNMPv2              |     | X   |        |
| Serial              | X   | X   | X      |
| Serial single       | X   | X   | X      |
| Smart-Serial        | X   | X   |        |
| Smart-Serial single | X   | X   |        |
| HTTP                | X   |     |        |
| GPIB                | X   |     |        |
| Virtual             |     |     |        |
| OPC                 | X   |     |        |
| SLA                 |     |     |        |

Make sure to disable any of the ports that are not possible for a specific type of protocol.

HTTP example:

```xml
<PortSettings>
   <BusAddress>
      <DefaultValue>ByPassProxy</DefaultValue>
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

Some ports will already be disabled in the client. The ones that we still need to check and add are the following:

- **Serial**: When using SSH, "Serial" and "UDP" need to be disabled in the protocol.
- **Smart-serial**: "Serial" needs to be disabled in the protocol.
- **Smart-serial single**: "Serial" needs to be disabled in the protocol.
- **HTTP**: "Serial" and "UDP" need to be disabled in the protocol.
