---
uid: Web_apps_Feature_Release_10.4.12
---

# DataMiner web apps Feature Release 10.4.12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.12](xref:General_Feature_Release_10.4.12).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.12](xref:Cube_Feature_Release_10.4.12).

## Highlights

- [Dashboards/Low-Code Apps: Flows [ID 40974]](#dashboardslow-code-apps-flows-id-40974)
- [Dashboards/Low-Code Apps: Variables [ID 41039] [ID 41063] [ID 41132]](#dashboardslow-code-apps-variables-id-41039-id-41063-id-41132)

## New features

#### Interactive automation scripts: New option to skip the confirmation window when aborting [ID 40700]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

DataMiner web applications now support the new `SkipAbortConfirmation` property that was added to `UIBuilder`. When this property is set to true, the confirmation window will not be displayed when the interactive automation script is aborted. By default, this property will be set to false.

> [!TIP]
> See also: [Interactive automation scripts: New option to skip the confirmation window when aborting [ID 40683]](xref:General_Feature_Release_10.4.12#interactive-automation-scripts-new-option-to-skip-the-confirmation-window-when-aborting-id-40683)

#### Dashboards/Low-Code Apps: Flows [ID 40974]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Flows allow you to modify the behavior of one or more data objects by applying a series of operators. Similar to how GQI works, operators are chained together and applied to the data object step by step until a final value is reached, which is then passed to all consumers.

Examples:

- If a text input provides a text feed, we can use that feed to trigger a query. If the text box is set to update upon every key press, a query is executed with each keystroke. However, by applying a *debounce* in a flow, you can adjust this behavior so that the query runs only after the user has stopped typing for a certain time.

- Instead of fetching all the data for a particular timeline, you only want to fetch the data for the current viewport.

Currently, you can use the following operators:

| Operator | Function |
|----------|----------|
| Combine  | Combines multiple inputs into one by forwarding *the most recently updated value of each input* as the output. Whenever any input changes, the operator will emit the *combination of all latest values*. |
| Debounce | Delays the emission of a value until a specified amount of time has passed without another value having been received. |
| Merge    | Merges multiple inputs into one by forwarding *the most recently updated input* as the output. Whenever any input changes, the operator will emit the *latest* value. |

#### Dashboards/Low-Code Apps: Variables [ID 41039] [ID 41063] [ID 41132]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When editing a dashboard or a low-code app, you can now create data objects called "variables".

A variable has the following properties:

- A name, which must be unique within the dashboard or the low-code app.
- A type: Element, View, Service, Text, Number, Table, DOM instance
- A default value

  > [!NOTE]
  > In a low-code app, specifying a default value for a variable is optional, except when the variable is marked *Read-only* (see below).

- Read-only. When selected, the variable cannot be modified at runtime.

  > [!NOTE]
  >
  > - Dashboard variables are always read-only. Only variables in low-code apps will allow you to change their *Read-only* property.
  > - If, in a low-code app, you make a variable read-only, specifying a default value for it will no longer be optional.

Variables of a certain type can be used wherever you can use that specific type. You can drop a variable onto a component, link it in a query, use it in a flow, etc.

Variables of type *Table* are static tables that can have up to 20 columns and/or 100 rows. In these tables, cells can contain the following types of data: Text, Number and Boolean. Also, users can specify a display value for each cell.

#### Dashboards/Low-Code Apps: 'Dropdown', 'Tree' and 'List' components are now also able to show table data [ID 41161]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

*Dropdown*, *Tree* and *List* components are now also able to show table data. This means that you will now be able to drop both queries or tables on top of them.

- If you add a single table/query, the component will show the individual rows as entries. Selecting an entry will expose the entire row.
- If you add multiple tables/queries, the component will show the list of tables/queries. Selecting an entry will expose the entire table (in case of table data) or the query (in case of query data).

When you add a table/query to one of the above-mentioned components, you can specify the column that contains the display values in the *Layout > Advanced > Display column* setting.

## Changes

### Breaking changes

#### Monitoring app: Alarm card URLs now also contain the element ID [ID 41059]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

From now on, Monitoring app alarm card URLs will also contain the element ID.

New URL format: `/alarm/DMAID/ELEMENTID/ROOTALARMID/ALARMID`

### Enhancements

#### Dashboards/Low-Code Apps: GQI sessions will now be executed asynchronously over WebSockets [ID 40416]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, after a GQI session had been opened, all necessary pages would be requested synchronously.

From now on, a GQI query will be opened synchronously, after which a first page will be sent to the client over WebSockets without the client having to request it. Then, the client will request and receive all following pages over WebSockets.

When WebSockets are not available, GQI sessions will be executed synchronously as before.

#### Low-Code Apps: 'Open monitoring card' event can now be passed the name of an element, service or view as a text string or a feed containing text data [ID 40814] [ID 41067]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, an *Open monitoring card* event was only able to open the card of an element, service or view that either had been selected during its configuration or was provided via a feed. From now on, it will also be possible to pass the name of an element, service or view as a text string or any feed containing text data.

#### Dashboards/Low-Code Apps - Node edge graph component: Initial viewport in case of custom node positions will now be calculated based on the midpoints of all nodes [ID 40869]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you opened a node edge graph component with custom node positions, up to now, its initial viewport was [50,50]. From now on, its center will be calculated based on the midpoints of all its nodes.

#### Dashboards/Low-Code Apps - GQI components: Query result set is now limited to 100,000 rows [ID 40886]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

From now on, all GQI components will no longer be allowed to fetch more than 100,000 items in total. When this limit has been reached, a message will be displayed at the bottom of the component.

#### Low-Code Apps: Enhanced performance when opening or updating low-code apps [ID 40944]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Because of a number of enhancements, overall performance has increased when opening or updating low-code apps.

#### Dashboards app: Enhanced error handling when sharing dashboards [ID 40946]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When an error occurs while you are sharing a dashboard, in some cases, the "Failed saving WAF rules" message will appear.

From now on, when that message appears, the cause of the error will be added to the web API logs.

#### Low-Code Apps: Version history pane now also shows the version numbers [ID 41034]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you open the *Version history* pane of a low-code app, it will now also display the version numbers.

#### Monitoring app is now compatible with new alarm IDs [ID 41060]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

The Monitoring app is now fully compatible with the new alarms IDs that will be used on systems with Swarming enabled.

#### Dashboards/Low-Code Apps: Data type 'String' and 'Query row' have been renamed to 'Text' and 'Table' [ID 41075]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

The following data types have been renamed:

| Former name | New name |
|-------------|----------|
| String      | Text     |
| Query row   | Table    |

#### Low-Code Apps: Enhanced performance when publishing a low-code app [ID 41078]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Because of a number of enhancements, overall performance has increased when publishing a low-code app.

#### Dashboards app: Minor enhancements regarding user permissions [ID 41079]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

A number of minor enhancements have been made with regard to dashboard user permissions.

For example, in the *Dashboard settings* window, *Access* has now been renamed to *Permissions*. Also, when you strip the person who created a dashboard of their edit rights, a message saying "You have removed the edit rights from the creator" will now appear.

#### Dashboards/Low-Code Apps - Alarm table component: 'Alarm ID' and 'Root Alarm ID' columns will now also include the element ID [ID 41113]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

The alarm ID in the *Alarm ID* and *Root Alarm ID* columns will now also include the element ID.

#### Web apps: Gray colors updated in themes used by the web apps [ID 41131]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In the color themes used by the web apps, the gray colors have been updated.

#### Root page: Adding, updating or deleting an application will no longer cause the entire application list to get refreshed [ID 41135]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when you added, updated or deleted an application on the root page (e.g. `https://myDma/root/`), the entire list of applications would always be refreshed. From now on, only the information that has changed will be refreshed.

#### Dashboards/Low-Code Apps: Term 'Feed' replaced by 'Components' and 'URL' [ID 41141]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, Dashboards and Low-Code Apps had a separate "feed" component category. Now, the term "Feed" has been removed from the UI across all contexts, reflecting that all components in a dashboard or low-code app can expose data, and not just feed components.

The following changes have been made:

- The *Feeds* visualization category has been removed. Its components have been redistributed as follows:

  - General: Time range, query filter, and trigger components

  - Other: List, tree, parameter picker (previously "parameter feed"), and EPM picker (previously "EPM feed") components

- The *Feeds* section in the *Data* tab is now called "Components". This section now represents data exposed by each component in the dashboard or app.

- URL data, previously included under *Feeds* in the *Data* tab, now has its own section named "URL".

- The syntax for [dynamically referencing data in text](xref:Dynamically_Referencing_Data_in_Text) has been updated. For example:

  - Old: `{Feed."Table 1"."Selected rows"...}`

  - New: `{Component."Table 1"."Selected rows"...}`

- Several settings that previously included the term "Feed" have been renamed.

### Fixes

#### Web APIs: Problem when an exception was thrown while processing a bulk request [ID 40884]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When an exception was thrown while processing a bulk request, in some cases, the web APIs could stop working.

#### Low-Code Apps: Web component would not be initialized correctly after it had received an update [ID 40893]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In some cases, a Web component would not be initialized correctly after it had received an update.

#### Dashboards/Low-Code Apps - Table, Maps, Grid & Timeline components: Templates did not allow any interaction when the component was loading [ID 40909]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In case of a Table, Map, Grid or Timeline component, the templates did not allow any interaction when the component was loading. Also, feeds and conditions would not be updated.

#### Web apps: Authentication page would show 'A username is required' message although user name and password were filled in [ID 40925]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, on the authentication page, you clicked *Log on* while your user name and password were both filled in, in some cases, the "A username is required." message would incorrectly appear. When you then clicked *Log on* again, the logon request would succeed.

#### Dashboards/Low-Code Apps - GQI: Problem when arguments of ad hoc data sources were set to empty strings [ID 40932]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When a required argument of an ad hoc data source was set to an empty string, up to now, the empty string would incorrectly not be seen as a valid value. Hence, queries using that ad hoc data source would not get executed.

From now on, arguments of ad hoc data sources will be allowed to have an empty string as value.

#### Dashboards app - State component: Problem when loading parameter data [ID 40949]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When parameter data was loaded into a *State* component, the dashboard could get stuck in an infinite loop.

#### Legacy Reports & Dashboards app: No longer logged in automatically when being logged in to another web app [ID 40989]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, on a system that was not using automatic Windows authentication, you were logged in to one of the other web apps (e.g. Monitoring, Dashboards, etc.), you would no longer automatically be logged in to the legacy *Reports & Dashboards* app.

#### Dashboards app - Generic map component: Problem when rendering maps with AppVersion set to 1 [ID 41035]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Since DataMiner feature version 10.4.9, a *Generic map* component would no longer be able to render maps of which the `AppVersion` property was set to 1 in the `C:\Skyline DataMiner\Maps\ServerConfig.xml` file.

Example:

```xml
<MapsServerConfig>
    <VirtualHosts>
        <VirtualHost hostname="*">
            <AppVersion>1</AppVersion>
            ...
        </VirtualHost>
    </VirtualHosts>
</MapsServerConfig>
```

#### Web Services API v1: Problem with SOAP methods 'GetVisioFor...' [ID 41036]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Due to a serialization issue, the `GetVisioFor...` methods would throw an error when the Visio page contained shapes that executed automation scripts with dummies, parameters or memory files.

#### Dashboards/Low-Code Apps: Migration of a dashboard or page of a low-code app would incorrectly continue when the dashboard or page was closed [ID 41045]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When a dashboard or a page of a low-code app was closed, up to now, when a migration was in progress, it would incorrectly continue. From now on, when a dashboard of page of a low-code app is closed while it is being migrated, the migration will be cancelled.

#### Dashboards/Low-Code Apps - Time range component: Apply and Cancel buttons were not positioned correctly when no presets had been configured [ID 41085]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when no presets had been configured in a *Time range* component, the *Apply* and *Cancel* buttons would be too close to the date/time pickers. From now on, when a *Time range* component does not have presets configured, both buttons will be positioned correctly below the date/time pickers.

#### Low-Code Apps: Problem when creating a new draft [ID 41091]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when you created a new draft, in some cases, a `Dashboard not found` error could incorrectly appear.

#### Low-Code Apps: Problems when installing a low-code app [ID 41094]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you installed a low-code app, in some cases, it would not have the correct icon and color scheme.

Also, it would not be possible to install more than one low-code app per DataMiner Agent.

#### Dashboards/Low-Code Apps - Table component: Problem when removing the only or the last query [ID 41096]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you removed either the only or the last query from a Table component, the loader bar would appear and get stuck.

#### Low-Code Apps - Node edge graph component: Problem with 'Open monitoring card' action [ID 41105]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you added an *Open monitoring card* action to a *Node edge graph* component, an error would occur.

#### Dashboards/Low-Code Apps - Maps component: Markers would be removed when panning or zooming out while map data was being retrieved [ID 41125]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you panned or zoomed out while map data was being retrieved, in some cases, the markers could be removed from the map.

#### Dashboards/Low-Code Apps - Timeline component: Problem with items that should only become visible when you hover over them [ID 41127]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When your mouse pointer was hovering over a timeline item that should only become visible when you hover over it, in some cases, it would incorrectly not be displayed. In order to have it displayed, you had to move the mouse pointer away from the timeline and back.

#### Interactive automation scripts: Problem when none of the components had an identifier configured [ID 41128]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When none of the components defined in an interactive automation script had an identifier (DestVar) configured, interacting with the UI of the script would result in an exception being thrown.

#### Dashboards/Low-Code Apps - Web component: URL changes would no longer be detected [ID 41179]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

The *Web* component would no longer detect that the URL had changed. As a result, the component would go blank instead of showing the expected web page.

#### Dashboards/Low-Code Apps - Table component: Users would incorrectly be able to select rows while the data was being loaded [ID 41186]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, users would incorrectly be able to select rows while the data was being loaded into the table.

#### Low-Code Apps: Problem when migrating a low-code app created before the introduction of the template editor [ID 41193]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

During the migration of a low-code app that was created before the introduction of the template editor, in some cases, an error could occur.

#### Dashboards/Low-Code Apps: GQI components did not fully support static tables [ID 41197]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

While all GQI components (i.e. *Table*, *Grid*, *Maps*, *State*, *Column & bar chart*, *Pie & donut chart*, *Line & area chart*, *Node edge graph*)allowed you to drop tables onto them as data, up to now, they would not fully support those static tables.

In many cases, a component would not be able to properly visualize the table. Also, users would not be able to properly configure the component settings.

From now on, the GQI components will fully support dropping tables onto them as data.

#### Dashboards app: After duplicating a dashboard, the components in both dashboards would incorrectly have the same ID [ID 41199]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When you had duplicated a dashboard, the components in the newly created duplicate dashboard incorrectly had the same IDs as the components in the original dashboard. As a result, when you changed a component in one dashboard, those changes would also be applied to that same component in the other dashboard.

#### Dashboards/Low-Code Apps - Image component: Uploaded images would incorrectly not be synchronized within a DMS [ID 41202]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Uploaded images shown in an *Image* component would incorrectly not be synchronized among all DataMiner Agents in a DMS. As a result, no image would be shown if the dashboard or low-code app was accessed from a DMA other than the one onto which the image had been uploaded.

#### Low-Code Apps: Additions, updates and removals would not be synchronized among the DMAs in the DMS [ID 41228]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] / 10.5.0 [CU0] - FR 10.4.12 [CU0] -->

When you created, updated or deleted a low-code app, this would incorrectly not be synchronized among the DataMiner Agents in the DMS.

#### Dashboards/Low-Code Apps - Web component: Default margin would incorrectly no longer be 0px when showing custom HTML [ID 41241]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] / 10.5.0 [CU0] - FR 10.4.12 [CU0] -->

The default margin of a *Web* component in which *Type* was set to "Custom HTML" would incorrectly no longer be 0px. This would cause scrollbars to appear.

#### Dashboards app: Problem when running a GQI query multiple times in quick succession [ID 41246]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] / 10.5.0 [CU0] - FR 10.4.12 [CU0] -->

When a GQI query was run multiple times in quick succession, in some cases, a `Session does not exist` error could appear.

#### Dashboards/Low-Code Apps: No chart data would be shown when a parameter value was fed to a Line & area chart component linked to a Time range component [ID 41252]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] / 10.5.0 [CU0] - FR 10.4.12 [CU0] -->

When the value of a parameter selected in another component (e.g. a *Gauge* or a *Ring* component) was fed to a *Line & area chart* component that was linked to a *Time range* component, in some cases, the *Line & area chart* component would not show any data.

#### Monitoring/Dashboards/Low-Code Apps - Line & area chart component: Changes would not always be detected and processed properly [ID 41470]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 [CU0] -->

Up to now, in some cases, changes made to a *Line & area chart* component would not be reflected corrected in the UI. This could lead to the following problems:

- Trend cards in the *Monitoring* app would be empty or would not update properly.
- Trend cards in the *Monitoring* app would not use the proper *Monitoring* app color as trend line color.
- Data changes in dashboards would not always be applied in *Line & area chart* components:

  - Time ranges would not always be applied correctly.
  - The trend lines would not always correctly reflect the actual trend of a parameter.
  - Scrolling fast through a trend chart could result in that chart getting stuck in a loading state.
  - etc.

Also, an issue has been fixed regarding errors coming from trend requests. Up to now, in some cases, "[Object object]" would be displayed instead of the actual error message.
