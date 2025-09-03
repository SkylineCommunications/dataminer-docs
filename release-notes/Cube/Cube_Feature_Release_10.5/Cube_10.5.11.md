---
uid: Cube_Feature_Release_10.5.11
---

# DataMiner Cube Feature Release 10.5.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU20] and 10.5.0 [CU8].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.11](xref:General_Feature_Release_10.5.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.11](xref:Web_apps_Feature_Release_10.5.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Trending: Alarm timeline would incorrectly be displayed on top of or beyond the Y axis when zooming in [ID 43593]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you zoomed in on a trend graph, the alarm timeline on the X axis would incorrectly be displayed either on top of or beyond the Y axis.

#### Problem when a broadcast message expired [ID 43634]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When a broadcast message expired, up to now, an exception could be thrown.

#### Trending: Changes made to the 'Display the alarm template in the trend graph' option would incorrectly not be applied when the bottom navigator chart was not enabled [ID 43638]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When, in a visual overview, a shape showing a trend component was configured to not show the bottom navigator chart (i.e. by means of the "NavigatorChart:false" option set in the *ParametersOptions* shape data field), up to now, changes made to the *Display the alarm template in the trend graph* option in the component's settings would incorrectly not be applied.

Also, when a shape showing a trend component was configured to not show the bottom navigator chart, up to now, changes made to the mouse actions in the component's settings would incorrectly not be applied until the card was re-opened.
