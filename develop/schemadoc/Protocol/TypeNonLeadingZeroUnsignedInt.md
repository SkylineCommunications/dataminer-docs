---
metadata_version: 1
uid: Protocol-TypeNonLeadingZeroUnsignedInt
description: "Use the TypeNonLeadingZeroUnsignedInt simple type to validate unsigned integers without leading zeros in the DataMiner connector protocol schema."
---

# TypeNonLeadingZeroUnsignedInt simple type

Specifies an unsigned integer value that has no leading zeros.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***unsignedInt restriction***|||
|&nbsp;&nbsp;Pattern|`[123456789]\d*|0`||
