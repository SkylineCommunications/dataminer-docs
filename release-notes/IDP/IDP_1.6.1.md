---
uid: IDP_1.6.1
---

# IDP 1.6.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This IDP version requires that DataMiner 10.4.0 [CU0] or higher is installed.

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Enabling extended logging could abort discovery [ID 44331]

When extended logging was enabled on the IDP Discovery element, this could cause a discovery action to be aborted.

#### Shared folder for configuration archive incorrectly reported as unavailable [ID 44436]

In some cases, it could occur that the configuration archive reported a disconnected or unavailable status for the configured shared folders even though the connection was fine. This especially occurred when the shared folder had not been accessed for a while. To prevent this, the connection check has now been replaced with a more accurate implementation.

#### Credential conflicts for configuration archive shared folders caused unnecessary account lockouts [ID 44450]

When credential conflicts for session-global SMB connections occurred with the credentials used for the configuration archive shared folders, these conflicts were incorrectly treated as authentication failures, leading to unnecessary account lockouts. To prevent this, IDP will now attempt to resolve these conflicts by disconnecting the existing session before retrying. If a conflict persists, IDP will use the existing session but log a warning regarding potential file permission issues.
