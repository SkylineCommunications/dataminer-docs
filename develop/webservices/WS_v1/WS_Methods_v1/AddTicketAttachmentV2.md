---
uid: AddTicketAttachmentV2
---

# AddTicketAttachmentV2

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

Use this method to add an attachment file to a ticket.

> [!NOTE]
>
> - From DataMiner 10.2.0 \[CU9\]/10.2.12 onwards, this method should be used instead of the [AddTicketAttachment](xref:AddTicketAttachment) method.
> - DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/user-guide/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                             |
| ticketID   | Integer | The ID of the ticket.                                |
| fileName   | String | The name of the attachment file.                     |
| ID         | String | The ID retrieved through an UploadFile call (only available for Skyline employees). |

## Output

None.
