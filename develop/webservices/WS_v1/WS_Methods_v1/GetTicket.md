---
uid: GetTicket
---

# GetTicket

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

This method is deprecated. Use the [GetTicketV2](xref:GetTicketV2) method instead.

## Input

| Item           | Format  | Description                                                        |
|----------------|---------|--------------------------------------------------------------------|
| connection     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).              |
| dmaID          | Integer | The ID of the DMA.                                                 |
| ticketID       | Integer | The ID of the ticket.                                              |
| includeHistory | Boolean | Determines whether the revision history of the ticket is included. |

## Output

| Item            | Format                      | Description           |
|-----------------|-----------------------------|-----------------------|
| GetTicketResult | [DMATicket](xref:DMATicket) | The requested ticket. |
