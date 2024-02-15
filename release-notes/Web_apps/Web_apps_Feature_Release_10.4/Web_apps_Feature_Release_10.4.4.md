---
uid: Web_apps_Feature_Release_10.4.4
---

# DataMiner web apps Feature Release 10.4.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.4](xref:General_Feature_Release_10.4.4).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboards app & Monitoring app: WebSocket connection status indicator [ID_38676]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

Both the Dashboards app and the Monitoring app now have a WebSocket connection status indicator in the top-right corner of the screen.

This indicator will show the current status of the client's WebSocket connection:

| Icon | Status |
|---|---|
| Red error icon | Offline |
| Gray information icon<br>(with link to [What should I do if I get WebSocket errors when using Dashboards or Low-Code Apps?](https://aka.dataminer.services/WebSocketInWebApps)) | No WebSocket connection. Polling. |
| Orange icon | Establishing WebSocket connection. Polling. |
| Green success icon | WebSocket connection |

## Changes

### Enhancements

#### Web apps: Executing Automation scripts will now only require you to have Execute permission [ID_38529]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

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

#### Additional logging with regard to the persistent connection between Web API and SLNet [ID_38700]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

The persistent connection between the Web API and SLNet is used to cache active alarms, views, etc. As it is difficult to investigate issues related to this connection, additional logging with regard to this connection will now be added to the web logging located in `C:\Skyline DataMiner\Logging\Web`.

### Fixes

#### Web apps: Visual overviews would incorrectly get updated while nothing had changed [ID_38362]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When viewing a visual overview on a web app, in some cases, the visual overview would incorrectly get updated while nothing had changed.

#### Dashboards app & Low-Code Apps: Problem when making a backup of all dashboards and low-code apps during a DataMiner upgrade [ID_38640]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When you perform a DataMiner upgrade (either a full upgrade or a web-only upgrade), a backup of all existing dashboards and low-code apps on the system is made. During the upgrade procedure, the backup tool will create a temporary folder, place a copy of all dashboard and low-code app files in that folder, compress those files, and then delete the temporary folder.

Up to now, a DataMiner upgrade could fail due to the backup tool being unable to perform that last step, i.e. delete the temporarily folder.

From now on, when that temporary folder cannot be deleted, the upgrade will no longer fail. A new attempt to delete the folder will be made the next time a DataMiner upgrade is performed.

#### Low-Code Apps: Delete button would not be disabled when you had clicked the button in order to delete a panel [ID_38663]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When you clicked the *Delete* button in order to delete a panel, that button would incorrectly not be disabled when the delete operation started. As a result, it was possible to click *Delete* again, causing errors to be thrown.

#### Dashboards app & Low-Code Apps - GQI: Regex node values would incorrectly be transformed [ID_38664]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When a query contained a regex node, up to now, the value of that node would incorrectly be transformed to `^(VALUE|VALUE2|VALUE3)$`.

This will no longer be the case. The value of a regex node will now have the format `VALUE1|VALUE2|VALUE3|...`.

#### Low-Code Apps: Problem when opening the icon picker [ID_38666]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When you opened the icon picker in e.g. *Configure Context menu*, up to now, the icons would not entirely fill the box, causing a white bar to appear on the right-hand size. From now on, the rows will again contain 10 icons instead of 9.

#### Low-Code Apps: Selection boxes in the header bar would appear behind the component that had the focus [ID_38677]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When a panel component had the focus, selection boxes in the header bar would incorrectly appear behind the component that had the focus.

#### Dashboards app: Dashboard duplicate would not inherit the settings of the original dashboard [ID_38679]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When you duplicated a dashboard, the newly created duplicate would incorrectly not inherit the dashboard settings of the original dashboard.
