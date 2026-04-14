---
uid: Cube_Feature_Release_10.6.6
---

# DataMiner Cube Feature Release 10.6.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU3].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.6](xref:General_Feature_Release_10.6.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.6](xref:Web_apps_Feature_Release_10.6.6).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### Redesigned Properties window [ID 45163]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In version 10.6.4, the entire Cube UI and UI themes were redesigned. In this version, the *Properties* windows has also been redesigned.

#### Spectrum analysis: Overlays will now dynamically follow the Cube theme [ID 45172]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Because of a number of enhancements, overlays appearing on top of a spectrum card will now dynamically follow the Cube theme.

#### Enhanced performance when loading data into the Reports page of element, service, and parameter cards [ID 45191]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Because of a number of enhancements, overall performance has increased when loading data into the Reports page of element, service, and parameter cards.

### Fixes

#### Problem when loading a trend graph for a dynamic discrete parameter [ID 45276]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, an exception could be thrown when DataMiner Cube tried to load a trend graph for a dynamic discrete parameter.

#### Redundancy groups: Problem when deleting elements used for switching logic or switching detection from a redundancy group configuration [ID 45278]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When elements used for switching logic or switching detection were deleted from a redundancy group configuration, up to now, not all references to those elements would be removed correctly.

#### Trending: Row instance key in trend graph title would incorrectly not be shown in the display format [ID 45280]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When a trend graph shows trend data for a table cell value, the title above the trend graph shows the name of the column and the row instance key.

However, up to now, the row instance key would incorrectly be shown in the format that is passed to the DataMiner Agent. From now on, the row instance key will be shown in a more readable display format.
