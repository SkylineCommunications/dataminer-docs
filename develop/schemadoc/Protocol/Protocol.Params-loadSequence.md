---
metadata_version: 1
uid: Protocol.Params-loadSequence
description: "Reference the DataMiner connector protocol schema entry for loadSequence attribute, including its documented structure, attributes, values, and constraint."
---

# loadSequence attribute

Changes the order in which saved parameter data is retrieved when the element starts up.

## Content Type

string

## Parent

[Params](xref:Protocol.Params)

## Examples

In the following example, the values of table 15000 will be retrieved before all other saved parameters:

```xml
<Params loadSequence="15000">
```
