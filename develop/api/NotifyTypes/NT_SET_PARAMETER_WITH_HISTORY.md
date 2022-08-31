---
uid: NT_SET_PARAMETER_WITH_HISTORY
---

# NT_SET_PARAMETER_WITH_HISTORY (256)

Sets a parameter with the provided timestamp.

```csharp
uint dmaID = 346;
uint elementID = 806;
uint parameterID = 10;

uint[] ids = new uint[] { dmaID, elementID, parameterID };

int value = 10;
DateTime time = DateTime.Now - TimeSpan.FromDays(1);

object[] valueDetails = new object[] { value, time };

protocol.NotifyDataMiner(256/*NT_SET_PARAMETER_WITH_HISTORY*/ , ids, valueDetails);
```

## Parameters

- ids (uint[]):
  - ids[0]: DataMiner Agent ID.
  - ids[1]: Element ID.
  - ids[2]: Parameter ID.
- value (object): Value to set.

## Return Value

- Does not return an object.

## Remarks

- If the DateTime.Kind property of the timestamp is unspecified, the timestamp will be handled as local time.

## See also

- SLProtocol.SetParameter method
