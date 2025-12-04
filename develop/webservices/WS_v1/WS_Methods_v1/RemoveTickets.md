---
uid: RemoveTickets
---

# RemoveTickets

Use this method to remove multiple tickets.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. For more details, see [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles). ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| tickets | Array of DMATicketUpdate | A DMATicketUpdate object for each ticket that must be removed, consisting of the DataMinerID and ID of the ticket. |

## Output

None.
