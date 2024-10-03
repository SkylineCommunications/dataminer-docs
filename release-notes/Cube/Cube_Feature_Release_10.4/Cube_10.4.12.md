---
uid: Cube_Feature_Release_10.4.12
---

# DataMiner Cube Feature Release 10.4.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.12](xref:General_Feature_Release_10.4.12).

## Highlights

*No highlights have been selected yet.*

## New features

#### Interactive Automation scripts: New option to skip the confirmation window when aborting [ID 40720]

<!-- MR 10.5.0 - FR 10.4.12 -->

DataMiner Cube now supports the new `SkipAbortConfirmation` property that was added to `UIBuilder`. When this property is set to true, the confirmation window will not be displayed when the interactive Automation script is aborted. By default, this property will be set to false.

> [!TIP]
> See also: [Interactive Automation scripts: New option to skip the confirmation window when aborting [ID 40683]](xref:General_Feature_Release_10.4.12#interactive-automation-scripts-new-option-to-skip-the-confirmation-window-when-aborting-id-40683)

## Changes

### Enhancements

*No enhancements have been added yet.*

#### Label "Show Agent alarms" now translated [ID 40868]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

If you view the Cube UI in one of the supported languages other than English, the label "Show Agent alarms" will now be translated to the selected language.

This label is used in the *Agent alarms* section of the *System Center > Agents > Manage* page.

### Fixes

#### License expiration window: Title and text included the incorrectly spelled word "licence" [ID 40894]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When a license has expired, a notification window will appear when you open DataMiner Cube.

Up to now, both the title and the text of that notification window would include the incorrectly spelled word "licence". This word has now been changed to "license".

#### Desktop app start window: Message 'Did you mean ...?' would incorrectly be displayed when you entered the name of a non-existing DMS [ID 40896]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, in the start window of the Cube desktop app, you clicked the '+' button and entered the name of a non-existing DataMiner System in the *Host* box, up to now, two messages would appear:

- "Not a DataMiner Agent", and
- "Did you mean", followed by the exact name you entered.

This last message will no longer be displayed.
