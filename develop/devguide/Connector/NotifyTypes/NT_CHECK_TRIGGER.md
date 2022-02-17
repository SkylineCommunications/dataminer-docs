---
uid: NT_CHECK_TRIGGER
---

# NT_CHECK_TRIGGER (134)

Triggers the trigger with the specified ID.

```csharp
int triggerId = 20;

protocol.NotifyProtocol(134 /*NT_CHECK_TRIGGER*/, triggerId, null);
```

## Parameters

- triggerID (int): The ID of the trigger to be executed.

## Return Value

- The SLProtocol interface defines a wrapper method "CheckTrigger" for this call.
