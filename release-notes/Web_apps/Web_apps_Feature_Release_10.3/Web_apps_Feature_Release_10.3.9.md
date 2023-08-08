---
uid: Web_apps_Feature_Release_10.3.9
---

# DataMiner web apps Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.9](xref:General_Feature_Release_10.3.9).

## Highlights

#### Dashboards app & Low-Code Apps: Query filter component now officially released [ID_33530] [ID_33547] [ID_34037] [ID_36822] [ID_36832]

<!-- MR 10.4.0 - FR 10.3.9 -->

The *Query filter* component has now officially been released. When linked to a *Table* component or a *Node edge graph* component, this component will allow you to filter the table or the node edge graph on the fly.

There are two ways in which you can link a query filter. See the following examples.

- **Feeding queries as data**

  1. Place a new *Query filter* component on the dashboard.

  1. Create a query (e.g. a query named *Elements* based on the *Get elements* data source) and drag it on top of the query filter component.
  
     Note that a feed name will appear in the bottom-right corner of the query filter component (e.g. "Query filter 1").

  1. Place a new *Table* component on the dashboard.

  1. In the *Data* tab, go to *All available data* > *Feeds*, expand the feed associated with the query filter (e.g. "Query filter 1"), and drag *Queries* on top of the table component.

  Result: Each time you change the query filter, a new query will be fed to the table. The latter will only show the rows that match the filter set in the query filter component.

- **Feeding query columns as filter**

  1. Place a new *Query filter* component on the dashboard.

  1. Create a query (e.g. a query named *Elements* based on the *Get elements* data source) and drag it on top of the query filter component.
  
     Note that a feed name will appear in the bottom-right corner of the query filter component (e.g. "Query filter 1").

  1. Place a new *Table* component on the dashboard.

  1. In the *Data* tab, go to *All available data* > *Queries*, and drag the query you created earlier (e.g. *Elements*) on top of the table component.

  1. In the *Data* tab, go to *All available data* > *Feeds*, expand the feed associated with the query filter (e.g. "Query filter 1"), and drag *Query columns* on top of the yellow filter drop area of the table component.

  Result: Each time you change the query filter, the data inside the table will be filtered according to the filter settings in the query filter. No new query will be fed to the table. The latter will keep on showing all rows, but those that do not match the filter will turn gray.

Settings:

- **Filter assistance**: If you activate this setting, the choices the query filter offers will already be filtered according to the data that is available.

  For example, if the table contains a *State* column, and the table only contains rows of which that column contains "Active" or "Stopped", you will not be able to filter on other state values. Moreover, next to each filter option the number of matching rows will be displayed. For example, when there are 20 rows of which the *State* column contains "Active", then the filter will show the Active state option as "Active (20)".

- **Allow color mode**: If this setting is activated (which it is by default), in the top-right corner of the filter query component, you will be able to click a color marker icon. When you do so, a color legend will appear on the right of the filter options, and for each of those options you will be able to configure a color (default color: green).

  > [!NOTE]
  > When you deactivate the *Allow color mode* setting, the colors you configured will stay visible and applied.

> [!NOTE]
>
> - At the top of a *Query filter* component, you have an *Active (x)* toggle button. If you enable this button, the component will display only the active filter options and the button itself will indicate the number of active options.
> - In a *Query filter* component, next to each column that contains discrete values of type string or number, you will find a button that allows you to change how the possible values are displayed:
>
>   - Click *Toggle checklist* to have all possible values listed in the form of a checklist.
>   - Click *Toggle free form* to display a text box in which users can type a value.
>
> - when you only filter a node edge graph by node, edges will be highlighted only when both source and destination are highlighted. When you only filter a node edge graph by edge, the source and/or destination attached to the highlighted edge segments will be highlighted.

#### Dashboards app & Low-Code Apps: Button panel visualization now officially released [ID_36775]

<!-- MR 10.4.0 - FR 10.3.9 -->

The button panel visualization has now officially been released. This component will display a button panel with buttons representing the rows of a table parameter. Using an element with a custom button panel protocol, you can configure what kind of buttons are displayed and how the buttons are displayed.

The following types of buttons can be configured:

- Simple buttons used only to set parameters.
- HTML buttons.
- Rotate buttons, resembling a control dial, used to decrement or increment the value of a particular parameter. The buttons can be used by dragging and dropping with the mouse, by using the arrow keys on the keyboard, or by sliding on a mobile device.

For more information, see [Button panel](xref:DashboardButtonPanel).

## Other features

#### GQI: Ad hoc data sources can now include columns of type GQITimeSpanColumn [ID_36717]

<!-- MR 10.4.0 - FR 10.3.9 -->

Ad hoc data sources can now include columns of type `GQITimeSpanColumn`. These columns can contain a time span and can have operators applied to them.

#### Dashboards app & Low-Code Apps - Parameters dataset: Selecting an index/cell of a column parameter [ID_36724]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Parameters* section of the edit panel's *DATA* tab, column parameters will now by default list their first 100 indices (i.e. cells). When you drag one of those cells onto a component, element ID, parameter ID as well as index will be passed along.

If the index (i.e. cell) you need is not among the first 100 indices that are listed, you can use the search box above the parameter list to narrow down the list of indices.

## Changes

### Enhancements

#### Dashboards app: Enhanced PDF generation [ID_36461]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of enhancements have been made to the way in which PDF files are generated from dashboards. For example, up to now, items selected on a dashboard would no longer be selected after a PDF file had been generated.

#### Monitoring app, Dashboards app & Low-Code Apps: Asynchronous operations now also supported when using WebSockets [ID_36583] [ID_36884] [ID_36885] [ID_36886] [ID_36887] [ID_36896] [ID_36904] [ID_37029] [ID_37031]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the following asynchronous operations were only supported over HTTP(s). From now on, these asynchronous operations will also be supported when using WebSockets.

- Retrieving trend data
- Retrieving alarm details
- Retrieving alarm history
- Retrieving visual overviews of elements, services and views
- Retrieving parameter status information (serving as input for pivot table components)
- Generating PDF reports
- Sending emails containing PDF reports
- Sharing a dashboard

#### Dashboards app: Enhanced mechanism to update the list of dashboards in the navigation pane [ID_36604]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the list of dashboards displayed in the navigation pane on the left would be updated every 5 seconds via a polling mechanism. From now on, whenever that list is changed, all connected clients will receive an event that will update the list.

#### BREAKING CHANGE: GQI - 'Get alarms' data source: Format of alarm IDs has changed [ID_36621]

<!-- MR 10.4.0 - FR 10.3.9 -->

The format of the alarm IDs listed in the *AlarmID* column of the *Get alarms* data source has been changed:

- Old format: *DmaId/RootId/AlarmId*
- New format: *HostingDmaId/AlarmId*

#### Monitoring app: A new type of text area boxes will now be used on parameter pages [ID_36693]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Monitoring* app, a new type of text area boxes will now be used on parameter pages.

#### Security enhancements [ID_36695]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of security enhancements have been made.

#### Monitoring app: A new type of duration boxes will now be used on parameter pages [ID_36713]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Monitoring* app, a new type of duration boxes will now be used on parameter pages.

#### Dashboards app: Tooltips will be displayed when hovering over a visualization in a component menu [ID_36737] [ID_36778]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you want to change the visualization of a component, you can hover over the component, click the *Visualizations* icon, and then select a visualization from the overview.

From now on, when you hover over each of the possible visualizations in the overview, a tooltip will appear, giving more information about that visualization.

Also, the component will no longer change instantly when you hover over a visualization in the overview. A visualization preview will be shown when the mouse pointer has been hovering over a particular visualization icon for more than 400ms and will disappear when the mouse pointer leaves the visualizations overview. The component will change its visualization only when you click a certain visualization in the overview.

#### DataMiner Comparison tool: Redesigned header and sidebar [ID_36747]

<!-- MR 10.4.0 - FR 10.3.9 -->

The header and sidebar of the DataMiner Comparison tool have been redesigned.

#### Dashboards app & Low-Code Apps: Deleting components by pressing the DELETE button [ID_36753]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

You can now delete components by pressing the *DELETE* button on your keyboard.

1. In Edit mode, select the component(s) you want to delete.
1. Press the *DELETE* button.

#### Dashboards app - GQI: Version column added to 'Get trend data patterns' and 'Get trend data pattern events' data sources [ID_36754]

<!-- MR 10.4.0 - FR 10.3.9 -->
<!-- Not added to MR 10.4.0  -->

The *Get trend data patterns* and *Get trend data pattern events* data sources now have a *Version* column containing the pattern version.

Each time the time range of a pattern gets updated, a new pattern record is created with a new pattern version.

#### Monitoring app: A new type of buttons and toggle buttons will now be used on parameter pages [ID_36773]

<!-- MR 10.4.0 - FR 10.3.9 -->

In the *Monitoring* app, a new type of buttons and toggle buttons will now be used on parameter pages.

#### Dashboards app - Line chart component: Enhanced performance [ID_36869]

<!-- MR 10.4.0 - FR 10.3.9 -->

When a line chart component used element table column parameters as data and indices as filter, up to now, it would cross-match indices across the unique elements associated with the table column parameters. This will now be prevented when the *Hide non-trended parameters* option is disabled.

> [!NOTE]
> The *Hide non-trended parameters* setting is now disabled by default.

> [!IMPORTANT]
> Because of the enhancements that have been made, in some cases, a line chart will no longer show any data when the indices are not available in the specified table. If so, you can opt to work with cell parameters instead (see [release note 36724](#dashboards-app--low-code-apps---parameters-dataset-selecting-an-indexcell-of-a-column-parameter-id_36724)) or to enable the *Hide non-trended parameters* option.

#### Monitoring app: Parameter control now supports dynamic units [ID_36892]

<!-- MR 10.4.0 - FR 10.3.9 -->

The parameter control used in the *Monitoring* app now supports dynamic units.

#### Dashboards app & Low-Code Apps: 'ReportsAndDashboardsAlpha' soft-launch option is now deprecated [ID_36894]

<!-- MR 10.4.0 - FR 10.3.9 -->

The *ReportsAndDashboardsAlpha* soft-launch option is now deprecated.

#### Dashboards app/Low-Code Apps: Removed unused legacy components [ID_36907]

<!-- MR 10.4.0 - FR 10.3.9 -->

In order to reduce the package size for the Dashboards app and Low-Code Apps, a number of legacy components, which were not used and were unavailable in the UI, have now been removed.

#### Dashboards app & Low-Code Apps - 'Numeric input' and 'Text input' feeds: New setting to determine the position of the label [ID_36983]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, a *Numeric input* feed would display the label above the input box while a *Text input* feed would display the label in front of the input box.

When, in edit mode, you select one of these feeds and open the *Layout* tab, below the *Label* box you can now find the *Label is inline* checkbox. Select this checkbox if you want the label to be displayed in front of the input box. By default, this option is disabled, meaning that the label will be displayed above the input box.

### Fixes

#### Low-Code Apps: Incorrect error message would appear when you tried to edit an app that you were not allowed to edit [ID_36650]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When you tried to open the edit mode of a low-code app that you were not allowed to edit, an incorrect error message would appear.

#### Referenced DomInstances would not get updated when a DomInstance was created or updated [ID_36734]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a DomInstance was created or updated, the DomInstances that were referenced by that DomInstance would incorrectly not get updated unless the browser window was refreshed.

#### Dashboards app: Black boxes on top of first or last field of selection boxes on small screens [ID_36738]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you reduced the screen size to the point at which the navigation pane got hidden, a black box would incorrectly appear on top of the first or last field of a selection box.

#### Dashboards app & Low-Code Apps: Table component would show skeleton loading when refetching data with external column filters applied [ID_36743]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

A table component would show skeleton loading when it refetched data with external column filters applied. From now on, a table component will only show skeleton loading during the initial fetch.

#### Low-Code Apps: Creating an app with an existing name would incorrectly be possible [ID_36744]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, it would incorrectly be possible to create a low-code app with a name that was identical to that of an existing app.

From now on, when you try to create an app with a name that is identical to that of an existing app, an error will be thrown.

#### Dashboards app: Problems with shared dashboards [ID_36752]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When you viewed a shared dashboard that you were not allowed to edit, in some cases, the dashboard would incorrectly be updated in the background, causing an error to be thrown.

Also, when you refreshed a shared dashboard while it was in edit mode, edit mode would incorrectly be closed.

#### Dashboards app: 'UpdateDashboard' call was sent twice when deleting a component [ID_36766]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you deleted a component from a dashboard, an `UpdateDashboard` call would incorrectly be sent twice.

#### Dashboards app: Problem when clicking 'Start with a blank dashboard' [ID_36798]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you clicked *Start with a blank dashboard* twice in rapid succession, two pop-up windows would open.

#### Low-Code Apps: Not possible to feed a selected timeline item to a component on a panel [ID_36820]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, it would incorrectly not be possible to feed a selected timeline item to a component on a panel of a low-code app.

#### Dashboards app & Low-Code Apps: User menu would not close when clicking the user icon [ID_36829]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you had opened the user menu by clicking the user icon in the top-right corner, that menu would not close when you clicked the user icon a second time.

#### GQI: Not all DCF interface properties would be returned [ID_36840]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, when DCF interface properties were fetched, only the properties found on the DataMiner Agent to which you were connected would be returned. From now on, all DCF interface properties in the entire DataMiner System will be returned instead.

#### Problem when sharing a dashboard containing a Gauge component fed by a State component with indices [ID_36872]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

In some cases, an error could be thrown when you shared a dashboard that contained a *Gauge* component fed by a *State* component with indices.

#### Web services API: Problem when fetching the next page of a GQI query [ID_36903]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a table visualization fetched the next page of a GQI query, GQI would throw an exception saying that the session was already closed.

This was due to GQI incorrectly closing the session automatically after 5 minutes of inactivity.

#### Dashboards app & Low-Code Apps - GQI: Not possible to link empty feeds to ad hoc arguments [ID_36913]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, when empty feeds had not yet been initialized with a value, it would not be possible to link those feeds to ad hoc arguments.

From now on, it will always be possible to link feeds to ad hoc arguments, regardless of their value.

#### Dashboards app & Monitoring app: Problem with parameter table component when switching from mobile view to desktop view [ID_36949]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When the Dashboards app or the Monitoring app switched from mobile view to desktop view, the parameter table component would incorrectly continue to use the mobile UI.

#### Dashboards app & Low-Code Apps: Query row feed would send a selected row twice when the table used two identical queries [ID_36952]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, when you selected a row of a table that used two identical queries, the query row feed would send the row twice. From now on, it will only send the row once.

#### Dashboards app: Problem when generating a PDF file with a custom paper size [ID_36968]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When a PDF file with a custom paper size was generated, the following error would be thrown:

`Cannot read properties of undefined (reading 'width')'.`

#### Dashboards app & Low-Code Apps: Problem when exporting a table with a query row feed to a CSV file [ID_36969]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, an error would be thrown when you tried to export a table with a query row feed to a CSV file.

#### Dashboards app & Low-Code Apps - GQI: Link to feed not saved when the feed value is identical [ID_36990]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some cases, query nodes that were linked to a feed would incorrectly not save their link when a new feed was linked with the exact same value.

From now on, queries will always be updated when the source (dashboard/page), selector (component), type (datatype) or property of the link changes.

#### Low-Code Apps: Problem after removing a query used by a component [ID_36998]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you removed a query that was used by a component on the page you were viewing, the *UpdateDashboard* call and all subsequent calls would fail.

#### Low-Code Apps: Problem when a form component linked to a DOM instance feed was not fed an instance [ID_37000]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a form component linked to a DOM instance feed was not fed an instance, it would get stuck in a loading state.

#### Dashboards app & Low-Code Apps: Form component would not be cleared when it was no longer fed a DOM instance or a DOM definition [ID_37001]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

The *Form* component would not be cleared when it was no longer fed a DOM instance or a DOM definition.

#### Dashboards app: 'Loading...' indicator would appear when trying to save a nameless folder [ID_37002]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, in the *Create folder* or *Create dashboard* window, you clicked inside the *Location* box, clicked "+" to add a new folder, entered a folder name, cleared that same folder name, and then clicked the checkmark button, a "Loading..." indicator would appear at the top of the window but nothing would happen.

#### Low-Code Apps: Header bar changes would not be shown in preview mode [ID_37005]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When changes had been made to the header bar of a low-code app, those changes would incorrectly not be shown when you switched to preview mode.

#### Monitoring app: Problem when no view properties were shown in the Surveyor [ID_37010]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you opened the *Monitoring* app, an error could occur when no view properties were shown in the Surveyor.

#### Dashboards app: Height of 'Data used in Dashboard' section would not be reduced when you deleted multiple components at once [ID_37032]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 -->

When, while in edit mode, you deleted multiple components at once, the *Data used in Dashboard* section of the edit pane would not be updated correctly. The data would be removed, but the height of the section would incorrectly not be reduced.

#### Dashboards app: Problem when adding or configuring a node edge graph component [ID_37039]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some cases, it would no longer be possible to add a new node edge graph component to a dashboard. Also, an error could occur when trying to configure a node edge graph that had already been added.

#### Monitoring app & Dashboards app: Cleared alarm groups would incorrectly still appear in alarm lists [ID_37045]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you opened the Alarm Console in the *Monitoring* app or an alarm list in the *Dashboards* app, alarm groups that had already been cleared would incorrectly still appear in the list.
