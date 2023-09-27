---
uid: DMASectionDomainConfig
---

# DMASectionDomainConfig

| Item | Format | Description |
|--|--|--|
| SectionDefinitionID | String | The ID of the job section definition. |
| SectionDefinitionInfo.Icon | String | The name of the icon associated with this section. |
| SectionDefinitionInfo.Color | Array of int | The background color of the section, in RGB format. |
| SectionDefinitionInfo.Column | Integer | The position of the column containing this section in the Jobs app layout. |
| SectionDefinitionInfo.Index | Integer | The row containing this section in the Jobs app layout. |
| SectionDefinitionInfo.MultiSelectionFilters | Array of string | The IDs of the drop-down fields that are configured as filter, if available. |
| SectionDefinitionInfo.ShowInListView | Array of string | Determines whether the section is shown as a column in the list of jobs in the Jobs app. |
| SectionDefinitionInfo.FieldIndices | Array of string | Determines the position and order of the fields in the section. |
| SectionDefinitionInfo.CustomSectionDefinitionExtensionID | String | The section definition ID of the section definition that is created in case a field is added to the default section. |
| SectionDefinitionInfo.AllowMultipleInstances | Boolean | Indicates whether multiple instances of the job section will be allowed. |
