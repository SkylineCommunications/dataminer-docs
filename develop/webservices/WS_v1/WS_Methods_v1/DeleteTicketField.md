---
uid: DeleteTicketField
---

# DeleteTicketField

Use this method to delete a specified field from a ticket type (called “domain” in the Ticketing app).

> [!NOTE]
> The *State* field cannot be deleted.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item         | Format | Description                                          |
|--------------|--------|------------------------------------------------------|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | GUID   | The GUID of the ticket type.                         |
| fieldName    | String | The name of the ticket field you want to delete.     |

## Output

None.
