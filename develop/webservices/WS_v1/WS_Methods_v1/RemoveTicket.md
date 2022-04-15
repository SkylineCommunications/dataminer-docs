---
uid: RemoveTicket
---

# RemoveTicket

Use this method to remove a particular ticket.

> [!NOTE]
> -  From DataMiner 10.0.13 onwards, use the [RemoveTicketV2](xref:RemoveTicketV2) method instead.
> -  DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The ID of the DMA. |
| ticketID | Integer | The ID of the ticket. |

## Output

None.
