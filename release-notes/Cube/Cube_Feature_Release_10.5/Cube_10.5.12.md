---
uid: Cube_Feature_Release_10.5.12
---

# DataMiner Cube Feature Release 10.5.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU21] and 10.5.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.12](xref:General_Feature_Release_10.5.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.12](xref:Web_apps_Feature_Release_10.5.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Trend graph showing high-value predictions would not get updated when you scrolled the predictions beyond the viewport [ID 43776]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When you opened a trend graph showing trend data values with low Y values and predictions with very high Y values, up to now, the graph that resembled a flatline would incorrectly not get updated when you scrolled the predictions beyond the viewport.

#### Problem when switching themes while trend graphs were open [ID 43777]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When, in DataMiner Cube, you opened a trend graph and then switched to another theme, up to now, errors would start to appear in the logging.

Also, the trend graph colors would incorrectly not get updated.
