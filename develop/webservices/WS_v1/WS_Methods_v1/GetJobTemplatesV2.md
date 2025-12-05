---
uid: GetJobTemplatesV2
---

# GetJobTemplatesV2

Use this method to retrieve all the job templates available in a specific domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID   | String | The domain ID.                                       |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobTemplatesV2Result | Array of [DMAJobTemplate](xref:DMAJobTemplate) | The available job templates. |
