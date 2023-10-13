---
uid: NT_SET_ITEM_DATA
---

# NT_SET_ITEM_DATA (89)

Sets the values stored for the specified parameters in the ElementData.xml file.

## Parameters

Setting a **single value**:

```csharp
string parameterName =  "ExampleParameter";
string value = "Data";

protocol.NotifyProtocol(89, parameterName, value);
```

- parameterName (string): The name of the parameter.
- values (string[]): The value to set.

Setting **multiple values**:

```csharp
string[] parameterNames =  new string[]{"ExampleParameter"};
string[] values = new string[] { "Data" };

object result = protocol.NotifyProtocol(89, parameterNames, values);

if (result != null)
{
    ////...
}
else
{
    ////...
}
```

- parameterNames (string[]): The names of the parameters.
- values (string[]): The values to set.

## Return Value

- (object): An array of unsigned integers (the same length as the number of parameters that have been set), with the result for each set.

## Remarks

- The [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) interface defines two wrapper methods for this call: [SetParameterItemData](xref:Skyline.DataMiner.Scripting.SLProtocol.SetParameterItemData(System.String,System.Object)) and [SetParametersItemData](xref:Skyline.DataMiner.Scripting.SLProtocol.SetParametersItemData(System.String[],System.Object[])).
- This Notify type is deprecated since DataMiner 10.3.4.
