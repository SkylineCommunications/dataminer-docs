---
uid: NT_RENAME_FOLDER
---

# NT_RENAME_FOLDER (183)

Renames a folder.

```csharp
string rootFolder = @"C:\Skyline DataMiner\Documents\";
string folderName = "Config";
string newFolderName = "Configuration";

object returnValue = protocol.NotifyDataMiner(183/*NT_RENAME_FOLDER*/ , rootFolder + folderName, rootFolder + newFolderName);
```

## Parameters

- folderName (string): Current name of the folder.
- newFolderName (string): New name of the folder.

## Return Value

- Does not return an object.

## Remarks

- In case the folder to rename does not exist, an error message is logged.
