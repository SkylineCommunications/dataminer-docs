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

#### Orchestration API: New AsyncExecuteEventsNow method [ID 45298]

When a job with orchestration events was started manually, up to now those events were always triggered synchronously, which could cause issues in case an event took a long time or timed out, as this would block the Scheduling user interface.

To prevent this, a new *AsyncExecuteEventsNow* method has now been added next to the *ExecuteEventsNow* method. This makes it possible to execute the orchestration events in a non-blocking, asynchronous way, so the Scheduling UI remains responsive. Any failing events will continue to be reflected on the job and visualized in the UI.

#### Clear exception thrown for connect/disconnect operations with destination endpoint without assigned element [ID 45299]

Any script that attempts a connect or disconnect with a destination endpoint that has no element assigned will now receive a clear exception instead of a silent skip or an vague null reference exception:

`Cannot resolve destination elements. Missing element for endpoints: <list of endpoints>`

#### Virtual Signal Groups: Improved error messages when deleting an object in use [ID 45314]

In the Virtual Signal Groups app, deleting an object that was still in use previously resulted in a generic error message. For example, when attempting to delete a transport type that was still referenced, users would see a message such as `One or more transport types are still in use.` This made it difficult to identify where the object was still being used. Similar behavior occurred when deleting endpoints, transport types, and levels.

This has now been improved. Error messages will provide more detailed information by explicitly listing the objects that reference the item that is being deleted. For example:

`Cannot delete transport type 'name' because it is referenced by level 'Video' and endpoints '...', '...', '...'.`

If more than five references exist, the list is truncated, which is indicated with an ellipsis.

## Fixes

#### Missing validation for profile parameter values [ID 45062]

Extra validation has been added to verify the values of profile parameters when orchestration events are saved in MediaOps Live. Previously, it was possible to assign a string value to a numeric profile parameter and vice versa. With this extra validation, this should no longer be possible.

When an orchestration event has incorrect values (saved before this change), it was no longer possible to open the configuration window in the app. This issue has also been resolved.

#### Control Surface app not working because of virtual signal group with non-existing endpoint [ID 45289]

If a virtual signal group referenced an endpoint that no longer existed, an exception in an ad hoc data source could cause the Control Surface app to stop working. This issue has now been resolved.

#### Control Surface: Virtual signal group data not refreshed after changes were implemented in Virtual Signal Group app [ID 45297]

The following refresh issues have been resolved in the Control Surface app:

- When you searched for a specific virtual signal group in the Control Surface app and then updated the name of that virtual signal group in the Virtual Signal Groups app, the Control Surface app kept displaying the old name unless the new name matched the applied search filter. Only after the search field was updated, were the changes shown.
- When you used the Control Surface app to view virtual signal groups that were part of a selected category, and you then updated the content of that category in the Virtual Signal Groups app, those changes were not applied in the Control Surface app until you navigated to a different category.

#### Destinations remained locked when disconnect did not succeed [ID 45301]

After an orchestration job that connected and disconnected source and destination virtual signal groups, it could occur that the destinations incorrectly remained locked. This happened when a disconnect operation was not supported by the connection handler script or was not executed because of an exception. Destinations are now always unlocked at the end of a job, even if the connection remains active.
