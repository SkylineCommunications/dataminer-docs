---
uid: EditTicketField
---

# EditTicketField

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to edit a specific ticket field for a specific ticket type (called “domain” in the Ticketing app).

## Input

| Item         | Format               | Description                                                    |
|--------------|----------------------|----------------------------------------------------------------|
| connection   | String               | The connection ID. See [ConnectApp](xref:ConnectApp).          |
| ticketTypeID | GUID                 | The GUID of the ticket type to which you are adding the field. |
| field        | DMATicketField array | See [DMATicketField](xref:DMATicketField).                     |

> [!NOTE]
> The field type *State* cannot be edited. As such, if a field is of type *State*, it is not possible to change the type, and if a field is not of type *State*, it is not possible to change its type to *State*.

## Output

None.
