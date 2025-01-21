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

#### System Center - Logging: Consulting DxM logs [ID 41674]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

In the *Logging* section of *System Center*, the *DataMiner* tab now also allows you to consult the logs of the different DataMiner Extension Modules (DxMs).

> [!NOTE]
> These DxM logs have a predefined log level that cannot be changed.

## Changes

### Enhancements

#### Visual Overview: Load times shown in SPI logging will now take into account the loading states of pending child shapes [ID 41517]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

In *System Center*, the *Cube* tab of the *Logging* section can be set to show SPI logging. This logging includes entries that show how long it took for Visual Overview pages to get loaded. From now on, the load times shown in those entries will also take into account the loading states of pending child shapes (i.e. child shapes that have placeholders that have not yet been resolved). Also, child shapes will now inherit any *EnableLoading* option that was set on shape, page, or system level.

> [!NOTE]
>
> - Because of the changes that were made, you may notice more loading bars than before when opening visual overviews. If you want to reduce the number of loading bars, make sure the shapes resolve or add the *EnableLoading=False* option to the shapes that do not resolve.
> - Mobile visual overviews only render their images when loading stops or when a one-minute timeout is reached. In setups where child shapes are not loaded and the *EnableLoading* option is set to true, the visual overview will only appear after 1 minute.
> - After shape loading has reached the two-minute timeout, or after you have cancelled loading by clicking *X* on the loading bar, you can check the debug logging to find out which shapes are still pending.

#### DataMiner Cube desktop app: Enhanced configuration file management [ID 41808]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

A number of minor enhancements have been made to the DataMiner Cube desktop app with regard to configuration file management.

#### DataMiner Cube desktop app: Users will no longer be able to simultaneously update the configuration file [ID 41851]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

A number of enhancements have been made to the DataMiner Cube desktop app to prevent users from simultaneously updating the configuration file.

#### DataMiner Cube will no longer be available as XBAP application [ID 41869] [ID 41873]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

From now on, DataMiner Cube will no longer be available as XBAP application.

#### Amazon Keyspaces Service is now end-of-life [ID 41874] [ID 41914]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

Support for Amazon Keyspaces Service is now officially end-of-life.

When you run the DataMiner installer or install a DataMiner upgrade package, the *VerifyNoAmazonKeyspaces* prerequisite will check whether the DataMiner Agent is configured to use a database of type *Amazon Keyspaces*. If so, the upgrade process will not be allowed to continue.

We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead. If you want to use self-hosted storage, install a [Cassandra Cluster](xref:Cassandra_database) database.

For more information, see [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service)

#### Alarm Console: Enhanced behavior of correlated alarms in linked alarm tabs [ID 41907]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

Up to now, when a correlated alarm appeared in a linked alarm tab because it matched the linked object, its base alarms would also appear in that alarm tab if they too matched the linked object. The behavior of correlated alarms in linked alarm tab has now been enhanced. See below.

- When the correlated alarm matches the linked object, but the base alarms do not, then only the correlated alarm will be shown.

- When the correlated alarm does not match the filter, but one or more of the base alarms do, then only those matching base alarms will be shown, even when *Correlation tracking* is enabled.

- When the correlated alarm matches the filter, and one or more of the base alarms also match the filter, then only the correlated alarm will be shown.

- When the correlated alarm does not match the filter, and none of the base alarms match the filter, then neither the correlated alarm nor the base alarms will be shown.

### Fixes

#### DataMiner Cube desktop app: Some Cube sessions would not get closed correctly [ID 41831]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

When a Cube session was closed, in some cases, the DataMiner Cube desktop app would not end the session correctly.

#### Trending: Open trend graph would not reflect alarm template changes [ID 41835]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

When an alarm template was updated while a trend graph containing parameters from that template was being displayed, in some cases, the trend graph would incorrectly not get updated. As a result, the graph would not reflect the changes that were made to the alarm template.

#### Alarm Console: Alarms generated during the last week of 2024 would not be grouped correctly [ID 41867]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

In the Alarm Console, alarms generated during the last week of 2024 (i.e. week 53) would not be grouped correctly.

#### Settings: Problem when interpreting the value of the 'Parameter display mode' setting [ID 41890]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

In the *User > Data Display* section of the *Settings* window, the *Parameter display mode* setting allows you to specify whether you want Cube to use normal parameter controls or lite parameter controls.

Up to now, Cube would check the value of this setting ("Normal" or "Lite") depending on the UI language. As a result, when that language was set to a language other than English, in some cases, the value of this setting would be interpreted incorrectly.

From now on, Cube will check whether the value is the default setting (i.e. "Normal") or not. In the latter case, Cube will use the lite parameter controls.
