---
uid: GetTicketV2
---

# GetTicketV2

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to retrieve a specific ticket.

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
