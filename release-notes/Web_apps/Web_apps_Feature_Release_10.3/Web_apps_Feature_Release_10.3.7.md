---
uid: Web_apps_Feature_Release_10.3.7
---

# DataMiner web apps Feature Release 10.3.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.7](xref:General_Feature_Release_10.3.7).

## New features

#### Interactive Automation scripts: New DownloadButton component [ID_35869]

<!-- MR 10.4.0 - FR 10.3.7 -->

In an interactive Automation script launched from a dashboard or a low-code app, you can now use *DownloadButton* components. These components allow you to add download buttons that will enable users to download a specified file from the server.

To add a *DownloadButton* component to an interactive Automation script, create a *UIBlockDefinition* and set its *Type* property to "UIBlockType.DownloadButton". The button can be configured and styled in same way as a regular button component. For example, you can set the *Style* property to "Style.Button.CallToAction" and the *Text* property to "Download".

To configure the download properties, assign `AutomationDownloadButtonOptions` to the *ConfigOptions* property of the *UIBlockDefinition*.

These are the supported download properties:

- **Url**: The URL of the file. This URL can be either an absolute or a relative path.

  - An absolute path must refer to a file that is publicly accessible on the internet.
  - A relative path is relative to the DMA hostname and must start with `/`, `./` or `../`.

  Examples:

  - Example of an absolute path: To download the latest Cube version from DataMiner Services, set *Url* to `https://dataminer.services/install/DataMinerCube.exe`.
  - Example of a relative path: To download the file hosted on URL `http(s)://yourDma/Documents/MyElement/MyDocument.txt` (i.e. the file *MyDocument.txt* located in the folder `C:\Skyline DataMiner\Documents\MyElement\` of the DMA), set *Url* to `/Documents/MyElement/MyDocument.txt`.

- **FileNameToSave**: The name that will be given to the file once it has been downloaded. By default, this name is identical to that of the file at the remote location.

  > [!NOTE]
  > Some browsers block overriding the file name when the file to be downloaded is not located on the DataMiner Agent. In this case, the original file name will be used.

- **StartDownloadImmediately**: If set to true (default setting is false), the download will start as soon as the component is displayed. The button will stay visible and can be clicked to download the file again.

- **ReturnWhenDownloadIsStarted**: If set to true (default default is false), the `engine.ShowUI()` method will return as soon as the download is started (either immediately or when the user clicks the button, depending on *StartDownloadImmediately*). When both *StartDownloadImmediately* and *ReturnWhenDownloadIsStarted* are set to true, the script will start the download and exit immediately (unless a new `engine.ShowUI()` call is made).

  > [!NOTE]
  > The script's UI will be visible for about half a second.

The `UIResult` now also supports the following function method, which returns true when a download button with *ReturnWhenDownloadIsStarted* set to true has started a download.

```csharp
bool WasOnDownloadStarted(string key)
```

> [!NOTE]
>
> - Modern browsers block downloads from a `file:///` URL to an HTTP(s) address. In other words, they don't allow you to download a file located on a network share. As a workaround, you can copy the file from the network share to *Documents* (or any other HTTP-reachable location), and then let the client download it from that URL.
> - The current IIS configuration does not allow all file types to be downloaded.

#### Dashboards app & Low-Code Apps - Column & bar chart / Pie & donut chart: Automatically select columns based on type [ID_36229]

<!-- MR 10.4.0 - FR 10.3.7 -->

When you add a query to a *Column & bar chart* component or a *Pie & donut chart* component, the label, segment size and bars will now automatically be configured.

To do so, the system will proceed as follows:

1. Search for a column that contains label values (i.e. a column with heading "label", "name", etc.).
1. Search for a column that contains segment size or bar size values (i.e. a column with heading "amount", "value", "quantity", etc.).
1. If nothing could be found in steps 1 and 2, take the first string value as label and the first numeric value as segment size or bar size value.

> [!NOTE]
> Existing *Column & bar chart* components and *Pie & donut chart* components will be migrated automatically.

## Changes

### Enhancements

#### Security enhancements [ID_36217]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

A number of security enhancements have been made.

#### External authentication using SAML: Enhanced error handling [ID_36274]

<!-- MR 10.4.0 - FR 10.3.7 -->

Instead of a generic error message, a more meaningful error message will now appear when something goes wrong while authenticating a user via SAML.

#### Monitoring app: Enhanced parameter controls [ID_36275]

<!-- MR 10.4.0 - FR 10.3.7 -->

In the *Monitoring* app, the parameter controls have been enhanced. You will now be able to edit a parameter by clicking a pencil icon.

#### Dashboards app & Monitoring app: Parameter page component now supports WebSockets [ID_36314]

<!-- MR 10.4.0 - FR 10.3.7 -->

The *Parameter page* component now supports the WebSocket protocol. As a result, parameter updates will now be received immediately.

#### Monitoring app: Enhanced performance when editing a parameter on a parameter page component [ID_36348]

<!-- MR 10.4.0 - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when editing a parameter on a parameter page component.

#### Monitoring app - Parameter control: Clicking the trending icon of a parameter will immediately open the trending page [ID_36352]

<!-- MR 10.4.0 - FR 10.3.7 -->

Up to now, when you clicked the trending icon of a parameter, the parameter edit pane would expand, showing additional information about that parameter. From now on, when you click the trending icon of a parameter, the trending page will open instead.

#### Dashboards app & Low-Code Apps - Table component: Selected rows will again be selected after refetching the data [ID_36372]

<!-- MR 10.4.0 - FR 10.3.7 -->

From now on, when table data is refetched with a trigger or an action, the rows that were selected before the refetch will automatically be selected again.

#### Dashboards app & Low-Code Apps: Enhanced migration message [ID_36435]

<!-- MR 10.4.0 - FR 10.3.7 -->

When a dashboard or a low-code app page is being migrated, a message will appear to notify the user.

From now on, when the user has edit permission, the message will only appear when the migration takes longer than 15 seconds. When the user does not have edit permission, the message will appear immediately at the start of the migration, notifying the user that the migration will not be saved and that it will be repeated every time the dashboard or low-code app page is loaded.

#### Dashboards app & Low-Code Apps: No visual replacement will be displayed anymore when a State component feeds empty query rows [ID_36460]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, when a *State* component fed empty query rows, a visual replacement would be displayed. From now on, this will no longer be the case.

### Fixes

#### Dashboards app & Low-Code Apps - Line chart: X and Y axis labels would not show the correct text [ID_35943]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The X and Y axis labels of a line chart would not show the correct text when the data was grouped.

#### Dashboards app & Low-Code Apps: Components would prematurely consider themselves loaded [ID_36142]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

In some cases, components would incorrectly consider themselves loaded while they were still loading. As a result, it would already be possible to execute actions on those components before those actions could be properly processed.

#### Dashboards app & Low-Code Apps - Query builder: Select nodes would incorrectly not show the selected columns [ID_36251]

<!-- MR 10.4.0 - FR 10.3.7 -->

In the query builder, when a *Select* node was not in edit mode, its description would incorrectly not show the selected columns.

#### Dashboards app & Low-Code Apps: State component would incorrectly not be cleared when its input feed was cleared [ID_36261]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, a *State* component would incorrectly not be cleared when its input feed was cleared.

#### Low-Code Apps: Table actions would incorrectly be executed before the rows were fed [ID_36263]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, table actions would be executed before the rows were fed. As a result, the feed would get lost when you navigated away from the page via an action. From now on, a row will always be fed before row actions are executed.

#### Low-Code Apps: Custom icon of a low-code app without a draft version would not be displayed on the DataMiner landing page [ID_36277]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a low-code app with a custom icon did not have a draft version, the DataMiner landing page would incorrectly not display the icon of that app.

#### Dashboards app: Height of 'DATA USED IN DASHBOARD' section would incorrectly change after collapsing and expanding it [ID_36282]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you collapsed and expanded the *DATA USED IN DASHBOARD* section of the *DATA* tab, in some cases, the height of that section would incorrectly change.

#### Dashboards app & Low-Code Apps: Updating a query would incorrectly not update the query filter component [ID_36283]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a query was updated, the query filter component would incorrectly only get updated after a refresh.

#### Monitoring app: Surveyor items would be sorted incorrectly [ID_36303]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In the Surveyor of the Monitoring app, items of which the name contained a number would be sorted incorrectly. For example, *Element 2* would appear below *Element 11*. From now on, the items in the Surveyor of the Monitoring app will be sorted in the same way as those in the Surveyor of DataMiner Cube.

#### Dashboards app: Problem with trend components in PDF reports [ID_36331]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

In a PDF report of a dashboard, in some cases, trend components would collide with other components.

#### GQI: Table unable to feed data when its query included a column manipulation [ID_36350]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a query that retrieved object manager instances followed by a column manipulation and a select operator was added to a table component, the table would incorrectly not be able to feed object manager instances to other components.

#### Dashboards app & Low-Code Apps - Table component: Columns with an action applied would not show a loading indication [ID_36376]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

Table columns that had an action applied would incorrectly not show a loading indication. Instead, they would remain empty until the data was loaded.

#### Dashboards app & Low-Code Apps - Line & area chart: Legend would incorrectly show the primary key of a parameter [ID_36381]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The chart legend would incorrectly show the primary key of a parameter instead of the display key.

#### Dashboards app: Problem when opening a dashboard of which the URL was longer than 2048 characters [ID_36382] [ID_36510]

<!-- MR 10.4.0 - FR 10.3.7 -->
<!-- Not added to MR 10.4.0 -->

When you opened a dashboard of which the URL was longer than 2048 characters, the authentication app would fail to open, causing IIS to either stop operating or throw a 404 or 414 error.

#### GQI: Exception thrown when grouping an empty aggregation result [ID_36392]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

An exception would be thrown when executing a query that first applied an aggregation on an Elasticsearch table, which produced an empty result set, and then grouped that empty result set by operation.

Exception that was thrown:

```txt
(*) Error trapped: Unable to cast object of type '<CastIterator>d__97`1[Skyline.DataMiner.Net.SLSearch.Messages.ValueAggregation]' to type 'Skyline.DataMiner.Net.SLSearch.Messages.AggregationContainer'.
```

Example of a query that would cause the above-mentioned exception to be thrown:

```txt
1. Get parameter table by ID (fetches the data from the Elasticsearch table)
2. Filter "column 1" on value "A" (in this particular example, a filter will cause no rows to be returned)
3. Aggregate "column 1"
4. Group by "column 2"
```

#### Dashboards app & Low-Code Apps: A message would no longer be displayed when a component was being migrated [ID_36410]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

A message would incorrectly no longer be displayed when a component was being migrated to the most recent version. From now on, when a component is being migrated, a message showing the component icon and the text *Migrating...* will again be displayed.

#### Dashboards app: Problem when updating a query linked to a feed [ID_36414]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When a dashboard contained a query component that was linked to a feed, the app could become unresponsive when the feed would send updates faster than the time it took to resolve the query.

#### Dashboards app & Low-Code Apps: Table components sharing the same GQI query could end up containing duplicate rows [ID_36416]

<!-- MR 10.4.0 - FR 10.3.7 -->

When multiple table components used the same GQI query, in some rare cases, those components could end up containing duplicate rows.

#### Web API: Problem when migrating queries [ID_36442]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The web API would no longer be able to correctly migrate queries in which ad hoc data source arguments contained null values.

Also, when those queries were linked to feeds, the migration would break those links.

#### Low-Code Apps: Action to open an already open panel would not resolve [ID_36457]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

Up to now, when an action to open an already open panel was triggered, it would incorrectly not resolve. As a result, all actions configured to be executed upon completion of that *Open* action would not be executed.

#### Dashboards app & Low-Code Apps: An error would appear when two GQI visualizations used the same query [ID_36465]

<!-- MR 10.4.0 - FR 10.3.7 -->

When the same query was used in two different GQI visualizations, one of those visualizations would display the following error:

```txt
Cannot read properties of null ('reading delete')
```

#### Low-Code Apps: Table actions would not get triggered when the GQI data source row key was of type string [ID_36488]

<!-- MR 10.4.0 - FR 10.3.7 [CU0] -->
<!-- Not added to 10.4.0 -->

Table actions would incorrectly not be triggered when the key of the GQI data source row was of type string.

#### GQI: IsChecked property would not be filled in for list and drop-down options in SLAnalyticsTypes.dll [ID_36491]

<!-- MR 10.4.0 - FR 10.3.7 -->

When you installed a DataMiner web upgrade for version 10.3.5 or newer on a server running a DataMiner version older than 10.3.5, the value of the `IsChecked` property would not be filled in for list and drop-down options in *SLAnalyticsTypes.dll*. As a result, list and drop-down options that should be selected by default, would not be selected by default.

#### Dashboards app & Low-Code Apps: Problem when sending updates to the Web API when the user did not have edit rights [ID_36571]

<!-- MR 10.3.0 [CU5] - FR 10.3.7 [CU0] -->

When a pie chart or a bar chart had its settings changed automatically, in some cases, an update would be triggered in the background, causing the Web API to throw an error when the user did not have edit rights. From now on, when the user does not have edit rights, updates will no longer be sent to the Web API.

#### Dashboards app & Low-Code Apps: Problem with large tables in PDF reports [ID_36616]

<!-- MR 10.3.0 [CU5] - FR 10.3.7 [CU0] -->

When you generated a PDF report of a dashboard that contained a large table, in the PDF report, the table would incorrectly not contain all rows. Moreover, the rows in the table would all show a loading state.
