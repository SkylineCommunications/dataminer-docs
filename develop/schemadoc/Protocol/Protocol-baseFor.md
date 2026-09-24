---
metadata_version: 1
uid: Protocol-baseFor
description: "Use the Protocol baseFor attribute to mark a connector as a base protocol for an element type that another protocol can reference."
---

# baseFor attribute

Specifies the type of element for which this protocol serves as a base protocol.

## Content Type

string

## Parent

[Protocol](xref:Protocol)

## Remarks

In case a value is defined in this attribute, the protocol is considered a base protocol.

> [!NOTE]
> Another protocol can indicate that it is based on this base protocol by specifying this value in [ElementType](xref:Protocol.ElementType).

## Examples

```xml
<Protocol baseFor="Information Platform" xmlns="http://www.skyline.be/protocol">
```
