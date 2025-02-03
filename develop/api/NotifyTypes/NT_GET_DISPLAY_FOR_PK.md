---
uid: NT_GET_DISPLAY_FOR_PK
---

# NT_GET_DISPLAY_FOR_PK (161)

Gets the display key that corresponds with the specified primary key.

```csharp
int displayColumnID = 1002;

string primaryKey = "Row 1";

string displayKey = (string)protocol.NotifyProtocol(161/*NT_GET_DISPLAY_FOR_PK*/ , displayColumnID, primaryKey);
```

## Parameters

- displayColumnID (int): ID of the column parameter that contains the display keys.
- primaryKey (string): Primary key.

## Return Value

- displayKey (string): The display key that corresponds with the specified primary key, or in case the specified primary key is not found, the provided primary key value.

## Remarks

- This call only works in case the now deprecated [displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn) attribute is used. Using this notify on a table without the displayColumn attribute will result in the provided primary key value being returned.
