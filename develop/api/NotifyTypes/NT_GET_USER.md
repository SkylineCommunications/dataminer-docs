---
uid: NT_GET_USER
---

# NT_GET_USER (109)

Retrieves the user.

```csharp
var userCookie = protocol.UserCookie;
var user = (string) protocol.NotifyDataMiner(108 /* NT_GET_USER */, userCookie, null);

if (!String.IsNullOrEmpty(user))
{
   //// ...

}
```

## Parameters

- userCookie (string): The user cookie.

## Return Value

- (string) The corresponding user. In case no corresponding user is found, an empty string is returned.

## Remarks

- This call can be used to obtain the user that triggered a QAction.
