---
uid: UpdateTicket
---

# UpdateTicket

Use this method to update an existing ticket.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/user-guide/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| ticket | Array | Array similar to the DMATicketNew array specified when creating a ticket, but with in addition the DataMiner ID and ticket ID of the ticket you want to update. |

> [!TIP]
> See also: [CreateTicket](xref:CreateTicket)

## Output

None.
