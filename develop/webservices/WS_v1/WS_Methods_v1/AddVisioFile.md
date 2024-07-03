---
uid: AddVisioFile
---

# AddVisioFile

Use this method to upload a Visio file that can be assigned to services and views.

## Input

| Item          | Format       | Description                                                                                  |
|---------------|--------------|----------------------------------------------------------------------------------------------|
| connection    | String       | The connection ID. See [ConnectApp](xref:ConnectApp).                                        |
| visioFileName | String       | The file name of the Visio file. The file name may not contain more than 150 characters.     |
| visio         | Base64Binary | A byte array representing the Visio file you want to upload.                                 |

## Output

None.
