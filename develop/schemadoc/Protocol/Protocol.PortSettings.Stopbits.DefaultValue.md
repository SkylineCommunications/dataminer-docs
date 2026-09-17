---
metadata_version: 1
uid: Protocol.PortSettings.Stopbits.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
