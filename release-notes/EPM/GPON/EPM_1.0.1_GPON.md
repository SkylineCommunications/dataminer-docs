---
uid: EPM_1.0.1_GPON
---

# EPM 1.0.1 GPON - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Alarm suppression at lower levels via alarm template conditions for routes, distributions, and FAT levels [ID_36874]

In order to suppress alarms for routes, distributions, and FAT levels, the alarm template has been modified to include conditions for these levels. The alarm will be suppressed if the following conditions are met:

- The route reports that 100% of its ONTs are offline.
- The route has more than 3 ONTs.

Both of these conditions must be met for the alarm to be suppressed.

The Skyline EPM Platform GPON has been modified to calculate the percentage of ONTs that are offline. This information is used to determine if the alarm should be suppressed.

#### GPON maps integration [ID_36995]

The QUICK topology now allows access to GPON system maps, with the following three levels: Route, Distribution, and FATs.

- At Route level, the map displays subscribers and the split FATs connected to them. Because no latitude and longitude information is available for distribution, this is not shown on this map.
- At Distribution level, the map displays subscribers and associated split FATs.
- At FAT level, the map shows the connected subscribers.

When you click any shape on the map, a pop-up will show device-specific information. For subscriber shapes, it shows the following information:

- ONT Serial
- ONT Slot Name
- ONT Port Name
- OLT Name
- ONT State
- ONT Rx Power State
- ONT Tx Power State

For a split FAT shape, the pop-up shows the following information:

- Total ONT
- ONT Offline
- Percentage ONT Offline

## Changes

### Enhancements

#### Number ONT KPI improved [ID_37024]

The logic that calculates the Number ONT KPI at network level has been adjusted to provide a more accurate count of the ONTs in the system.

#### Improved EPM front-end ID request flow [ID_37036]

To improve the EPM front-end ID request flow, so that new entities are available to the user more quickly, the EPM front-end element now no longer has to assign IDs to the GPON CPE devices.
