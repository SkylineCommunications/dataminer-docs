---
uid: NT_GET_TABLE_ID_BY_COLUMN_ID
---

# NT_GET_TABLE_ID_BY_COLUMN_ID (393)

Retrieves the ID of the table parameter to which the column with the specified ID belongs.<!-- RN 23579 -->

```csharp
int columnId = 1001;

int tableId =  (int) protocol.NotifyProtocol(393 /* NT_GET_TABLE_ID_BY_COLUMN_ID */, columnId, null);
```

## Parameters

- columnId (int): ID of the column parameter.

## Return Value

- tableId (int): The ID of the table parameter to which the column with the specified ID belongs.

## Remarks

- This only works for parameters that are defined in the table parameter's ArrayOptions/ColumnOption. Write parameters that are implicitly part of the table through their read parameters are not supported.
- In case the specified columnId does not represent a column parameter, the following error code will be logged: 0x80040221
