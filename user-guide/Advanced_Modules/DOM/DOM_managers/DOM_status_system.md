---
uid: DOM_status_system
---

# DOM status system

In a DOM manager, you can configure the status system for a DOM definition. Each DOM instance linked to that DOM definition will then need to adhere to the rules defined for that status system.

This configuration is done using a [DomBehaviorDefinition](xref:DomBehaviorDefinition) object that the DOM definition is linked to. This object contains properties to store the statuses, initial status, transitions, and links to the section definitions.

Using the status system is an alternate way of defining which data must be present in a DOM instance. That means that the *SectionDefinitionLinks* on the DOM definition are not used in that case.

![Status system overview](~/user-guide/images/DOM_StatusSystem_Overview.jpg)

> [!NOTE]
> A DOM manager detects that the status system is used from the moment that a DOM definition is linked to a DOM behavior definition AND that DOM behavior definition contains at least one status.

To set up a status system:

1. Create a new DOM behavior definition.

   1. Add all statuses. (See [Configuring statuses](#configuring-statuses)).

   1. Define the initial status.

   1. Add all transitions. (See [Configuring transitions](#configuring-transitions)).

   1. Configure all fields. (See [Configuring fields](#configuring-fields)).

1. Link a DOM definition to the DOM behavior definition.

1. Create DOM instances using the appropriate statuses and fields.

## Configuring statuses

You can configure the possible statuses by adding a *DomStatus* object to the *Statuses* list property on the *DomBehaviorDefinition* object. A *DomStatus* has the following properties:

| Property | Type | Explanation |
| Id | string | The ID of this status. It must contain lowercase characters only (e.g. "initial_status"). |
| DisplayName | string | The display name of this status (e.g. "Initial"). |

> [!NOTE]
> Make sure that the *Statuses* collection does not contain *DomStatus* objects with the same ID. The *InitialStatusId* must also contain one of the statuses. When a DOM instance is created that does not have a status assigned, this initial status will automatically be filled in.

## Configuring transitions

You can configure what transitions are allowed by adding a *DomStatusTransition* object to the *Transitions* list property on the DOm behavior definition. A *DomStatusTransition* has the following properties:

| Property | Type | Explanation |
| Id | string | The ID of this transition. It must contain lowercase characters only (e.g. "initial_to_accepted_status"). |
| FromStatusId | string | The ID that the DOM instance will transition from. |
| ToStatusId | string | The ID that the DOM instance will transition to. |
| FlowLevel | int | The level of flow between transitions. The main transition will have the highest priority (0 is highest). An alternate transition from the same status will then have value 1 or more. |

FlowLevel Overview

Make sure that the Transitions collection does not contain DomStatusTransition objects with the same ID.

## Configuring fields

For each status, you can configure the requirements of a specific field. This is done with DomStatusSectionDefinitionLinks that each include DomStatusFieldDescriptorLinks. A DomStatusSectionDefinitionLink has the following properties:

| Property | Type | Explanation |
| Id | DomStatusSectionDefinitionLinkId | Contains the SectionDefinitionID and status ID |
| FieldDescriptorLinks | `List<DomStatusFieldDescriptorLink>` | Contains the links to FieldDescriptors that are part of the SectionDefinition. |

A DomStatusFieldDescriptorLink then contains the following properties:

| Property | Type | Explanation |
| FieldDescriptorId | FieldDescriptorID | Contains the ID of the linked FieldDescriptor |
| Visible | bool | Determines whether this field should be visible in the UI for this status |
| RequiredForStatus | bool | Determines whether a value for this field must be present AND valid in this status |
| ReadOnly | bool | Determines whether values of this field are read-only in this status |

Clarifying notes:

When no FieldDescriptorLink is present for an existing FieldDescriptor, that means that no values are allowed to be present for this FieldDescriptor in that specific status.
The Visible bool has no logic server-side and is solely used by the UI to know if the field should be visible or not.
When a field is marked as required by setting the RequiredForStatus bool, it means that at least one value for this FieldDescriptor must be present in a DomInstance AND that all values for this FieldDescriptor are valid according to the validators of that descriptor (if any were defined).
When a field is marked as read-only for a specified status, the values can not be changed. Note that if none were present before transitioning to this status, none can be added anymore once the DomInstance is in this status.
The existence of the SectionDefinitions and FieldDescriptors are not checked when a DomBehaviorDefinition is saved (reduces complexity and prevents performance issues).
Below you can see an overview of a few realistic use cases of how a field can be defined.

| Case | RequiredForStatus | ReadOnly | Note |
| Not allowed | N/A | N/A | When a no values are allowed to be present, no FieldDescriptorLink should be added to the list |
| Optional & editable | false | false | A value can optionally be added or an existing value can be updated/deleted. |
| Optional & not editable | false | true | A value may be present but it is not required. None can be added, edited or deleted. |
| Required & editable | true | false | A valid value must be present when transitioning to this status and it can be updated as long as there is at least one value and all values are valid. |
| Required & not editable | true | true | A valid value must be present when transitioning and it can not be changed anymore in this status |

Creating and transitioning DOM instances

If a DomInstance is created without a status, the DomManager will automatically assign the initial status when it detects the instance is linked to a DomDefinition that uses the status system. You can also create a DomInstance in any status that you want by assigning the status ID to the StatusId property of the instance. Make sure that the DomInstance always has the correct fields for the status it is created in.

Transitioning to another status can only be done using the specific transition request. Changing the status by doing a normal update is not allowed. The transition request requires the ID of the DomInstance and the ID of the transition. These requests can be sent using the helper.

domHelper.DomInstances.DoStatusTransition(domInstance.ID, "initial_to_acceptance");
When something goes wrong while transitioning, a DomStatusTransitionError will be returned in the TraceData of the request. This error can contain the following reasons:

| Reason | Description |
| StatusTransitionNotFound | The given transition ID does not match with any defined on the associated DomBehaviorDefinition. This error can also occur when there is no valid DomBehaviorDefinition linked in the first place. StatusTransitionId contains the ID of the transition that could not be found |
| StatusTransitionIncompatibleWithCurrentStatus | The current status of the DomInstance does not match the 'from' status defined by the transition. StatusTransitionId contains the ID of the transition that could not be completed. |
| DomInstanceContainsUnknownFieldsForNextStatus | There is at least one FieldValue defined on the DomInstance where no link could be found DomBehaviorDefinition for the next status. AssociatedFields contains the SectionDefinitionID and FieldDescriptorID combos of the unknown fields |
| DomInstanceHasInvalidFieldsForNextStatus | The DomInstance contains fields that are required but are not valid according to at least one validator. If there are multiple values for the same SectionDefinition and FieldDescriptor, only one entry will be included. AssociatedFields contains the SectionDefinitionID and FieldDescriptorID combos of the invalid fields |
| DomInstanceHasMissingRequiredFieldsForNextStatus | The DomInstance does not contain all fields that are required for the next status. AssociatedFields contains the SectionDefinitionID and FieldDescriptorID combos of the missing fields |
| CrudFailedExceptionOccurred | When saving the DomInstance, a CrudFailedException occurred. InnerTraceData contains the TraceData contained in the exception |

ModuleDomBehaviorDefinition and inheritance
It is also possible to mark one DomBehaviorDefinition as the main 'Module' definition. This will force all other DomBehaviorDefinitions to inherit from it and thus all have the same status system. The inheriting definitions can only add extra DomStatusSectionDefinitionLinks. Also see the DomBehaviorDefinition page for more info about inheritance.

Example
Be sure to checkout the status system example that can possibly help you better understand this status system.
