---
uid: NT_SET_THREAD_POOL_STATE
---

# NT_SET_THREAD_POOL_STATE (328)

Resets the thread pool of the specified multithreaded timer.

```csharp
bool isEnabled = true;
int timerId = 1;

protocol.NotifyDataMiner(328 /*NT_SET_THREAD_POOL_STATE*/, timerId, isEnabled);
```

## Parameters

- timerId (int): The timer ID.
- Thread pool state (bool): true to enable the thread pool; otherwise, false.

## Return Value

- Does not return an object.
