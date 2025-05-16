---
uid: NT_CLEAR_PARAMETER
---

# NT_CLEAR_PARAMETER (474)

<!-- RN 42368 -->

Clears a parameter and its display value. If the parameter is saved, the change is also saved.

This notify can be used on a standalone parameter or a table parameter, but it cannot clear the contents of a column of a table.

```csharp
int parameterId = 20;

protocol.NotifyProtocol(474 /*NT_CLEAR_PARAMETER*/, parameterId, null);
```

## Parameters

- parameterId (int): The ID of the parameter to be cleared (table or standalone parameter).

## Return Value

- A string with an error message if *parameterId* was an invalid parameter ID (e.g. a table column, or the parameter does not exist), otherwise null.

## Remarks

- The SLProtocol interface defines a wrapper method "ClearParameter" for this call.
- Feature introduced in DataMiner 10.5.6 (RN 42368).
