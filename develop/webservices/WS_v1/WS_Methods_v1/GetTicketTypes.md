---
uid: GetTicketTypes
---

# GetTicketTypes

Use this method to retrieve the available ticket types (or “domains” in the Ticketing app).

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item       | Format | Description                                                                      |
|------------|--------|----------------------------------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item                 | Format                 | Description                                                     |
|----------------------|------------------------|-----------------------------------------------------------------|
| GetTicketTypesResult | Array of DMATicketType | See [DMATicketType](xref:DMATicketType). |
