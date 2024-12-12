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

## See also

- [SetParameter (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.FillArrayWithColumn(System.Int32,System.Int32,System.Object[],System.Object[],System.Nullable{System.DateTime})) method
