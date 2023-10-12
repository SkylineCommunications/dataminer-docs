---
uid: DOM_SectionDefinition
---

# SectionDefinition object

A `SectionDefinition` object uses `FieldDescriptor` objects to define the fields a `DomInstance` should have. The Jobs module also uses this same `SectionDefinition` object.

The main class is an abstract implementation, as it allows the existence of two types:

- **StaticSectionDefinition**: Currently not used by DOM managers, but used by the Jobs module.

- **CustomSectionDefinition**: Used with DOM managers. When `SectionDefinitions` are discussed further on this page, it is always this custom type that is meant.

When you work with `SectionDefinitions` in a script, you need to typecast them to the custom type, since you will otherwise not be able to set some properties.

```csharp
var sectionDefinition = new CustomSectionDefinition()
{
    Name = "ThisIsACustomSectionDefinition"
};

// When saving the SectionDefinition using the helper, you need to typecast it back to the custom type
sectionDefinition = domHelper.SectionDefinitions.Create(sectionDefinition) as CustomSectionDefinition;
```

![DOM object relations](~/user-guide/images/DOM_Object_Relations_Simplified_SectionDefinition.jpg)

## FieldDescriptor

A `FieldDescriptor` object defines what a field of a `DomInstance` should look like. To define the type of the field, you need to set the *FieldType* property. The following types are supported:

- string
- double
- long
- DateTime
- TimeSpan
- bool

Below is an overview of all other important properties:

| Property | Type | Description |
|--|--|--|
| ID | FieldDescriptorID | The ID of the `FieldDescriptor`. |
| Name | string | The name of the `FieldDescriptor`. |
| IsOptional | bool | Determines whether a `FieldValue` must be present for this descriptor or if it is optional. |
| IsHidden | bool | Determines whether this descriptor is hidden from the UI. |
| IsReadonly | bool | Determines whether this descriptor can only be manipulated from scripts/API and not from the UI. |
| Tooltip | string | Short description of the field that will be available as a tooltip in the UI. |
| DefaultValue | IValueWrapper | The default value that will be used to pre-fill the field in the UI. |
| IsSoftDeleted | bool | Determines whether this descriptor is soft-deleted. See [soft-deletable objects](xref:DOM_objects#soft-deletable-objects). Available from DataMiner 10.3.9/10.4.0 onwards. |

There are also special types of `FieldDescriptors` that are purpose-made to store a special value. These include:

- **AutoIncrementFieldDescriptor**: Defines a field that will automatically get an incrementing value when saved. When marked as soft-deleted, these fields will no longer be incremented. The value will remain the last value before the descriptor was marked as soft-deleted.

- **GenericEnumFieldDescriptor**: Defines a field that has a list of possible pre-determined values.

- **ReservationFieldDescriptor**: Defines a field that has the ID of an SRM `(Service)ReservationInstance`.

- **ResourceFieldDescriptor**: Defines a field that has the ID of an SRM resource. The descriptor has a *ResourcePoolIds* property that can be used to define from which resource pools the user can select a resource.

- **ServiceDefinitionFieldDescriptor**: Defines a field that has the ID of an SRM service definition. It contains a *ServiceDefinitionFilter* property that has a *FilterElement* that can be used to determine which service definitions will be presented to the user.

- **StaticTextFieldDescriptor**: Defines a field that should always have the same static value, defined by the *StaticText* property.

- **DomInstanceFieldDescriptor**: Available from DataMiner 10.1.10/10.2.0 onwards. Can be used to define that a field should contain the ID of a `DomInstance`. This `DomInstance` can exist in a different DOM manager. This is why the descriptor has a *ModuleId* property that defines where the instances can be found. There is also a *DomDefinitionIds* list property that can be used to define whether DOM instances should be linked to the defined definitions. Both properties are intended for UIs, and their validity and existence is not checked server-side. The `FieldValues` are of type "Guid".

- **ElementFieldDescriptor**: Available from DataMiner 10.1.10/10.2.0 onwards. Can be used to define that a field should contain the ID of an element. The ID must be saved as a string according to the common `[DMA ID]/[ELEMENT ID]` format (e.g. "868/65874"). There is a *ViewIds* list property that can be used to define whether the elements should be in any of these views. The `FieldValues` are of type "string".

- **DomInstanceValueFieldDescriptor**: Available from DataMiner 10.2.3/10.3.0 onwards. Can be used to define that a field should contain the ID of a `DomInstance`. However, compared to the `DomInstanceFieldDescriptor`, this one also references a specific value of that `DomInstance`. The configuration is the same as the other descriptor, but it adds the *FieldDescriptorId* property that references a specific `FieldValue`.

- **GroupFieldDescriptor**: Available from DataMiner 10.3.3/10.4.0 onwards. Can be used to define that a field should contain the name of a DataMiner user group.

- **UserFieldDescriptor**: Available from DataMiner 10.3.3/10.4.0 onwards. Can be used to define that a field should contain the name of a DataMiner user. There is a *GroupNames* property that can be used to define which groups the user can be a part of. 

> [!NOTE]
> From DataMiner 10.2.3/10.3.0 onwards, the following `FieldDescriptors` can have **multiple values**:
>
> - DomInstanceFieldDescriptor
> - ElementFieldDescriptor
> - ResourceFieldDescriptor
> - ReservationFieldDescriptor
> - ServiceDefinitionFieldDescriptor
>
> From DataMiner 10.2.5/10.3.0 onwards, this also applies for the *DomInstanceValueFieldDescriptor*.
>
> These `FieldDescriptors` therefore also support a list of the type that was already supported before.
>
> Adding multiple values to a `DomInstance` or updating the `DomInstance` with multiple values can be done as follows.
>
> - FieldDescriptor type configuration:
>
>   ```csharp
>   // Change the supported type of the fieldDescriptor to list
>   fieldDescriptor.FieldType = typeof(List<Guid>);
>   ```
>
>- Assigning a FieldValue with a list to a DomInstance:
>
>   ```csharp
>   // Adding a fieldValue to the domInstance
>   var fieldValue = new FieldValue()
>   {
>       FieldDescriptorID = fieldDescriptor.Id,
>       Value = new ListValueWrapper<Guid>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() })
>   };
>   domInstance.Sections.First().AddOrReplaceFieldValue(fieldValue);
>
>   // Update the FielValue of the domInstance
>   var values = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
>   domInstance.AddOrUpdateListFieldValue(sectionDefinition, fieldDescriptor, values);
>   ```

## CustomSectionDefinition properties

The table below lists the properties of the `CustomSectionDefinition` object. (The base `SectionDefinition` object only exposes its ID.) The table also indicates whether a property can be used for filtering using the `SectionDefinitionExposers`.

> [!NOTE]
> From DataMiner 10.3.2/10.4.0 onwards, the `CustomSectionDefinition` object also has [the *ITrackBase* properties](xref:DOM_objects#itrackbase-properties).

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | SectionDefinitionID | Yes | The ID of the `SectionDefinition`. |
| Name | string | Yes | The name of the `SectionDefinition`. |

> [!NOTE]
> Adding and removing `FieldDescriptors` must be done using the `AddOrReplaceFieldDescriptor()` and `RemoveFieldDescriptor()` methods. You can also filter on the `FieldDescriptors` using the `FieldDescriptorIDs` or `FieldDescriptorNames` exposers (found on `SectionDefinitionExposers`).

## Requirements

- To **create or update** a `SectionDefinition`, it must define `FieldDescriptors` with types that are actually supported by the relevant `FieldDescriptor`.

- When you **update** a `SectionDefinition`:

  - You cannot remove `FieldDescriptors` from a `SectionDefinition` when a `DomInstance` already uses that definition.

  - During an update, the properties of the previous and updated version of the `FieldDescriptor` are checked. The behavior of this check depends on the type of `FieldDescriptor`, but by default, the following properties can be changed freely:

    - *Name*
    - *IsHidden*
    - *Tooltip*
    - *IsOptional*
    - *IsReadonly*

  - There is a special case for `GenericEnumFieldDescriptors`: you can only update and delete `GenericEnumEntries` that are not in use by `DomInstances`.

- You can only **delete** a `SectionDefinition` if it is not linked by a `DomDefinition` and it is not used by `DomInstances`.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `SectionDefinitionErrors`. Below is a list of all possible `ErrorReasons`. (This list does not contain the errors that are only used by the Jobs module.)

| Reason | Description |
|--|--|
| FieldTypeNotSupported | A type was defined on a `FieldDescriptor` that is not supported by that descriptor. Available properties: *NotSupportedType*, *SupportedTypes*. |
| SectionDefinitionInUseByDomInstances | The `SectionDefinition` could not be updated because it is being used by at least one `DomInstance`. Available properties: *SectionDefinition*, *OriginalSectionDefinition*, *DomInstanceIds*. |
| SectionDefinitionInUseByDomDefinitions | The `SectionDefinition` could not be deleted because it is being used by at least one `DomDefinition`. Set the *FieldDecriptor.IsSoftDeleted* boolean for the `FieldDescriptor` you want to delete instead. Available properties: *SectionDefinition*, *DomDefinitionIds*. |
| GenericEnumEntryInUseByDomInstances | The `GenericEnumEntry` could not be deleted or updated because it is being used by at least one `DomInstance`. Available properties: *GenericEnumEntry*, *DomInstanceIds*. |
