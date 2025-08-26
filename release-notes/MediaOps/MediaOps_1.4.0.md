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

#### Scheduling: Improvements to capability and capacity filters and node configuration [ID 43553]

In the *Edit job* panel, when nodes are added or resources are picked or swapped for a job, the capability and capacity filters used will now be saved in the node configuration the moment the button to add a node or pick/swap a resource is clicked. This will make sure that the filters used to find a resource are available for when a resource is swapped for a node. As the changes of the filter are only applied when the swap button is clicked, this also means that it is now possible to swap resources for nodes while changing the capabilities at the same time.

#### Cleanup of objects created by older MediaOps versions [ID 43566]

When a MediaOps upgrade package is installed, a number of predefined existing scripts and DOM definitions created by older versions of MediaOps will now first be cleaned up.

For each major version, this predefined list will be reset. Consequently, when you upgrade across major versions (e.g. from 1.x.x to 2.x.x), we recommend upgrading to the latest version of the current major version first before moving to the next major version, to ensure that these cleanup actions have taken place at least once.

### Fixes

#### Resource Studio: Incorrect step size after change to number of decimals of capacity or configuration parameter of type number [ID_43580]

When capacity or configuration parameters of type number were defined, it could occur that the step size did not update after the number of decimals was changed, which could lead to unwanted behavior when the parameter was used in the Scheduler app. The UI has now been improved to prevent this: other fields that are affected by changes will now be updated or highlighted.
