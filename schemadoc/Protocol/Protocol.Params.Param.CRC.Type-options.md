---
uid: Protocol.Params.Param.CRC.Type-options
---

# options attribute

Specifies additional options, separated by semicolons (”;”).

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

The following options are available:

### ONES COMPLEMENT

Each bit of the calculated CRC will be inverted.

Example: AAAA will become 5555

### OR TOTALOFFSET

The totaloffset value will not be added but “OR”-ed.
