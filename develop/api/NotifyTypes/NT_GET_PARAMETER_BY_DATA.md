---
uid: NT_GET_PARAMETER_BY_DATA
---

# NT_GET_PARAMETER_BY_DATA (87)

Gets the parameter value corresponding with the parameter that has the specified data stored in the ElementData.xml file.

```csharp
string data = "Data";
object result = protocol.NotifyProtocol(87, data, null);

if (result != null)
{
    double value = (double)result;

    ////...
}
else
{
    ////...
}
```

## Parameters

- data (string): The data value stored in the ElementData.xml for the parameter.

## Return Value

- (object): The parameter value. In case ElementData.xml does not contain a parameter with the specified data, a null reference is returned.

## Remarks

- The [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) interface defines a wrapper method [GetParameterByData](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameterByData(System.String)) for this call.
- This Notify type is **deprecated** since DataMiner 10.3.4.<!-- RN 33625 -->
