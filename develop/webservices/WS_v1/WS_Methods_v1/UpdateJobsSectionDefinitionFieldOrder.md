---
uid: UpdateJobsSectionDefinitionFieldOrder
---

# UpdateJobsSectionDefinitionFieldOrder

Use this method to save the configuration of a job section domain.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item                | Format          | Description                                           |
|---------------------|-----------------|-------------------------------------------------------|
| connection          | String          | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID            | String          | The jobs domain ID.                                   |
| sectionDefinitionID | String          | The section definition ID.                            |
| fieldOrder          | Array of string | The section definition fields in the desired order.   |

## Output

None.
