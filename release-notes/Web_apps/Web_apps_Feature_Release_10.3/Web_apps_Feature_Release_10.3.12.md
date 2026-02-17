---
uid: Web_apps_Feature_Release_10.3.12
---

# DataMiner web apps Feature Release 10.3.12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.3.12](xref:General_Feature_Release_10.3.12).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.12](xref:Cube_Feature_Release_10.3.12).

## Changes

### Enhancements

#### Interactive automation scripts: FileSelector now allows to keep the files that were already uploaded after the UI was shown [ID 37260]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Unlike other UI block types, *FileSelector* does not allow setting an [InitialValue](xref:Skyline.DataMiner.Automation.UIBlockDefinition.InitialValue). However, from now on, during an interactive automation script session, it is possible to keep the files that were already uploaded after the UI was shown.

When an interactive automation script is executed **in a web app**, the UI block needs to keep the same [Row](xref:Skyline.DataMiner.Automation.UIBlockDefinition.Row), [Column](xref:Skyline.DataMiner.Automation.UIBlockDefinition.Column), and [DestVar](xref:Skyline.DataMiner.Automation.UIBlockDefinition.DestVar) within the session. If a block of a different type or [DestVar](xref:Skyline.DataMiner.Automation.UIBlockDefinition.DestVar) is at same location or that location has no blocks when the UI is shown again, the information about the uploaded files is lost.

See also [DataMiner Cube Feature Release 10.3.12](xref:Cube_Feature_Release_10.3.12#interactive-automation-scripts-fileselector-now-allows-to-keep-the-files-that-were-already-uploaded-after-the-ui-was-shown-id-37260)

#### Security enhancements [ID 37488] [ID 37520]

<!-- RN 37488/37520: MR 10.3.0 [CU9] - FR 10.3.12 -->

A number of security enhancements have been made.

#### Dashboards app & Low-Code Apps - GQI: Use browser locale to determine query culture [ID 37505]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when the Dashboards app or a low-code app executed a GQI query, the invariant culture would always be used by default because the Web API was not able to provide a culture.

From now on, the Web API will allow the web apps to specify a `LanguageTag` in the `DMAGenericInterfaceQueryFetchOptions`. This `LanguageTag` should contain a [BCP 47](https://www.rfc-editor.org/info/bcp47) string representation of a specific language (e.g., "en", "en-US", etc.), which will then be converted to a C# culture before being passed to GQI. For more information, see <https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.getcultureinfo>. If no valid `LanguageTag` value is provided, the invariant culture will be used as fallback.

By default, the web apps will use the browser locale to determine the culture. For more information, see <https://developer.mozilla.org/en-US/docs/Web/API/Navigator/language>.

### Fixes

#### Dashboards app: Problem with 'Clear all' button [ID 37232]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Clicking the *Clear all* button would incorrectly not clear the selection in certain components. Also, the parameters would not be removed from the dashboard's URL.

#### Dashboards app & Low-Code Apps - Table component: All table rows would incorrectly be exported when a filter was applied [ID 37473]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you applied a filter to a table and then exported the data to a CSV file, all rows would incorrectly be exported. From now on, only the visible rows (i.e., the rows that match the filter) will be exported.

#### Dashboards app & Low-Code Apps - Table component: Exceptions would cause both an empty result message and an error message to be displayed [ID 37479]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When GQI threw an exception when a session was opened, both an empty result message and an error message would be displayed on top of each other. From now on, when an exception is thrown, only an error message will be displayed.

#### Dashboards app: URL option 'showAdvancedSettings' was case sensitive [ID 37493]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, the *showAdvancedSettings* URL option would incorrectly be case sensitive. This option is now case insensitive.

#### Low-Code Apps: No longer possible to edit a low-code app of which the query migration had failed [ID 37501]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, it would no longer be possible to edit a low-code app of which the query migration had failed.

From now on, when the query migration fails, the original query will be left untouched, allowing you to edit the app and fix any errors.

#### Dashboards app & Low-Code Apps - Table component: Table headers would not get updated when the column order was changed by the query [ID 37504]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the order of the table columns was changed by the query, the table headers would incorrectly not get updated.

#### Web apps - Interactive automation scripts: Dropdown component would not show all available options [ID 37510]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, a Dropdown component in an interactive automation script would not resize itself correctly, causing some options to remain invisible.

#### Dashboards app & Low-Code Apps - Table component: Order of the cells in exported rows in CSV file would not match the order of the table headers [ID 37517]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, in a table component, you changed the order of the columns, and then exported table data to a CSV file, the order of the cells in the exported rows would incorrectly not match the order of the table headers at the top of the CSV file.

#### Web apps: Waffle menu would not open on mobile devices [ID 37535]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When you clicked the waffle button while viewing a DataMiner web app (e.g., Monitoring) on a mobile device, the menu would incorrectly not open.

#### Dashboards app: Problem when migrating empty queries [ID 37537]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, attempts to migrate empty queries would fail. From now on, no errors will occur anymore when migrating empty queries.

#### Low-Code Apps: Problem when feeding falsy values to app actions [ID 37538]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a falsy value (empty string, 0, etc.) was fed as an argument of an app action, that value would not be updated correctly.

#### Dashboards app & Low-Code Apps: Numeric input component would not get the focus when one of its arrow buttons was clicked [ID 37543]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, a *Numeric input* component would not automatically get the focus when you clicked one of its arrow buttons. As a result, the feed value of the component would also not get updated.

From now on, when you click the *Up* or *Down* button of a *Numeric input* component, it will get the focus and its feed value will be updated.

#### Dashboards app: 'No parameters available' error would appear when trying to retrieve parameters belonging to a stopped element [ID 37561]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, in the Dashboards app, parameters belonging to a stopped element were retrieved, a *No parameters available* error would appear.

From now on, element lists will no longer include non-active elements. As a result, it will no longer be possible to select parameters belonging to non-active elements.

#### Dashboards app & Low-Code Apps - Chart components: Basic updates no longer triggered a refresh of the visualized data [ID 37567]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the *Column & bar chart*, *Line & area chart* and *Pie & donut chart* components were fed by a query that did not support full real-time updates, basic updates to those components would no longer trigger a refresh of the visualized data.

#### Dashboards app & Low-Code Apps - Table component: Exporting data to CSV would incorrectly be possible when the table was empty [ID 37585]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, it would incorrectly be possible to export table data to a CSV file when a table did not display any rows. From now on, when a table does not display any rows (e.g., when no rows match the applied filter), the button allowing you to export the table data to a CSV file will be disabled.

#### Dashboards app: Sidebar would overlap large components when the viewport was too narrow [ID 37594]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a component was too large to fit into a narrow viewport (e.g., when viewing the dashboard on a mobile device), in some cases, the sidebar would incorrectly overlap the component.

This issue would also occur when a visual overview had been embedded in a *Visual overview* component that was too small.

#### Low-Code Apps: Deleting all components on a panel using the Delete button would delete all components on the page [ID 37615]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, while editing a panel in a low-code app, you used Ctrl+A to select all components on that panel and pressed DELETE to delete them, this would not only delete the components on the panel but also the other components on the rest of the page.

#### Dashboards app & Low-Code Apps: Node keys would be omitted when converting a query to a JSON string [ID 37627]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, when a query using node keys was converted to a JSON string, the node keys would incorrect be omitted.

#### Dashboards app & Low-Code Apps - Table component: Header bar options would not reinitialize correctly after the table data had been refreshed [ID 37643]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

The options shown on the header bar of a table component would not reinitialize correctly after the table data had been refreshed.

#### Low-Code Apps: Multiple context menus could incorrectly be opened at the same time [ID 37652]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, multiple context menus could incorrectly be opened at the same time. From now on, when you open a context menu while another one is still open, that open menu will first be closed.

#### Low-Code Apps: Problem when a component refetched its data multiple times in quick succession [ID 37654]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a component refetched its data multiple times in quick succession, a `There are no open sessions` error would be thrown.

#### Dashboards app - Query builder: Too much whitespace below a query after its migration had finished [ID 37660]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, in the query builder, you opened an unused query, too much whitespace would be shown below it when its migration had finished.

#### Dashboards app & Low-Code Apps - Bar chart and Pie & donut chart: Chart configuration could get changed unexpectedly [ID 37662]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the query of a *Bar* chart or a *Pie & donut* chart was linked to a feed as a filter, in some cases, the chart configuration could get changed unexpectedly.

#### Low-Code Apps: Images on a low-code app would only be visible to users who had permission to view dashboards [ID 37667]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When you opened a low-code app you were allowed to view, the images on that low-code app would not be visible unless you had permission to view dashboards.

#### Web apps - Visual Overview: Pop-up window containing a page from another visual overview could not be opened [ID 37685]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a visual overview was opened on a mobile device, it would not be possible to open another page in a pop-up window when that other page was part of a visual overview linked to another object.

#### Dashboards app - Query builder: Filter would ignore changes made to boolean columns the dashboard had been refreshed [ID 37697]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, in a query, a filter had been applied to a boolean column, the filter would ignore any changes made to that boolean column after you had refreshed the dashboard. In other words, when the query was used to fetch data to be displayed in a table component, the table would not reflect changes made to that boolean column as the filter would not apply those changes.

#### Dashboards app - Query builder: Problem when a string specified in a filter node exceeded the width of the input box [ID 37701]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a filter node that filtered a column of type string was set to a string that exceeded the width of the input box, up to now, the contents of that input box would not wrap to the next line. From now on, it will.

#### Values of URL-encoded parameters could incorrectly get changed when the Authentication app redirected you back after logging in [ID 37704]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When IIS redirected you to the Authentication app after you had clicked a URL containing URL-encoded parameters, in some cases, those URL-encoded parameters would not be encoded correctly. When the Authentication app redirected you back after you had logged in, in some cases, the values of those parameters had incorrectly changed.
