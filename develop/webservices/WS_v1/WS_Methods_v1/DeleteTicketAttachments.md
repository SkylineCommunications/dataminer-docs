---
uid: DeleteTicketAttachments
---

# DeleteTicketAttachments

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to delete several attachments from a ticket.

## Input

| Item       | Format          | Description                                          |
|------------|-----------------|------------------------------------------------------|
| connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer         | The DataMiner Agent ID.                              |
| ticketID   | Integer         | The ID of the ticket.                                |
| fileNames  | Array of string | The names of the attachment files.                   |

## Output

None.
