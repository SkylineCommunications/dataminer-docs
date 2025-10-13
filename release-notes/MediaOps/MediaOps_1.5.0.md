---
uid: MediaOps_1.5.0
---

# MediaOps 1.5.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

> [!NOTE]
> This release also includes the enhancements and fixes of the 1.4.x releases.

### Enhancements

#### Resource Studio: Improved feedback and visibility when deprecating or restoring multiple resources [ID 43804]

On the *Resources* page of the Resource Studio app, when a large number of resources are deprecated or restored, a loading indicator is now displayed, providing feedback on the action in progress. In addition, when you start an action to deprecate or restore multiple resources, you will now first be asked to confirm the action.

### Fixes

#### Scheduling: Action buttons missing in Edit Job panel after reverting job status to Tentative [ID 43808]

When the status of a job was reverted from Confirmed to Tentative, it could occur that action buttons for the job were no longer displayed in the Edit Job panel.
