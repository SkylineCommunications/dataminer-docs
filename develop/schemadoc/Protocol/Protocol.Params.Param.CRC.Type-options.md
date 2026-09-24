---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-options
description: "Learn how to use the options attribute to invert CRC bits or apply total offset with a bitwise OR operation in a DataMiner connector protocol."
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
