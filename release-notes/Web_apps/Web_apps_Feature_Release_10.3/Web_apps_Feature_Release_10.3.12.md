---
uid: Web_apps_Feature_Release_10.3.12
---

# DataMiner web apps Feature Release 10.3.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.12](xref:General_Feature_Release_10.3.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Interactive Automation scripts: FileSelector now allows to keep the files that were already uploaded after the UI was shown [ID_37260]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Unlike other UI block types, *FileSelector* does not allow setting an [InitialValue](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_InitialValue). However, from now on, during an interactive Automation script session, it is possible to keep the files that were already uploaded after the UI was shown.

When an interactive Automation script is executed **in a web app**, the UI block needs to keep the same [Row](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_Row), [Column](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_Column), and [DestVar](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_DestVar) within the session. If a block of a different type or [DestVar](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_DestVar) is at same location or that location has no blocks when the UI is shown again, the information about the uploaded files is lost.

See also [DataMiner Cube Feature Release 10.3.12](xref:Cube_Feature_Release_10.3.12#interactive-automation-scripts-fileselector-now-allows-to-keep-the-files-that-were-already-uploaded-after-the-ui-was-shown-id_37260)

#### Security enhancements [ID_37488] [ID_37520]

<!-- RN 37488/37520: MR 10.3.0 [CU9] - FR 10.3.12 -->

A number of security enhancements have been made.

#### Dashboards app & Low-Code Apps - GQI: Use browser locale to determine query culture [ID_37505]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when the Dashboards app or a low-code app executed a GQI query, the invariant culture would always be used by default because the Web API was not able to provide a culture.

From now on, the Web API will allow the web apps to specify a `LanguageTag` in the `DMAGenericInterfaceQueryFetchOptions`. This `LanguageTag` should contain a [BCP 47](https://www.rfc-editor.org/info/bcp47) string representation of a specific language (e.g. "en", "en-US", etc.), which will then be converted to a C# culture before being passed to GQI. For more information, see <https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.getcultureinfo>. If no valid `LanguageTag` value is provided, the invariant culture will be used as fallback.

By default, the web apps will use the browser locale to determine the culture. For more information, see <https://developer.mozilla.org/en-US/docs/Web/API/Navigator/language>.

### Fixes

#### Dashboards app: Problem with 'Clear all' button [ID_37232]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Clicking the *Clear all* button would incorrectly not clear the selection in certain components. Also, the parameters would not be removed from the dashboard's URL.

#### Dashboards app & Low-Code Apps - Table component: All table rows would incorrectly be exported when a filter was applied [ID_37473]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you applied a filter to a table and then exported the data to a CSV file, all rows would incorrectly be exported. From now on, only the visible rows (i.e. the rows that match the filter) will be exported.

#### Dashboards app & Low-Code Apps - Table component: Exceptions would cause both an empty result message and an error message to be displayed [ID_37479]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When GQI threw an exception when a session was opened, both an empty result message and an error message would be displayed on top of each other. From now on, when an exception is thrown, only an error message will be displayed.

#### Dashboards app: URL option 'showAdvancedSettings' was case sensitive [ID_37493]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, the *showAdvancedSettings* URL option would incorrectly be case sensitive. This option is now case insensitive.

#### Low-Code Apps: No longer possible to edit a low-code app of which the query migration had failed [ID_37501]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, it would no longer be possible to edit a low-code app of which the query migration had failed.

From now on, when the query migration fails, the original query will be left untouched, allowing you to edit the app and fix any errors.

#### Dashboards app & Low-Code Apps - Table component: Table headers would not get updated when the column order was changed by the query [ID_37504]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the order of the table columns was changed by the query, the table headers would incorrectly not get updated.

#### Web apps - Interactive Automation scripts: Dropdown component would not show all available options [ID_37510]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

In some cases, a Dropdown component in an interactive Automation script would not resize itself correctly, causing some options to remain invisible.

#### Dashboards app & Low-Code Apps - Table component: Order of the cells in exported rows in CSV file would not match the order of the table headers [ID_37517]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, in a table component, you changed the order of the columns, and then exported table data to a CSV file, the order of the cells in the exported rows would incorrectly not match the order of the table headers at the top of the CSV file.

#### Web apps: Waffle menu would not open on mobile devices [ID_37535]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When you clicked the waffle button while viewing a DataMiner web app (e.g. Monitoring) on a mobile device, the menu would incorrectly not open.

#### Dashboards app: Problem when migrating empty queries [ID_37537]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, attempts to migrate empty queries would fail. From now on, no errors will occur anymore when migrating empty queries.

#### Low-Code Apps: Problem when feeding falsy values to app actions [ID_37538]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a falsy value (empty string, 0, etc.) was fed as an argument of an app action, that value would not be updated correctly.

#### Dashboards app & Low-Code Apps: Numeric input component would not get the focus when one of its arrow buttons was clicked [ID_37543]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, a *Numeric input* component would not automatically get the focus when you clicked one of its arrow buttons. As a result, the feed value of the component would also not get updated.

From now on, when you click the *Up* or *Down* button of a *Numeric input* component, it will get the focus and its feed value will be updated.

#### Dashboards app: 'No parameters available' error would appear when trying to retrieve parameters belonging to a stopped element [ID_37561]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, in the Dashboards app, parameters belonging to a stopped element were retrieved, a *No parameters available* error would appear.

From now on, element lists will no longer include non-active elements. As a result, it will no longer be possible to select parameters belonging to non-active elements.

#### Dashboards app & Low-Code Apps - Chart components: Basic updates no longer triggered a refresh of the visualized data [ID_37567]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When the *Column & bar chart*, *Line & area chart* and *Pie & donut chart* components were fed by a query that did not support full real-time updates, basic updates to those components would no longer trigger a refresh of the visualized data.

#### Dashboards app & Low-Code Apps - Table component: Exporting data to CSV would incorrectly be possible when the table was empty [ID_37585]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, it would incorrectly be possible to export table data to a CSV file when a table did not display any rows. From now on, when a table does not display any rows (e.g. when no rows match the applied filter), the button allowing you to export the table data to a CSV file will be disabled.

#### Dashboards app: Sidebar would overlap large components when the viewport was too narrow [ID_37594]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When a component was too large to fit into a narrow viewport (e.g. when viewing the dashboard on a mobile device), in some cases, the sidebar would incorrectly overlap the component.

This issue would also occur when a visual overview had been embedded in a *Visual overview* component that was too small.

#### Low-Code Apps: Deleting all components on a panel using the Delete button would delete all components on the page [ID_37615]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When, while editing a panel in a low-code app, you used CTRL+a to select all components on that panel and pressed DELETE to delete them, this would not only delete the components on the panel but also the other components on the rest of the page.
