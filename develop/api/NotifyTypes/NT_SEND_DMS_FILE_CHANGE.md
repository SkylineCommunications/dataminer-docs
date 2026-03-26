---
uid: NT_SEND_DMS_FILE_CHANGE
---

# NT_SEND_DMS_FILE_CHANGE (41)

Notifies DataMiner that a file has changed, to make DataMiner sync it across all Agents of the DataMiner System.

```csharp
string filePath = @"C:\Skyline DataMiner\Documents\Arris CMTS\scripts\empty.cfg";
int fileChangeType = 32;

protocol.NotifyDataMiner(41 /*NT_SEND_DMS_FILE_CHANGE*/, filePath, fileChangeType);
```

## Parameters

- filePath (string): Path and file name that has changed (e.g., C:\Skyline DataMiner\path.xml).
- fileChangeType (int): Integer indicating the type of file change (32 = File modified, 33 = File removed, 34 = File added). 

## Return Value

- Does not return an object.
