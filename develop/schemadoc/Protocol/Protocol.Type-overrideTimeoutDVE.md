---
uid: Protocol.Type-overrideTimeoutDVE
---

# overrideTimeoutDVE attribute

Specifies whether the DVE will go into timeout when the main element is in timeout.

> [!NOTE]
> Prior to DataMiner 10.5.3/10.6.0, when the `overrideTimeoutDVE` attribute is set to *true*, the timeout will apply to DVE elements as well as virtual functions (VFs). From DataMiner 10.5.3/10.6.0 onwards<!--RN 41388-->, this option will only apply to DVE elements, and the [`overrideTimeoutVF` tag](xref:Functions_XML_files#functions-xml-structure) in a *Functions.xml* file can be used to override the timeout for VFs.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Type](xref:Protocol.Type)

## Remarks

By default the DVEs will not go into timeout when the main element is in timeout. With this attribute, you can override this behavior.

You can specify one of two values:

- true: Override the default behavior in the main protocol
- false: (default)
