---
uid: GetTicketFields
---

# GetTicketFields

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to retrieve the fields for a particular ticket type (called “domain” in the Ticketing app).

This method can also be used to see which third-party fields are available, and which DataMiner fields are linked to which third-party field (by checking the ExternalFieldName tag in the DMATicketField array).

## Input

| Item         | Format | Description                                           |
|--------------|--------|-------------------------------------------------------|
| connection   | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ticketTypeID | GUID   | The GUID of the ticket type.                          |

## Output

| Item | Format | Description |
|--|--|--|
| GetTicketFieldsResult | Array of [DMATicketField](xref:DMATicketField) | Array containing two sets of DMATicketField entries, with the fields for this ticket type in DataMiner, and the fields for the corresponding third-party ticket type, respectively. |
