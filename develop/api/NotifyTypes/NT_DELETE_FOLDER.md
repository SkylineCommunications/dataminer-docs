---
uid: NT_DELETE_FOLDER
---

# NT_DELETE_FOLDER (182)

Deletes a folder in the C:\ Skyline DataMiner\Documents folder.

```csharp
string folder = "Configurations";

protocol.NotifyDataMiner(182 /*NT_DELETE_FOLDER*/, folder, null);
```

## Parameters

- folder (string): Name of the folder.

> [!NOTE]
> If a relative path is passed to the NT_DELETE_FOLDER function, it will assume it to be relative to the C:\Skyline DataMiner\Documents\ folder. As such, in the example above, the function will try to delete the C:\Skyline DataMiner\Documents\Configurations folder. If you want it to delete the C:\Skyline DataMiner\Configurations folder, you have to specify the full path.

## Return Value

- Does not return an object.

## Remarks

- You can specify whether the DataMiner recycle bin should be bypassed:<!-- RN 24639 -->

  ```csharp
  string folder = "Configurations";
  bool recycle = true;

  protocol.NotifyDataMiner(182 /*NT_DELETE_FOLDER*/, folder, null);
  ```

  Parameters:
  - folder (string): Name of the folder.
  - recycle (bool): When set to true, the specified folder will be moved to the DataMiner recycle bin (default behavior). When set to false, the specified folder will not be moved to the DataMiner recycle bin but will be deleted instead.
