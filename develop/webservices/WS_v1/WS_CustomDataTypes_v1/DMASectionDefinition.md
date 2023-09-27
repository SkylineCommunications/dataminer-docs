---
uid: DMASectionDefinition
---

# DMASectionDefinition

| Item | Format | Description |
|--|--|--|
| Name | String | The name of the job section. |
| ID | String | The ID of the job section. |
| ReadOnly | Boolean | Indicates whether the job section can be modified. |
| IsHidden | Boolean | Indicates whether the job section is hidden. |
| Fields | Array of DMASectionDefinitionField | See [DMASectionDefinitionField](xref:DMASectionDefinitionField). |
| BookingLinkInfo.BookingManager | Array of int | The DataMiner ID, element ID and name of the Booking Manager element that is used, in case the section is linked to a booking. |
| BookingLinkInfo.BookingScript | String | The script that should be executed when a user clicks an action in the job section, in case the section is linked to a booking. |
| Info.Icon | String | The name of the icon associated with this section. |
| Info.Color | Array of int | The background color of the section, in RGB format. |
| Info.Column | Integer | The column of the Jobs app containing this job section. |
| Info.Index | Integer | The row of the Jobs app containing this job section. |
| Info.MultiSelectionFilters | Array of string | The IDs of the drop-down fields that are configured as filter, if available. |
| Info.ShowInListView | Array of string | Determines whether the section is shown as a column in the list of jobs in the Jobs app. |
| Info.FieldIndices | Array of string | Determines the position and order of the fields in the section. |
| CustomSectionDefinitionExtensionID | String | The section definition ID of the section definition that is created in case a field is added to the default section. |
| AllowMultipleInstances | Boolean | Indicates whether multiple instances of the job section will be allowed. |
