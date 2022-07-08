---
uid: DomDefinition
---

# DomDefinition object

The *DomDefinition* object groups *DomInstance* objects together (as each instance has a link to a definition). It also defines which section definitions can ir must be used by the linked DOM instances.

## Properties

The table below lists the properties of the *DomDefinition* object. It also indicates whether a property can be used for filtering using the *DomDefinitionExposers*.

| Property | Type | Filterable | Explanation |
| ID | DomDefinitionId | Yes | The ID of the DOM definition. |
| Name | string | Yes | The name of the DOM definition. |
| SectionDefinitionLinks | List\<[SectionDefinitionLink](#sectiondefinitionlink)> | Yes | Contains the required/allowed section definitions. |
| VisualStructure | DomDefinitionVisualStructure | No | Used by the client UI to store info about how things should be visualized. |
| ModuleSettingsOverrides | [ModuleSettingsOverrides](#modulesettingsoverrides) | No | Used to override some *ModuleSettings* settings. |

### SectionDefinitionLink

This object is also used in the Jobs app. It is used to store a link to a *SectionDefinition* object and to define whether the use of this definition is optional or mandatory.

It also has the *IsSoftDeleted* boolean. If this is set to true, sections in a DOM instance for this section definition ID are not required, will no longer be validated, but are still allowed to exist on the DOM instance. The section definition will also no longer be shown in the UI.

### ModuleSettingsOverrides

The object contains settings that override the settings defined in the *ModuleSettings*. See [ModuleSettings](xref:DOM_ModuleSettings) for details about the specific settings.

At present, the following setting can be overridden:

- DomInstanceNameDefinition

## Requirements

- To **create or update** a *DomDefinition* object, it must contain a *SectionDefinitionLink* for each module section definition defined in the *ModuleSettings*.
- When you **update** the *SectionDefinitionLinks* list of a *DomDefinition* object, it is not possible to remove a link when there are already DOM instances that have sections for this link. However, you can hide the link from the UI by flagging it as soft-deleted.
- A *DomDefinition* object can only be deleted when no DOM instances are linked to it. You should therefore first delete those before you can delete the DOM definition.

## Errors

When something goes wrong during the CRUD actions, the *TraceData* can contain one or more *DomDefinitionErrors*. Below is a list of all possible *ErrorReasons*:

| Reason | Description |
| DomDefinitionHasLinkedDomInstances | The DOM definition you want to delete has DOM instances linked to it. The DOM definition can be retrieved from the *DomDefinition* property. The IDs of the linked DOM instances can be retrieved from the *DomInstanceIds* property. |
| SectionDefinitionLinkInUseByDomInstances | The section definition link cannot be deleted since this DOM definition is in use by DOM instances. Set the *SectionDefinitionLink.IsSoftDeleted* boolean instead. The DOM definition can be retrieved from the *DomDefinition* property. The IDs of the linked DOM instances can be retrieved from the *DomInstanceIds* property. The links that could not be deleted can be retrieved from the *SectionDefinitionLinks* property. |
| DomDefinitionDoesNotContainRequiredModuleSectionDefinitions | The DOM definition you want to create or update does not include all required section definition links for this module. The DOM definition can be retrieved from the *DomDefinition* property. The missing section definition IDs can be retrieved from the *SectionDefinitionIds* property. |

## Security

Security checks are done on CRUD actions when permission flags are configured on the *DomManagerSecuritySettings* (in the [ModuleSettings](xref:DOM_ModuleSettings)):

- To read DOM definitions, the user requires the permission flag defined by *DomManagerSecuritySettings.ViewPermission*.
- To create, update or delete DOM definitions, the user requires the permission flag defined by *DomManagerSecuritySettings.ConfigurePermission*.
