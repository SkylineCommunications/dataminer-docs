---
uid: AddTicketField
---

# AddTicketField

Use this method to add a new field to a specified ticket type (called “domain” in the Ticketing app).

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. <!-- From DataMiner 10.0.13 onwards, -->It also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item         | Format               | Description                                                       |
|--------------|----------------------|-------------------------------------------------------------------|
| connection   | String               | The connection ID. See [ConnectApp](xref:ConnectApp).              |
| ticketTypeID | GUID                 | The GUID of the ticket type to which you are adding the field.    |
| field        | DMATicketField array | See [DMATicketField](xref:DMATicketField). |

> [!NOTE]
> It is not possible to add a ticket field of type *State*.

## Output

None.
