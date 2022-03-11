---
uid: DeleteTicketAttachments
---

# DeleteTicketAttachments

Use this method to delete several attachments from a ticket.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item       | Format          | Description                                          |
|------------|-----------------|------------------------------------------------------|
| Connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer         | The DataMiner Agent ID.                              |
| TicketID   | Integer         | The ID of the ticket.                                |
| FileNames  | Array of string | The names of the attachment files.                   |

## Output

None.
