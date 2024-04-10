---
uid: Cube_Feature_Release_10.4.6
---

# DataMiner Cube Feature Release 10.4.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.6](xref:General_Feature_Release_10.4.6).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### Alarm Console: Enhanced performance when loading a large number of alarms in an active alarms tab [ID_39235] [ID_39236]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when loading a large number of alarms into an active alarm tab.

#### Visual Overview: Enhanced performance when processing conditions based on view names, service names or element names [ID_39241]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when processing conditions based on view names, service names or element names.

#### Alarm Console: Enhanced performance when retrieving the side panel data after selecting an alarm [ID_39284]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

For each alarm tab, you can open a side panel in the Alarm Console showing the real-time value and history of a selected alarm.

Because of a number of enhancements, overall performance has now increased when retrieving this side panel data after selecting an alarm.

### Fixes

#### Visual Overview: Problem with placeholder value update detection [ID_39325]

<!-- MR 10.3.0 [CU15] / 10.4.0 [CU3] - FR 10.4.6 -->

In some cases, the algorithm that had to detect placeholder value updates would work incorrectly. When a placeholder value had been changed, it would incorrectly not report a value change, and when a placeholder value had not been changed, it would incorrectly report a value change.
