---
uid: MediaOps_Live_1.0.1
---

# MediaOps Live 1.0.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Enhancements

#### Virtual Signal Groups: Various UI improvements [ID 45052]

Several improvements have been made to the UI of the Virtual Signal Groups app:

- The *Delete* button has been removed from the edit dialogs for endpoints, virtual signal groups, levels, and transport types. This functionality remains available elsewhere in the UI, and its presence in edit dialogs could be confusing.
- The *Edit* option has been removed from context menus, as the same action is already available via the pencil icon next to the menu.
- Save buttons are now consistently right-aligned.

## Fixes

#### Missing validation for profile parameter values [ID 45062]

Extra validation has been added to verify the values of profile parameters when orchestration events are saved in MediaOps Live. Previously, it was possible to assign a string value to a numeric profile parameter and vice versa. With this extra validation, this should no longer be possible.

When an orchestration event has incorrect values (saved before this change), it was no longer possible to open the configuration window in the app. This issue has also been resolved.
