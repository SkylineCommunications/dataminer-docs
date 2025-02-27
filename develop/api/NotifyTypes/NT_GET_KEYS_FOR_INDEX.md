---
uid: NT_GET_KEYS_FOR_INDEX
---

# NT_GET_KEYS_FOR_INDEX (196)

Gets the primary keys of all rows that have the specified value for the specified column.

```csharp
int columnID = 1010;

string value = "Value 1";

string[] primaryKeys = (string[])protocol.NotifyProtocol(196/*NT_GET_KEYS_FOR_INDEX*/ , columnID, value);
```

## Parameters

- columnID (int): ID of the column parameter.
- value (string): The value to search. (This may be a string or number, depending on the column that needs to be checked) 

## Return Value

- (string[]): The primary keys of rows having the specified value for the specified column. If no matches are found, an empty array is returned.

## Remarks

- The use of the wrapper method [SLProtocol.GetKeysForIndex](xref:Skyline.DataMiner.Scripting.SLProtocol.GetKeysForIndex*) is preferred over this notify call.
- In order for this method to work, the column must either be a foreign key column or it must have the option "indexColumn".
- This call does not perform a case-sensitive lookup.<!-- RN 15333 --> In case a case-sensitive lookup is required, use the [NT_GET_KEYS_FOR_INDEX_CASED (411)](xref:NT_GET_KEYS_FOR_INDEX_CASED) notify type.

## See also

- [Requesting index values from index columns](xref:Protocol.Params.Param.ArrayOptions.ColumnOption#requesting-index-values-from-index-columns)
- [GetKeysForIndex](xref:Skyline.DataMiner.Scripting.SLProtocol.GetKeysForIndex(System.Int32,System.String)) method
