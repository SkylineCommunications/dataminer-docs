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

#### Security enhancements [ID_37488]

<!-- RN 37488: MR 10.3.0 [CU9] - FR 10.3.12 -->

A number of security enhancements have been made.

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
