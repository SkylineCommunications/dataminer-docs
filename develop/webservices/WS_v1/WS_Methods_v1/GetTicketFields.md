---
uid: GetTicketFields
---

# GetTicketFields

Use this method to retrieve the fields for a particular ticket type (called “domain” in the Ticketing app).

This method can also be used to see which third-party fields are available, and which DataMiner fields are linked to which third-party field (by checking the ExternalFieldName tag in the DMATicketField array).

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/user-guide/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item         | Format | Description                                                                      |
|--------------|--------|----------------------------------------------------------------------------------|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | GUID   | The GUID of the ticket type.                                                     |

## Output

| Item | Format | Description |
|--|--|--|
| GetTicketFieldsResult | Array of [DMATicketField](xref:DMATicketField) | Array containing two sets of DMATicketField entries, with the fields for this ticket type in DataMiner, and the fields for the corresponding third-party ticket type, respectively. |
