---
uid: GetTicketType
---

# GetTicketType

Use this method to retrieve the ticket type for a ticket with a specific ID.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item         | Format | Description                                                                      |
|--------------|--------|----------------------------------------------------------------------------------|
| Connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| TicketTypeID | String | The ticket ID.                                                                   |

## Output

| Item | Format | Description |
|--|--|--|
| GetTicketTypeResult | [DMATicketType](xref:DMATicketType) | The ticket type of the specified ticket. |
