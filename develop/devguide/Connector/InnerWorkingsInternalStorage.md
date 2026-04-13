---
uid: InnerWorkingsInternalStorage
---

# Internal storage

A numeric parameter (i.e., a parameter having RawType set to either "numeric text", "signed number" or "unsigned number") that is not initialized will return different values depending on whether it is a cell in a table or single parameter.

- Cell: a null reference is returned (e.g., object cellValue = protocol.GetParameterIndexByKey(1000, "124", 4);).
- Standalone parameter: the value 0 is returned (e.g., object value = protocol.GetParameter(100);). To determine if a standalone parameter is uninitialized, the IsEmpty method can be used (e.g., bool isEmpty = protocol.IsEmpty(100);)
