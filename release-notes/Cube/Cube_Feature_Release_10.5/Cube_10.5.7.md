---
uid: Cube_Feature_Release_10.5.7
---

# DataMiner Cube Feature Release 10.5.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.7](xref:General_Feature_Release_10.5.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.7](xref:Web_apps_Feature_Release_10.5.7).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### DataMiner Cube desktop app: Enhanced feedback in case of DataMiner version mismatch [ID 42706]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When the DataMiner Cube desktop app is deployed using [shared MSI installation](xref:DataMiner_Cube_deployment_methods#shared-msi-installation), only one Cube version will be available system-wide, and that version must remain compatible with the DataMiner System to which the Cube clients will connect. This can eventually lead to issues when, for example, DataMiner Agents get upgraded.

From now on, users will get more feedback when a DataMiner version mismatch is detected:

- In the *About* box of the DataMiner Cube desktop app, the version of the app will now include either a "(shared)" or "(MSI)" suffix. This will indicate whether the app was deployed using [shared MSI installation](xref:DataMiner_Cube_deployment_methods#shared-msi-installation) or [bootstrap MSI installation](xref:DataMiner_Cube_deployment_methods#bootstrap-msi-installation).

- The logging of the DataMiner Cube desktop app will now explicitly indicate when a "version not found" error was caused by a system-wide installation conflict.

- The error message displayed on the screen will now explicitly say that a version mismatch was detected and that an update is required. Also, users will be referred to the [DataMiner Cube deployment methods](xref:DataMiner_Cube_deployment_methods) documentation page for more details.

### Fixes

#### Alarm templates: Problem when duplicating a scheduled alarm template [ID 42823]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in the *Protocols & Templates* module, you duplicated an alarm template that was scheduled to only be active at certain times, the newly created duplicate would incorrectly be disabled, although the schedule of the original alarm template had correctly been copied.

#### Cube logon screen would not be fully visible after a disconnect [ID 42824]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, when the logon screen appeared after a Cube session had been disconnected, in some cases, only part of that logon screen would be visible.

#### Topology pane: Problem when navigating quickly through the different levels of a topology chain [ID 42825]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in the *Topology* pane, you navigated quickly through the different levels of a topology chain, in some cases, an exception could be thrown.
