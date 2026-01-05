---
uid: GenerateTicketBasedOnAlarm
---

# GenerateTicketBasedOnAlarm

Use this method to generate a ticket based on the properties of a particular alarm.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item         | Format  | Description                                          |
|--------------|---------|------------------------------------------------------|
| connection   | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | GUID    | The GUID of the ticket type.                         |
| dmaID        | Integer | The DataMiner Agent ID.                              |
| alarmID      | Integer | The alarm ID.                                        |

## Output

| Item         | Format  | Description |
|--------------|---------|-------------|
| GenerateTicketBasedOnAlarmResult | [DMATicket](xref:DMATicket) | The generated ticket. |
