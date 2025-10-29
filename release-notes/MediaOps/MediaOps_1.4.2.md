---
uid: MediaOps_1.4.2
---

# MediaOps 1.4.2 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires DataMiner 10.5.9/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Adding a resource with linked resource pool to a confirmed or running job could cause an empty node [ID 44030]

When a resource was added to a confirmed or running job, and that resource was part of a resource pool that had a linked resource pool using manual resource selection or without available resources, it could occur that this resource was not added as expected. This could lead to a confirmed or running job with an empty node.

To prevent this issue, when a resource is added to a confirmed or running job, any linked pools will now no longer be added. A pop-up message will inform the user of which pools were not added.
