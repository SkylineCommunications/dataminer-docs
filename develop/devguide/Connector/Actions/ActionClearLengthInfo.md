---
uid: LogicActionClearLengthInfo
---

# clear length info

This action can be executed on responses only.

This action can be used when the header or the trailer need to be adjusted. If a length parameter gets new info, for example, then this action must be executed on the response.

## Attributes

### On@id

Specifies the ID(s) of the responses(s) of which the length info must be cleared.

## Examples

```xml
<Action id="1">
   <On id="501">response</On>
   <Type>clear length info</Type>
</Action>
```
