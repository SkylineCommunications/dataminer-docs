---
metadata_version: 1
uid: Protocol.PortSettings.Databits.DefaultValue
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

Specifies the default number of data bits.

## Type

string

## Parent

[Databits](xref:Protocol.PortSettings.Databits)

## Remarks

Each time a user adds an element using the element wizard, the data bits setting will by default be set to this value.

> [!NOTE]
> For an SNMPv3 connection, this tag can be used to specify default the user name.
