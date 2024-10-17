---
uid: NT_GET_KEYS_FOR_INDEX_CASED
---

# NT_GET_KEYS_FOR_INDEX_CASED  (411)

Gets the primary keys of all rows that have the specified value (case sensitive) for the specified column.<!-- RN 15333 -->

```csharp
int columnID = 1010;
string valueToFind = "Value 1";

string[] primaryKeys = (string[])protocol.NotifyProtocol(411 /*NT_GET_KEYS_FOR_INDEX_CASED*/ , columnID, valueToFind);
```

## Parameters

- columnID (int): ID of the column parameter.
- value (string): The value to search. This may be a string or number, depending on the column that needs to be checked.

## Return Value

- (string[]) The primary keys of rows that have the specified value for the specified column. If no matches are found, an empty array is returned.

## Remarks

- In order for this method to work, the column must either be a foreign key column or it must have the option "indexColumn".
- In order to perform a case-insensitive lookup, use the [NT_GET_KEYS_FOR_INDEX (196)](xref:NT_GET_KEYS_FOR_INDEX) notify type.

## See also

- [Requesting index values from index columns](xref:Protocol.Params.Param.ArrayOptions.ColumnOption#requesting-index-values-from-index-columns)
