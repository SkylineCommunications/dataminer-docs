---
uid: NT_GET_PARAMETER
---

# NT_GET_PARAMETER (73)

Gets a parameter value.

## Parameters

To retrieve a **local parameter**:

```csharp
int parameterId = 10;
object result = protocol.NotifyProtocol(73/*NT_GET_PARAMETER*/, parameterId, null);

if (result != null)
{
    ////...
}
```

- parameterId (int): Parameter ID

To retrieve a parameter value from a remote element:

```csharp
uint dmaID = 346;
uint elementID = 193;
uint parameterID = 1017;
uint[] ids = new uint[] { dmaID, elementID, parameterID };
object[] result = (object[])protocol.NotifyDataMiner(73/*NT_GET_PARAMETER*/, ids, null);

if (result != null && result.Length > 0)
{
    string parameterValue = Convert.ToString(result[0]);

    ////...
}
```

- ids (uint[]):
  - ids[0]: DMA ID
  - ids[1]: Element ID
  - ids[2]: Parameter ID

## Return Value

Local parameter:

- (object): The parameter value.

Remote parameter:

- result (object[]): object array containing the parameter value.

## Remarks

- To retrieve a parameter using this call, the parameter must have [RTDisplay](xref:Protocol.Params.Param.Display.RTDisplay) set to `true`.
- The SLProtocol interface defines a wrapper method "GetParameter" for this call. See [GetParameter (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameter(System.Int32)) method and [GetParameters (SLProtocol)](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameters(System.Object)) methods.
