---
uid: DomBehaviorDefinition
---

# DomBehaviorDefinition object

A `DomBehaviorDefinition` object is a standalone object that extends a normal DOM definition and contains the configuration for special behavior. This includes all configuration for the status system.

> [!NOTE]
> This object is supported from DataMiner 10.1.11/10.2.0 onwards.

## Properties

The table below lists the properties of the `DomBehaviorDefinition` object. It also indicates whether a property can be used for filtering using the `DomBehaviorDefinitionExposers`.

> [!NOTE]
> From DataMiner 10.3.2/10.4.0 onwards, the `DomBehaviorDefinition` object also has [the *ITrackBase* properties](xref:DOM_objects#itrackbase-properties).

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | DomBehaviorDefinitionId | Yes | The unique ID of the object. |
| Name | string | Yes | The name of this definition. |
| ParentId | DomBehaviorDefinitionId | Yes | The ID of the parent `DomBehaviorDefinition` when inheritance is used. |
| InitialStatusId | string | No | The ID of the status that should be used when new `DomInstances` are created. |
| Statuses | List\<DomStatus> | No | Contains all statuses. |
| StatusSectionDefinitionLinks | List\<DomStatusSectionDefinitionLink> | No | Contains all links to `SectionDefinitions` that define what fields are required, allowed etc. for a specific status. |
| StatusTransitions | List\<DomStatusTransition> | No | Contains all transitions that are allowed to be made from one status to another. |
| ButtonDefinitions | List\<IDomButtonDefinition> | No | Contains the button definitions (see [Actions](xref:DOM_actions)). |
| ActionDefinitions | List\<IDomActionDefinition> | No | Contains the action definitions (see [Actions](xref:DOM_actions)). |

## Inheritance

One `DomBehaviorDefinition` can inherit from another. However, there are important limitations in place:

- It can only inherit from the `ModuleDomBehaviorDefinition` (the ID is defined in the *ModuleBehaviorDefinition* property of the `ModuleSettings`).

- The inheriting definition can only contain an ID, parent ID, and extra:

  - `DomStatusSectionDefinitionLinks` for `SectionDefinitions` that are not already defined on the module definition.

  - `ButtonDefinitions` (with other IDs than those defined on the parent).

  - `ActionDefinitions` (with other IDs than those defined on the parent).

Adding extra statuses or transitions on the child definition is not allowed.

This logic makes it possible to define a complete status system that should be used by all `DomDefinitions`. With an inheriting `DomBehaviorDefinition`, you can then define the visibility, requirements etc. for fields of extra `SectionDefinitions`.

![Inheritance Overview](~/user-guide/images/DOM_DomBehaviorDefinition_Inheritance.jpg)

## Status System

The `DomBehaviorDefinition` has several properties that contain the configuration for the status system. For more information on how these should be used, see [DOM status system](xref:DOM_status_system).

## Buttons and Actions

The `DomBehaviorDefinition` has several properties related to the buttons and actions concept. For more information, see [Actions](xref:DOM_actions).

## Requirements

- To **create or update** a `DomBehaviorDefinition`:

  - The string IDs of the statuses and transitions must not contain duplicates and should all be lowercase.

  - When there is a `ModuleDomBehaviorDefinition` defined, this definition must inherit from it. If this is not defined, the *ParentId* property should be empty.

  - The *InitialStatusId* property must contain the ID of an existing status. (This is not checked for an inheriting definition.)

  - The transitions must contain IDs of existing statuses.

  - Only one `DomStatusSectionDefinitionLink` for each `SectionDefinition` and status combo is allowed.

  - The links must also reference existing status IDs.

- You can only **delete** a `DomBehaviorDefinition` if there is no `DomDefinition` or other `DomBehaviorDefinition` linked to it.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `DomDefinitionErrors`. For each error, the *Id* and *Name* properties will be filled in alongside any other property mentioned in the description. Below is a list of all possible `ErrorReasons`:

| Reason | Description |
|--|--|
| InvalidParentId | The `DomBehaviorDefinition.ParentId` property contains an unexpected ID. If a module `DomBehaviorDefinition` is defined, it must contain the ID of that definition. If that is not the case, it should be empty. |
| InheritingDefinitionContainsInvalidData | This `DomBehaviorDefinition` is inheriting from another `DomBehaviorDefinition`, but it contains data that is not allowed. Only the `StatusSectionDefinitionLinks`, `ButtonDefinitions`, and `ActionDefinitions` can contain extra objects. |
| StatusTransitionsReferenceNonExistingStatuses | There was at least one `DomStatusTransition` that references a status that does not exist. *StatusTransitionsIds* contains the ID(s) of the invalid transition(s). |
| StatusSectionDefinitionLinksReferenceNonExistingStatuses | There was at least one `DomStatusSectionDefinitionLink` that referenced a status that does not exist. *DomStatusSectionDefinitionLinkIds* contains the ID(s) of the invalid `DomStatusSectionDefinitionLink(s)`. |
| InvalidStatusIds | There was at least one status defined with an invalid ID (should only contain lowercase characters). *StatusIds* contains the ID(s) of the invalid status(es). |
| DuplicateStatusIds | There are statuses defined with duplicate status IDs. *StatusIds* contains the ID(s) of the duplicate status(es). |
| InvalidTransitionIds | There was at least one transition defined with an invalid transition ID (should only contain lowercase characters). *StatusTransitionsIds* contains the ID(s) of the invalid transition(s). |
| DuplicateTransitionIds | There are transitions defined with duplicate transition IDs. *StatusTransitionsIds* contains the ID(s) of the duplicate transition(s) |
| InUseByDomDefinitions | The `DomBehaviorDefinition` for which there was a deletion attempt is still used by at least one `DomDefinition`. *DomDefinitionIds* contains the ID(s) of these `DomDefinition(s)`. |
| InUseByDomBehaviorDefinitions | The `DomBehaviorDefinition` for which there was a deletion attempt is still used by at least one `DomBehaviorDefinition`. *DomBehaviorDefinitionIds* contains the ID(s) of these `DomBehaviorDefinition(s)` |
| InvalidInitialStatusId | The `DomBehaviorDefinition` defines at least one status but does not define a valid initial status. *StatusIds* contains the ID of the invalid initial status (could be empty). |
| DuplicateSectionDefinitionLinks | The `DomBehaviorDefinition` defines more than one `DomStatusSectionDefinitionLink` for the same `SectionDefinition` and status. *DomStatusSectionDefinitionLinkIds* contains the ID(s) of the duplicate `DomStatusSectionDefinitionLinks`. |
| InvalidActionDefinitionIds | There was at least one `IDomActionDefinition` defined with an invalid ID (should only contain lowercase characters). *ActionDefinitionIds* contains the ID(s) of the invalid definition(s). |
| DuplicateActionDefinitionIds | There are `IDomActionDefinition` defined with duplicate IDs. *ActionDefinitionIds* contains the ID(s) of the duplicate definition(s). |
| InvalidButtonDefinitionIds | There was at least one `IDomButtonDefinition` defined with an invalid ID (should only contain lowercase characters). *ButtonDefinitionIds* contains the ID(s) of the invalid definition(s). |
| DuplicateButtonDefinitionIds | There are `IDomButtonDefinition` defined with duplicate IDs. *ButtonDefinitionIds* contains the ID(s) of the duplicate definition(s). |
|InvalidButtonActionCombination | An `IDomButtonDefinition` contains a combination of actions, which is not supported. At this time, only a single action is allowed. This error is returned from DataMiner 10.3.2/10.4.0 onwards when more than one action ID is added to an `IDomButtonDefinition`. *ButtonDefinitionIds* contains the ID(s) of the invalid definition(s). |

> [!NOTE]
> When a `DomBehaviorDefinition` inherits from another definition, make sure that the IDs of the `StatusSectionDefinitionLinks`, `ButtonDefinitions` and `ActionDefinitions` are unique accross both parent & child definition.
