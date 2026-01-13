---
uid: GenerateTicketBasedOnAlarm
---

# GenerateTicketBasedOnAlarm

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to generate a ticket based on the properties of a particular alarm.

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
