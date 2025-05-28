---
uid: Web_apps_Feature_Release_10.5.8
---

# DataMiner web apps Feature Release 10.5.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.8](xref:General_Feature_Release_10.5.8).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.8](xref:Cube_Feature_Release_10.5.8).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Low-Code Apps: It would incorrectly be possible to publish a low-code app while it was still being saved [ID 42680]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, it would incorrectly be possible to publish a low-code app while it was still being saved.

From now on, it will only be possible to publish a low-code app when the app has been saved.

#### Low-Code Apps - Interactive Automation scripts: initialValue of UI component 'Time' would not get updated in the UI when the value changed [ID 42878]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When the `UIBlockType.Time` component had a time range configured in the AutomationTimeUpDownOptions property, up to now, the initialValue that was displayed, would incorrectly not get updated when the value changed.
