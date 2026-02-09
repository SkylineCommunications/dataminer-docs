---
uid: EditTicketFieldOrder
---

# EditTicketFieldOrder

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to edit the order of the ticket fields for a specific ticket type (called “domain” in the Ticketing app).

## Input

| Item         | Format          | Description                                          |
|--------------|-----------------|------------------------------------------------------|
| connection   | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | GUID            | The GUID of the ticket type.                         |
| fieldNames   | Array of string | The names of the fields in the new order.            |

## Output

None.
