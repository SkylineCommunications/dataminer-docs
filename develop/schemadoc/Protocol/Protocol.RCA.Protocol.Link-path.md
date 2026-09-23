---
metadata_version: 1
uid: Protocol.RCA.Protocol.Link-path
description: "Reference the DataMiner connector protocol schema entry for path attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# path attribute

Specifies a semicolon-separated list of parameter IDs that defines the flow of the RCA chain.

## Content Type

string

## Parent

[Link](xref:Protocol.RCA.Protocol.Link)

## Remarks

The leftmost ID refers to the most probable root cause.

## Examples

In the following example, an alarm on parameter 40011 will have RCA level 1 if parameter 21008 is also in alarm:

```xml
<Link path="21008;40011"/>
```
