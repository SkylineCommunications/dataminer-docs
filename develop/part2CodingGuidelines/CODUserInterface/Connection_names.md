---
uid: Connection_names
---

# Connection names

- If there is only one connection for a specific type, the name needs to have the following format, where the second option can (optionally) be used to add more info about the goal of the connection (e.g. XXX = Traps, XXX = Events, XXX = Alarms, etc):

    - "IP Connection" or "IP Connection - XXX": <br>For drivers that support TCP and/or UDP (see [Protocol.Portsettings.PortTypeIP](xref:Protocol_Portsettings_PortTypeIP#protocolportsettingsporttypeip), [Protocol.Portsettings.PortTypeUDP](xref:Protocol_Portsettings_PortTypeUDP#protocolportsettingsporttypeudp) and [Protocol.Portsettings.PortTypeSerial](xref:Protocol_Portsettings_PortTypeSerial#protocolportsettingsporttypeserial)).

    - "HTTP Connection" or "HTTP Connection - XXX"

    - "SNMP Connection" or "SNMP Connection - XXX"

    - "Serial Connection" or "Serial Connection - XXX": <br>For drivers that only support the physical serial port, i.e. driver connections of type serial that do not support TCP or UDP (see [Protocol.Portsettings.PortTypeIP](xref:Protocol_Portsettings_PortTypeIP#protocolportsettingsporttypeip), [Protocol.Portsettings.PortTypeUDP](xref:Protocol_Portsettings_PortTypeUDP#protocolportsettingsporttypeudp) and [Protocol.Portsettings.PortTypeSerial](xref:Protocol_Portsettings_PortTypeSerial#protocolportsettingsporttypeserial)).

- If there is more than one connection for a specific type, the name needs have the following format, where XXX is used to distinguish between the connections (e.g. XXX = Redundant, XXX = Redundant 2, XXX = Backup, XXX = Traps, XXX = Events, etc):

    - "IP Connection - XXX"

    - "HTTP Connection - XXX"

    - Etc.
