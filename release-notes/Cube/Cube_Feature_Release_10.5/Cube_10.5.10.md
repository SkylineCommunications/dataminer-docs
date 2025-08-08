---
uid: Cube_Feature_Release_10.5.10
---

# DataMiner Cube Feature Release 10.5.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU19] and 10.5.0 [CU7].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.10](xref:General_Feature_Release_10.5.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.10](xref:Web_apps_Feature_Release_10.5.10).

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Improved alarm storm notification [ID 43326]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

The notification shown in Cube when an alarm storm is triggered has been improved. Previously, it only mentioned the number of alarms with a specific description that had entered Cube. Now the notification will also mention the protocols of the alarms. The same also goes for the tooltip shown for an alarm storm. In addition, the alarm details card for the alarm storm alarm will now also include a list of the protocols of the alarms involved. Finally, the total count of the alarms mentioned in the notification and used to determine when to enter or leave an alarm storm has also been improved, taking up to 20 alarms from the existing alarm tree into account.

#### Security enhancements [ID 43483]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

A number of security enhancements have been made.

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
