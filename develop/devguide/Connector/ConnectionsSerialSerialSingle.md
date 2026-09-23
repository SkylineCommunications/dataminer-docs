---
metadata_version: 1
uid: ConnectionsSerialSerialSingle
description: "Use the serial single connector type when each element connecting to the same device address needs its own dedicated SLPort socket."
---

# Serial single

When creating a serial connection towards a device, DataMiner combines all the connections (when there are multiple connections for the same device). This might not be desired behavior since a device sometimes allows multiple clients to be connected on the device. In this case, this behavior can be disabled by setting the protocol type to “serial single”.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Type](xref:Protocol.Type)
