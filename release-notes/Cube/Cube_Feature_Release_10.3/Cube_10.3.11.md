---
uid: Cube_Feature_Release_10.3.11
---

# DataMiner Cube Feature Release 10.3.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.11](xref:General_Feature_Release_10.3.11).

## Highlights

*No highlights have been selected yet.*

## New features

#### Spectrum analysis: Panning inside a spectrum window [ID_37284]

<!-- MR 10.4.0 - FR 10.3.11 -->

It is now possible to pan inside a spectrum window by clicking and dragging.

When, after clicking the left mouse button, you start dragging, the following will happen:

- The spectrum trace will move to the left or the right while being refreshed at a rate equal to the original rate.
- The start, stop and center frequency labels on the X axis will continuously update to reflect the ongoing change.
- The unknown part of the trace (i.e. the frequency range located outside of the original span) will be visualized as a grey area with a grid in the background.

When you stop dragging and release the left mouse button, the panning dimensions will be set on the spectrum analyzer device and the screen will be updated with the new data.

Only upon releasing the left mouse button will the unknown part of the trace be requested from the spectrum analyzer. The newly received trace points will then replace the grey area and a new, uniform spectrum trace will be displayed based on the new center frequency.

> [!IMPORTANT]
> This feature is only available if the spectrum protocol includes the *Start Frequency*, *Center Frequency* and *Stop Frequency* parameters.

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Trending: Problem when editing a trend pattern on a graph other than the one on which the pattern was created [ID_37191]

<!-- MR 10.4.0 - FR 10.3.11 -->

When you edited a trend pattern on a trend graph, up to now, the trend data on the graph on which the pattern was created would incorrectly be used instead. From now on, the trend data in the selected part of the graph will be used.

#### Alarm Console : Problem when a correlation/incident alarm got cleared [ID_37231]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

On a system with a large number of correlation/incident alarms, in some cases, an error could occur when one of those alarms was cleared. That alarm would then incorrectly remain visible in the Alarm Console.

#### System Center - Database: No longer possible to create and delete database configurations in the Offload and Other tabs when Type was set to 'Database per cluster' [ID_37254]

<!-- MR 10.4.0 - FR 10.3.11 -->

In the *Database* section of *System Center*, when *Type* was set to "Database per cluster" in the *General* tab, creating and deleting database configurations in the *Offload* and *Other* tabs would no longer work.

#### Trend templates: Offload settings would be lost when you disabled to 'Allow Offload Database Configuration' option [ID_37268]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

In a trend template, you can configure the data offload settings for a particular parameter by clicking the cogwheel, enabling the *Allow Offload Database Configuration* option and configuring the settings in two dedicated columns.

Up to now, when you disabled the *Allow Offload Database Configuration* option, the two dedicated columns would disappear and the offload settings would be lost. From now on, when you disable the *Allow Offload Database Configuration* option, the offload settings that were specified will be kept and will re-appear when you enable the *Allow Offload Database Configuration* option again.

Also, when you open a trend template in which offload settings have been specified, from now on, the two dedicated columns will be visible by default.

#### Trending: Problem with Y axis labels on trend graphs showing data from string and non-string parameters [ID_37281]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you opened a trend graph showing trend data of a parameter of type string, and you added another, non-string parameter to that same graph, the Y axis of the newly added parameter would not be rendered correctly. The labels would be placed too close to each other, making them unreadable.

#### Alarm Console: Problem when creating a linked alarm tab while connected to a system with a large number of correlated/incident alarms [ID_37332]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When, in the Alarm Console, you created a linked alarm tab while connected to a system with a large number of correlated/incident alarms, in some cases, Cube could become unresponsive for a while until the tab was loaded.
