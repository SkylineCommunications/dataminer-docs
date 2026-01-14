---
uid: GetTicketAttachmentNames
---

# GetTicketAttachmentNames

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to retrieve the names of all files attached to a specific ticket.

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                               |
| ticketID   | Integer | The ticket ID.                                        |

## Output

| Item                           | Format          | Description                                           |
|--------------------------------|-----------------|-------------------------------------------------------|
| GetTicketAttachmentNamesResult | Array of string | The names of the attachments of the specified ticket. |
