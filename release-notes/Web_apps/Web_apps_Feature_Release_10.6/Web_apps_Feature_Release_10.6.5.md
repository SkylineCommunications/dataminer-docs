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

#### Dashboards/Low-Code Apps - Node edge graph component: New advanced settings to optimize how concurrent edges are displayed between two nodes [ID 44791]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When configuring a *Node edge graph* component, you can now use the following advanced settings to optimize how concurrent edges are displayed between two nodes.

| Setting | Description |
|---------|-------------|
| Max bundle size | When the number of edges exceeds this value, the edges will automatically be combined into a single line.<br>The color and style of that single line will be based either on the highest alarm severity (when in alarm mode) or the lowest color (when in analytical mode).<br>Clicking the line will expand all edges, revealing their actual values and colors.<br>Default value: 20 |
| Spread offset   | The distance from the source/destination node where edges begin to spread.<br>Default value: 0% |
| Spread length   | The portion of the path where edges spread apart from the connection point.<br>Default value: 25% |
| Max spread size | The maximum distance occupied by bundled edges.<br>Default value: 80px |
| Min gap         | The minimum distance between adjacent edges in a bundle.<br>Default value: 15px |

> [!NOTE]
>
> - The *Min gap* setting has priority over the *Max spread size* setting. Having 10 edges with a *Min gap* of 5px will exceed a *Max spread size* of 40px.
> - The above-mentioned settings will only be accessible when you added the `?showAdvancedSettings=true` argument to the URL of the dashboard or the low-code app.

#### Dashboards/Low-Code Apps - Node edge graph component: Node or edge labels can now be linked to data from another component [ID 44907]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Since DataMiner 10.5.0 CU11/10.6.2, you can select a specific field to be displayed as node or edge label.

From now on, you can link a node or edge label to data from another component (e.g. a list of query columns displayed in a *Dropdown* component).

#### Dashboards/Low-Code Apps - Node edge graph component: 'Node move' events can now be cancelled by pressing ESC [ID 44938]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Per node query linked to a *Node edge graph* component, you can configure *node move* events that will be triggered when a node belonging to that query is moved.

From now on, it will be possible to cancel a node movement by pressing the ESC key.

When you do so, the move event will not be executed, and the node will automatically return to its last know position.

#### Dashboards/Low-Code Apps - GQI components: Dynamically referencing data in layers of type Text and HTML as well as in tooltips [ID 44976]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In the template editor, it is now possible to dynamically reference the following types of data in layers of type *Text* and *HTML* as well as in tooltips:

- Component data
- Flow data
- URL data
- Variables

## Changes

### Enhancements

#### GQI DxM: Query version will no longer be linked to the DxM version [ID 44719]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a query was created, the version of that query would be linked to the current version of the GQI DxM. As a result, queries would be migrated each time the minor or major version of the GQI DxM was increased, even when nothing had been changed to the query logic.

From now on, the query version will no longer be linked to the version of the GQI DxM. Queries will only be migrated when they were altered in such a way that it prevents them from being run in their current form.

#### Dashboards/Low-Code Apps - Form component: Time spans will now be displayed in a more readable format [ID 44762]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In a *Form* component, up to now, time spans would be displayed in `dd.mm:hh:ss` format. In order to enhance the readability of those time spans, they will now be displayed in `dd days hh hrs mm mins ss secs` format instead.

See the following examples:

| Old format  | New format |
|-------------|------------|
| 10.11:00:00 | 10 days 11 hrs |
| 10.11:00:30 | 10 days 11 hrs 00 mins 30 secs |
| 0.02:03:00  | 2 hrs 03 mins |
| 0.00:05:12  | 5 mins 12 secs |
| 0.00:00:45  | 45 secs |
| 1.00:00:00  | 1 day |
| 1.00:05:00  | 1 day 00 hrs 05 mins |
| -0.01:30:00 | - 1 hr 30 mins |

#### DataMiner web apps updated to Angular 20 [ID 44794]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The DataMiner web apps that use Angular (e.g., Low-Code Apps, Dashboards, Monitoring, etc.) now use Angular 20.

#### GQI DxM has been upgraded to Microsoft .NET 10 [ID 44800]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The GQI DxM has been upgraded to Microsoft .NET 10. It no longer requires the .NET 8 runtime.

#### Web DcM has been upgraded to Microsoft .NET 10 [ID 44820]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The Web DcM has been upgraded to Microsoft .NET 10.

#### GQI DxM: Percentage values for trend data will now be passed and displayed like all other percentage values [ID 44884]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, percentage values for average trend data of discreet parameters were passed as a number between 0 to 100. In order to have percentage values passed consistently throughout all GQI data sources, from now on, those percentage values will be passed as a number between 0 to 1.

Also, in order to have all percentage values displayed consistently, percentage values for average trend data of discreet parameters will now be displayed in the culture of the user.

#### Low-Code Apps: Enhanced performance when entering text in a text box that supports highlighting [ID 44888]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Because of a number of enhancements, overall performance has increased when entering text in a text box that supports highlighting.

Up to now, when you pasted a large piece of formatted text in such a text box, in some cases, the browser could freeze for a while.

> [!NOTE]
> When you set a *Web* component to "Custom HTML", the *HTML* box is limited to 100,000 characters. Up to now, HTML syntax highlighting would be disabled from 15,000 characters onwards. From now on, this 15,000-character limit will no longer apply.

#### DataMiner Comparison tool: Enhanced performance when managing large files [ID 44897]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Because of a number of enhancements, the DataMiner Comparison tool will now be able to manage larger files.

#### Web upgrade: Prerequisite check will now verify whether .NET 10 is installed [ID 44906]

<!-- MR 10.7.0 - FR 10.6.5 -->

When you install a DataMiner web upgrade package, from now on, a prerequisite check will verify whether Microsoft .NET 10 is installed. If not, the installation will fail.

#### GQI DxM - Extensions: Display value of empty cells will no longer be discarded [ID 44947]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a GQI extension (i.e., an ad hoc data source or a custom operator) returned a cell of which the value was set to null, its display value would be discarded. From now on, this display value will no longer be discarded. Instead, it will be displayed in the UI.

#### Web apps: Splash screens have been redesigned [ID 44998]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In all DataMiner web apps, the splash screen has been redesigned in order to match the UI of the app.

### Fixes

#### Low-Code Apps - Form component: Required lazy-loaded dropdown boxes would incorrectly be marked as invalid [ID 44815]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, in a *Form* component, in some cases, required dropdown boxes of which the values were lazy-loaded would incorrectly be marked as invalid.

#### GQI DxM: 'Get profile instances' and 'Get trend data' data sources would incorrectly format parameters using invariant culture [ID 44857]

<!-- MR 10.7.0 - FR 10.6.5 -->

Up to now, the *Get profile instances* and *Get trend data* data sources would format the display values of DataMiner parameters using invariant culture and would show inconsistent group separators.

From now on, all data sources will format the display values for DataMiner parameters consistently using the culture of the user and will also use the group separator defined in that culture.

#### Dashboards/Low-Code Apps - Timeline component: Timestamps would be converted incorrectly when the user's regional settings took a long time to load [ID 44870]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When the user's regional settings took a long time to load, in some cases, timestamps would be converted incorrectly.

#### Dashboards/Low-Code Apps - Table component: Data fed to another component would not get updated during a refetch [ID 44871]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When the data in a *Table* component was fed to another component, up to now, the data in that other component would incorrectly not get updated while the data in the *Table* component was being refetched.

Also, in the different GQI components (i.e., *Table*, *Grid*, *Node edge graph*, *Timeline*, and *Maps*), a number of inconsistencies have been fixed with regard to selection behavior during a refetch.

#### Dashboards/Low-Code Apps - Query builder: Problem when inserting a node before a Join operator [ID 44883]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, in the query builder, you inserted a node (for example a filter) before a *Join* operator, up to now, some of the node's options (such as column selection, filter method, and value) would incorrectly not appear. As a result, it would not be possible to completely configure the node.

#### GQI DxM: Display values created for numeric values would incorrectly be formatted using invariant culture [ID 44903]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when display values were created for numeric values, they would always be formatted using invariant culture (unless the data source overrode this behavior). As a result, in some cases, numeric values would be displayed with a decimal separator users did not expect.

From now on, when display values are created for numeric values, by default, they will always be formatted using the culture of the user.

#### Dashboards/Low-Code Apps - Query filter component: Problem when opening the operator selection box [ID 44918]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, in a *Query filter* component, you opened the operator selection box in order to select "equals", "contains", or "match regex", in some cases, part of that selection box would incorrectly not be displayed.

#### Dashboards/Low-Code Apps: Value received from a linked component would incorrectly not be visible in an input component [ID 44927]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When an input component was fed data from another component, in some cases, the value received from the other component would incorrectly not be visible in that input component.

#### Dashboards/Low-Code Apps - Maps component: Map sessions could close unexpectedly [ID 44931]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some rare cases, a map session could close unexpectedly, causing markers or lines to disappear from the map.

#### Dashboards/Low-Code Apps - GQI components: Problem when data from another component changed rapidly [ID 44934]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, in a GQI component (e.g., *Grid*, *Table*, *Timeline*, etc.), a query was filtered by data from another component, in some cases, the filtering would not be reflected in the UI when the data from the other component changed rapidly.

#### GQI DxM: Problem when a query applied a custom operator to a row with AlarmID metadata [ID 44948]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, a query handled by the GQI DxM would fail and throw the following error when it applied a custom operator to a row with AlarmID metadata.

`Unsupported row metadata object ref type: Skyline.DataMiner.Net.Messages.SLDataGateway.AlarmID`

That same error would also occur when an ad hoc data source or custom operator added AlarmID metadata to a row.

> [!NOTE]
> Currently, there is no reason for users to define AlarmID metadata via ad hoc data sources or custom operators. At present, the *Get alarms* data source is the only built-in data source that provides AlarmID metadata.

#### Dashboards app: Side panel would incorrectly always scroll whenever a dashboard or a folder was selected [ID 44962]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, each time you selected a dashboard or a dashboard folder in the side panel, the side panel would scroll in order to get the selected item centered.

From now on, the side panel will only scroll when the newly selected item would otherwise not be entirely visible.

#### Comparison tool / DOM security app: Clicking the title button would no longer navigate to the DataMiner landing page [ID 44963]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, in the header bar of the Comparison tool and the DOM security app, you clicked the title button, you would incorrectly navigate to the root of the app instead of the DataMiner landing page.

#### Dashboards app: 'No dashboards found' icon would be hard to see on devices with small screens [ID 44967]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When you opened the Dashboards app on a device with a small screen, up to now, the *No dashboards found* icon would be hard to see. The image has now been adapted.

#### Web apps: Title of login screen would incorrectly show 'Home' instead of the app name when logging in to a landing page [ID 44968]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When you try to log in to a certain web app (e.g., Dashboards, Monitoring, etc.), the title of the login screen mentions the name of the app you want to access: `Sign in to <System name> to access <App name>`.

However, in some rare cases, when you tried to log in to the landing page of a DataMiner Agent (e.g., `https://myDma/root/`), `<App name>` would incorrectly be replaced by `Home`.

#### Low-Code Apps: 'On open' events would not take into account the correct selection when resolving event values [ID 44971]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some cases, *On open* events configured on pages or panels would not take into account the correct selection when resolving event values.

#### GQI DxM: Row metadata would be lost when a column selector that modified the order of the columns was applied to the query [ID 44974]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When a row with metadata was added via a real-time query update, up to now, the metadata would be lost when a column selector that modified the order of the columns was applied to the query.

#### GQI DxM: Log level for a particular GQI extension could not be set lower than the default setting [ID 44983]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when working with the GQI DxM, it would incorrectly not be possible to lower the log level for a particular GQI extension (i.e., an ad hoc data source or a custom operator).

From now on, similar to the way in which log levels can be either lowered or increased when working with SLHelper, it will also be possible to either lower or increase the log level for a particular GQI extension when working with the GQI DxM.

#### Dashboards/Low-Code Apps: 'Allow components to shift' setting would incorrectly not be taken into account when you resized a component [ID 45045]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the *Allow components to shift* setting would only be taken into account when you moved a component. It would incorrectly not be taken into account when you resized a component.

From now on, the *Allow components to shift* setting will be taken into account when you move a component as well as when you resize a component.
