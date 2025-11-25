---
uid: GetHistoryTickets
---

# GetHistoryTickets

This method is deprecated. Use the [GetHistoryTicketsV2](xref:GetHistoryTicketsV2) method instead.

> [!CAUTION]
>
> - DataMiner Ticketing is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - DataMiner Ticketing is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| utcStartTime | Long integer | The start time of the time span for which tickets should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the time span for which tickets should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| pageSessionID | Long integer | The page session ID (cf. note below). |
| pageNumber | Integer | The page number (cf. note below). |
| count | Integer | The number of tickets to be retrieved. |
| filter | Array | An array of various filters that can be used to determine which tickets are retrieved. |
| filter.TicketTypeID | GUID | The GUID of the ticket type (or “domain” in the Ticketing app). |
| filter.Filters | Array of [DMATicketFieldValueDisplay](xref:DMATicketFieldValueDisplay) | The display name, name and value of a field that is used to filter the retrieved tickets. |
| filter.Affecting.Value | Array | Array containing the DMA ID, ID and name of a DataMiner object. |
| filter.Affecting.Type | String | The type of the affected DataMiner object. |
| filter.SearchText | String | A piece of text used to filter the tickets, similar to the quick filter in the Ticketing app. |

> [!NOTE]
> As there can be a large number of tickets, this method makes use of paging, so that you do not have to download all tickets at once. To get the first page of tickets, execute the method with *PageSessionID* = 0, *PageNumber* = 0, and *Count* equalling the number of tickets you want to retrieve on one page (e.g. 50). In the response, the *PageSessionID* will be filled in, and the total number of tickets will be indicated.
>
> With this result, you can then:
>
> - Request the next page, by executing the method again, using the *PageSessionID* from the first result, but keeping the same *PageNumber* and *Count*.
> - Request for example the fifth next page, by executing the method again, while specifying *Pagenumber* = 4 and *PageSessionID* = 0. (The *Count* remains unchanged.) This will return a new *PageSessionID* that can be used to get the next pages.

## Output

| Item | Format | Description |
|--|--|--|
| GetHistoryTicketsResult | Array | Array of [DMATicket](xref:DMATicket), with the page session ID and the total number of tickets. |
