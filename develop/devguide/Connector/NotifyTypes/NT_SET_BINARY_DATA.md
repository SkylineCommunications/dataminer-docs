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

- Setting a parameter value using this method does not trigger a change event.


## See also

- SetParameterBinary
