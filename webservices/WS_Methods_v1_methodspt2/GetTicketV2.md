---
uid: GetTicketV2
---

# GetTicketV2

Use this method to retrieve a specific ticket.

> [!NOTE]
> -  From DataMiner 10.0.13 onwards, this method should be used instead of *GetTicket* (see [GetTicket](xref:GetTicket)).
> -  DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires DataMiner Indexing. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item           | Format  | Description                                                                      |
|----------------|---------|----------------------------------------------------------------------------------|
| Connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| TicketID       | Integer | The ID of the ticket.                                                            |
| IncludeHistory | Boolean | Determines whether the revision history of the ticket is included.               |

## Output

| Item              | Format    | Description                                             |
|-------------------|-----------|---------------------------------------------------------|
| GetTicketV2Result | DMATicket | See [DMATicket](xref:DMATicket). |

