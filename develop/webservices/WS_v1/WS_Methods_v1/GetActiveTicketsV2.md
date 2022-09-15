---
uid: GetActiveTicketsV2
---

# GetActiveTicketsV2

Use this method to retrieve the active tickets for this DMA, i.e. tickets that are not closed and tickets linked to an active DataMiner alarm. The tickets are retrieved in pages, in descending order.

> [!NOTE]
>
> - From DataMiner 10.0.13 onwards, this method should be used instead of the [GetActiveTickets](xref:GetActiveTickets) method.
> - DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

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
