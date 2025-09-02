---
uid: Web_apps_Feature_Release_10.5.11
---

# DataMiner web apps Feature Release 10.5.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU20] and 10.5.0 [CU8].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.11](xref:General_Feature_Release_10.5.11).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.11](xref:Cube_Feature_Release_10.5.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards/Low-Code Apps - Maps component: Specifying line color conditions in the query filter [ID 43617]

<!-- 10.4.0 [CU20] / MR 10.5.0 [CU8] - FR 10.5.11 -->

From now on, map lines can be colored by specifying a color condition in the query filter.

- When a color condition is specified in the query filter, any conditional coloring configured in the *Layout* pane of the *Maps* component will be disregarded until the query filter is removed.

- If the query filter contains multiple color conditions, only the first color condition will be applied. Because a line can only have one color, all other color conditions will be disregarded.

#### Dashboards/Low-Code Apps - Grid component: Enhanced default selection behavior [ID 43625]

<!-- 10.4.0 [CU20] / MR 10.5.0 [CU8] - FR 10.5.11 -->

A number of enhancements have been made to the default selection behavior of the *Grid* component.

- On initial load, the component will try to apply the selection instructions specified in the URL. If the URL does not contain any of these instructions, then the *Select first item by default* setting will be applied.

- On reload, the component will try to re-apply the latest selection. If this results in no items getting selected (because there is no previous selection or because the previously selected items are no longer displayed), then the *Select first item by default* setting will be applied.

In a *Grid* component, at least one item will always be selected

- when the component contains data, and
- when the *Select first item by default* setting is enabled.

### Fixes

*No fixes have been added yet.*
