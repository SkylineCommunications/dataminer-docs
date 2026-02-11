---
uid: Web_apps_Feature_Release_10.4.4
---

# DataMiner web apps Feature Release 10.4.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.4](xref:General_Feature_Release_10.4.4).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.4](xref:Cube_Feature_Release_10.4.4).

## New features

#### Dashboards app & Monitoring app: WebSocket connection status indicator [ID 38676]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Both the Dashboards app and the Monitoring app now have a WebSocket connection status indicator in the top-right corner of the screen.

This indicator will show the current status of the client's WebSocket connection:

| Icon | Status |
|---|---|
| Red error icon | Offline |
| Gray information icon<br>(with link to [What should I do if I get WebSocket errors when using Dashboards or Low-Code Apps?](https://aka.dataminer.services/WebSocketInWebApps)) | No WebSocket connection. Polling. |
| Orange icon | Establishing WebSocket connection. Polling. |
| Green success icon | WebSocket connection |

#### Dashboards app & Low-Code Apps - Dropdown component: New 'Clear selection' setting [ID 38758]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Dropdown components now have a *Clear selection* setting. When you enable the setting, a *Clear* button will be displayed inside the selection box, allowing users to clear the current selection.

> [!NOTE]
> When you disable the setting for a particular dropdown component, clicking the dashboard's *Clear all* button will not affect that component. Its current selection will be left untouched.

#### Dashboards app & Low-Code Apps - Dropdown, List & Tree components: New 'Select first item by default' setting [ID 38775]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Dropdown, *List* and tree components now have a new *Select first item by default* setting under *Initial selection*. When you enable the setting, the first value shown in the component will automatically be selected.

> [!NOTE]
>
> - When you add a new dropdown, *List* or tree component, this setting will be enabled by default.
> - If, in case of an existing dropdown, *List* or tree component, an existing selection setting is enabled under *Initial selection*, that existing setting will remain unchanged, and the new *Select first item by default* setting will not be enabled. However, if none of the existing settings under *Initial selection* are enabled, the new *Select first item by default* setting will automatically be enabled.

## Changes

### Enhancements

#### Web apps - Interactive Automation scripts: Theme colors will now be passed to script windows and popups [ID 38472]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When an interactive Automation script was launched from a web app, up to now, the windows and popups of the script would always have the default background and foreground colors (i.e. white background and black foreground).

From now on, when an interactive Automation script is launched in any of the following ways, the windows and popups of that script will inherit the foreground color and the default component background color of the page, panel or dashboard from which the script was launched:

- When clicking a Button component in a low-code app.
- When clicking a button in the page/panel header bar of a low-code app.
- When clicking a DOM action button.
- When clicking a cell or double-clicking a row in a Table component.
- When clicking an entry in a Grid component.
- When clicking an entry in a Timeline component.
- When clicking a marker in a Maps component.
- When clicking a node in a Service Definition component.
- When clicking a region on a Visual Overview component.
- When clicking an Automation script button on a dashboard.
- When a page of a low-code app is loaded.

> [!NOTE]
> If an interactive Automation script is launched from a component that has a custom theme applied, the color settings of that custom theme will not be taken into account.

#### Web apps: Executing Automation scripts will now only require you to have Execute permission [ID 38529]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, in order to execute an Automation script from a web app or a dashboard, users had to have both *Execute* and *UI available* permission. From now on, having been granted *Execute* permission will suffice to be able to execute Automation scripts from a web app or a dashboard.

The following Web Services API methods will now also only require users to have *Execute* permission (instead of *Execute* and *UI available*):

- ContinueAutomationScript
- DetachAutomationScript
- ExecuteAutomationScript
- ExecuteAutomationScriptWithOutput

Also, when an Automation script fails due to missing script input, users will now receive the following error message:

`Not all required input was provided to execute the script`

> [!NOTE]
> Up to now, when an Automation script that had memory files configured was launched from a low-code app, you would incorrectly always be prompted to enter a value for those memory files. From now on, this will no longer be the case.

#### Additional logging with regard to the persistent connection between Web API and SLNet [ID 38700]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

The persistent connection between the Web API and SLNet is used to cache active alarms, views, etc. As it is difficult to investigate issues related to this connection, additional logging with regard to this connection will now be added to the web logging located in `C:\Skyline DataMiner\Logging\Web`.

#### Web apps: Angular and other dependencies have been upgraded [ID 38731]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

In all web apps (e.g. Low-Code Apps, Dashboards, Monitoring, etc.), Angular and other dependencies have been upgraded.

#### Dashboards app & Low-Code Apps: Dropdown, List & Tree components now support queries as data source [ID 38811]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

The dropdown, *List* and tree components will now behave as follows when linked to one or more queries:

- When linked to multiple queries, they will continue to list the queries as data.

  In case of a dropdown component, for example, the feed can then (still) be used to dynamically populate a table, showing the result of the selected query from the dropdown.

- When linked to one query, they will now list the resulting rows from that query instead of the query itself. Making a selection will then

  - feed the selected row(s), and
  - feed any data that is linked to the selected row(s) as metadata (e.g. parameters, elements, indices).

Two new settings have also been added:

- **Layout > Advanced > Display column**: Setting that allows you to specify the column that needs to be used to represent the row in the UI.

  > [!NOTE]
  > This setting is only visible when one query is linked and is used as data.

- **Settings > Data retrieval > Update data**: When this setting is enabled, the values will be updated in real time (when the data supports this).

  > [!NOTE]
  > This setting is only visible when one query is linked and is used as data, or when the index dataset is linked as data.

The visualizations can now also be linked to a trigger component and support two actions in low-code apps:

- Fetch the data
- Select an item (limited to DOM instances)

#### Monitoring app: Trend charts have now been fully aligned with those in DataMiner Cube [ID 38926]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

In the Monitoring app, the trend charts have now been fully aligned with those in DataMiner Cube.

For example, the *Trend points* option will now by default be set to "Average (changes only)" instead of "Average (fixed interval)".

#### WebAPI: Maximum log file size reduced to 3 MB [ID 38958]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

The maximum size of the log files generated by the Web API in the `C:\Skyline DataMiner\Logging\Web` folder has been reduced to 3 MB.

> [!NOTE]
>
> - On existing systems, the maximum log file size will still be 50 MB. Only when the log configuration file is initialized will this new 3 MB limit be applied by default.
> - If you want to change the maximum log file size manually, open the `C:\Skyline DataMiner\Logging\Web\log.conf` file, and change the "MaxFileSize" setting.

### Fixes

#### Web apps: Visual overviews would incorrectly get updated while nothing had changed [ID 38362] [ID 38800]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When viewing a visual overview on a web app, in some cases, the visual overview would incorrectly get updated while nothing had changed.

#### Dashboards app & Low-Code Apps - Interactive Automation scripts: UTC values in datetime components would not be converted correctly [ID 38634]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When, in a dashboard or a low-code app, you launched an interactive Automation script with datetime components containing values in UTC format, in some cases, those date/time values in UTC would not correctly be converted to the client's local time.

#### Dashboards app & Low-Code Apps: Problem when making a backup of all dashboards and low-code apps during a DataMiner upgrade [ID 38640]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you perform a DataMiner upgrade (either a full upgrade or a web-only upgrade), a backup of all existing dashboards and low-code apps on the system is made. During the upgrade procedure, the backup tool will create a temporary folder, place a copy of all dashboard and low-code app files in that folder, compress those files, and then delete the temporary folder.

Up to now, a DataMiner upgrade could fail due to the backup tool being unable to perform that last step, i.e. delete the temporarily folder.

From now on, when that temporary folder cannot be deleted, the upgrade will no longer fail. A new attempt to delete the folder will be made the next time a DataMiner upgrade is performed.

#### Low-Code Apps: Delete button would not be disabled when you had clicked the button in order to delete a panel [ID 38663]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you clicked the *Delete* button in order to delete a panel, that button would incorrectly not be disabled when the delete operation started. As a result, it was possible to click *Delete* again, causing errors to be thrown.

#### Dashboards app & Low-Code Apps - GQI: Regex node values would incorrectly be transformed [ID 38664]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When a query contained a regex node, up to now, the value of that node would incorrectly be transformed to `^(VALUE|VALUE2|VALUE3)$`.

This will no longer be the case. The value of a regex node will now have the format `VALUE1|VALUE2|VALUE3|...`.

#### Low-Code Apps: Problem when opening the icon picker [ID 38666]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you opened the icon picker in e.g. *Configure Context menu*, up to now, the icons would not entirely fill the box, causing a white bar to appear on the right-hand size. From now on, the rows will again contain 10 icons instead of 9.

#### Low-Code Apps: Selection boxes in the header bar would appear behind the component that had the focus [ID 38677]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When a panel component had the focus, selection boxes in the header bar would incorrectly appear behind the component that had the focus.

#### Dashboards app: Dashboard duplicate would not inherit the settings of the original dashboard [ID 38679]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you duplicated a dashboard, the newly created duplicate would incorrectly not inherit the dashboard settings of the original dashboard.

#### Dashboards app & Low-Code Apps: Selection in query filter of a column with discrete numeric values would be cleared when the data was fetched again [ID 38685]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, in some cases, the selection made in the query filter of a column with discrete numeric values would incorrectly be cleared each time the data was fetched again.

Also, up to now, when a column had both a discrete filter and another filter applied, that other filter would incorrectly be dropped the moment you selected a discrete value.

#### Dashboards app: Issues with input controls on mobile devices [ID 38723]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

A number of input control issues on mobile devices have been fixed.

For example, on devices with a touch screen, it was no longer possible to disable *View password* after enabling it. Also, you will now need to long press a label instead of tap it to see its tooltip.

#### Low-Code Apps: Panel opened as a popup would incorrectly appear behind a panel that had previously been opened as a popup [ID 38736]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When a panel had been opened as a popup, any new panel opened as a popup would incorrectly appear behind the open panel instead of in front of it.

#### Dashboards app & Low-Code Apps - Maps component: Manually configured line dimensions could incorrectly be reset [ID 38753]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When, in a Maps component, you had manually configured line dimensions, in some cases, those manually configured line dimensions could incorrectly be reset.

#### Dashboards app: Not possible to share a dashboard with feeds in query nodes [ID 38805]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

In some cases, it would not be possible to share a dashboard that contained queries with feeds in some of their nodes.

#### Web apps: All clients that had a mobile visual overview open would receive updates when the visual overview was resized on one of them [ID 38812]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When a mobile visual overview opened on multiple clients was resized on one of those clients, all clients that had this visual overview open would start to receive continuous updates although nothing had been changed.

#### GQI sessions would not be closed when a client using polling had disconnected [ID 38816]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, when a client using polling instead of WebSockets had disconnected, the GQI sessions would not get closed correctly.

From now on, when a user closes a tab or a page containing a GQI query, the corresponding GQI session will be closed within maximum 5 minutes.

#### Dashboards app & Low-Code Apps: Web component would display scroll bars when all content fitted inside [ID 38821]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, a Web component would incorrectly display scrollbars when all content fitted inside.

#### Dashboards app & Low-Code Apps: GQI updates would not be shown in the UI when using polling [ID 38832]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, when a client was using polling, GQI updates would not be shown in the UI due to incorrect event processing.

#### Dashboards app & Low-Code Apps - Dropdown component: Feed would be empty after selecting a query, clearing the selection and selecting the same query again [ID 38845]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When, in a dropdown component, you selected a query, cleared the selection, and then selected the same query again, the feed would incorrectly be empty.

#### Dashboards app & Low-Code Apps: Components needed to be selected first before they could be deleted [ID 38859]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, before you were able to delete a component by clicking the delete button at the bottom of the component, you first had to select that component. This meant that, for example, you had to click the delete button twice. From now on, clicking the delete button will automatically select the component.

#### Dashboards app - Table component: Not possible to sort or filter Table component data in shared dashboards [ID 38876]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you had shared a dashboard containing table components, it would not be possible to filter or sort the data in those table components.

#### Dashboards app: Problem when trying to share a dashboard that did not retrieve any data [ID 38965]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you tried to share a dashboard that did not retrieve any data, in some cases, a *NullReference* exception could be thrown.
