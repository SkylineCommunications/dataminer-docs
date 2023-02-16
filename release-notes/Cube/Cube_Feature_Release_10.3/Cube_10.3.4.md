---
uid: Cube_Feature_Release_10.3.4
---

# DataMiner Cube Feature Release 10.3.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.4).

## Highlights

*No highlights have been selected for this release yet*

## Other features

## Changes

### Enhancements

### Fixes

#### Visual Overview: Problem with EnableFollowMode option of Resource Manager timeline [ID_35528]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you had specified the *EnableFollowMode* option in the *ComponentOptions* shape data field of a shape configured to display the Resource Manager timeline, in some cases, that option would incorrectly be disabled.

From now on, when you activate the follow mode by specifying the *EnableFollowMode* option, the timeline will move along with the current time. When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.
