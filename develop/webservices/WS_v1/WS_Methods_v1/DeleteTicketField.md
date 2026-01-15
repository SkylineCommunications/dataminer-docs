---
uid: DeleteTicketField
---

# DeleteTicketField

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.6.0/10.6.2 onwards.<!-- RN 44371+44373 -->
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to delete a specified field from a ticket type (called “domain” in the Ticketing app).

> [!NOTE]
> The *State* field cannot be deleted.

## Input

| Item         | Format | Description                                          |
|--------------|--------|------------------------------------------------------|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | GUID   | The GUID of the ticket type.                         |
| fieldName    | String | The name of the ticket field you want to delete.     |

## Output

None.
