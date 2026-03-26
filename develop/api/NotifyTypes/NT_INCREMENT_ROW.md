---
uid: NT_INCREMENT_ROW
---

# NT_INCREMENT_ROW (293)

Adds the specified numeric values to the current values in the row.

```csharp
int tableID = 3000;
string primaryKey = "Row 1";

object[] rowDetails = new object[] { tableID, primaryKey };
object[] rowValues = new object[] { null, 1.5, 2.0, -1.0, null, null, null };
object[] result = (object[])protocol.NotifyProtocol(293 /*NT_INCREMENT_ROW*/, rowDetails, rowValues);
```

## Parameters

- rowDetails (object[]):
  - rowDetails[0] (int): ID of the table parameter.
  - rowDetails[1] (string): Primary key of the row.
- rowValues (object[]):
  - rowValues[0…n]: Values to add to current cell values. Use null for cells that should not be updated.

## Return Value

- object[]): Array containing the resulting values for every cell that was updated (i.e., where rowValues[i] was not set to null).

## Remarks

- This call is only intended to be used with columns of type double.
