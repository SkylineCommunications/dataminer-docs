---
uid: UpdateJobsSectionDefinition
---

# UpdateJobsSectionDefinition

Use this method to update a job section definition.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection string. See [ConnectApp](xref:ConnectApp). |
| domainID | String | The domain ID. |
| sectionDefinitionID | String | The ID of the job section definition. |
| name | String | The name of the job section definition. |
| bookingLinkInfo.BookingManager | Array of int | The DataMiner ID, element ID and name of the Booking Manager element that should be used, in case the section is linked to a booking. |
| bookingLinkInfo.BookingScript | String | The script that should be executed when a user clicks an action in the job section, in case the section is linked to a booking. |
| info.Icon | String | The name of the icon associated with this section. |
| info.Color | Array of int | The background color of the section, in RGB format. |
| info.Column | Integer | The position of the column containing this section in the Jobs app layout. |
| info.Index | Integer | The row containing this section in the Jobs app layout. |
| info.FieldIndices | Array of string | Determines the position and order of the fields in the section. |
| info.MultiSelectionFilters | Array of string | The IDs of the drop-down fields that are configured as filter, if available. |
| info.ShowInListView | Array of string | Determines whether the section is shown as a column in the list of jobs in the Jobs app. |
| info.allowMultipleInstances | Boolean | Indicates whether multiple instances of the job section will be allowed. |

## Output

| Item                               | Format | Description                                   |
|------------------------------------|--------|-----------------------------------------------|
| UpdateJobsSectionDefinitionResult | String | The ID of the updated job section definition. |
