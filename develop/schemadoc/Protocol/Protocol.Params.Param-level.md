---
uid: Protocol.Params.Param-level
---

# level attribute

Specifies the security level of this parameter.

## Content Type

unsignedInt

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Default range: 0 (highest level, all rights) to 100 (lowest level).

If you do not specify the *level* attribute, the parameter will have level 0xFFFFFFFF, which is the default security level.

All users with a security level equal to or higher than the one specified in this attribute will be able to see the parameter. For example, a user with security level 3 can see level 3, 4, 5, etc.

## Examples

```xml
<Param id="1" level="4">
```
