---
uid: DMASectionDomainConfig
---

# DMASectionDomainConfig

| Item                                                          | Format          | Description                                                                                                          |
|---------------------------------------------------------------|-----------------|----------------------------------------------------------------------------------------------------------------------|
| SectionDefinitionID                                           | String          | The ID of the job section definition.                                                                                |
| SectionDefinitionInfo.<br>Icon                                | String          | The name of the icon associated with this section.                                                                   |
| SectionDefinitionInfo.<br>Color                               | Array of int    | The background color of the section, in RGB format.                                                                  |
| SectionDefinitionInfo.<br>Column                              | Integer         | The position of the column containing this section in the Jobs app layout.                                           |
| SectionDefinitionInfo.<br>Index                               | Integer         | The row containing this section in the Jobs app layout.                                                              |
| SectionDefinitionInfo.<br>MultiSelectionFilters               | Array of string | The IDs of the drop-down fields that are configured as filter, if available.                                         |
| SectionDefinitionInfo.<br>ShowInListView                      | Array of string | Determines whether the section is shown as a column in the list of jobs in the Jobs app.                             |
| SectionDefinitionInfo.<br>FieldIndices                        | Array of string | Determines the position and order of the fields in the section.                                                      |
| SectionDefinitionInfo.<br>CustomSectionDefini­tionExtensionID | String          | The section definition ID of the section definition that is created in case a field is added to the default section. |
| SectionDefinitionInfo.<br>AllowMultipleInstances              | Boolean         | Indicates whether multiple instances of the job section will be allowed.                                             |
