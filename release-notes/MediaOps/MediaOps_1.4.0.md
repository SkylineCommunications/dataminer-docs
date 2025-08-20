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

#### Cleanup of objects created by older MediaOps versions [ID 43566]

When a MediaOps upgrade package is installed, a number of predefined existing scripts and DOM definitions created by older versions of MediaOps will now first be cleaned up.

For each major version, this predefined list will be reset. Consequently, when you upgrade across major versions (e.g. from 1.x.x to 2.x.x), we recommend upgrading to the latest version of the current major version first before moving to the next major version, to ensure that these cleanup actions have taken place at least once.
