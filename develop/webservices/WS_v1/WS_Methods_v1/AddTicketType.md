---
uid: AddTicketType
---

# AddTicketType

Use this method to add a new ticket type (called "domain" in the Ticketing app).

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item           | Format | Description                                           |
|----------------|--------|-------------------------------------------------------|
| connection     | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeName | String | The name of the new ticket type.                      |

## Output

| Item                | Format | Description                      |
|---------------------|--------|----------------------------------|
| AddTicketTypeResult | GUID   | The GUID of the new ticket type. |
