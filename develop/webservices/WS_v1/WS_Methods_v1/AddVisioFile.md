---
uid: AddVisioFile
---

# AddVisioFile

Use this method to upload a Visio file that can be assigned to services and views.

## Input

| Item          | Format       | Description                                                                                  |
|---------------|--------------|----------------------------------------------------------------------------------------------|
| Connection    | String       | The connection ID. See [ConnectApp](xref:ConnectApp).                                         |
| VisioFileName | String       | The file name of the Visio file.<br> The file name may not contain more than 150 characters. |
| Visio         | Base64Binary | A byte array representing the Visio file you want to upload.                                 |

## Output

None.
