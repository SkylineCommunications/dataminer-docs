---
uid: Cube_Feature_Release_10.5.3
---

# DataMiner Cube Feature Release 10.5.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.3](xref:General_Feature_Release_10.5.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.3](xref:Web_apps_Feature_Release_10.5.3).

## Highlights

*No highlights have been selected yet.*

## New features

#### System Center: Copying rights from one user group to one or more other user groups [ID 40803]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

In *System Center > Users/Groups > Groups*, it is now possible to copy the rights from one user group to one or more other users groups.

To do so, proceed as follows:

1. Select a user group.
1. Go to *Permissions > Rights*.
1. Click the *Copy rights...* button.

   The *Copy rights...* button will only be available if there are no pending changes to the rights in the user group you selected.

1. Select the groups to which you want the right to be copied.

   Users will only be able to copy rights to user groups they are allowed to edit. If you do not have permission to edit any of the user groups, a "No groups available" message will appear.

1. Click *Apply*.

## Changes

### Enhancements

#### DataMiner Cube desktop app: Enhanced configuration file management [ID 41808]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

A number of minor enhancements have been made to the DataMiner Cube desktop app with regard to configuration file management.

#### DataMiner Cube can no longer be deployed as a ClickOnce XBAP application [ID 41869] [ID 41873]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

From now on, it will no longer be possible to deploy DataMiner Cube as a ClickOne XBAP application.

### Fixes

#### Alarm Console: Alarms generated during the last week of 2024 would not be grouped correctly [ID 41867]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

In the Alarm Console, alarms generated during the last week of 2024 (i.e. week 53) would not be grouped correctly.
