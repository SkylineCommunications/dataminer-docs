---
uid: GetTicketTypes
---

# GetTicketTypes

Use this method to retrieve the available ticket types (or “domains” in the Ticketing app).

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item                 | Format                 | Description                              |
|----------------------|------------------------|------------------------------------------|
| GetTicketTypesResult | Array of DMATicketType | See [DMATicketType](xref:DMATicketType). |
