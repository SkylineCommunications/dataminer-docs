---
uid: GetJobSuggestions
---

# GetJobSuggestions

Use this method to retrieve job suggestions matching a particular filter.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item                | Format                     | Description                                                       |
|---------------------|----------------------------|-------------------------------------------------------------------|
| connection          | String                     | The connection ID. See [ConnectApp](xref:ConnectApp).             |
| domainID            | String                     | The ID of the job domain.                                         |
| filter.SearchText   | String                     | The text that the job suggestions should match.                   |
| filter.FieldFilters | Array of DMAJobFieldFilter | See [DMAJobFieldFilter](xref:DMAJobFieldFilter).                  |
| filter.DateFrom     | Long integer               | The earliest date the jobs in the job suggestions can be planned. |
| filter.DateTill     | Long integer               | The latest date the jobs in the job suggestions can be planned.   |
| filter.DateOccurrence | String                   | OCCUR or START or END                                             |
| filter.CurrentPage  | Integer                    | The ID of the page of suggestions to be retrieved, in case there are multiple pages.   |
| filter.PageSize     | Integer                    | The size of the page of suggestions to be retrieved, in case there are multiple pages. |
| filter.Order        | String                     | ASC or DESC                                                       |
| filter.OrderBy      | [DMAJobFieldFilter](xref:DMAJobFieldFilter) | The field by which the list should be order.     |
| amount              | Integer                    | The number of suggestions that should be retrieved.               |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobSuggestionsResult | Array of [DMAJobSuggestion](xref:DMAJobSuggestion) | The job suggestions matching the filter. |
