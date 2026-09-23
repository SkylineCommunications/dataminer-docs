---
metadata_version: 1
uid: Protocol.PortSettings.FlushPerDatagram
description: "Learn how FlushPerDatagram immediately forwards each received UDP datagram to SLProtocol for smart-serial connections."
---

# FlushPerDatagram element

<!-- RN 28999 -->

When this option is set to true, any datagram received on the connection will be forwarded to SLProtocol immediately.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Remarks

Only applicable for smart-serial connections of type UDP.

> [!NOTE]
> When this option is used on a connection, you should use a response consisting of only a next param for that connection.

## Examples

```xml
<PortSettings>
   <FlushPerDatagram>true</FlushPerDatagram>
</PortSettings>
```
