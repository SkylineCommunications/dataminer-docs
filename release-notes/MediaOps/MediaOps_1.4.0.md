---
uid: MediaOps_1.4.0
---

# MediaOps 1.4.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## New features

#### Scheduling: Creating a job in the tentative state [ID 43448]

While previously new jobs were always created in the draft state, now it is also possible to create a job in the tentative state. This has the advantage that the resources are immediately assigned to the job and checked for conflicts.

## Changes

### Enhancements

#### Scheduling: Improved capability and capacity filtering when manipulating nodes [ID 43553]

When resources are added, picked, or swapped, the capability and capacity filters used will now take effect the moment the add, pick, or swap action is executed. In the past, configuration and node manipulations had to happen separately, which could lead to challenges when swapping resources while changing capabilities. Now it is possible to swap resources while changing the capabilities at the same time.

#### Cleanup of objects created by older MediaOps versions [ID 43566]

When a MediaOps upgrade package is installed, a number of predefined existing scripts and DOM definitions created by older versions of MediaOps will now first be cleaned up.

For each major version, this predefined list will be reset. Consequently, when you upgrade across major versions (e.g. from 1.x.x to 2.x.x), we recommend upgrading to the latest version of the current major version first before moving to the next major version, to ensure that these cleanup actions have taken place at least once.

### Fixes

#### Resource Studio: Incorrect step size after change to number of decimals of capacity or configuration parameter of type number [ID_43580]

When capacity or configuration parameters of type number were defined, it could occur that the step size did not update after the number of decimals was changed, which could lead to unwanted behavior when the parameter was used in the Scheduler app. The UI has now been improved to prevent this: other fields that are affected by changes will now be updated or highlighted.
