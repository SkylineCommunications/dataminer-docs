---
uid: AddVisioFileToProtocol
---

# AddVisioFileToProtocol

Use this method to upload a Visio file that can be assigned to elements of a specified protocol.

## Input

| Item          | Format       | Description                                                                                  |
|---------------|--------------|----------------------------------------------------------------------------------------------|
| connection    | String       | The connection ID. See [ConnectApp](xref:ConnectApp).                                        |
| protocolName  | String       | The name of the protocol.                                                                    |
| visioFileName | String       | The file name of the Visio file.<br>This must be the default name *\[protocolName\].vsdx* or *\[protocolName\].vdx*.<br>Also, this file name may not contain more than 150 characters. |
| visio         | Base64Binary | A byte array representing the Visio file you want to upload.                                 |

## Output

None.
