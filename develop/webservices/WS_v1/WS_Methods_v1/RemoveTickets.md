---
uid: RemoveTickets
---

# RemoveTickets

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to remove multiple tickets.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| tickets | Array of DMATicketUpdate | A DMATicketUpdate object for each ticket that must be removed, consisting of the DataMinerID and ID of the ticket. |

## Output

None.
