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

#### Linked resource pools could cause confirmed jobs with missing resources [ID 44030]

When a resource pool with a linked resource pool was added to a confirmed or running job, and that linked resource pool used manual resource selection or did not have any available resources, the job could end up with nodes for which no resource was selected. Now a resource will be selected, and a pop-up message will inform the user of any pools that have not been added.
