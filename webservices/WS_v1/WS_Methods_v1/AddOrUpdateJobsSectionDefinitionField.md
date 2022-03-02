---
uid: AddOrUpdateJobsSectionDefinitionField
---

# AddOrUpdateJobsSectionDefinitionField

Use this method to add or update a job section definition field.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DomainID | String | The domain ID. |
| SectionDefinitionID | String | The ID of the job section definition. |
| Field | Array | See [DMASectionDefinitionField](xref:DMASectionDefinitionField). |
| possibleValueUpdates | Array of DMAJob­FieldPossibleValue­Update | Arrays consisting of:<br> -  OldValue: The old value of the field.<br> -  NewValue: The new value of the field.<br> -  Deleted: Indicates if the field should be deleted.<br> -  IsHidden: Indicates if the field is hidden? |

## Output

| Item | Format | Description |
|--|--|--|
| AddOrUpdateJobsSec­tionDefinitionFieldResult | Array of FieldID, FieldIs­SoftDeleted and Option­IsSoftDeleted | The ID of the added or updated field, along with two booleans indicating whether the field is hidden because it was deleted and whether an option of the field is hidden because it was deleted (in case of a drop-down field). |
