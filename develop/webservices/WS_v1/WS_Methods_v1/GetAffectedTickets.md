---
uid: GetAffectedTickets
---

# GetAffectedTickets

Use this method to retrieve the tickets linked to a particular DataMiner resource, e.g. an element or a service. The tickets are retrieved in pages, in descending order.

> [!NOTE]
> DataMiner Ticketing requires a Cassandra database as well as a specific license. From DataMiner 10.0.13 onwards, it also requires an Elasticsearch database. For more information on acquiring a Ticketing license, contact the Skyline Sales department.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| pageSessionID | Long integer | Obsolete. |
| pageNumber | Integer | The page number (cf. note below). |
| count | Integer | The number of tickets to be retrieved. |
| filter | Array | An array of various filters that can be used to determine which tickets are retrieved. |
| filter.TicketTypeID | GUID | The GUID of the ticket type (or “domain” in the Ticketing app). |
| filter.Filters | Array of DMATicketFieldValueDisplay | The display name, name and value of a field that is used to filter the retrieved tickets. |
| filter.Affecting.Value | Array | Array containing the DMA ID, the ID and the name of a DataMiner object. |
| filter.Affecting.Type | String | The type of the affected DataMiner object. Possible values are: "Element", "Service", "Redundancy Group", "Alarm", or "View". |
| filter.SearchText | String | A piece of text used to filter the tickets, similar to the quick filter in the Ticketing app. |

> [!NOTE]
> As there can be a large number of tickets, this method makes use of paging, so that you do not have to download all tickets at once. To get the first page of tickets, execute the method with *PageNumber* = 0, and *Count* equaling the number of tickets you want to retrieve on one page (e.g. 50). In the response, the *HasNextPage* indicates if there is another page after the current page.

## Output

| Item | Format | Description |
|--|--|--|
| GetAffectedTicketsResult | Array | A list of active tickets for all ticket types (or “domains”), linked to the specified affected DataMiner object, along with an array containing the merged list of the fields of the different ticket types (both DataMiner ticket types and third-party ticket types). |
