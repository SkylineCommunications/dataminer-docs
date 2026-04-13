---
uid: Connection_names
---

# Connection names

- If there is only one connection for a specific type, the name needs to have the following format, where the second option can (optionally) be used to add more info about the goal of the connection (e.g., XXX = Traps, XXX = Events, XXX = Alarms, etc):

  - "IP Connection" or "IP Connection - XXX":

    For connectors that support TCP and/or UDP (see [Protocol.PortSettings.PortTypeIP](xref:Protocol.PortSettings.PortTypeIP), [Protocol.PortSettings.PortTypeUDP](xref:Protocol.PortSettings.PortTypeUDP) and [Protocol.PortSettings.PortTypeSerial](xref:Protocol.PortSettings.PortTypeSerial)).

  - "HTTP Connection" or "HTTP Connection - XXX"

  - "SNMP Connection" or "SNMP Connection - XXX"

  - "Serial Connection" or "Serial Connection - XXX":

    For connectors that only support the physical serial port, i.e., connections of type serial that do not support TCP or UDP (see [Protocol.PortSettings.PortTypeIP](xref:Protocol.PortSettings.PortTypeIP), [Protocol.PortSettings.PortTypeUDP](xref:Protocol.PortSettings.PortTypeUDP) and [Protocol.PortSettings.PortTypeSerial](xref:Protocol.PortSettings.PortTypeSerial)).

- If there is more than one connection for a specific type, the name needs have the following format, where XXX is used to distinguish between the connections (e.g., XXX = Redundant, XXX = Redundant 2, XXX = Backup, XXX = Traps, XXX = Events, etc):

  - "IP Connection - XXX"

  - "HTTP Connection - XXX"

  - Etc.
