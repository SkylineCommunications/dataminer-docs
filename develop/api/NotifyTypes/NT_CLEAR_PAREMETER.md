---
uid: NT_CLEAR_PARAMETER
---

# NT_CLEAR_PARAMETER (474)

Clears a parameter and its display value.
If the parameter is saved the change is also saved.

This notify cannot clear the contents of a column of a table.

```csharp
int parameterId = 20;

protocol.NotifyProtocol(474 /*NT_CLEAR_PARAMETER*/, parameterId, null);
```

## Parameters

- parameterId (int): The ID of the parameter to be cleared.

## Return Value

- A string if with an error message if the parameterId was invalid (e.g. a table column, or the parameter does not exist), otherwise null.

## Remarks

- The SLProtocol interface defines a wrapper method "ClearParameter" for this call.
