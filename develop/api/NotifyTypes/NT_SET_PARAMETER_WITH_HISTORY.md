---
uid: NT_SET_PARAMETER_WITH_HISTORY
---

# NT_SET_PARAMETER_WITH_HISTORY (256)

Sets a parameter with the provided timestamp.

> [!NOTE]
> To set parameters with a history timestamp on the local element, we recommend using `SetParameters(IDictionary<int, object>, DateTime?)`, `SetCell(int, string, int, object, DateTime?)`, or `SetColumns(...)` from the [Skyline.DataMiner.Utils.Protocol.Extension](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) NuGet package (`using Skyline.DataMiner.Utils.Protocol.Extension;`), or [SLProtocol.SetParameter](xref:Skyline.DataMiner.Scripting.SLProtocol.SetParameter(System.Int32,System.Object,Skyline.DataMiner.Scripting.ValueWrapper{System.DateTime})) / [SLProtocol.SetParameters](xref:Skyline.DataMiner.Scripting.SLProtocol.SetParameters(System.Int32[],System.Object[],System.DateTime[])).

```csharp
uint dmaID = 346;
uint elementID = 806;
uint parameterID = 10;

uint[] ids = new uint[] { dmaID, elementID, parameterID };

int value = 10;
DateTime time = DateTime.Now - TimeSpan.FromDays(1);

object[] valueDetails = new object[] { value, time };

protocol.NotifyDataMiner(256 /*NT_SET_PARAMETER_WITH_HISTORY*/, ids, valueDetails);
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
