---
uid: CreateJobTemplate
---

# CreateJobTemplate

Use this method to create a job template.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format         | Description                                                        |
|------------|----------------|--------------------------------------------------------------------|
| connection | String         | The connection string. See [ConnectApp](xref:ConnectApp).          |
| template   | DMAJobTemplate | See [DMAJobTemplate](xref:DMAJobTemplate).                         |

## Output

| Item                     | Format | Description                         |
|--------------------------|--------|-------------------------------------|
| CreateJobTemplateResult  | String | The ID of the created job template. |
