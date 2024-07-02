---
uid: NT_RUN_ACTION
---

# NT_RUN_ACTION (221)

Runs an action.

```csharp
int actionID = 1;

protocol.NotifyProtocol(221/*NT_RUN_ACTION*/, actionID, null);
```

## Parameters

- actionID (int): ID of the action to run.

## Return Value

- Does not return an object.
