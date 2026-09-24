---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.TrapMappings.TrapMapping-bindingMatch
description: "Learn how the bindingMatch attribute matches an SNMP trap binding number and value list, with wildcard support in a DataMiner connector protocol."
---

# bindingMatch attribute

Specifies one or more values for a specific binding.

## Content Type

string

## Parent

[TrapMapping](xref:Protocol.Params.Param.SNMP.TrapMappings.TrapMapping)

## Remarks

This attribute consists of two parts, separated by a colon:

- the number of the binding, and
- a pipe-separated enumeration of values you want to compare to the value of the binding.

Wildcards are allowed.

## Examples

```xml
<TrapMapping bindingMatch="1:1" />
<TrapMapping bindingMatch="*" />
```
