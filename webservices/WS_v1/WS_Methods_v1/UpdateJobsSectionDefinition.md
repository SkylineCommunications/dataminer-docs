---
uid: UpdateJobsSectionDefinition
---

# UpdateJobsSectionDefinition

Use this method to update a job section definition.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| DomainID | String | The domain ID. |
| SectionDefinitionID | String | The ID of the job section definition. |
| Name | String | The name of the job section definition. |
| BookingLinkInfo.BookingManager | Array of int | The DataMiner ID, element ID and name of the Booking Manager element that should be used, in case the section is linked to a booking. |
| BookingLinkInfo.BookingScript | String | The script that should be executed when a user clicks an action in the job section, in case the section is linked to a booking. |
| Info.Icon | String | The name of the icon associated with this section. |
| Info.Color | Array of int | The background color of the section, in RGB format. |
| Info.Column | Integer | The position of the column containing this section in the Jobs app layout. |
| Info.Index | Integer | The row containing this section in the Jobs app layout. |
| Info.MultiSelectionFilters | Array of string | The IDs of the drop-down fields that are configured as filter, if available. |
| Info.ShowInListView | Array of string | Determines whether the section is shown as a column in the list of jobs in the Jobs app. |
| Info.FieldIndices | Array of string | Determines the position and order of the fields in the section. |
| CustomSectionDefini­tionExtensionID | String | The section definition ID of the section definition that is created in case a field is added to the default section. |
| AllowMultipleInstances | Boolean | Indicates whether multiple instances of the job section will be allowed. |

## Output

| Item                               | Format | Description                                   |
|------------------------------------|--------|-----------------------------------------------|
| UpdateJobsSection­DefinitionResult | String | The ID of the updated job section definition. |
