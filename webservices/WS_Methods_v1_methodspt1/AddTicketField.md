---
uid: AddTicketField
---

# AddTicketField

Use this method to add a new field to a specified ticket type (called “domain” in the Ticketing app).

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires DataMiner Indexing. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item         | Format               | Description                                                       |
|--------------|----------------------|-------------------------------------------------------------------|
| Connection   | String               | The connection ID. See [ConnectApp](xref:ConnectApp) .              |
| TicketTypeID | GUID                 | The GUID of the ticket type to which you are adding the field.    |
| Field        | DMATicketField array | See [DMATicketField](xref:DMATicketField). |

> [!NOTE]
> It is not possible to add a ticket field of type *State*.

## Output

None.

