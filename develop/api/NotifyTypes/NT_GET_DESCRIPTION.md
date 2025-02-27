---
uid: NT_GET_DESCRIPTION
---

# NT_GET_DESCRIPTION (77)

Gets the description of the specified parameter.

```csharp
int parameterID = 110;
object result = protocol.NotifyProtocol(77, parameterID, null);

if (result != null)
{
    string parameterDescription = (string)result;
}
```

## Parameters

- parameterID (int): ID of the element.

## Return Value

- (object): The parameter description as string. If no parameter with the specified ID exists in the protocol, a null reference is returned.

## Remarks

- The SLProtocol interface defines a wrapper method [GetParameterDescription](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameterDescription*) for this call.
