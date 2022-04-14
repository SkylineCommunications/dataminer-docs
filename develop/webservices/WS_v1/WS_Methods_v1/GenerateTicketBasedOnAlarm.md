---
uid: GenerateTicketBasedOnAlarm
---

# GenerateTicketBasedOnAlarm

Use this method to generate a ticket based on the properties of a particular alarm.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

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
