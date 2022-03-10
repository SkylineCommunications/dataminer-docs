---
uid: NT_CREATE_FOLDER
---

# NT_CREATE_FOLDER (181)

Creates a folder in the C:\ Skyline DataMiner\Documents folder.

```csharp
string folder = "Configurations";

protocol.NotifyDataMiner(181/*NT_CREATE_FOLDER*/, folder, null);
```

## Parameters

- folder (string): Name of the folder.

## Return Value

- Does not return an object.

## Remarks

- The folder will be created in the C:\Skyline DataMiner\Documents folder.
