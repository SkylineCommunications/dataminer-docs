---
uid: AddOrUpdateJobsSectionDefinitionField
---

# AddOrUpdateJobsSectionDefinitionField

Use this method to add or update a job section definition field.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The domain ID. |
| sectionDefinitionID | String | The ID of the job section definition. |
| field | Array | See [DMASectionDefinitionField](xref:DMASectionDefinitionField). |
| possibleValueUpdates | Array of DMAJobFieldPossibleValueUpdate | Arrays consisting of:<br> - OldValue: The old value of the field.<br> - NewValue: The new value of the field.<br> - Deleted: Indicates if the field should be deleted.<br> - IsHidden: Indicates if the field is hidden. |

## Output

| Item | Format | Description |
|--|--|--|
| AddOrUpdateJobsSectionDefinitionFieldResult | Array of FieldID, FieldIsSoftDeleted and OptionIsSoftDeleted | The ID of the added or updated field, along with two booleans indicating whether the field is hidden because it was deleted and whether an option of the field is hidden because it was deleted (in case of a drop-down field). |
