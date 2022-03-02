---
uid: AddTicketAttachment
---

# AddTicketAttachment

Use this method to add an attachment file to a ticket.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| TicketID   | String | The ID of the ticket.                                |
| FileName   | String | The name of the attachment file.                     |
| Path       | String | The file path of the attachment file.                |

## Output

None.
