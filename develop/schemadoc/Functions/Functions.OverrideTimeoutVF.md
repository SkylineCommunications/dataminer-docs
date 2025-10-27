---
uid: Functions.OverrideTimeoutVF
---

# OverrideTimeoutVF element

When set to "true", this tag allows the timeout override for a virtual function. Available from DataMiner 10.5.3/10.6.0 onwards.<!-- RN 41388 -->

## Type

[EnumTrueFalseLowerCase](xref:Functions-EnumTrueFalseLowerCase)

## Parent

[Functions](xref:Functions)

## Remarks

> [!NOTE]
> Prior to DataMiner 10.5.3/10.6.0, when the [`overrideTimeoutDVE` option](xref:Protocol.Type-overrideTimeoutDVE) is enabled in a *protocol.xml* file, the timeout will apply to DVE elements as well as virtual functions. From DataMiner 10.5.3/10.6.0 onwards<!--RN 41388-->, this option will only apply to DVE elements, and the *OverrideTimeoutVF* tag in a *Functions.xml* file can be used to override the timeout for virtual functions.
