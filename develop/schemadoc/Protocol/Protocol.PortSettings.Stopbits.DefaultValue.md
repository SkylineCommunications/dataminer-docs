---
metadata_version: 1
uid: Protocol.PortSettings.Stopbits.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# DefaultValue element

Specifies the default number of stop bits.

## Type

string

## Parent

[Stopbits](xref:Protocol.PortSettings.Stopbits)

## Remarks

Each time a user adds an element using the element wizard, the stopbits setting will by default be set to this value.

> [!NOTE]
> For an SNMPv3 connection, this tag can be used to specify the default security level and protocol (e.g., "authPriv").
