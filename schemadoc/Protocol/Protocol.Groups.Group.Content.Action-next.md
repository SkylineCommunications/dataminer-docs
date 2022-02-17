---
uid: Protocol.Groups.Group.Content.Action-next
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
