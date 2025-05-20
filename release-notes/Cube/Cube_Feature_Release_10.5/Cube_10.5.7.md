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

- [Cube search box now supports fuzzy matching [ID 42911]](#cube-search-box-now-supports-fuzzy-matching-id-42911)

## New features

#### Automation: Package name will now be displayed for Automation scripts installed as part of a DataMiner package [ID 42773]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in the *Automation* module, you select an Automation script that was installed as part of a DataMiner package, the name and version of that package will now be displayed below the description in the *General* section.

- Clicking the name of the package will open its page in the [DataMiner Catalog](https://catalog.dataminer.services/).
- If you try to save any changes you made to an Automation script that was installed as part of a package, a confirmation box will now appear, informing you that you are about to change the contents of a package script.
- If the word "[Customized]" is displayed in front of the package name, this means that the Automation script has been modified since the package was installed.

Also, the following problem has been fixed. When you made a change to an Automation script containing an Exe block with ID 1, up to now, the ID of the Exe block would incorrectly be changed to 2 after the script had been saved.

#### Cube search box now supports fuzzy matching [ID 42911]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

The search box in the middle of the Cube header bar now supports fuzzy matching.

Search results will now account for diacritic similarities within the same alphabet (e.g. "é" with will match "e"). However, transliteration is not supported. Typos or substitutions with the closest corresponding letters (e.g. "ø" vs. "o" or "graphic" vs. "grafic") will not yield any results.

> [!NOTE]
> For Japanese characters to be processed properly, your Windows system needs to support Japanese text rendering.

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

#### Problem when multiple property updates were received for the same element, service or view card [ID 42863]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, an error could be thrown when a Cube client received multiple property updates for the same element, service or view card.
