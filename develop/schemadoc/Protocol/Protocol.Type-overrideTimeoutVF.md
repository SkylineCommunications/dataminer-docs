---
uid: Protocol.Type-overrideTimeoutVF
---

# overrideTimeoutVF attribute

Available from DataMiner 10.5.3/10.6.0 onwards<!--RN 41388-->. Specifies whether the VF will go into timeout when the main element is in timeout.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Type](xref:Protocol.Type)

## Remarks

By default, the VFs will not go into timeout when the main element is in timeout. With this attribute, you can override this behavior.

You can specify one of two values:

- true: Override the default behavior in the main protocol
- false: (default)
