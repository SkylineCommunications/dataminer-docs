---
uid: GenerateTicketBasedOnAlarm
---

# GenerateTicketBasedOnAlarm

Use this method to generate a ticket based on the properties of a particular alarm.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires DataMiner Indexing. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item         | Format  | Description                                          |
|--------------|---------|------------------------------------------------------|
| Connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| TicketTypeID | GUID    | The GUID of the ticket type.                         |
| DmaID        | Integer | The DataMiner Agent ID.                              |
| AlarmID      | Integer | The alarm ID.                                        |

## Output

| Item                             | Format                                             | Description           |
|----------------------------------|----------------------------------------------------|-----------------------|
| GenerateTicketBasedOnAlarmResult | [DMATicket](xref:DMATicket) | The generated ticket. |

