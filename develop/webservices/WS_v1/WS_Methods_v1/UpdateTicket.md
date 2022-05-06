---
uid: UpdateTicket
---

# UpdateTicket

Use this method to update an existing ticket.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| ticket | Array | Array similar to the DMATicketNew array specified when creating a ticket, but with in addition the DataMiner ID and ticket ID of the ticket you want to update. |

> [!TIP]
> See also: [CreateTicket](xref:CreateTicket)

## Output

None.
