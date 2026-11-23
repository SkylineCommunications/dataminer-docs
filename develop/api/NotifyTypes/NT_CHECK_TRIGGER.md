---
uid: NT_CHECK_TRIGGER
---

# NT_CHECK_TRIGGER (134)

Triggers the trigger with the specified ID.

> [!NOTE]
> Rather than calling `NotifyProtocol(134, ...)` directly, we recommend using [SLProtocol.CheckTrigger](xref:Skyline.DataMiner.Scripting.SLProtocol.CheckTrigger(System.Int32)).

```csharp
int triggerId = 20;

protocol.NotifyProtocol(134 /*NT_CHECK_TRIGGER*/, triggerId, null);
```

## Parameters

- triggerID (int): The ID of the trigger to be executed.

## Return Value

- The SLProtocol interface defines a wrapper method "CheckTrigger" for this call.
