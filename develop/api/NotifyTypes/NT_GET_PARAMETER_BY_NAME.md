---
uid: NT_GET_PARAMETER_BY_NAME
---

# NT_GET_PARAMETER_BY_NAME (85)

Gets the value of the parameter with the specified name.

```csharp
string name = "OperationalStatus";
object result = protocol.NotifyProtocol(85, name, null);

if (result != null)
{
    ////...
}
```

## Parameters

- name (string): The name of the parameter.

## Return Value

- (object): The parameter value.

## Remarks

- The SLProtocol interface defines a wrapper method [GetParameterByName](xref:Skyline.DataMiner.Scripting.SLProtocol.GetParameterByName*) for this call.
- When a call is executed for a parameter name that does not exist in the protocol, a null reference is returned and the following message will be logged "NotifyProtocol with 85 failed. 0x80040239".
- In case there is both a read and write parameter with the specified name, the value of the write parameter will be returned.
- When calling this method on a numeric parameter (i.e., a parameter having RawType set to either numeric text, signed number or unsigned number) that is not initialized, 0 will be returned. To determine whether a standalone parameter is uninitialized, the IsEmpty method should be used.
