---
uid: Cube_Feature_Release_10.5.6
---

# DataMiner Cube Feature Release 10.5.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.6](xref:General_Feature_Release_10.5.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.6](xref:Web_apps_Feature_Release_10.5.6).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Trending: SPI log entry containing the loading times of the trend graph labels will be added to SLClient.txt [ID 42514]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When you open a trend graph, from now on, an SPI entry containing the loading times of the trend graph labels (including metadata like loaded trend data points, etc.) will be added to the *SLClient.txt* log file.

#### Matrices: All input and output options will now be reset before a matrix update is applied [ID 42585]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When a matrix was updated, up to now, only input and output options included in the updated would be changed. Options not included in the updated would be left unchanged.

From now on, when a matrix is updated, all input and output options will first be reset to their default values before the changes included in the update are applied.

### Fixes

#### Visual Overview: Problem when processing shape conditions or creating shape properties [ID 42436]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In some cases, an *Object reference not set to an instance of an object* exception could be thrown when processing shape conditions or creating shape properties.
