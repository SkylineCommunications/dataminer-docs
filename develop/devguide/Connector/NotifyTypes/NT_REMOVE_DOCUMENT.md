---
uid: NT_REMOVE_DOCUMENT
---

# NT_REMOVE_DOCUMENT (103)

Removes the specified document from the Documents folder.

```csharp
string file = @"C:\Skyline DataMiner\Documents\document.txt";

protocol.NotifyDataMiner(103 /* NT_REMOVE_DOCUMENT */, file, false);
```

## Parameters

- file (string): The file to be removed.
  > [!NOTE]
  > An absolute path must be used.
- flag (bool): This must be set to false.

## Return Value

- TBD
