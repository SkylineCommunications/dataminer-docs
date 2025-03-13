---
uid: Web_apps_Feature_Release_10.5.5
---

# DataMiner web apps Feature Release 10.5.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.5](xref:General_Feature_Release_10.5.5).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.5](xref:Cube_Feature_Release_10.5.5).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Low-Code Apps: Problem when a 'Close a panel' event was linked to a component action involving a lazy loaded component [ID 42302]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a *Close a panel* event was linked to a component action, the panel would not get closed when the component in question was a lazy loaded component that was not loaded yet.

From now on, in cases like this, the component will be forced to render and the component action will be executed. As a result, the *Close a panel* event will be processed.

#### Dashboards/Low-Code Apps: Migration warning would incorrectly appear when the dashboard or low-code app was up to date [ID 42312]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a check was performed to determine whether a dashboard or a low-code app had to be migrated to the latest version, and the dashboard or low-code was already up to date, in some cases, the migration warning popup would incorrectly appear.

#### Low-Code Apps - Table and Parameter table components: Search icon would block part of the table data [ID 42313]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In the *Table* and *Parameter table* components, up to now, the search icon would appear at the bottom, blocking part of the table data. From now on, a search icon in the header bar will allow you to open a search bar at the top of the component.

#### Dashboards/Low-Code Apps - Node edge graph component: Problem when the topology is updated while a block is being moved [ID 42372]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When the topology was updated while you were moving a block from one location to another, up to now, the position of the mouse pointer would get out of sync with the block you were moving. From now on, the block that is being moved will always follow the mouse pointer.
