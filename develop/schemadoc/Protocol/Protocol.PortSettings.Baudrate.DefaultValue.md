---
metadata_version: 1
uid: Protocol.PortSettings.Baudrate.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# DefaultValue element

Specifies the default baud rate.

## Type

unsignedInt

## Parent

[Baudrate](xref:Protocol.PortSettings.Baudrate)

## Remarks

Each time a user adds an element using the element wizard, the baud rate will by default be set to this value.



## Examples


```xml
<DefaultValue>19200</DefaultValue>
```



