---
uid: GetTicketV2
---

# GetTicketV2

Use this method to retrieve a specific ticket.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item           | Format  | Description                                                        |
|----------------|---------|--------------------------------------------------------------------|
| connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).              |
| ticketID       | Integer | The ID of the ticket.                                              |
| includeHistory | Boolean | Determines whether the revision history of the ticket is included. |

## Output

| Item              | Format    | Description                      |
|-------------------|-----------|----------------------------------|
| GetTicketV2Result | DMATicket | See [DMATicket](xref:DMATicket). |
