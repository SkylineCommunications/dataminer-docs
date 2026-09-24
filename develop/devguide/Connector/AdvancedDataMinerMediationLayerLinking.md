---
metadata_version: 1
uid: AdvancedDataMinerMediationLayerLinking
description: "Link a device protocol to a base protocol by matching its Protocol.ElementType value to the baseFor value of the Production base protocol."
---

# Linking a device protocol to a base protocol

In the [Protocol.ElementType](xref:Protocol.ElementType) tag of the device protocol, specify the element type that is specified in the baseFor attribute of the base protocol.

For example:

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
<Name>Device Protocol X</Name>
<ElementType>IRD</ElementType>
```

When you upload the base protocol and set it to Production, elements executing this device-specific protocol support the standard view provided by the base protocol.
