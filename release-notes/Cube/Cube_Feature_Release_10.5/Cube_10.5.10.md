---
uid: Cube_Feature_Release_10.5.10
---

# DataMiner Cube Feature Release 10.5.10

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU19] and 10.5.0 [CU7].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.10](xref:General_Feature_Release_10.5.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.10](xref:Web_apps_Feature_Release_10.5.10).

## New features

#### Profiles and Resources modules now support resource capacity ranges [ID 43438]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

DataMiner Cube now supports resource capacity ranges.

- In the *Profiles* module, you can now create and edit parameters of type "Range", and when you configure a profile instance, you can now configure the value and requested capacity of such a parameter of type "Range".

- In the *Resources* module, you can now configure the supported range capacity of a resource.

See also: [Service & Resource Management: Support for capacity ranges [ID 43335]](xref:General_Feature_Release_10.5.9#service--resource-management-support-for-capacity-ranges-id-43335)

## Changes

### Enhancements

#### Improved alarm storm notification [ID 43326]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

The notification shown in Cube when an alarm storm is triggered has been improved. Previously, it only mentioned the number of alarms with a specific description that had entered Cube. Now the notification will also mention the protocols of the alarms. The same also goes for the tooltip shown for an alarm storm. In addition, the alarm details card for the alarm storm alarm will now also include a list of the protocols of the alarms involved. Finally, the total count of the alarms mentioned in the notification and used to determine when to enter or leave an alarm storm has also been improved, taking up to 20 alarms from the existing alarm tree into account.

#### Automation, Correlation & Scheduler apps: 'Send email' action now allows you to select a private dashboard [ID 43393] [ID 43394] [ID 43570]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In a *Send email* action, it is now possible to select a private dashboard provided you have access to it, and provided that the DataMiner server uses at least DataMiner version 10.5.10 or 10.6.0.

If you try to edit a *Send email* action linked to a private dashboard you do not have access to, the following error message will appear. However, you will be allowed to replace it by a dashboard you do have access to.

`This dashboard doesn't exist or you don't have access.`

#### Trending: Enhanced performance when loading trend graphs [ID 43433]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Because of a number of enhancements, overall performance has increased when loading trend graphs.

#### Security enhancements [ID 43483]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

A number of security enhancements have been made.

#### Data Display: Enhanced error handling when saving and loading matrix crosspoints over gRPC connections [ID 43516]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Overall error handling has been improved when saving and loading crosspoints of matrix parameters over gRPC connections.

### Fixes

#### Dummy placeholders not accepted in redundancy group configuration [ID 43464]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When configuring a redundancy group to use an Automation script, previously it could occur that placeholders were rejected as valid input for dummies. An existing element had to be selected first before it was possible to switch to the placeholder. The redundancy group configuration validation has now been improved so that placeholders will immediately be accepted as valid input.

#### No expander shown for General Parameters pages on element card [ID 43480]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

On an element card, it could occur that no expander was shown to open the pages under *General Parameters*, so that you had to double-click to see those instead. The expander will now be shown again.

#### Trending: Starting gap incorrectly filled [ID 43484]

In some cases, it could occur that the gap at the starting point of a trend graph was incorrectly filled, causing the trend curve to expand unnecessarily when zooming out.

This has now been fixed by ensuring that the gap’s starting point is accurately identified and data is properly inserted, maintaining consistent and reliable trend visualization.

#### Exceptions when aborting actions from Visual page while using WebView2 browser [ID 43494]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When the WebView2 browser was used in Cube, exceptions could be shown in case an action was aborted, for example when quickly opening and closing pop-up windows in an embedded browser from a Visual page. These exceptions will now instead be logged in the debug logging.

#### Alarm data not included in element migration [ID 43497]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When elements were migrated between DataMiner Agents via the Element Migration window in System Center, it could occur that alarm data was not included in the migration. Now the alarm data will be properly included in the migration again.

#### System Center: Problem when performing a DataMiner upgrade while being connected to a DMA in a Failover system based on hostname [ID 43513]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When, in System Center, you performed a DataMiner upgrade while Cube was connected to a DataMiner Agent that was part of a Failover system based on hostname, up to now, the upgrade could fail to start after the package had been uploaded.

#### Trending: Changepoints would not be displayed when opening a trend graph [ID 43576]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When you opened a trend graph, in some cases, the changepoints would incorrectly not be displayed.

#### Closed API connection would incorrectly not be automatically re-established [ID 43586]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

Up to now, when the API connection had been closed, no attempt would incorrectly be made to automatically re-establish the connection.

For example, when, after DataMiner Cube had been idle for more than 5 minutes and the API connection had automatically closed, you opened the Automation tab, the API request to retrieve the list of dashboards would fail.

From now on, when the API connection was closed, it will automatically be re-established when a new API request is sent.

#### Trending: Trend graph displayed in visual overview could be partially covered by the anomalies bar [ID 43602]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

When a trend graph was displayed in a visual overview, in some cases, the graph would be partially covered by the anomalies bar.
