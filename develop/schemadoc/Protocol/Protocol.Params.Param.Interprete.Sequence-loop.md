---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Sequence-loop
description: "Reference the DataMiner connector protocol schema entry for loop attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# loop attribute

Specifies the loop value for the sequence (integer).

## Content Type

unsignedInt

## Parent

[Sequence](xref:Protocol.Params.Param.Interprete.Sequence)

## Remarks

The loop value for the sequence (integer).

The value in the parameter will be automatically recalculated taking into account the loop (overflow) sequence.

Bytes sent rate calculation

- Time 0 : total bytes sent = 1000
- Time 1 : total bytes sent = 20

When you specify `<Sequence loop="1010"></Sequence>`, the “total bytes sent” parameter will hold 30 at time 1 instead of 20, taking into account the extra 10 bytes in the overflow.
