---
uid: Protocol.Ports.PortSettings
description: "Use the PortSettings element in a DataMiner protocol to specify communication and port settings for an additional connection."
---

# PortSettings element

Specifies the port settings for any additional protocol type specified in [Protocol.Type](xref:Protocol.Type).

## Parent

[Ports](xref:Protocol.Ports)

## Remarks

For an overview of the possible port settings, see Protocol.[PortSettings](xref:Protocol.PortSettings).

> [!NOTE]
> For each port that is defined, a [PortSettings](xref:Protocol.PortSettings) element should be defined. In addition, the order of these PortSettings elements must correspond with the order of the connections defined in the [Protocol.Type@advanced](xref:Protocol.Type-advanced) attribute.
