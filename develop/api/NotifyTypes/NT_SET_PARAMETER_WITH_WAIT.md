---
uid: NT_SET_PARAMETER_WITH_WAIT 
---

# NT_SET_PARAMETER_WITH_WAIT  (167)

Sets a parameter with wait.

```csharp
uint dmaID = 346;
uint elementID = 808;
uint parameterID = 10;

uint[] ids = new uint[] { dmaID, elementID, parameterID };

int value = 10;

protocol.NotifyDataMiner(167 /*NT_SET_PARAMETER_WITH_WAIT*/ , ids, value);
```

## Parameters

- ids (uint[]):
  - ids[0]: DataMiner Agent ID
  - ids[1]: element ID
  - ids[2]: parameter ID
- value (object): Value to set, depending on the type of set (standalone parameter, matrix, table cell)
  - Standalone parameter: Value is the value that needs to be set (e.g., a string).
  - Matrix: Value contains the input, output and the crosspoint that needs to be set (e.g., value = input + "," + output + "," + crosspoint;)
  - Table cell: Value is object array identifying the cell that needs to be set.

  > [!NOTE]
  > In this case, ids[2] specifies the ID of the column parameter.

  ```csharp
  string primaryKey = "Row 1";
  int cellValue = 20;

  object[] paramArray = new object[] { primaryKey, cellValue };

  protocol.NotifyDataMiner(167, ids, paramArray);
  ```

## Return Value

- Does not return an object.
