---
uid: Cube_Feature_Release_10.4.11
---

# DataMiner Cube Feature Release 10.4.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.11](xref:General_Feature_Release_10.4.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Enhanced performance when starting up DataMiner Cube [ID 40373]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

Up to now, all DCF interface data would be retrieved by default each time you started DataMiner Cube. From now on, this data will only be retrieved when needed. As a result, overall performance has increased when starting up DataMiner Cube.

### Fixes

#### Services: Alarm color of a service card page would be incorrect when the service contained a partially included table of an element [ID 40597]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

When you opened the card of a service that contained only part of a table of an element, in some cases, the alarm color of the card page would  incorrectly reflect the alarm state of the entire table instead of the consolidated alarm state of the included rows.
