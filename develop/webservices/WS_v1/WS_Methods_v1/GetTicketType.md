---
uid: GetTicketType
---

# GetTicketType

Use this method to retrieve the ticket type for a ticket with a specific ID.

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
