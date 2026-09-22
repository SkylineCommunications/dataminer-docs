---
metadata_version: 1
uid: Protocol.Ports.PortSettings
description: "Reference the DataMiner connector protocol schema entry for PortSettings element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# PortSettings element

Specifies the port settings for any additional protocol type specified in [Protocol.Type](xref:Protocol.Type).

## Parent

[Ports](xref:Protocol.Ports)

## Remarks

For an overview of the possible port settings, see Protocol.[PortSettings](xref:Protocol.PortSettings).

> [!NOTE]
> For each port that is defined, a [PortSettings](xref:Protocol.PortSettings) element should be defined. In addition, the order of these PortSettings elements must correspond with the order of the connections defined in the [Protocol.Type@advanced](xref:Protocol.Type-advanced) attribute.
