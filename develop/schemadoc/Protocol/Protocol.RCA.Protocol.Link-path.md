---
metadata_version: 1
uid: Protocol.RCA.Protocol.Link-path
description: "Learn how the RCA Link path attribute orders parameter IDs from the most probable root cause through the resulting RCA chain."
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
