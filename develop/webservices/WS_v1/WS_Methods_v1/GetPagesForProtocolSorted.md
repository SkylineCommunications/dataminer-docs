---
uid: GetPagesForProtocolSorted
---

# GetPagesForProtocolSorted

Use this method to retrieve a specific number of pages for a specified protocol.

## Input

| Item            | Format  | Description                                                                      |
|-----------------|---------|----------------------------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| protocolName    | String  | The name of the protocol                                                         |
| protocolVersion | String  | The protocol version                                                             |
| index           | Integer | The point from which to start returning child pages.                             |
| count           | Integer | The number of pages to be returned.                                              |
| orderBy         | String  | The field(s) by which to order the pages (separated by semicolons).              |

## Output

| Item | Format | Description |
|--|--|--|
| GetPagesForProtocolSortedResult | Array of [DMAProtocolPage](xref:DMAProtocolPage) | The pages of the specified protocol, sorted as requested. |
