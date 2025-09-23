---
uid: NT_RESET_THREAD_POOL
---

# NT_RESET_THREAD_POOL (327)

Resets the thread pool of the specified multithreaded timer.

```csharp
int timerId = 1;

protocol.NotifyDataMiner(327 /*NT_RESET_THREAD_POOL*/, timerId, null);
```

## Parameters

- timerId (int): The timer ID.

## Return Value

- Does not return an object.
