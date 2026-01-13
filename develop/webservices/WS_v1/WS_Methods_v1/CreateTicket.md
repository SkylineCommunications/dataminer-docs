---
uid: CreateTicket
---

# CreateTicket

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to create a new ticket.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| ticket | DMATicketNew array | An array with the values for each field of the ticket (in the format DMATicketFieldValueDisplay), an array with the linked DataMiner resources (in the format DMATicketLinkField), and the ID of the ticket type (or “domain” in the Ticketing app). The fields depend on the configuration of the ticket type.<br> See also:<br> - [DMATicketFieldValueDisplay](xref:DMATicketFieldValueDisplay)<br> - [DMATicketLinkField](xref:DMATicketLinkField) |

## Output

| Item | Format | Description |
|------|--------|-------------|
| CreateTicketResult | Array of integers | The DataMiner ID, ticket ID, and ticket UID of the new ticket. |
