---
uid: AddVisioFileToProtocol
---

# AddVisioFileToProtocol

Use this method to upload a Visio file that can be assigned to elements of a specified protocol.

## Input

| Item          | Format       | Description                                                                                  |
|---------------|--------------|----------------------------------------------------------------------------------------------|
| Connection    | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                         |
| ProtocolName  | String       | The name of the protocol.                                                                    |
| VisioFileName | String       | The file name of the Visio file.<br> The file name may not contain more than 150 characters. |
| Visio         | Base64Binary | A byte array representing the Visio file you want to upload.                                 |

> [!NOTE]
> Up till DataMiner 9.0.4, it is possible to add more than one custom Visio file with this method. However, from DataMiner 9.0.5 onwards, this is no longer possible, and the only allowed value for the visioFileName parameter is the default name *\[protocolName\].vsdx* or *\[protocolName\].vdx*.

## Output

None.

