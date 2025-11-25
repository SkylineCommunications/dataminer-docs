---
uid: AddTicketAttachment
---

# AddTicketAttachment

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

Deprecated. Use the [AddTicketAttachmentV2](xref:AddTicketAttachmentV2) method instead.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                             |
| ticketID   | Integer | The ID of the ticket.                               |
| fileName   | String | The name of the attachment file.                     |
| path       | String | The file path of the attachment file.                |

## Output

None.
