---
uid: DOM_SectionDefinition
---

# SectionDefinition object

A `SectionDefinition` object uses `FieldDescriptor` objects to define the fields a `DomInstance` should have. The Jobs module also uses this same `SectionDefinition` object.

The main class is an abstract implementation, as it allows the existence of two types:

- **StaticSectionDefinition**: Currently not used by DOM managers, but used by the Jobs module.

- **CustomSectionDefinition**: Used with DOM managers. When `SectionDefinitions` are discussed below, it is always this custom type that is meant.

When you work with `SectionDefinitions` in a script, you need to typecast them to the custom type, since you will otherwise not be able to set some properties.

```csharp
var sectionDefinition = new CustomSectionDefinition()
{
    Name = "ThisIsACustomSectionDefinition"
};

// When saving the SectionDefinition using the helper, you need to typecast it back to the custom type
sectionDefinition = domHelper.SectionDefinitions.Create(sectionDefinition) as CustomSectionDefinition;
```

![DOM object relations](~/dataminer/images/DOM_Object_Relations_Simplified_SectionDefinition.jpg)

> [!NOTE]
> From 10.5.10/10.6.0 onwards, creating, updating, or deleting `SectionDefinitions` requires the [*Module settings* permission](xref:DOM_security#module-settings-user-permission).

## FieldDescriptor

A `FieldDescriptor` object defines what a field of a `DomInstance` should look like. To define the type of the field, you need to set the *FieldType* property. The following types are supported:

- string
- double
- long
- DateTime
- TimeSpan
- bool

> [!IMPORTANT]
>
> - When you store `DateTime` values, you can save them in either the local or UTC time zone. However, we strongly recommend always using UTC. When a `DateTime` field value is displayed in a low-code app form, the values will be converted to the time zone set by the browser. When it is updated via the form, the value will be converted and saved in UTC even if the value was originally stored in local time.
> - When a `string` value is stored, from DataMiner 10.4.12/10.5.0 onwards, the value is limited to a maximum of 32 766 UTF-8 bytes, so the maximum number of characters will have to be lower.<!-- RN 39496 -->
> - When a `TimeSpan` value is used, make sure its value does not exceed 10,000 or go below -10,000 years.

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
| IsSoftDeleted | bool | Determines whether this descriptor is soft-deleted. See [soft-deletable objects](xref:DOM_objects#soft-deletable-objects).<br>Available from DataMiner 10.3.9/10.4.0 onwards. |

There are also special types of `FieldDescriptors` that are purpose-made to store a special value. These include:

- [**AutoIncrementFieldDescriptor**](xref:DOM_AutoIncrementFieldDescriptor): Defines a field that will automatically get an incremented value assigned. When a `DomInstance` does not have a value for this field yet, it will get assigned the next time the instance is updated.

- [**GenericEnumFieldDescriptor**](xref:DOM_GenericEnumFieldDescriptor): Defines a field that has a list of possible pre-determined values.

- [**ReservationFieldDescriptor**](xref:DOM_ReservationFieldDescriptor): Defines a field that has the ID of an SRM `(Service)ReservationInstance`.

- [**ResourceFieldDescriptor**](xref:DOM_ResourceFieldDescriptor): Defines a field that has the ID of an SRM resource. The descriptor has a *ResourcePoolIds* property that can be used to define from which resource pools the user can select a resource.

- [**ServiceDefinitionFieldDescriptor**](xref:DOM_ServiceDefinitionFieldDescriptor): Defines a field that has the ID of an SRM service definition. It contains a *ServiceDefinitionFilter* property that has a *FilterElement* that can be used to determine which service definitions will be presented to the user.

- [**StaticTextFieldDescriptor**](xref:DOM_StaticTextFieldDescriptor): Defines a field that should always have the same static value, defined by the *StaticText* property.

- [**DomInstanceFieldDescriptor**](xref:DOM_DomInstanceFieldDescriptor): Available from DataMiner 10.1.10/10.2.0 onwards. Can be used to define that a field should contain the ID of a `DomInstance`.

- [**ElementFieldDescriptor**](xref:DOM_ElementFieldDescriptor): Available from DataMiner 10.1.10/10.2.0 onwards. Can be used to define that a field should contain the ID of an element.

- [**DomInstanceValueFieldDescriptor**](xref:DOM_DomInstanceValueFieldDescriptor): Available from DataMiner 10.2.3/10.3.0 onwards. Can be used to define that a field should contain the ID of a `DomInstance`. However, compared to the `DomInstanceFieldDescriptor`, this one also references a specific value of that `DomInstance`.

- [**GroupFieldDescriptor**](xref:DOM_GroupFieldDescriptor): Available from DataMiner 10.3.3/10.4.0 onwards. Can be used to define that a field should contain the name of a DataMiner user group.

- [**UserFieldDescriptor**](xref:DOM_UserFieldDescriptor): Available from DataMiner 10.3.3/10.4.0 onwards. Can be used to define that a field should contain the name of a DataMiner user. There is a *GroupNames* property that can be used to define which groups the user can be a part of.

> [!IMPORTANT]
> The ID of a `FieldDescriptor` should be unique within a DOM module.
>
> Currently, the uniqueness of the ID does not get enforced when a `SectionDefinition` is added or updated.
>
> Using `FieldDescriptors` that have the same ID in multiple `SectionDefinitions` might result in inconsistent behavior. When a `FieldDescriptor` with the same ID is used in a name definition, the name of the `DomInstance` might differ depending on the first section available in the `DomInstance` that has a value assigned for the `FieldDescriptor` with that ID. During the validation of changes to the `FieldDescriptor`, this might result in DataMiner incorrectly detecting that a `FieldDescriptor` is no longer in use, which may cause the removal of a descriptor that is actually still in use.

### Multiple values

Some `FieldDescriptors` offer the capability to store multiple values rather than a single one. Refer to the respective descriptor documentation to check if a specific descriptor provides this functionality and from which DataMiner version onwards it is supported.

When configuring a `FieldDescriptor` to accommodate multiple values, adjust the type property to match the list variant of the underlying base type. For instance, change `Guid` to `List<Guid>`. When assigning values to a `DomInstance`, utilize the `AddOrUpdateListFieldValue` extension method to easily add a list of values to the instance.

```csharp
var fieldDescriptor = new ResourceFieldDescriptor
{
    FieldType = typeof(List<Guid>)
};
```

```csharp
var multipleValues = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
domInstance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, multipleValues);
```

> [!NOTE]
>
> - From DataMiner 10.4.2/10.5.0 onwards, it is no longer possible to pass empty lists as value for a `FieldDescriptor` that allows multiple values if that field is required. A `FieldDescriptor` that is not required will still allow empty lists as value, but note that it is best practice to not pass values for `FieldDescriptors` if the value is empty or an empty list.
> - Fields with multiple values are not available in GQI queries.

## CustomSectionDefinition properties

In the table below, you can find the properties of the `CustomSectionDefinition` object (the base `SectionDefinition` object only exposes its ID). The table also indicates whether a property can be used for filtering using the `SectionDefinitionExposers`.

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

  - Prior to DataMiner 10.3.12/10.4.0, you cannot remove `FieldDescriptors` from a `SectionDefinition` when a `DomInstance` already uses that definition.

    From DataMiner 10.3.12/10.4.0 onwards<!-- RN 37395 -->, removing `FieldDescriptors` is not possible in the following cases only:

    - When they have a value set on a section, for that `SectionDefinition`, on a `DomInstance`.
    - When they are still used on the `DomManagerSettings` of the DOM manager. Either in the `DomInstanceNameDefinition`, or in one of the `FieldAliases`.
    - When they are still used in a `DomInstanceNameDefinition` set on a `DomDefinition`.
    - When they are still used in a `DomStatusSectionDefinitionLink` for that `SectionDefinition` on a `DomBehaviorDefinition`.

  - During an update, the properties of the previous and updated version of the `FieldDescriptor` are checked. The behavior of this check depends on the type of `FieldDescriptor`, but by default, the following properties can be changed freely:

    - *Name*
    - *IsHidden*
    - *Tooltip*
    - *IsOptional*
    - *IsReadonly*

  - There is a special case for `GenericEnumFieldDescriptors`: you can only update and delete `GenericEnumEntries` that are not in use by `DomInstances`.

- You can only **delete** a `SectionDefinition` if it is not linked by a `DomDefinition` and it is not used by `DomInstances`.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `SectionDefinitionErrors`. Below, you can find a list of all possible `ErrorReasons` (this list does not contain the errors that are only used by the Jobs module).

| Reason | Description |
|--|--|
| FieldTypeNotSupported | A type was defined on a `FieldDescriptor` that is not supported by that descriptor.<br>Available properties: *NotSupportedType*, *SupportedTypes*. |
| SectionDefinitionInUseByDomInstances | The `SectionDefinition` could not be updated because it is being used by at least one `DomInstance`.<br>Available properties: *SectionDefinition*, *OriginalSectionDefinition*, *DomInstanceIds* (limited to the first 100 instances<!-- RN 41572 -->). |
| SectionDefinitionInUseByDomDefinitions | The `SectionDefinition` could not be deleted because it is being used by at least one `DomDefinition`. Set the *FieldDescriptor.IsSoftDeleted* boolean for the `FieldDescriptor` you want to delete instead.<br>Available properties: *SectionDefinition*, *DomDefinitionIds*. |
| GenericEnumEntryInUseByDomInstances | The `GenericEnumEntry` could not be deleted or updated because it is being used by at least one `DomInstance`.<br>Available properties: *GenericEnumEntry*, *DomInstanceIds* (limited to the first 100 instances<!-- RN 41572 -->). |
