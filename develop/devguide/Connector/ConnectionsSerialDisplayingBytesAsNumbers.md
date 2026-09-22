---
metadata_version: 1
uid: ConnectionsSerialDisplayingBytesAsNumbers
description: "Describe the DataMiner connector development topic Displaying bytes as numbers, including its purpose, behavior, implementation guidance, and relevant con."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Displaying bytes as numbers

It can happen that you receive a number of bytes that represent a number. In case you want to display the decimal representation of those bytes, you need to take into account that decimal numbers are stored in memory in reverse order (little endian). So in order to display the correct number, you need to use Endian big in the Interprete tag of the parameter so that the bytes are reversed again.

In case the number you want to display originates from a group parameter used for read bits, it is advised to copy the contents to another parameter and use that one for displaying, so that there is no influence on the read bits.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Interprete.Endian](xref:Protocol.Params.Param.Interprete.Endian)
