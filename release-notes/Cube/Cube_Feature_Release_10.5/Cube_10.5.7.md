---
uid: Cube_Feature_Release_10.5.7
---

# DataMiner Cube Feature Release 10.5.7

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU16] and 10.5.0 [CU4].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.7](xref:General_Feature_Release_10.5.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.7](xref:Web_apps_Feature_Release_10.5.7).

## Highlights

- [Improved search [ID 42911]](#improved-search-id-42911)

## Changes

### Enhancements

#### DataMiner Cube desktop app: Enhanced feedback in case of DataMiner version mismatch [ID 42706]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When the DataMiner Cube desktop app is deployed using [shared MSI installation](xref:DataMiner_Cube_deployment_methods#shared-msi-installation), only one Cube version will be available system-wide, and that version must remain compatible with the DataMiner System to which the Cube clients will connect. This can eventually lead to issues when, for example, DataMiner Agents get upgraded.

From now on, users will get more feedback when a DataMiner version mismatch is detected:

- In the *About* box of the DataMiner Cube desktop app, the version of the app will now include either a "(shared)" or "(bootstrap)" suffix. This will indicate whether the app was deployed using [shared MSI installation](xref:DataMiner_Cube_deployment_methods#shared-msi-installation) or [bootstrap MSI installation](xref:DataMiner_Cube_deployment_methods#bootstrap-msi-installation).

- The logging of the DataMiner Cube desktop app will now explicitly indicate when a "version not found" error was caused by a system-wide installation conflict.

- The error message displayed on the screen will now explicitly say that a version mismatch was detected and that an update is required. Also, users will be referred to the [DataMiner Cube deployment methods](xref:DataMiner_Cube_deployment_methods) documentation page for more details.

#### Improved search [ID 42911]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

An improvement has been implemented to the search engine in DataMiner Cube, so that diacritic similarities within the same alphabet will now be taken into account when text is entered in the search box (e.g., "é" with will match "e"). However, transliteration is not supported. Typos or substitutions with the closest corresponding letters (e.g., "ø" vs. "o" or "graphic" vs. "grafic") will not yield any results.

> [!NOTE]
> For Japanese characters to be processed properly, your Windows system needs to support Japanese text rendering.

#### DataMiner Cube desktop app: Clicking 'Check for updates' will now always let users download the latest app version of the chosen update track [ID 42939]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in the DataMiner Cube desktop app, you opened the cogwheel menu and clicked *Check for updates*, up to now, the app would not always let users download the very latest app version of the update track that had been chosen.

From now on, when you open the cogwheel menu and click *Check for updates*, the app will always let users download the very latest app version of the update track that had been chosen.

> [!NOTE]
> This change in behavior only applies to manual updates, i.e., updates launched by a user clicking the *Check for updates* button. Automatic updates launched by a scheduled task will always respect the update track and the phase delay specified in the configuration file.

### Fixes

#### Spectrum analysis: No context menu would appear when selecting a measurement point [ID 42735]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in a spectrum card, you had selected one or more measurement points in the *Manual* tab of the right-hand pane, no context menu would appear in the *Measurement points* section of the spectrum graph sidebar.

From now on, when you select a single measurement point in the *Manual* tab of the right-hand pane, a context menu will appear with the following options:

- Display trace
- Display min. hold
- Display max. hold
- Display avg hold

Also, in the *trace* menu, the *Show current* button will now be disabled when multiple measurement points are selected.

#### Alarm templates: Problem when duplicating a scheduled alarm template [ID 42823]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in the *Protocols & Templates* module, you duplicated an alarm template that was scheduled to only be active at certain times, the newly created duplicate would incorrectly be disabled, although the schedule of the original alarm template had correctly been copied.

#### Cube logon screen would not be fully visible after a disconnect [ID 42824]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, when the logon screen appeared after a Cube session had been disconnected, in some cases, only part of that logon screen would be visible.

#### Topology pane: Problem when navigating quickly through the different levels of a topology chain [ID 42825]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in the *Topology* pane, you navigated quickly through the different levels of a topology chain, in some cases, an exception could be thrown.

#### Problem when multiple property updates were received for the same element, service or view card [ID 42863]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, an error could be thrown when a Cube client received multiple property updates for the same element, service or view card.

#### Trending: Problem with trend graphs displaying exception values with multiple Y axes [ID 42889]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

In some cases, trend graphs displaying exception values with multiple Y axes would render unstably, resulting in misaligned axes or inconsistent graph layouts.
