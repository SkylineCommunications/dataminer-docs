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

## Changes

### Enhancements

#### Dashboards app: Enhanced PDF generation [ID_36461]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of enhancements have been made to the way in which PDF files are generated from dashboards. For example, up to now, items selected on a dashboard would no longer be selected after a PDF file had been generated.

#### Dashboards app & Low-Code Apps: Retrieving trend data asynchronously via websockets [ID_36583]

<!-- MR 10.4.0 - FR 10.3.9 -->

Because of a number of enhancements, dashboards and low-code apps are now fully capable of retrieving trend data asynchronously via websockets.

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

#### Dashboards app: Tooltips will be displayed when hovering over a visualization in a component menu [ID_36737]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you want to change the visualization of a component, you can hover over the component, click the *Visualizations* icon, and then select a visualization from the list.

From now on, when you hover over each of the possible visualizations in the list, a tooltip will appear, giving more information about that visualization.

#### Dashboards app - GQI: Version column added to 'Get trend data patterns' and 'Get trend data pattern events' data sources [ID_36754]

<!-- MR 10.4.0 - FR 10.3.9 -->
<!-- Not added to MR 10.4.0  -->

The *Get trend data patterns* and *Get trend data pattern events* data sources now have a *Version* column containing the pattern version.

Each time the time range of a pattern gets updated, a new pattern record is created with a new pattern version.

### Fixes

#### Low-Code Apps: Incorrect error message would appear when you tried to edit an app that you were not allowed to edit [ID_36650]

<!-- MR 10.4.0 - FR 10.3.9 -->

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

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When you deleted a component from a dashboard, an `UpdateDashboard` call would incorrectly be sent twice.

#### Dashboards app: Problem when clicking 'Start with a blank dashboard' [ID_36798]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you clicked *Start with a blank dashboard* twice in rapid succession, two pop-up windows would open.

#### Low-Code Apps: Not possible to feed a selected timeline item to a component on a panel [ID_36820]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, it would incorrectly not be possible to feed a selected timeline item to a component on a panel of a low-code app.

#### Dashboards app & Low-Code Apps: User menu would not close when clicking the user icon [ID_36829]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you had opened the user menu by clicking the user icon in the top-right corner, that menu would not close when you clicked the user icon a second time.

#### GQI: Not all DCF interface properties would be returned [ID_36840]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, when DCF interface properties were fetched, only the properties found on the DataMiner Agent to which you were connected would be returned. From now on, all DCF interface properties in the entire DataMiner System will be returned instead.
