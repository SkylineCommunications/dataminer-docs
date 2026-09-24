---
metadata_version: 1
uid: Protocol.Groups.Group.Content.Action-next
description: "Learn how the next attribute sets the delay after an action response before the next group item executes in a DataMiner connector protocol."
---

# next attribute

Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed action before executing the next action.

## Content Type

unsignedInt

## Parent

[Action](xref:Protocol.Groups.Group.Content.Action)

## Remarks

If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

## Example

```xml
<Action next="5000">25</Action>
```
