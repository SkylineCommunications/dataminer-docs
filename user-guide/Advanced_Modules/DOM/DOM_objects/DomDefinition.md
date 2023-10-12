---
uid: DomDefinition
---

# DomDefinition object

The `DomDefinition` object groups `DomInstance` objects together (as each instance has a link to a definition). It also defines which `SectionDefinitions` can or must be used by the linked `DomInstances`.

## Properties

The table below lists the properties of the `DomDefinition` object. It also indicates whether a property can be used for filtering using the `DomDefinitionExposers`. 

> [!NOTE]
> From DataMiner 10.3.2/10.4.0 onwards, the `DomDefinition` object also has [the *ITrackBase* properties](xref:DOM_objects#itrackbase-properties).

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | DomDefinitionId | Yes | The ID of the `DomDefinition`. |
| Name | string | Yes | The name of the `DomDefinition`. |
| SectionDefinitionLinks | List\<[SectionDefinitionLink](#sectiondefinitionlink)> | Yes | Contains the required/allowed `SectionDefinitions`. |
| VisualStructure | DomDefinitionVisualStructure | No | Contains settings related to the client UI. Most of these do not apply for DOM. This property should be ignored since it will be removed in the near future. |
| DomBehaviorDefinitionId | DomBehaviorDefinitionId | Yes | ID of the `DomBehaviorDefinition` that this `DomDefinition` is linked to. See [DomBehaviorDefinition](xref:DomBehaviorDefinition). |
| ModuleSettingsOverrides | [ModuleSettingsOverrides](#modulesettingsoverrides) | No | Used to override some `ModuleSettings`. See [DomInstanceNameDefinition](xref:DomInstanceNameDefinition). |

### SectionDefinitionLink

This object is also used in the Jobs app. It is used to store a link to a `SectionDefinition` object and to define whether the use of this definition is optional or mandatory.

It also has the *IsSoftDeleted* boolean. See [soft-deletable objects](xref:DOM_objects#soft-deletable-objects).

> [!NOTE]
> From DataMiner version 10.3.0/10.3.3 onwards, the `SectionDefinitionLink` also contains the *AllowMultipleSections* boolean, which can be used to define whether a `DomInstance` can have multiple `Sections` for that specific `SectionDefinition`. In earlier DataMiner versions, it is possible to add multiple `Sections` already, but these are not checked and cannot be used in the UI. When you upgrade to DataMiner 10.3.0/10.3.3, you will need to update any existing `DomDefinitions` with multiple `Sections`.

### ModuleSettingsOverrides

The object contains settings that override the settings defined in the `ModuleSettings`. See [ModuleSettings](xref:DOM_ModuleSettings) for details about the specific settings.

At present, the following setting can be overridden:

- DomInstanceNameDefinition

## Requirements

- To **create or update** a `DomDefinition`, it must contain a `SectionDefinitionLink` for each [ModuleSection](xref:DOM_ModuleSections) defined in the `ModuleSettings`.

- When you **update** the `SectionDefinitionLinks` list of a `DomDefinition`, it is not possible to remove a link when there are already `DomInstances` that have sections for this link. However, you can hide the link from the UI by flagging it as soft deleted.

- A `DomDefinition` can only be deleted when no `DomInstances` are linked to it. You should therefore first delete those before you can delete the `DomDefinition`.

## Errors

When something goes wrong during the CRUD actions, the *TraceData* can contain one or more *DomDefinitionErrors*. Below is a list of all possible *ErrorReasons*:

| Reason | Description |
|--|--|
| DomDefinitionHasLinkedDomInstances | The `DomDefinition` you want to delete has `DomInstances` linked to it. The `DomDefinition` can be retrieved from the *DomDefinition* property. The IDs of the linked `DomInstances` can be retrieved from the *DomInstanceIds* property. |
| SectionDefinitionLinkInUseByDomInstances | The `SectionDefinitionLink` cannot be deleted since this `DomDefinition` is in use by `DomInstances`. Set the *SectionDefinitionLink.IsSoftDeleted* boolean instead. The `DomDefinition` can be retrieved from the *DomDefinition* property. The IDs of the linked `DomInstances` can be retrieved from the *DomInstanceIds* property. The links that could not be deleted can be retrieved from the *SectionDefinitionLinks* property. |
| DomDefinitionDoesNotContainRequiredModuleSectionDefinitions | The `DomDefinition` you want to create or update does not include all required section definition links for this module. The `DomDefinition` can be retrieved from the *DomDefinition* property. The missing `SectionDefinitionIDs` can be retrieved from the *SectionDefinitionIds* property. |
