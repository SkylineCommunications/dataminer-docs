---
uid: GetAvailableVisioFilesForProtocol
---

# GetAvailableVisioFilesForProtocol

Use this method to retrieve all available Visio files assigned to a protocol.

## Input

| Item         | Format | Description                                          |
|--------------|--------|------------------------------------------------------|
| Connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ProtocolName | String | The name of the protocol.                            |

## Output

| Item                                     | Format          | Description                                                        |
|------------------------------------------|-----------------|--------------------------------------------------------------------|
| GetAvailableVisioFiles­ForProtocolResult | Array of string | The names of the available Visio files for the specified protocol. |
