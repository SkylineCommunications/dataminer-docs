---
uid: Protocol.Version
---

# Version element

Specifies the protocol version.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Protocol](xref:Protocol)

## Remarks

Within a DataMiner System, you can maintain different versions of the same protocol and assign them to different elements. If you have to make modifications to a protocol, do not create a completely new protocol. Instead, make a new version of that same protocol.

The content of the Version element can be a structured string specifying the branch, firmware, major and minor version (e.g. "1.0.0.3") or a string (e.g. "high power").

For more information about the version semantics, refer to [Protocol version semantics](xref:ProtocolVersionSemantics).

> [!NOTE]
> When you have two types of elements that are very similar (e.g. an optical transmitter: one with a high output power and another with a low output power), you can use the same protocol and create two versions (e.g. version "high power" and version "low power" for the protocol "optical transmitter". The only difference between the two versions would then be e.g. the range settings for the "Output Power" parameter).
