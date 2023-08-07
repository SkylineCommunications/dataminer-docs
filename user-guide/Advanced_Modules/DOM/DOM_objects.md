---
uid: DOM_objects
---

# DOM objects

The most basic DOM object is the **DOM instance** (or `DomInstance` in the code), which contains different values (e.g. names, dates, IDs, etc.). A **DOM definition** (or `DomDefinition`) determines which sections are present in DOM instances, by grouping a number of section definitions. Each **section definition** (or `SectionDefinition`) defines the data that should be present in a section of a DOM instance (e.g. the type of data and the number of fields).

In addition to this, a **DOM template** (or `DomTemplate`) can also be defined, which is a DOM instance object that already has specific values filled in. Finally, a DOM definition can be linked to a **DOM behavior definition** (or `DomBehaviorDefinition`), which contains configuration for extra behavior (e.g. different statuses).

In summary:

- [SectionDefinition](xref:DOM_SectionDefinition): Defines the data that should be present in a section of a DOM instance, using field descriptors.

- [DomDefinition](xref:DomDefinition): Groups DOM instances together and defines which section definitions should be used by the instances.

- [DomInstance](xref:DomInstance): Contains field values in its different sections, as defined in the section definitions, which in turn are defined by the DOM definition.

- [DomTemplate](xref:DomTemplate): DOM instance with filled-in values that can be used as a template.

- [DomBehaviorDefinition](xref:DomBehaviorDefinition): Extension of a DOM definition that adds additional behavior configuration.

The following diagram illustrates the relation between these objects:

![Object relation diagram](~/user-guide/images/DOM_Object_Relations_Simplified.jpg)

For example, to create a system that stores time spent working on specific tasks registered by employees, you could create a `SectionDefinition` with the name "PunchInfoSectionDefinition", consisting of the following field descriptors:

- Field descriptor 1: *Name* = "Task ID" and *Type* = "GUID"

- Field descriptor 2: *Name* = "Username" and *Type* = "String"

- Field descriptor 3: *Name* = "Start time" and *Type* = "DateTime"

- Field descriptor 4: *Name* = "Stop time" and *Type* = "DateTime"

A DOM definition will then need to be created that contains a link to this section definition, so that employees can then register time by creating a new DOM instance linked to that DOM definition. The DOM instance will have a section linked to the section definition that contains a field value for each of the field descriptors.

## ITrackBase Properties

From DataMiner 10.3.2/10.4.0 onwards, all DOM objects (including the `ModuleSettings`) contain four properties that reflect who has created/updated the object, and at what time.

- **LastModified**: The moment when the object was last modified, in UTC DateTime format.

- **LastModifiedBy**: The full username (string) of the user who last modified the object.

- **CreatedAt**: The moment when the object was created, in UTC DateTime format.

- **CreatedBy**: The full username (string) of the user who created the object.

Since these are seen as metadata, they are not immediately accessible on the objects, but require a cast.

```csharp
DateTime lastModified = ((ITrackBase) domInstance).LastModified;
string lastModifiedBy = ((ITrackBase) domTemplate).LastModifiedBy;
DateTime createdAt = ((ITrackBase) moduleSettings).CreatedAt;
string createdBy = ((ITrackBase) sectionDefinition).CreatedBy;
```

It is also possible to use these fields to build filters when reading objects.

```csharp
var filter = DomInstanceExposers.CreatedBy.Equal("John Doe");
```

> [!NOTE]
> The DOM objects created prior to DataMiner 10.3.2/10.4.0 will not have a value for these fields. However, after an existing object is updated once, the `LastModified` and `LastModifiedBy` fields will be filled in.

## Soft-deletable objects

From DataMiner 10.3.9/10.4.0 onwards, the following DOM objects can be soft-deleted:

- [FieldDescriptor](xref:DOM_SectionDefinition#fielddescriptor)
- [SectionDefinitionLink](xref:DomDefinition#sectiondefinitionlink)
- [DomStatusSectionDefinitionLink](xref:DOM_status_system#configuring-fields)

When the fields linked to a soft-deleted `FieldDescriptor` or part of a soft-deleted `SectionDefinitionLink` or `DomStatusSectionDefinitionLink` are marked as *IsSoftDeleted*, the following applies:

- The fields will not be shown in a UI form.
- The fields are not validated when the `SectionDefinition`, `DomDefinition`, or `DomBehaviorDefinition` is updated.
- The fields are never be required.
- Values are allowed to exist in the fields on a `DomInstance` for a soft-deleted `FieldDescriptor`, `SectionDefinitionLink`, or `DomStatusSectionDefinitionLink`.
- Updating a `DomInstance` with new/updated values will be blocked for a field that has a soft-deleted `FieldDescriptor`, or is part of a soft-deleted `SectionDefinitionLink` or `DomStatusSectionDefinitionLink` (for that status). A [ValueForSoftDeletedFieldNotAllowed error](xref:DomInstance#errors) will be returned.
