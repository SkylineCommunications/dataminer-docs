---
uid: DMATicketField
---

# DMATicketField

| Item | Format | Description |
|--|--|--|
| Name | String | The system name of the field |
| DisplayName | String | The name of the field that is displayed for the user. |
| Type | String | The type of field. The following values are possible: "Boolean", "Double", "DateTime", "DataMiner Object", "DropDown", "Email", "Integer", "Text", "Url", "User", or "State". |
| PossibleValues | Array of [DMATicketFieldPossibleValue](xref:DMATicketFieldPossibleValue) | In case a field is of a type that allows the user to select different values, this array contains the different values. |
| ShowColumnInTicketOverview | Boolean | Determines whether the field is displayed as a column in the Ticketing app. |
| SingleSelectionFilter | Boolean | Determines whether it will be possible to use the field as a single selection filter in the Ticketing overview. |
| MultiSelectionFilter | Boolean | Determines whether it will be possible to use this field as a multiple selection filter in the Ticketing overview. |
| IsRequired | Boolean | Determines whether this field must always be filled in. |
| DefaultValue | String | The default value of the ticket, if applicable. |
| ExternalFieldName | String | The name of the corresponding field in a third-party ticketing system, if any. |
| IsExternalMaster | Boolean | Determines whether the value found in the DataMiner ticket is kept when it is merged with a ticket from a third-party system. |
| AlarmProperty | String | The alarm property that the ticket field is linked to. |
| CustomAlarmPropertyName | String | The custom alarm property that the ticket field is linked to. |
| CustomAlarmPropertyType | String | The type of custom alarm property (element, view, alarm, etc.) that the field is linked to. |
| StaticTextValue | String | The static text value assigned to the field, if any. |
| Concatenations | Array of DMATicketFieldConcatItem | Concatenation of multiple alarm fields and static text, if configured. Note that this requires the *CorrelationTicketAction* soft-launch flag. See [Soft-launch options](xref:SoftLaunchOptions). |
| IsSearchDisplayField | Boolean | Determines whether the field is displayed when users search for tickets. |
