---
uid: RemoveTickets
---

# RemoveTickets

Use this method to remove multiple tickets.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| tickets | Array of DMATicketUpdate | A DMATicketUpdate object for each ticket that must be removed, consisting of the DataMinerID and ID of the ticket. |

## Output

None.
