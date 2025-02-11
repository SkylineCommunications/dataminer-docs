---
uid: NT_GET_PK_ID_BY_TABLE_ID
---

# NT_GET_PK_ID_BY_TABLE_ID (394)

Retrieves the column index of the column that contains the primary keys of the table with the specified ID.<!-- RN 23579 -->

```csharp
int tableId = 1000;

int primaryKeyColumnId = (int) protocol.NotifyProtocol(193 /*NT_FILL_ARRAY*/, tableId, null);
```

## Parameters

- tableId (int): ID of the table parameter.

## Return Value

- primaryKeyColumnId (int): The ID of the column containing the primary keys of the table with the specified ID.

## Remarks

- In case the specified tableId does not represent a table parameter, the following error code will be logged: 0x80040221
