---
metadata_version: 1
uid: Protocol.Groups.Group-connection
description: "Learn how the connection attribute selects the connection used by a group when a protocol defines multiple connections in a DataMiner connector protocol."
---

# connection attribute

Specifies the connection to be used (used in case multiple connections are defined).

## Content Type

unsignedInt

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

In case of multiple connections, you can use this attribute to specify the connection to be used.

Default port: 0

> [!NOTE]
> In case extra [threads](xref:Protocol.Threads.Thread) are defined in the protocol, make sure every poll group has this connection attribute defined to indicate which thread to use. 

Example:

```xml
<Group id="25" connection="1">
```

From DataMiner 8.1.0 onwards (RN 7718), a group using a connection number and connection type other than that of the main connection can be used within a multithreaded timer. Example:

```xml
<Type relativeTimers="true" advanced="snmpv2:MTA SNMP Connection">serial</Type>
```
