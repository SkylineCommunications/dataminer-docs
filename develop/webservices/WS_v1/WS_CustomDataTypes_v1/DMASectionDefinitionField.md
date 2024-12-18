---
uid: DMASectionDefinitionField
---

# DMASectionDefinitionField

| Item | Format  | Description |
|---|---|---|
| ID                     | String  | The ID of the job section definition field. |
| Name                   | String  | The name of the job section definition field. |
| Type                   | String  | Type that the value must have. The following types are supported: *string*, *double*, *long*, *DateTime*, *TimeSpan* and *bool*. |
| IsMultiSelectionFilter | Boolean | Determines whether multiple instances of the section are allowed. |
| ShowInListView         | Boolean | Determines whether the field is shown in the list view of the Jobs app. |
| IsRequired             | Boolean | Determines whether filling in this field is mandatory when a job is created. |
| ReadOnly               | Boolean | Indicates whether the field is part of the default section definition. |
| AutoIncrementPrefix    | String  | For an “auto increment” section definition field, this field can optionally contain a prefix for the auto increment counter. |
| AutoIncrementSuffix    | String  | For an “auto increment” section definition field, this field can optionally contain a suffix for the auto increment counter. |
| IsReadOnly             | Boolean | Determines whether the client can change this field. |
| IsHidden               | Boolean | Determines whether the field is hidden. |
| Tooltip                | String  | The tooltip that should be displayed for this field. |
