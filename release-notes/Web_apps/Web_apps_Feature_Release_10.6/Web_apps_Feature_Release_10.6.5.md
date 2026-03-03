---
uid: Web_apps_Feature_Release_10.6.5
---

# DataMiner web apps Feature Release 10.6.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU2].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.5](xref:General_Feature_Release_10.6.5).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.5](xref:Cube_Feature_Release_10.6.5).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### GQI DxM: Query version will no longer be linked to the DxM version [ID 44719]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a query was created, the version of that query would be linked to the current version of the GQI DxM. As a result, queries would be migrated each time the minor or major version of the GQI DxM was increased, even when nothing had been changed to the query logic.

From now on, the query version will no longer be linked to the version of the GQI DxM. Queries will only be migrated when they were altered in such a way that it prevents them from being run in their current form.

### Fixes

*No fixes have been added yet.*
