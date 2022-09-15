---
uid: GetAvailableVisioFilesForProtocol
---

# GetAvailableVisioFilesForProtocol

Use this method to retrieve all available Visio files assigned to a protocol.

## Input

| Item         | Format | Description                                          |
|--------------|--------|------------------------------------------------------|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| protocolName | String | The name of the protocol.                            |

## Output

| Item                                     | Format          | Description                                                        |
|------------------------------------------|-----------------|--------------------------------------------------------------------|
| GetAvailableVisioFilesForProtocolResult | Array of string | The names of the available Visio files for the specified protocol. |
