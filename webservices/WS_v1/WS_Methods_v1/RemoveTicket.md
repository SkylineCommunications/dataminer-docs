---
uid: RemoveTicket
---

# RemoveTicket

Use this method to remove a particular ticket.

> [!NOTE]
> -  From DataMiner 10.0.13 onwards, use the *RemoveTicketV2* method instead. See [RemoveTicketV2](xref:RemoveTicketV2).
> -  DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires DataMiner Indexing. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The ID of the DMA.                                                               |
| TicketID   | Integer | The ID of the ticket.                                                            |

## Output

None.

