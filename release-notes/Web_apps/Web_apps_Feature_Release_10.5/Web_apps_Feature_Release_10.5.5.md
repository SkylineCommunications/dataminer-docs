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

#### Low-Code Apps - Template editor: Configuring actions for layers of type 'Text' [ID 42473]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Layers of type *Text* now also have a *Configure actions* property. This will allow you to configure actions that are executed when a user clicks the text box.

#### Dashboards/Low-Code Apps - Template editor: Duplicating layers [ID 42479]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In the *Layers* tab, you can now duplicate a layer. To do so, proceed as follows:

1. Hover over the layer that you want to duplicate, and click the ellipsis button ("...").
1. Select *Duplicate*.

> [!NOTE]
> Up to now, to delete a layer, you had to hover over the layer and click the *Delete* button in the top-right corner. From now on, you need to hover over the layer, click the ellipsis button, and select *Delete*.

## Changes

### Breaking changes

#### Dashboards/Low-Code Apps - Timeline component: Enhanced performance [ID 42432]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Because of a number of enhancements, overall performance of the *Timeline* component has increased, especially when the timeline in question contains a large number of groups.

> [!IMPORTANT]
> In some cases, this change will break existing setups. A *Timeline* component will now only load up to 10000 items, timeline groups will now be sorted, and real-time updates will no longer be applied when using e.g. a DOM instances data source.

### Enhancements

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'Numeric' [ID 42132]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.Numeric` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Enhancements made to redesigned UI components 'StaticText' and 'CheckBox' [ID 42210]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

A number of enhancements have been made to the redesigned UI components `UIBlockType.StaticText` and `UIBlockType.CheckBox`.

- When the text in a redesigned `UIBlockType.StaticText` component does not fit the width of the component, it will now automatically be ellipsed and when you hover over the component, the full text will be displayed in a tooltip.

- A redesigned `UIBlockType.CheckBox` component will now display its label in a tooltip if no tooltip was configured in its settings.

  > [!NOTE]
  > By design, no tooltips can be shown on mobile devices.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'FileSelector' [ID 42231]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.FileSelector` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'Treeview' [ID 42279]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.Treeview` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'Parameter' [ID 42401]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.Parameter` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards/Low-Code Apps: Queries will be sorted alphabetically whenever you close and re-open the Queries section [ID 42452]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Up to now, when you created a new query, it would always be added to the bottom of the *Queries* section. From now on, when you create a new query, it will initially be added to the bottom of that section, but when you close the *Queries* section and open it again, the queries will be sorted alphabetically.

The same will now also apply for flows, variables and parameter table filters.

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

#### Web API would incorrectly drop the connection with an idle browser tab [ID 42407]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, when a browser tab was idle, the Web API would incorrectly drop the connection with that tab. When you then went back to that tab, you would be asked to log on again.

#### DataMiner Comparison app: Problem when using the tool in embedded mode [ID 42409]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, the DataMiner Comparison app would not work correctly when used in embedded mode.

Example: `https://myDma/comparison/#/?parameter1=935%2F152%2F30602%2F1&parameter2=935%2F108%2F5518%2F7.22&embed=true`

When no connection was established yet, the query parameters would not get saved and be removed. Also, no parameters could be fetched.

#### Low-Code Apps: Exporting a low-code app would fail if the name contained illegal characters [ID 42416]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Up to now, it would not be possible to export a low-code app of which the name contained illegal characters (e.g. question marks).

#### Dashboards/Low-Code Apps - Timeline component: Not possible to edit the template [ID 42449]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a table variable was visualized as a *Timeline* component, it would not be possible to edit its template.

#### Dashboards/Low-Code Apps: Basic controls incorrectly had to layout sections named 'General' [ID 42487]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Up to now, the *Layout* pane of the *Numeric input*, *Search input* and *Toggle* component would incorrectly have two sections named *General*.

The second section named *General* has now been renamed to *Advanced*.

#### Dashboards/Low-Code Apps: 'onLoad' event would incorrectly be triggered multiple times [ID 42489]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In e.g. a *Maps* component or a *Web* component, the `onLoad` event would incorrectly be triggered multiple times. From now on, this event will only be triggered once.

#### Dashboards app: Maps component would incorrectly not reapply its previous selection when the dashboard was refreshed [ID 42496]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you refreshed a dashboard, in some cases, a *Maps* component would incorrectly not reapply its previous selection.
