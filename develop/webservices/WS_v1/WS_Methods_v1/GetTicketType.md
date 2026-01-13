---
uid: GetTicketType
---

# GetTicketType

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to retrieve the ticket type for a ticket with a specific ID.

## Input

| Item         | Format | Description                                           |
|--------------|--------|-------------------------------------------------------|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | String | The ticket ID.                                        |

## Output

| Item | Format | Description |
|--|--|--|
| GetTicketTypeResult | [DMATicketType](xref:DMATicketType) | The ticket type of the specified ticket. |
