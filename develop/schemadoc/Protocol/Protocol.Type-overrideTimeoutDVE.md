---
uid: Protocol.Type-overrideTimeoutDVE
---

# overrideTimeoutDVE attribute

Specifies whether the DVE will go into timeout when the main element is in timeout.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Type](xref:Protocol.Type)

## Remarks

By default the DVEs will not go into timeout when the main element is in timeout. With this attribute, you can override this behavior.

You can specify one of two values:

- true: Override the default behavior in the main protocol
- false: (default)

> [!NOTE]
> Prior to DataMiner 10.5.3/10.6.0, if the `overrideTimeoutDVE` attribute is set to *true*, the timeout applies to VFs as well. From DataMiner 10.5.3/10.6.0 onwards<!--RN 41388-->, you can use the [`overrideTimeoutVF` attribute](xref:Protocol.Type-overrideTimeoutVF) instead.
