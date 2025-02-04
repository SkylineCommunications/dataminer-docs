---
uid: NT_GET_PK_FOR_DISPLAY
---

# NT_GET_PK_FOR_DISPLAY (162)

Gets the primary key that corresponds with the specified display key.

```csharp
int displayColumnID = 1002;

string displayKey = "Device A";

string primaryKey = (string)protocol.NotifyProtocol(162/*NT_GET_PK_FOR_DISPLAY*/ , displayColumnID, displayKey);
```

## Parameters

- displayColumnID (int): ID of the column parameter that contains the display keys.
- displayKey (string): Display key.

## Return Value

- (string): The primary key that corresponds with the specified display key or, in case the specified display key is not found, the provided display key value.

## Remarks

- This call only works in case the now deprecated [displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn) attribute is used. Using this notify on a table without the displayColumn attribute will result in the provided primary key value being returned.
