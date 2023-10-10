---
uid: GenerateTicketBasedOnAlarm
---

# GenerateTicketBasedOnAlarm

Use this method to generate a ticket based on the properties of a particular alarm.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/user-guide/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item         | Format  | Description                                          |
|--------------|---------|------------------------------------------------------|
| connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | GUID    | The GUID of the ticket type.                         |
| dmaID        | Integer | The DataMiner Agent ID.                              |
| alarmID      | Integer | The alarm ID.                                        |

## Output

| Item                             | Format                                             | Description           |
|----------------------------------|----------------------------------------------------|-----------------------|
| GenerateTicketBasedOnAlarmResult | [DMATicket](xref:DMATicket) | The generated ticket. |
