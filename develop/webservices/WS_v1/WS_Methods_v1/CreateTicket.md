---
uid: CreateTicket
---

# CreateTicket

Use this method to create a new ticket.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/user-guide/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| ticket | DMATicketNew array | An array with the values for each field of the ticket (in the format DMATicketFieldValueDisplay), an array with the linked DataMiner resources (in the format DMATicketLinkField), and the ID of the ticket type (or “domain” in the Ticketing app). The fields depend on the configuration of the ticket type.<br> See also:<br> -  [DMATicketFieldValueDisplay](xref:DMATicketFieldValueDisplay)<br> -  [DMATicketLinkField](xref:DMATicketLinkField) |

## Output

| Item               | Format            | Description                                                                                                        |
|--------------------|-------------------|--------------------------------------------------------------------------------------------------------------------|
| CreateTicketResult | Array of integers | The DataMiner ID and ticket ID of the new ticket. From DataMiner 10.0.13 onwards, the ticket UID is also returned. |
