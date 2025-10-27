---
uid: GetTicketType
---

# GetTicketType

Use this method to retrieve the ticket type for a ticket with a specific ID.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. <!-- From DataMiner 10.0.13 onwards, -->It also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item         | Format | Description                                           |
|--------------|--------|-------------------------------------------------------|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | String | The ticket ID.                                        |

## Output

| Item | Format | Description |
|--|--|--|
| GetTicketTypeResult | [DMATicketType](xref:DMATicketType) | The ticket type of the specified ticket. |
