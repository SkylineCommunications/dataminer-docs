---
uid: NT_GET_ITEM_DATA
---

# NT_GET_ITEM_DATA (88)

Gets the value stored for the specified parameter in the ElementData.xml file.

```csharp
string parameterName = "Status Code";
object result = protocol.NotifyProtocol(88, parameterName, null);

if (result != null)
{
    string value = (string)result;

    ////...
}
```

## Parameters

- parameterName (string): The name of the parameter.

## Return Value

- (object): The value stored in the ElementData.xml file (as string). In case the ElementData.xml file did not contain a value for the specified parameter and the parameter is defined in the protocol, an empty string is returned. In case there is no parameter defined with the specified name, a null reference is returned.

## Remarks

- The [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) interface defines a wrapper method [GetParameterItemData](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameterItemData(System.String)) for this call.
- This Notify type is **deprecated** since DataMiner 10.3.4.<!-- RN 33625 -->
