---
uid: NT_SET_PARAMETER
---

# NT_SET_PARAMETER (50)

Sets a parameter.

```csharp
uint dmaID = 346;
uint elementID = 801;
uint parameterID = 10;

uint[] ids = new uint[] { dmaID, elementID, parameterID };

int value = 10;

protocol.NotifyDataMiner(50 /*NT_SET_PARAMETER*/, ids, value);
```

## Parameters

- ids (uint[]):
  - ids[0]: DataMiner Agent ID
  - ids[1]: Element ID
  - ids[2]: Parameter ID
- value (object): Value to set, depends on type of set (standalone parameter, matrix, table cell)
  - standalone parameter: value is the value that needs to be set (e.g., a string).
  - matrix: value contains the input, output and the crosspoint that needs to be set (e.g., value = input + "," + output + "," + crosspoint;)
  - table cell: value is an object array identifying the cell that needs to be set.

  > [!NOTE]
  > In this case, ids[2] specifies the ID of the column parameter.

  ```csharp
  string primaryKey = "Row 1";
  int cellValue = 20;

  object[] parameterDetails = new object[] { primaryKey, cellValue };

  protocol.NotifyDataMiner(50, ids, parameterDetails);
  ```

## Return Value

- Does not return an object.

## Remarks

- To set an entire row in one call, refer to NT_SET_ROW. See <xref:NT_SET_ROW>.
