---
uid: GetTicketAttachmentNames
---

# GetTicketAttachmentNames

Use this method to retrieve the names of all files attached to a specific ticket.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

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
