---
uid: MediaOps_1.3.1
---

# MediaOps 1.3.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Fixes

#### Resource Studio: Downgrading resource concurrency could cause sync issue [ID 43031]

When the concurrency of a resource was downgraded, this could result in conflicts for future jobs or bookings, which could in turn cause an incorrect concurrency to be visualized in Resource Studio, because the concurrency could not be lowered in DataMiner. Now when changing the concurrency will cause a conflict, the user will be prompted to confirm whether to proceed and jobs or bookings may be pushed into quarantine as a result.
