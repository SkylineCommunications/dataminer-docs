---
uid: DOM_status_system
---

# DOM status system

In a DOM manager, you can configure the status system for a DOM definition. Each DOM instance linked to that DOM definition will then need to adhere to the rules defined for that status system.

This configuration is done using a [DomBehaviorDefinition](xref:DomBehaviorDefinition) object that the DOM definition is linked to. This object contains properties to store the statuses, initial status, transitions, and links to the section definitions.

![DomBehaviorDefinition](~/user-guide/images/DOM_DomBehaviorDefinition_Status_Properties_Overview.jpg)

Using the status system is an alternate way of defining which data must be present in a DOM instance. That means that the `SectionDefinitionLinks` on the DOM definition are not used in that case.

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

You can configure the possible statuses by adding a `DomStatus` object to the *Statuses* list property on the `DomBehaviorDefinition` object. A `DomStatus` has the following properties:

| Property | Type | Explanation |
| Id | string | The ID of this status. It must contain lowercase characters only (e.g. "initial_status"). |
| DisplayName | string | The display name of this status (e.g. "Initial"). |

> [!NOTE]
> Make sure that the *Statuses* collection does not contain `DomStatus` objects with the same ID. The *InitialStatusId* must also contain one of the statuses. When a DOM instance is created that does not have a status assigned, this initial status will automatically be filled in.

## Configuring transitions

You can configure what transitions are allowed by adding a `DomStatusTransition` object to the *Transitions* list property on the DOM behavior definition. A `DomStatusTransition` has the following properties:

| Property | Type | Explanation |
| Id | string | The ID of this transition. It must contain lowercase characters only (e.g. "initial_to_accepted_status"). |
| FromStatusId | string | The ID that the DOM instance will transition from. |
| ToStatusId | string | The ID that the DOM instance will transition to. |
| FlowLevel | int | The level of flow between transitions. The main transition will have the highest priority (0 is highest). An alternate transition from the same status will then have the value 1 or more. |

![Transitions overview](~/user-guide/images/DOM_StatusSystem_FlowLevel.jpg)

> [!NOTE]
> Make sure that the *Transitions* collection does not contain `DomStatusTransition` objects with the same ID.

## Configuring fields

For each status, you can configure the requirements of a specific field. This is done with `DomStatusSectionDefinitionLink` objects that each include `DomStatusFieldDescriptorLink` objects. A `DomStatusSectionDefinitionLink` has the following properties:

| Property | Type | Explanation |
| Id | DomStatusSectionDefinitionLinkId | Contains the section definition ID and status ID. |
| FieldDescriptorLinks | `List<DomStatusFieldDescriptorLink>` | Contains the links to field descriptors that are part of the section definition. |

A `DomStatusFieldDescriptorLink` has the following properties:

| Property | Type | Explanation |
| FieldDescriptorId | FieldDescriptorID | Contains the ID of the linked field descriptor. |
| Visible | bool | Determines whether this field should be visible in the UI for this status. This is only used by the UI; there is no logic for this property server-side. |
| RequiredForStatus | bool | Determines whether a value for this field must be present AND valid in this status. If a field is marked as required, at least one value for the field descriptor must be present in a DOM instance, and all values for this field descriptor are valid according to the validators of the field descriptor (if any are defined). |
| ReadOnly | bool | Determines whether values of this field are read-only with this status. When a field is marked as read-only for a specified status, the values cannot be changed when the DOM instance has this status. This also means that if no values were present before transitioning to this status, no values can be added as long as the DOM instance continues to have this status. |

> [!NOTE]
>
> - If no `FieldDescriptorLink` is present for an existing field descriptor, no values are allowed to be present for this field descriptor when the DOM instance has that specific status.
> - To prevent performance issues, when a DOM behavior definition is saved, there is no check whether the section definitions and field descriptors exist.

A couple of examples:

| Case | RequiredForStatus | ReadOnly | Description
| No values allowed | N/A | N/A | If no values should be allowed for the status, do not add a `FieldDescriptorLink` to the list. |
| Optional and editable values | false | false | If it should be possible to optionally add, update or delete a value for the status, set both *RequiredForStatus* and *ReadOnly* to *false*. |
| Optional and non-editable values |false | true | If a value should be present, but it is not required, and it should not be possible to add, update or delete a value for the status, set *RequiredForStatus* to *false* and *ReadOnly* to *true*. |
| Required and editable values | true | false | If a valid value must be present when transitioning to this status, and it should be possible update it as long as there is at least one value and all values are valid, set *RequiredForStatus* to *true* and *ReadOnly* to *false*. |
| Required and non-editable values | true | true | If a valid value must be present when transitioning to this status, and it should not be possible to change it while the DOM instance continues to have this status, set both *RequiredForStatus* and *ReadOnly* to *true*. |

## Creating and transitioning DOM instances

If a DOM instance is created without a status, and the DOM manager detects that the instance is linked to a DOM definition that uses the status system, it will automatically assign the initial status.

You can also create a DOM instance with any status you want, by assigning the status ID to the *StatusId* property of the instance. In this case, make sure that the `DomInstance` object has the correct fields for the status it is created in.

Transitioning to another status can only be done using a specific transition request. The status cannot change based on a normal update. The transition request requires the ID of the DOM instance and the ID of the transition. These requests can be sent using the helper. See [Sending a transition request](xref:DomHelper_class#sending-a-transition-request).

## ModuleDomBehaviorDefinition and inheritance

It is possible to mark a specific DOM behavior definition as the main "Module" definition.

This will force all other DOM behavior definitions to inherit from it, sot that they all have the same status system. The inheriting definitions can only add extra `DomStatusSectionDefinitionLink` objects. For more information about inheritance, see [DomBehaviorDefinition](xref:DomBehaviorDefinition).

<!-- Link to example -->
