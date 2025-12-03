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

### Fixes

#### Dashboards app: Problem when generating a PDF report of a dashboard containing a Time range component [ID 44168]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When you had generated a PDF report of a dashboard that contained a *Time range* component of which the *Edit using* option was set to "Keyboard & calendar", up to now, the date would incorrectly not be displayed.
