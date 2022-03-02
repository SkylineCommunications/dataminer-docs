---
uid: GetJobSuggestions
---

# GetJobSuggestions

Use this method to retrieve job suggestions matching a particular filter.

## Input

| Item                | Format                     | Description                                                                            |
|---------------------|----------------------------|----------------------------------------------------------------------------------------|
| Connection          | String                     | The connection ID. See [ConnectApp](xref:ConnectApp).                                   |
| DomainID            | String                     | The ID of the job domain.                                                              |
| Filter.SearchText   | String                     | The text that the job suggestions should match.                                        |
| Filter.FieldFilters | Array of DMAJobFieldFilter | See [DMAJobFieldFilter](xref:DMAJobFieldFilter).                |
| Filter.DateFrom     | Long integer               | The earliest date the jobs in the job suggestions can be planned.                      |
| Filter.DateTill     | Long integer               | The latest date the jobs in the job suggestions can be planned.                        |
| Filter.CurrentPage  | Integer                    | The ID of the page of suggestions to be retrieved, in case there are multiple pages.   |
| Filter.PageSize     | Integer                    | The size of the page of suggestions to be retrieved, in case there are multiple pages. |
| Amount              | Integer                    | The number of suggestions that should be retrieved.                                    |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobSuggestionsResult | Array of DMAJobSuggestion (see [DMAJobSuggestion](xref:DMAJobSuggestion)) | The job suggestions matching the filter. |
