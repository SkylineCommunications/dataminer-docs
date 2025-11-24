---
uid: DeleteJobsDomain
---

# DeleteJobsDomain

Use this method to delete a jobs domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID   | String | The ID of the job domain.                            |

## Output

| Item                   | Format  | Description                                                 |
|------------------------|---------|-------------------------------------------------------------|
| DeleteJobsDomainResult | Boolean | Returns “true” if the jobs domain was deleted successfully. |
