---
uid: EditTicketField
---

# EditTicketField

Use this method to edit a specific ticket field for a specific ticket type (called “domain” in the Ticketing app).

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an indexing database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/user-guide/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item         | Format               | Description                                                       |
|--------------|----------------------|-------------------------------------------------------------------|
| connection   | String               | The connection ID. See [ConnectApp](xref:ConnectApp).              |
| ticketTypeID | GUID                 | The GUID of the ticket type to which you are adding the field.    |
| field        | DMATicketField array | See [DMATicketField](xref:DMATicketField). |

> [!NOTE]
> The field type *State* cannot be edited. As such, if a field is of type *State*, it is not possible to change the type, and if a field is not of type *State*, it is not possible to change its type to *State*.

## Output

None.
