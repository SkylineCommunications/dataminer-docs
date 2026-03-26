---
uid: Web_apps_Feature_Release_10.5.5
---

# DataMiner web apps Feature Release 10.5.5

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU14] and 10.5.0 [CU2].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.5](xref:General_Feature_Release_10.5.5).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.5](xref:Cube_Feature_Release_10.5.5).

## Highlights

- [Dashboards/Low-Code Apps - Template editor: Layer tooltips [ID 42503]](#dashboardslow-code-apps---template-editor-layer-tooltips-id-42503)
- [Dashboards/Low-Code Apps - Template editor: New layer of type HTML [ID 42519]](#dashboardslow-code-apps---template-editor-new-layer-of-type-html-id-42519)

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

#### Dashboards/Low-Code Apps - Template editor: Layer tooltips [ID 42503]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

It is now possible to configure a tooltip for any type of layer (*Icon*, *Text*, *Rectangle*, or *Ellipse*).

When you hover over the layers, the tooltip of the layer in front will be displayed.

#### Dashboards/Low-Code Apps - Template editor: New layer of type HTML [ID 42519]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In the template editor, you can now add layers of type *HTML*. Adding a layer of type *HTML* will add a text box in which you can add HTML content. It will offer basic syntax highlighting and intellisense.

> [!IMPORTANT]
> Newly added layers of type *Text* will no longer support HTML content. If you add HTML content to new layers of type *Text*, it will be rendered as plain text instead of HTML. For backward compatibility, HTML code in existing layers of type *Text* will still be rendered as HTML.

## Changes

### Breaking changes

#### Dashboards/Low-Code Apps - Timeline component: Enhanced performance [ID 42432]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Because of a number of enhancements, overall performance of the *Timeline* component has increased, especially when the timeline in question contains a large number of groups.

> [!IMPORTANT]
> In some cases, this change will break existing setups. A *Timeline* component will now only load up to 10000 items, timeline groups will now be sorted, and real-time updates will no longer be applied when using e.g., a DOM instances data source.

### Enhancements

#### Low-Code Apps - Interactive automation scripts: Redesigned UI component 'Numeric' [ID 42132]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.Numeric` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive automation scripts: Enhancements made to redesigned UI components 'StaticText' and 'CheckBox' [ID 42210]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

A number of enhancements have been made to the redesigned UI components `UIBlockType.StaticText` and `UIBlockType.CheckBox`.

- When the text in a redesigned `UIBlockType.StaticText` component does not fit the width of the component, it will now automatically be ellipsed and when you hover over the component, the full text will be displayed in a tooltip.

- A redesigned `UIBlockType.CheckBox` component will now display its label in a tooltip if no tooltip was configured in its settings.

  > [!NOTE]
  > By design, no tooltips can be shown on mobile devices.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive automation scripts: Redesigned UI component 'FileSelector' [ID 42231]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.FileSelector` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive automation scripts: Redesigned UI component 'Treeview' [ID 42279]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.Treeview` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Low-Code Apps - Interactive automation scripts: Redesigned UI component 'Parameter' [ID 42401]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

The UI component `UIBlockType.Parameter` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards/Low-Code Apps: Queries will be sorted alphabetically whenever you close and re-open the Queries section [ID 42452]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Up to now, when you created a new query, it would always be added to the bottom of the *Queries* section. From now on, when you create a new query, it will initially be added to the bottom of that section, but when you close the *Queries* section and open it again, the queries will be sorted alphabetically.

The same will now also apply for flows, variables and parameter table filters.

#### Dashboards/Low-Code Apps - Time range component: Enhancements [ID 42493] [ID 42505]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

A number of minor enhancements have been made to the *Time range* component, especially with regard to design and usability.

#### Dashboards/Low-Code Apps - Line & area chart component: 'Hide non-trended parameters' setting will now by default be set to true [ID 42532]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Up to now, the *Hide non-trended parameters* setting was by default set to false. From now on, it will by default be set to true.

#### Dashboards/Low-Code Apps - Time range component: Enhanced scrolling behavior in the date pickers [ID 42537]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Because of a number of enhancements, scrolling has improved in the date pickers.

For example, up to now, a month would only be focused when all weeks of that month became visible in the calendar. From now on, the month of which most days are visible will be focused.

#### Dashboards/Low-Code Apps - Maps component: Visual enhancements [ID 42553]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

A number of minor enhancements have been made to the *Maps* component, especially with regard to the overall look and feel of the UI elements.

#### Security enhancements [ID 42565]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

A number of security enhancements have been made.

#### Dashboards/Low-Code Apps: Search box in the 'Queries' section of a 'Data' pane will now only filter the query names [ID 42589]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When, while configuring a component, you opened the *Queries* section of the *Data* pane, and entered a search string in the search box, up to now, both the query names and the query columns would be filtered. From now on, only the query names will be filtered.

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

#### DataMiner Object Models: Web API would incorrectly not allow the ModuleID property to be empty when using DomInstanceFieldDescriptor or DomInstanceValueFieldDescriptor [ID 42334]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Although it is not mandatory to specify the `ModuleID` property when using `DomInstanceFieldDescriptor` or `DomInstanceValueFieldDescriptor`, up to now, the Web API would incorrectly not allow the `ModuleID` property to be empty.

> [!NOTE]
> If no `ModuleID` property is set, only DOM instances in the same module as the `DomInstanceFieldDescriptor` or `DomInstanceValueFieldDescriptor` can be referenced.

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

Up to now, it would not be possible to export a low-code app of which the name contained illegal characters (e.g., question marks).

#### Dashboards/Low-Code Apps - Timeline component: Not possible to edit the template [ID 42449]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a table variable was visualized as a *Timeline* component, it would not be possible to edit its template.

#### Dashboards/Low-Code Apps: Basic controls incorrectly had to layout sections named 'General' [ID 42487]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

Up to now, the *Layout* pane of the *Numeric input*, *Search input* and *Toggle* component would incorrectly have two sections named *General*.

The second section named *General* has now been renamed to *Advanced*.

#### Dashboards/Low-Code Apps: 'onLoad' event would incorrectly be triggered multiple times [ID 42489]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In e.g., a *Maps* component or a *Web* component, the `onLoad` event would incorrectly be triggered multiple times. From now on, this event will only be triggered once.

#### Dashboards app: Maps component would incorrectly not reapply its previous selection when the dashboard was refreshed [ID 42496]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you refreshed a dashboard, in some cases, a *Maps* component would incorrectly not reapply its previous selection.

#### Dashboards/Low-Code Apps: Problem when components were linked to GQI table data [ID 42499]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a component was linked to GQI table data, up to now, it could lose its GQI-related settings when columns were re-ordered or renamed in that GQI table data.

#### Web API could lose the permission the write to the C:\\Skyline DataMiner\\Logging\\Web folder [ID 42513]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, the Web API would lose the permission the write to the `C:\Skyline DataMiner\Logging\Web` folder. As a result, it would no longer be allowed to write log entries.

#### Dashboards/Low-Code Apps - Node edge graph component: Real-time updates would not restored connections that had been removed [ID 42529]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a connection inside a node edge graph had been removed because of a real-time graph update, up to now, that connection would never re-appear after a subsequent graph update. The update process would incorrectly assume the connection already existed.

#### Low-Code Apps: Problem when using the TAB and ENTER keys when adding an action [ID 42539]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When you added an action (e.g., *Open monitoring card*), up to now, you had to incorrectly press the TAB key twice to set the focus to the *Link to data* button, and when you then pressed the ENTER key, the picker would not load correctly.

#### Dashboards/Low-Code Apps: Pickers would not be reset when closed [ID 42556]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a picker in e.g., a *Time range* component was closed, up to now, it would incorrectly not be reset.

#### Dashboards/Low-Code Apps - Grid component: Grid items would incorrectly get resized when a trigger went off [ID 42560]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, grid items would incorrectly get resized when a trigger went off.

#### Low-Code Apps - Action editor: Problem when trying to select a component using intellisense [ID 42575]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When, in the action editor, you tried to select a recently added component using intellisense, an error would be thrown.

#### Dashboards/Low-Code Apps: Icons of information elements would not change color [ID 42578]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In several components (e.g., the *Time range* component), information elements consisting of an icon and a text box are being used to convey messages to the user. Up to now, when the color of such an information element was changed, only the color of the text would be updated. The color of the icon would incorrectly not be updated.

#### Dashboards/Low-Code Apps - Maps component: 'Fetch the data' action could not be executed when no layers were visible or selected [ID 42579]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When no layers were visible or selected in a *Maps* component, it would incorrectly not be possible to execute a *Fetch the data* action.

#### Dashboards/Low-Code Apps: Empty query nodes would incorrectly not be marked as null [ID 42588]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, empty query nodes (i.e., nodes that did not contain any value) would incorrectly not be marked as null.

#### Low-Code Apps: 'Fetch the data' action would not always be triggered [ID 42601]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, a *Fetch the data* action would incorrectly not get triggered.

#### Dashboards/Low-Code Apps - GQI: Component data fetched by joined queries would not get refetched when a selection changed [ID 42606]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

When a component used joined queries to fetch data, the data would incorrectly not be refetched when a selection changed in the component.

#### DataMiner Maps: Not possible to load the maps.asmx page [ID 42619]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 -->

In some cases, it would not be possible to load the `https://{HOSTNAME}/api/v0/maps.asmx` page due to a serialization issue.

#### Dashboards/Low-Code Apps - Query builder: Not possible to scroll up or down after selecting the 'Get object manager instances' data source [ID 42648]

<!-- MR 10.4.0 [CU14] / 10.5.0 [CU2] - FR 10.5.5 [CU0] -->

Up to now, when you had selected the *Get object manager instances* data source while building a GQI query, in some cases, the scrollbar would incorrectly not appear when you hovered over the object manager instances in the list, making it impossible to scroll up or down in the list.
