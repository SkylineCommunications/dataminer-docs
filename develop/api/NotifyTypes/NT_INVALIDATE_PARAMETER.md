---
uid: NT_INVALIDATE_PARAMETER
---

# NT_INVALIDATE_PARAMETER (307)

Set the validity state of the specified parameter(s).

```csharp
bool isValid = false;
uint[] parameterIDs = new uint[] { 10, 11 };

protocol.NotifyProtocol(307/*NT_INVALIDATE_PARAMETER*/ , parameterIDs, isValid);
```

## Parameters

- parameterIDs (uint[]): IDs of parameter(s).
- isValid (bool): Validity state. False = invalid, True = valid.

## Return Value

- Does not return an object.
