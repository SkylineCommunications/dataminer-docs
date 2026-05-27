---
uid: Web_apps_Feature_Release_10.6.8
---

# DataMiner web apps Feature Release 10.6.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU5].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.8](xref:General_Feature_Release_10.6.8).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.8](xref:Cube_Feature_Release_10.6.8).

## Highlights

*No highlights have been selected yet.*

## New features

#### GQI DxM: Defining discrete column values when building a custom ad hoc data source [ID 45380]

<!-- MR 10.5.0 [CU17] / 10.6.0 [CU5] - FR 10.6.8 -->

When building a custom ad hoc data source using the `Skyline.DataMiner.Core.GQI.Extensions` NuGet as API reference, you can now define a set of discrete values for any column. For example, a *Status* column can have the values "Active", "Inactive", and "Pending", each with a user-friendly display name.

This can be useful in the following scenarios:

- *Columns with a fixed set of values*: When a column only ever contains values from a known list (e.g. a status or category), marking the discrete values as
strict will present users with a convenient dropdown-style filter instead of a free-text input in the query filter.

- *Columns with exception values*: When a column holds a continuous range (e.g. a measurement from 0 to 100), but also has special values with a specific
meaning (e.g. -1 meaning "Error"), you can define those exception values as non-strict discrete values. Users will see these special values as quick filter
options while still being able to filter on the full numeric range.

Each discrete value can have a display name that differs from the underlying value, making filters and UI elements more readable for end users.

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

*No fixes have been added yet.*
