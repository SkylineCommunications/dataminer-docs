---
uid: DOM_objects
---

# DOM objects

The most basic DOM object is the **DOM instance**, which contains different values (e.g. names, dates, IDs, etc.). A **DOM definition** determines which sections are present in DOM instances, by grouping a number of section definitions. Each **section definition** defines the data that should be present in a section of a DOM instance (e.g. the type of data and the number of fields).

In addition to this, a **DOM template** can also be defined, which is a DOM instance object that already has specific values filled in. Finally, a DOM definition can be linked to a **DOM behavior definition**, which contains configuration for extra behavior (e.g. different statuses).

In summary:

- [SectionDefinition object](xref:DOM_SectionDefinition): Defines the data that should be present in a section of a DOM instance, using field descriptors.
- [DomDefinition object](xref:DomDefinition): Groups DOM instances together and defines which section definitions should be used by the instances.
- [DomInstance object](xref:DomInstance): Contains field values in its different sections, as defined in the section definitions, which in turn are defined by the DOM definition.
- [DomTemplate object](xref:DomTemplate): Pre-filled DOM instance object that can be used as a template.
- [DomBehaviorDefinition object](xref:DomBehaviorDefinition): Extension of a DOM definition that adds additional behavior configuration.

For example, to create a system that stores time spent working on specific tasks registered by employees, you could create a section definition with the name "PunchInfoSectionDefinition", consisting of the following field descriptors:

- Field descriptor 1: Name = "Task ID" and Type = "GUID"
- Field descriptor 2: Name = "Username" and Type = "String"
- Field descriptor 3: Name = "Start time" and Type = "DateTime"
- Field descriptor 4: Name = "Stop time" and Type = "DateTime"

A DOM definition will then need to be created that contains a link to this section definition, so that employees can then register time by creating a new DOM instance linked to the section definition. The DOM instance will contain a field value for each of the field descriptors.
