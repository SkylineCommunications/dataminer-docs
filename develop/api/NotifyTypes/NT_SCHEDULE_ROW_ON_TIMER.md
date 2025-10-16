---
uid: NT_SCHEDULE_ROW_ON_TIMER
---

# NT_SCHEDULE_ROW_ON_TIMER (229)

Allows the triggering of a specific row to be run by the multithreaded timer outside its normal behavior.

```csharp
string rowKey = "Row 1";
int timerID = 1;

protocol.NotifyProtocol(229 /* NT_SCHEDULE_ROW_ON_TIMER */, rowKey, timerID);
```

## Parameters

- rowKey (string): Primary key of the row.
- timerID (int): ID of the timer that needs to trigger.

## Return Value

- Does not return an object.

## Remarks

- This can only be used in case a table is being processed by a multithreaded timer.
