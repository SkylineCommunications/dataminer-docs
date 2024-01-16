---
uid: Web_apps_Feature_Release_10.4.3
---

# DataMiner web apps Feature Release 10.4.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.3](xref:General_Feature_Release_10.4.3).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### DataMiner Object Models: Enhanced performance of DomInstanceFieldDescriptor and DomInstanceValueFieldDescriptor in web forms [ID_37546]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The overall performance of `DomInstanceFieldDescriptor` and `DomInstanceValueFieldDescriptor` has increased.

Up to now, all options were loaded in the field on the web form. This had a negative impact on performance, especially on large setups. From now on, the fields will only load the first 100 instances and show a warning that not all fields have been loaded.

When a `DomInstanceValueFieldDescriptor` refers to a FieldDescriptor that is part of a SectionDefinition that allows multiple sections, the web form field will only show the first value it finds. If a DomInstance does not contain a value for that FieldDescriptor, only the DomInstance name will be shown.

The display value of the `DomInstanceValueFieldDescriptor` will now be one of the following:

- `<DomInstanceName>: <FieldValue>` (for instances that have a FieldValue)
- `<DomInstanceName>: <FieldValue1>, <FieldValue2>, ...` (for instances that have a FieldValue list)
- `<DomInstanceName>` (for instances that have no FieldValue)
- The ID of the DomInstance (if there is no DomInstanceName)

In a web form, values in a `DomInstanceValueFieldDescriptor` or `DomInstanceFieldDescriptor` selection box will now be alphabetically sorted based on DomInstance name.

> [!NOTE]
>
> - A `DomInstanceValueFieldDescriptor` cannot refer to a `StaticTextFieldDescriptor`, a `DomInstanceFieldDescriptor` or another `DomInstanceValueFieldDescriptor`.
> - A `DomInstanceValueFieldDescriptor` that refers to another `DomInstance(Value)FieldDescriptor` will only display the name (or the ID if there is no name) of the DomInstance to avoid performance degradation when fetching instances.
> - DisplayValue is limited to 70 characters to avoid performance degradation.

### Fixes

#### Dashboards app: Problem when an error occurred while creating a dashboard [ID_38310]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when an error occurred while creating a new dashboard, the items already created before the error occurred (e.g. the folder) would incorrectly not get cleaned up.

#### Dashboards app & Low-Code Apps - GQI: Queries would be fetched twice [ID_38335]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, a query would be fetched twice: once with old feed values filled in and once with new feed values filled in.

As the component was still in a loading state, users would only notice that it took longer for the data to appear.

#### Dashboards app & Low-Code Apps - GQI: Problem when multiple column manipulations had been configured on the same column [ID_38338]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, a query would throw an error when multiple column manipulations had been configured on the same column.

#### Low-Code Apps: Template editor would close when you pressed ESCAPE in the event editor [ID_38353]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When, in the template editor, you pressed ESCAPE while the event editor window was open, both the event editor window and the template editor window would incorrectly be closed.

#### Dashboards app & Low-Code Apps - Generic map component: No longer possible to select a map configuration file [ID_38394]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When configuring a *Generic map* component, it would incorrectly no longer be possible to select a map configuration file.

#### Dashboards app - GQI: Problem when fetching a GQI result [ID_38420]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a GQI result was being fetched, in some cases, the following error could be thrown:

```txt
Error: Uncaught (in promise): TypeError: Cannot read properties of undefined (reading 'then')
TypeError: Cannot read properties of undefined (reading 'then')
```
