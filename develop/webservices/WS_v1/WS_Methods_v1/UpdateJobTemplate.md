---
uid: UpdateJobTemplate
---

# UpdateJobTemplate

Use this method to update an existing job template.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format         | Description                                               |
|------------|----------------|-----------------------------------------------------------|
| connection | String         | The connection string. See [ConnectApp](xref:ConnectApp). |
| template   | [DMAJobTemplate](xref:DMAJobTemplate) | The job template configuration.    |

## Output

| Item                    | Format | Description                         |
|-------------------------|--------|-------------------------------------|
| UpdateJobTemplateResult | String | The ID of the updated job template. |
