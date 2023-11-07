---
uid: AddTicketType
---

# AddTicketType

Use this method to add a new ticket type (called “domain” in the Ticketing app).

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/user-guide/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item           | Format | Description                                          |
|----------------|--------|------------------------------------------------------|
| connection     | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeName | String | The name of the new ticket type.                     |

## Output

| Item                | Format | Description                      |
|---------------------|--------|----------------------------------|
| AddTicketTypeResult | GUID   | The GUID of the new ticket type. |
