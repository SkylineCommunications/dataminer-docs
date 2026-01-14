---
uid: UpdateTicket
---

# UpdateTicket

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to update an existing ticket.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| ticket | Array | Array similar to the DMATicketNew array specified when creating a ticket, but with in addition the DataMiner ID and ticket ID of the ticket you want to update. |

> [!TIP]
> See also: [CreateTicket](xref:CreateTicket)

## Output

None.
