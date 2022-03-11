---
uid: Protocol.Groups.Group.Content.Session-next
---

# next attribute

Specifies the number of milliseconds DataMiner has to wait after having received the response of the last executed session before executing the next session.

## Content Type

unsignedInt

## Parent

[Session](xref:Protocol.Groups.Group.Content.Session)

## Remarks

If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

## Examples

```xml
<Session next="1000">1</Session>
```
