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
| connection | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer         | The DataMiner Agent ID.                              |
| ticketID   | Integer         | The ID of the ticket.                                |
| fileNames  | Array of string | The names of the attachment files.                   |

## Output

None.
