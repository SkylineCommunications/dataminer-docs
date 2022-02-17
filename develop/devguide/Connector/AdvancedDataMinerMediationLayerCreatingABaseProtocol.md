---
uid: AdvancedDataMinerMediationLayerCreatingABaseProtocol
---

# Creating a base protocol

A base protocol is a virtual protocol defining parameters (in the range 70000-79999) that are mapped on device-specific protocols.

To create a base protocol, provide an element type name (e.g. "IRD" or "Switch") in the baseFor attribute of the root Protocol tag.

```xml
<Protocol baseFor="IRD" xmlns="http://www.skyline.be/protocol">
<Name>Standard IRD</Name>
```

> [!NOTE]
>
> - All protocols of which the baseFor attribute contains text are considered base protocols.
> - Only Production versions of base protocols are used. If no production version is assigned, the base protocol will be ignored.
