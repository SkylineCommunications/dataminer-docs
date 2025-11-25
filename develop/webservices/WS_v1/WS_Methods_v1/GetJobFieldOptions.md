---
uid: GetJobFieldOptions
---

# GetJobFieldOptions

Use this method to retrieve the dropdown options for a specific job field.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format  | Description                                                |
|------------|---------|------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).      |
| fieldID    | String  | The ID of the job field.                                   |
| pageSize   | Integer | The number of options retrieved.                           |
| filter     | String  | Case-insensitive filter on the display name of the options |

## Output

| Item | Format | Description |
|--|--|--|
| GetJobFieldOptionsResult | [DMAJobFieldPossibleValues](xref:DMAJobFieldPossibleValues) | The dropdown options for the specified job field, along with a boolean indicating whether more options are available. |
