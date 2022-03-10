---
uid: NT_GET_DOCUMENTS
---

# NT_GET_DOCUMENTS (180)

Gets an overview of the documents in the specified Documents folder.

```csharp
string folderName = "DMA_COMMON_DOCUMENTS";   // This will result in the absolute path "C:\Skyline DataMiner\Documents\Arris CMTS"
bool includeSubfolders = true;

string[] documentDetails = (string[]) protocol.NotifyDataMiner(180 /*NT_GET_DOCUMENTS*/, folderName, includeSubfolders);
```

## Parameters

- folderName (string): Name of the folder for which the document information must be retrieved.
- includeSubfolders (bool): Indicates whether documents of subfolders of the specified folder should be included (which are retrieved recursively).

## Return Value

- documents (string[]): The array is a list of document details. For every document, 5 details are returned:
  - documents[5*i]: File name. In case the includeSubfolders parameter has been set to true, this will be an absolute path instead of just the file name.
  - documents[5*i + 1]: Title.
  - documents[5*i + 2]: Comments.
  - documents[5*i + 3]: Last write time (format: YYYY/MM/DD HH:MM:SS).
  - documents[5*i + 4]: bool indication.
