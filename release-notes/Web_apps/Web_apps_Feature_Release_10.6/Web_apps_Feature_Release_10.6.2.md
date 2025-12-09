---
uid: Web_apps_Feature_Release_10.6.2
---

# DataMiner web apps Feature Release 10.6.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.5.0 [CU11].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.2](xref:General_Feature_Release_10.6.2).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.2](xref:Cube_Feature_Release_10.6.2).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards/Low-Code Apps: Enhanced performance when rendering a large number of template previews [ID 44156]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of a number of enhancements, performance has increased when rendering a large number of template previews in e.g. the *Browse templates* window.

#### Dashboards/Low-Code Apps - Templates: Default templates of all components that are using templates will now show up a presets in 'Browse templates' window [ID 44174]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In the *Browse templates* window, all default templates of all components that are using templates will now show up a presets.

Also, this window will now include a number of additional presets.

#### Dashboards/Low-Code Apps - Templates: Enhanced template previews [ID 44176]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of enhancements have been made with regard to template previews.

From now on, template previews will always be rendered in a consistent way, whatever the component in which they are viewed.

#### Dashboards/Low-Code Apps - Node edge graph component: Label enhancements [ID 44218]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Up to now, the label data of nodes and edges was always linked to the conditional coloring of the underlying column.

From now on, it will be possible to display node and edge labels in three different ways:

| Option | Description |
|--------|-------------|
| None          | The label will not be shown, even if the selected column has conditional coloring. |
| From coloring | This is the legacy behavior. The label visibility is fully determined by the conditional coloring settings. |
| Custom        | Allows you to select a specific field to be displayed as node or edge label. This means that, even if the node/edge does not have conditional coloring, the label field will still be shown. |

If you choose *Custom*:

- The first column of the query will be selected by default.
- The background color of edges will be determined as follows:

  - If the selected column has conditional coloring, then this color will be used as background color.
  - If the selected column does not have conditional coloring, but the edge has, then this color will be used as background color.
  - If neither the selected column nor the edge have conditional coloring, the default background color of the node edge graph component will be used as background color.

The above-mentioned label configuration can be set per node query, per edge query, and can also be overridden by means of node and edge overrides.

#### Dashboards app: Redesigned sidebar [ID 44222]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

The sidebar of the Dashboards app has been redesigned.

When you click the ... button at the top of the sidebar, or when you right-click the background of the sidebar, a menu with the following commands will open:

- Create > Dashboard
- Create > Folder
- Create > From Import
- Create > From Catalog
- Settings

When you right-click a folder, or click the ... button of a folder, a menu with the following commands will open:

- Create > Dashboard
- Create > Folder
- Create > From Import
- Create > From Catalog
- Settings
- Delete

When you right-click a dashboard, or click the ... button of a dashboard, a menu with the following commands will open:

- Open in a new tab
- Duplicate
- Settings
- Delete

#### GQI extensions: Filtering enhancements [ID 44230]

<!-- MR 10.7.0 - FR 10.6.2 -->

In `SLAnalyticsTypes`, the `IGQIFilterOperator` interface in the GQI extensions API now has a new read-only property:

- `IGQIFilter Filter`: The filter applied by the filter operator

> [!CAUTION]
> The introduction of this new property breaks compatibility for existing interface implementations. Although the `IGQIFilterOperator` interface will in practice only be implemented by the GQI framework and is not intended to be implemented by external code on production systems, existing test setups may get broken when upgrading to the new `SLAnalyticsTypes` version.

Additionally, the following new types have been defined:

- `Interface IGQIFilter`

  Common interface for all possible filters.

- `Interface IGQIValueFilter : IGQIFilter`

  Filter on a specific column with a specific constant value.

  With the following read-only properties:

  - `IGQIColumn Column`: The column to filter on.
  - `GQIFilterMethod Method`: The method to use for filtering.
  - `object Value`: The value to filter with.

- `Interface IGQIAndFilter : IGQIFilter`

  Conjunction of multiple filters.

  With the following read-only property:

  - `IReadOnlyList<IGQIFilter> Filters`: Filters to be combined.

- `Interface IGQIOrFilter : IGQIFilter`

  Disjunction of multiple filters.

  With the following read-only property:

  - `IReadOnlyList<IGQIFilter> Filters`: Filters to be combined.

- `Enum GQIFilterMethod`

  Represents the way a value can be used to filter a column.

  With the following values:

  - Contains
  - DoesNotContain
  - DoesNotEqual
  - DoesNotMatchRegex
  - Equals
  - IsGreaterThan
  - IsGreaterThanOrEquals
  - IsLessThan
  - IsLessThanOrEquals
  - MatchesRegex
  - None

#### Enhanced error logging when deleting DOM instances fails [ID 44263]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In a dashboard, a low-code app, or another DataMiner web app, each time an error occurs when you try to delete a DOM instance, from now on, all exceptions will be logged, and a message will appear in the UI.

#### Dashboards app - Grid component: Enhanced rendering on PDF reports in stacked mode [ID 44266]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of a number of enhancements, the behavior of the Grid component has improved when rendered on a PDF report in stacked mode.

From now on, the grid will try to grow or shrink vertically in order to avoid a vertical scrollbar and show as many items as possible with regard to its settings.

> [!NOTE]
> A PDF report containing a Grid component can still show scrollbars and/or clipped content when the grid is set to show a fixed amount of row and a fixed amount of columns (without *Stretch to fit* option).

### Fixes

#### Dashboards app: Problem when generating a PDF report of a dashboard containing a Time range component [ID 44168]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When you had generated a PDF report of a dashboard that contained a *Time range* component of which the *Edit using* option was set to "Keyboard & calendar", up to now, the date would incorrectly not be displayed.

#### Problem when importing a web app [ID 44202]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When you imported a web app, e.g. from the DataMiner Catalog onto the DataMiner landing page, in some cases, not all associated files would get synchronization across the DataMiner System.

#### Data Aggregator would not be able to execute a converted GQI query that contained a regular expression [ID 44258]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a GQI query was converted to JSON in order to have it executed by the Data Aggregator, up to now, on systems where Data Aggregator executed GQI queries using CoreGateway and SLHelper instead of the GQI DxM, it would incorrectly not be possible for the Data Aggregator to execute that query if it contained a regular expression.

The following error would be logged:

```console
A unknown exception occurred in CoreGateway: Error trapped: Skyline.DataMiner.Net.SLConfiguration.SLValue`1[System.String] could not be converted to System.Text.RegularExpressions.Regex.
Parameter name: value
```

#### Dashboards/Low-Code Apps - State timeline component: Problems when processing state changes [ID 44277]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of issues have been fixed with regard to the State timeline component. These issues would mostly occur when processing state changes.

#### Dashboards/Low-Code Apps - Timeline component: Problem when zooming or panning while linked components trigger viewport changes [ID 44280]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a Timeline component and a Time range component were linked in both directions, up to now, the Timeline component would not be able to properly perform viewport actions (e.g. zooming or panning).

From now on, a Timeline component will no longer adapt its viewport when instructed to do so by incoming events (from e.g. a Time range component) while a user is zooming or panning.

Note that the following actions will only affect the viewport after the user interaction has finished:

- Selecting a range by dragging the right mouse button.
- Selecting a segment on top of the timeline.

Because these two actions will only affect the viewport after the user interaction has finished, the Timeline component will also receive an incoming viewport change request from the Time range component after the user interaction has finished. That way, the latter request will overrule the viewport changes that were made initially.
