---
metadata_version: 1
uid: Protocol.Groups.Group.Content.Pair-next
description: "Learn how the next attribute sets the delay after a pair response before the next group item executes in a DataMiner connector protocol."
---

# next attribute

Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed pair before executing the next pair.

## Content Type

unsignedInt

## Parent

[Pair](xref:Protocol.Groups.Group.Content.Pair)

## Remarks

If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

Example:


```xml
<Pair next="5000">25</Pair>
```



