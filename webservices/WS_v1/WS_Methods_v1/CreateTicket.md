---
uid: CreateTicket
---

# CreateTicket

Use this method to create a new ticket.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| Ticket | DMATicketNew array | An array with the values for each field of the ticket (in the format DMATicketFieldValueDisplay), an array with the linked DataMiner resources (in the format DMATicketLinkField), and the ID of the ticket type (or “domain” in the Ticketing app). The fields depend on the configuration of the ticket type.<br> See also:<br> -  [DMATicketFieldValueDisplay](xref:DMATicketFieldValueDisplay)<br> -  [DMATicketLinkField](xref:DMATicketLinkField) |

## Output

| Item               | Format            | Description                                                                                                        |
|--------------------|-------------------|--------------------------------------------------------------------------------------------------------------------|
| CreateTicketResult | Array of integers | The DataMiner ID and ticket ID of the new ticket. From DataMiner 10.0.13 onwards, the ticket UID is also returned. |
