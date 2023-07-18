---
uid: DomInstance
---

# DomInstance object

A `DomInstance` object contains the `Sections` linked to the `SectionDefinitions`. These sections then contain a `FieldValue` for each `FieldDescriptor` defined in the `SectionDefinitions`.

![Object relation diagram](~/user-guide/images/DOM_Object_Relations_Simplified_DomInstance.jpg)

## Properties

The table below lists the properties of the `DomInstance` object. It also indicates whether a property can be used for filtering using the `DomInstanceExposers`.

> [!NOTE]
> From DataMiner 10.3.2/10.4.0 onwards, the `DomInstance` object also has [the *ITrackBase* properties](xref:DOM_objects#itrackbase-properties).

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | DomInstanceId | Yes | The ID of the `DomInstance`. |
| DomDefinitionId | DomDefinitionId | Yes | The ID of the `DomDefinition` that this instance is linked to. |
| Sections | List\<Section> | Yes | The `Sections` that contain the actual values for the `FieldDescriptors` wrapped in `FieldValues` |
| Name | string | Yes | The name of the `DomInstance`, which is updated by the `DomManager` on every create or update action using the `DomInstanceNameDefinition` in the `ModuleSettings`. |
| StatusId | string | Yes | The ID of the current status of this `DomInstance` (if statuses are used). |

## Requirements

To **create or update** a `DomInstance`:

- The `DomInstance` must have a link to an existing `DomDefinition`.

- The `DomInstance` must contain a valid `Section` for each `SectionDefinitionLink` defined on the linked `DomDefinition` (if that `SectionDefinitionLink` is not marked as optional or soft deleted).

- The sections on the `DomInstance` must contain the correct number of `FieldValues` that also have the correct type.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `DomInstanceErrors`. Below is a list of all possible `ErrorReasons`:

| Reason | Description |
|--|--|
| DomInstanceSectionInvalidFieldValueTypes | Attempted to create or update a `DomInstance` with a `FieldValue` that does not match the type of its `FieldDescriptor`. Available properties: *DomInstance*, *Section*, *FieldValue*, *FieldDescriptor* |
| DomInstanceDoesNotContainAllRequiredFieldsForSectionDefinition | The given `DomInstance` had a `Section` that did not contain a `FieldValue` for every non-optional `FieldDescriptor` of its `SectionDefinition`. Available properties: *DomInstance*, *Section*, *FieldDescriptor* |
| DomInstanceRequiresLinkToValidDomDefinition | The `DomInstance` has no valid and/or existing `DomDefinitionID` configured. Available properties: *DomInstance*. |
| SectionsUsedInDomInstanceDoNotMatchRequirementsOfDomDefinition | The `DomInstance` does not contain at least one `Section` for each `SectionDefinition` defined on the `DomDefinition` or contains `Sections` for `SectionDefinitions` that are not defined on that `DomDefinition`. Available properties: *DomInstance*, *DomDefinition*, *MissingSections*, *InvalidSections* |
| DomInstanceDoesNotContainRequiredModuleSections | The `DomInstance` does not contain exactly one `Section` for each required `SectionDefinition` defined for this module. Available properties: *DomInstance*, *MissingSections*, *InvalidSections* |
| MultipleSectionsNotAllowedForSectionDefinition | The `DomInstance` contains more than one `Section` for a `SectionDefinition` that does not allow multiple `Sections` according to either the `SectionDefinitionLink` or the `DomStatusSectionDefinitionLink`. Available properties: *InvalidSections* |
| ValueForSoftDeletedFieldNotAllowed | Attempted to create or update a `DomInstance` with one or multiple field values that are part of a soft-deleted `FieldDescriptor`, `SectionDefinitionLink`, or `StatusSectionDefinitionLink`. Available properties: *DommInstanceId*, *AssociatedFields* |

The errors below are solely related to the status system. For each error, the *DomInstanceId*, *DomInstanceName*, and *StatusId* properties will be filled in alongside any others that are mentioned in the description.

| Reason | Description |
|--|--|
| DomInstanceContainsInvalidStatus | The `DomInstance` contains a status ID that cannot be found on the linked `DomBehaviorDefinition`. *StatusId* contains the invalid status. |
| DomInstanceHasMissingRequiredFieldsForCurrentStatus | The `DomInstance` does not contain all fields that are required for the status it is currently in (or transitioning to). *AssociatedFields* contains the `SectionDefinitionID` and `FieldDescriptorID` combos of the missing fields. |
| DomInstanceHasInvalidFieldsForCurrentStatus | The `DomInstance` contains fields that are required but are not valid according to at least one validator. If there are multiple values for the same `SectionDefinition` and `FieldDescriptor`, only one entry will be included. *AssociatedFields* contains the `SectionDefinitionID` and `FieldDescriptorID` combos of the invalid fields. |
| ReadOnlyFieldsChangedForCurrentStatus | There is at least one `FieldValue` marked as read-only for the current status that was changed. *AssociatedFields* contains the `SectionDefinitionID` and `FieldDescriptorID` combos of the read-only fields that were changed. |
| DomInstanceContainsUnknownFieldsForCurrentStatus | There is at least one `FieldValue` defined on the `DomInstance` for which no link could be found in the associated `DomBehaviorDefinition` for the current status. *AssociatedFields* contains the `SectionDefinitionID` and `FieldDescriptorID` combos of the unknown fields. |
| StatusChangeNotAllowedForNormalUpdate | The status of the `DomInstance` was changed during a normal update request. It can only be updated by using the specific transition request. |

## Notes

- It is possible to let DataMiner trigger a script when doing CRUD actions on a `DomInstance`. For more information, see [ModuleSettings](xref:DOM_ModuleSettings) (ExecuteScriptOnDomInstanceActionSettings).

- The *Name* property is updated by the `DomManager`. If you assign your own value, it will be overwritten when the `DomInstance` is saved.

## History

Changes to the `FieldValues` are stored in `HistoryChanges`. For more information, see [DOM history](xref:DOM_history).
