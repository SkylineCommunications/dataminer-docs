---
uid: GetDocuments
---

# GetDocuments

Use this method to retrieve a list of available (general and protocol) documents.

## Input

| Item              | Format  | Description                                                 |
|-------------------|---------|-------------------------------------------------------------|
| Connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp).       |
| ParentFolder      | String  | The folder for which the document list should be retrieved. |
| IncludeSubFolders | Boolean | Determines whether subfolders should be included.           |

## Output

| Item | Format | Description |
|--|--|--|
| GetDocumentsResult | [DMADocumentFolder](xref:DMADocumentFolder) | The document folders and documents in the specified folder. |
