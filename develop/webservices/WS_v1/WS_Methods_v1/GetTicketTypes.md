---
uid: GetTicketTypes
---

# GetTicketTypes

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to retrieve the available ticket types (or “domains” in the Ticketing app).

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item                 | Format                 | Description                              |
|----------------------|------------------------|------------------------------------------|
| GetTicketTypesResult | Array of DMATicketType | See [DMATicketType](xref:DMATicketType). |
