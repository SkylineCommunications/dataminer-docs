---
uid: GetJobFieldOptions
---

# GetJobFieldOptions

Use this method to retrieve the drop-down options for a specific job field.

## Input

| Item       | Format  | Description                                                |
|------------|---------|------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .       |
| fieldID    | String  | The ID of the job field.                                   |
| PageSize   | Integer | The number of options retrieved.                           |
| Filter     | String  | Case-insensitive filter on the display name of the options |

## Output

| Item                      | Format                                                                             | Description                                                                                                            |
|---------------------------|------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| GetJobFieldOptionsRe­sult | [DMAJobFieldPossibleValues](xref:DMAJobFieldPossibleValues) | The drop-down options for the specified job field, along with a boolean indicating whether more options are available. |

