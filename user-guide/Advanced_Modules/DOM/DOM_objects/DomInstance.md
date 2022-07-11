---
uid: DomInstance
---

# DomInstance object

A *DomInstance* object contains the sections linked to the section definitions. These sections then contain a field value for each field descriptor defined in the section definitions.

![Object relation diagram](~/user-guide/images/DOM_Object_Relations_Simplified_DomInstance.jpg)

## Properties

The table below lists the properties of the *DomInstance* object. It also indicates whether a property can be used for filtering using the *DomInstanceExposers*.

| Property | Type | Filterable | Description |
| ID | DomInstanceId | Yes | The ID of the DOM instance. |
| DomDefinitionId | DomDefinitionId | Yes | The ID of the DOM definition that this instance is linked to. |
| Sections | List\<Section> | SectionIDs, SectionDefinitionIDs and FieldValues | Contains the required or allowed section definitions. |
| Name | string | Yes | The name of the DOM instance, which is updated by the DOM manager on every create or update action using the *DomInstanceNameDefinition* in the *ModuleSettings*. |
| StatusId | string | Yes | The ID of the current status of this DOM instance (if statuses are used). |

## Requirements

To **create or update** a *DomInstance* object:

- The DOM instance must have a link to an existing DOM definition.

- The DOM instance must contain a valid section for each *SectionDefinitionLink* defined on the linked DOM definition (if that *SectionDefinitionLink* is not marked as optional or soft deleted).

- The sections on the DOM instance must contain the correct number of field values that also have the correct type.

## Errors

When something goes wrong during the CRUD actions, the *TraceData* can contain one or more *DomInstanceErrors*. Below is a list of all possible *ErrorReasons*:

| Reason | Description |
| DomInstanceSectionInvalidFieldValueTypes | Attempted to create or update a DOM instance with a field value that does not match the type of its field descriptor. Available properties: *DomInstance*, *Section*, *FieldValue*, *FieldDescriptor* |
| DomInstanceDoesNotContainAllRequiredFieldsForSectionDefinition | The given DOM instance had a section that did not contain a field value for every non-optional field descriptor of its section definition. Available properties: *DomInstance*, *Section*, *FieldDescriptor* |
| DomInstanceRequiresLinkToValidDomDefinition | The DOM instance has no valid and/or existing DOM definition ID configured. Available properties: *DomInstance*. |
| SectionsUsedInDomInstanceDoNotMatchRequirementsOfDomDefinition | The DOM instance does not contain at least one section for each section definition defined on the DOM definition or contains sections for section definitions that are not defined on that DOM definition. Available properties: *DomInstance*, *DomDefinition*, *MissingSections*, *InvalidSections* |
| DomInstanceDoesNotContainRequiredModuleSections | The DOM instance does not contain exactly one section for each required section definition defined for this module. Available properties: *DomInstance*, *MissingSections*, *InvalidSections* |

The errors below are related to the status system. For each error, the *DomInstanceId*, *DomInstanceName*, and *StatusId* properties will be filled in alongside any others that are mentioned in the description.

| Reason | Description |
| DomInstanceContainsInvalidStatus | The DOM instance contains a status ID that cannot be found on the linked DOM behavior definition. *StatusId* contains the invalid status. |
| DomInstanceHasMissingRequiredFieldsForCurrentStatus | The DOM instance does not contain all fields that are required for the status it is currently in (or transitioning to). *AssociatedFields* contains the *SectionDefinitionID* and *FieldDescriptorID* combos of the missing fields. |
| DomInstanceHasInvalidFieldsForCurrentStatus | The DOM instance contains fields that are required but are not valid according to at least one validator. If there are multiple values for the same section definition and field descriptor, only one entry will be included. *AssociatedFields* contains the *SectionDefinitionID* and *FieldDescriptorID* combos of the invalid fields. |
| ReadOnlyFieldsChangedForCurrentStatus | There is at least one field value marked as read-only for the current status that was changed. *AssociatedFields* contains the *SectionDefinitionID* and *FieldDescriptorID* combos of the read-only fields that were changed. |
| DomInstanceContainsUnknownFieldsForCurrentStatus | There is at least one field value defined on the DOM instance for which no link could be found in the associated DOM behavior definition for the current status. *AssociatedFields* contains the *SectionDefinitionID* and *FieldDescriptorID* combos of the unknown fields. |
| StatusChangeNotAllowedForNormalUpdate | The status of the DOM instance was changed during a normal update request. It can only be updated by using the specific transition request. |

## Security

Security checks are done on CRUD actions when permission flags are configured on the *DomManagerSecuritySettings* (in the [ModuleSettings](xref:DOM_ModuleSettings)).

- To read DOM instances, the user needs the permission flag defined by *DomManagerSecuritySettings.ViewPermission*.

- To create or update DOM instances, the user needs the permission flag defined by *DomManagerSecuritySettings.CreateAndUpdateDomInstancePermission*.

- To delete DOM instances, the user needs the permission flag defined by *DomManagerSecuritySettings.DeleteDomInstancePermission*.

## Notes

It is possible to let DataMiner trigger a script when doing CRUD actions on a DOM instance. See the ModuleSettings page for more info (ExecuteScriptOnDomInstanceActionSettings).
As stated in the table, the 'Name' property is updated by the DomManager. When you assign your own value, it will be overwritten when saving.

## History

Changes to the field values are stored in *HistoryChanges*. For more information, see [DOM history](xref:DOM_history).
