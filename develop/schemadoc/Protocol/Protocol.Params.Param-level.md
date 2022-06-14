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

The lower the number of a user's security level, the more levels they can access. For example, a user with security level 3 can see level 3, 4, 5, etc. A user with security level 0 (i.e. the Administrator account) can see all levels.

See also: [User rights](xref:User_rights).

## Examples

```xml
<Param id="1" level="4">
```
