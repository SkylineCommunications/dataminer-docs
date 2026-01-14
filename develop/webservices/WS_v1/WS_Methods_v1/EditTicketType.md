---
uid: EditTicketType
---

# EditTicketType

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to edit a specific ticket type (called “domain” in the Ticketing app).

## Input

| Item           | Format | Description                                          |
|----------------|--------|------------------------------------------------------|
| connection     | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID   | GUID   | The GUID of the ticket type.                         |
| ticketTypeName | String | The name of the ticket type.                         |

## Output

| Item                 | Format | Description                  |
|----------------------|--------|------------------------------|
| EditTicketTypeResult | GUID   | The GUID of the ticket type. |
