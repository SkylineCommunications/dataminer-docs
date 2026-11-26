---
uid: NT_SET_DESCRIPTION
---

# NT_SET_DESCRIPTION (131)

Sets the description of the specified parameter.

> [!NOTE]
> Rather than calling `NotifyProtocol(131, ...)` directly, we recommend using [SLProtocol.SetParameterDescription](xref:Skyline.DataMiner.Scripting.SLProtocol.SetParameterDescription*).

```csharp
int parameterID = 110;
string description = "Status Code";

protocol.NotifyProtocol(131, parameterID, description);
```

## Parameters

- parameterID (int): The ID of the parameter.
- description (string): The description of the parameter.

## Return Value

- Does not return an object.

## Remarks

- The SLProtocol interface defines a wrapper method "SetParameterDescription" for this call. See [SLProtocol.SetParameterDescription](xref:Skyline.DataMiner.Scripting.SLProtocol.SetParameterDescription*) method.
