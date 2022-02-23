---
uid: NT_SET_BINARY_DATA
---

# NT_SET_BINARY_DATA (177)

Sets the value of the specified parameter to the specified byte array.

```csharp
int parameterID = 10;
byte[] data = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

protocol.NotifyProtocol(177/*NT_SET_BINARY_DATA*/ , parameterID, data);
```

## Parameters

- parameterID (int): ID of the parameter to set.
- data (byte[]): Data to set.

## Return Value

- Does not return an object.

## Remarks

- Only supported for parameters with [LengthType](xref:Protocol.Params.Param.Interprete.LengthType) set to `fixed`, `next param` or `last next param`. For parameters with LengthType set to `fixed`, the number of bytes that will be set is limited to the value specified in [Length](xref:Protocol.Params.Param.Interprete.Length).
- Setting a parameter value using this method does not trigger a change event. Refer to [Parameter change events](xref:LogicParameters#parameter-change-events) for more information on the implications.

## See also

- [SLProtocol.SetParameterBinary](xref:Skyline.DataMiner.Scripting.SLProtocol.SetParameterBinary(System.Int32,System.Byte[]))
