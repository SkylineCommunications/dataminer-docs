---
uid: Cube_Feature_Release_10.6.12
description: "Release notes for DataMiner Cube Feature Release 10.6.12, with new features, enhancements, and fixes planned for this preview release."
---

# DataMiner Cube Feature Release 10.6.12 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.12](xref:General_Feature_Release_10.6.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.12](xref:Web_apps_Feature_Release_10.6.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Profiles: Instances, parameters, or definitions could be incorrectly marked as modified [ID 46468]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

In some cases, a profile instance, a profile parameter, or a profile definition was marked as modified even though no changes had been made to it. This could happen when the server and client stored the same properties in different orders, causing Cube to detect a change.

Cube now compares profile instances, parameters, and definitions independently of property order, so differences in ordering no longer cause them to be marked as modified.

#### Spectrum: Average trace visibility would no longer be saved in presets [ID 46585]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Because of an issue, the visibility of the average trace in the Spectrum component would no longer be saved in presets. As a result, reopening a preset would not restore the visibility of the average trace.

From now on, Cube will again save and restore this setting with the preset.
