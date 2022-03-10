---
uid: GetPagesForProtocolSorted
---

# GetPagesForProtocolSorted

Use this method to retrieve a specific number of pages for a specified protocol.

## Input

| Item            | Format  | Description                                                                      |
|-----------------|---------|----------------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ProtocolName    | String  | The name of the protocol                                                         |
| ProtocolVersion | String  | The protocol version                                                             |
| Index           | Integer | The point from which to start returning child pages.                             |
| Count           | Integer | The number of pages to be returned.                                              |
| OrderBy         | String  | The field(s) by which to order the pages (separated by semicolons).              |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForProtocol­SortedResult | Array of [DMAProtocolPage](xref:DMAProtocolPage) | The pages of the specified protocol, sorted as requested. |
