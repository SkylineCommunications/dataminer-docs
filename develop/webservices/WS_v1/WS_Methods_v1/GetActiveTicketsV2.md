---
uid: GetActiveTicketsV2
---

# GetActiveTicketsV2

> [!IMPORTANT]
>
> - The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

Use this method to retrieve the active tickets for this DMA, i.e. tickets that are not closed and tickets linked to an active DataMiner alarm. The tickets are retrieved in pages, in descending order.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| pageNumber | Integer | The page number (cf. note below). |
| count | Integer | The number of tickets to be retrieved. |
| filter | Array | An array of various filters that can be used to determine which tickets are retrieved. |
| filter.TicketTypeID | GUID | The GUID of the ticket type (or “domain” in the Ticketing app). |
| filter.Filters | Array of DMATicketFieldValueDisplay | See [DMATicketFieldValueDisplay](xref:DMATicketFieldValueDisplay). |
| filter.Affecting.Value | Array | Array containing the DMA ID, the ID and the name of a DataMiner object. |
| filter.Affecting.Type | String | The type of the affected DataMiner object. Possible values are: "Element", "Service", "Redundancy Group", "Alarm", or "View". |
| filter.SearchText | String | A piece of text used to filter the tickets, similar to the quick filter in the Ticketing app. |

## Output

| Item | Format | Description |
|--|--|--|
| GetActiveTicketsV2Result | Array | Array of [DMATicket](xref:DMATicket), with an additional *HasNextPage* field indicating if another page of tickets is available. |

> [!NOTE]
> As there can be a large number of tickets, this method makes use of paging, so that you do not have to download all tickets at once. To get the first page of tickets, execute the method with *PageNumber* = 0, and *Count* equaling the number of tickets you want to retrieve on one page (e.g. 50). In the response, the *HasNextPage* indicates if there is another page after the current page.
