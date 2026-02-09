---
uid: AddTicketAttachmentV2
---

# AddTicketAttachmentV2

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

Use this method to add an attachment file to a ticket. This method should be used instead of the deprecated [AddTicketAttachment](xref:AddTicketAttachment) method.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                             |
| ticketID   | Integer | The ID of the ticket.                               |
| fileName   | String | The name of the attachment file.                     |
| ID         | String | The ID retrieved through an UploadFile call (only available for Skyline employees). |

## Output

None.
