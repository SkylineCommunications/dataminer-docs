---
uid: GetDocuments
---

# GetDocuments

Use this method to retrieve a list of available (general and protocol) documents.

## Input

| Item              | Format  | Description                                                 |
|-------------------|---------|-------------------------------------------------------------|
| connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp).       |
| parentFolder      | String  | The folder for which the document list should be retrieved. |
| includeSubFolders | Boolean | Determines whether subfolders should be included.           |

## Output

| Item | Format | Description |
|--|--|--|
| GetDocumentsResult | [DMADocumentFolder](xref:DMADocumentFolder) | The document folders and documents in the specified folder. |
