---
uid: Protocol.Description
description: "Use the Description element in a DataMiner protocol to store general protocol information, such as device firmware requirements."
---

# Description element

Contains a description of the protocol.

## Type

string

## Parent

[Protocol](xref:Protocol)

## Remarks

In this tag, you can specify general information about the protocol. You could, for example, use this tag to specify that the protocol has been developed for elements running a specific firmware version.

In protocols of elements that are used in Automation, the contents of this tag must be unique.

## Examples

```xml
<Description>Controls a host using WMI</Description>
```
