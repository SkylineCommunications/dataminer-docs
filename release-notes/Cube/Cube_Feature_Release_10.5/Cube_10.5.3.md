---
uid: Cube_Feature_Release_10.5.3
---

# DataMiner Cube Feature Release 10.5.3

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU12].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.3](xref:General_Feature_Release_10.5.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.3](xref:Web_apps_Feature_Release_10.5.3).

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

#### System Center: Save the rights of a user group as a preset [ID 41656]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.3 [CU0] -->

In *System Center > Users/Groups > Groups*, it is now possible to save the rights of a user group as a preset, which can then be exported/imported as a JSON file.

Proceed as follows to grant all rights in an existing preset to a particular user group:

1. Select a user group.
1. Go to *Permissions > Rights*. On the right, you will see a list with all the available presets (including the built-in presets like *Administrators*).
1. Select a preset to grant all rights in that preset to the user group selected in step 1.
1. Click *Apply*.

When you have selected a user group, you will now also be able to choose the following preset-related commands:

| Command | Function |
|---------|----------|
| Save rights as preset... | Saves the currently selected rights to a preset.<br>Note: If the currently selected rights have already been saved to a preset, this command will be unavailable. |
| Export preset            | Opens a window that will allow you to export the currently selected rights to a preset file (in JSON format).<br>If no preset is selected when you click *Export preset*, you will be asked to enter the name of the preset.<br>Note: When you export a preset to a preset file, that file will have a version number. That number will be incremented each time changes are made as to file format or syntax. |
| Import preset            | Opens a window that will allow you to import a preset file.<br>If the name of the preset is identical to the one of an existing preset, and the currently selected rights do not entirely match the rights in the existing preset with the same name, then you will be asked whether you want to override the rights in the existing preset with the rights in the preset you are about to import. |
| Reset                    | Reverts all changes made to the rights of the currently selected user group. |
| Delete preset            | Deletes the currently selected preset.<br>Note: Built-in presets (e.g. *Administrators*) cannot be deleted. |

When you try to import

- a preset file without a version number or with version number 0, a message will appear, saying that the file version is not valid.
- a preset file of which the version is too recent, a message will appear, indicating both the version that is expected and the version of the file you are trying to import.
- a preset file that is not a valid JSON file, a message will appear, saying that the file could not be parsed.
- a preset file of which the permissions field is missing or of which the permissions field does not contain any presets, a message will appear, saying that the file does not contain exactly one preset.

> [!NOTE]
>
> - There is no command to rename a preset. To rename a preset, select it, delete it, and then save it again with another name.
> - If you make any changes to presets, those changes will not automatically be visible in other places (e.g. other cards within the same Cube session or other Cube sessions).
> - If you want to override a certain preset, then save it as a new preset using the same name. This way, the previously created preset with the same name will be overridden. However, note that if that preset is being used by other user groups, it will not be overridden there.

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

#### Ticketing app will no longer be available when the DMA does not have an indexing engine configured [ID 41895]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

in DataMiner Cube, from now on, the Ticketing app will no longer be available if the DataMiner Agent to which you are connected does not have an indexing engine configured.

#### Amazon Keyspaces Service is now end-of-life [ID 41874] [ID 41914]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

Support for Amazon Keyspaces Service is now officially end-of-life.

When you run the DataMiner installer or install a DataMiner upgrade package, the *VerifyNoAmazonKeyspaces* prerequisite will check whether the DataMiner Agent is configured to use a database of type *Amazon Keyspaces*. If so, the upgrade process will not be allowed to continue.

We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead. If you want to use self-hosted storage, install a [Cassandra Cluster](xref:Cassandra_database) database.

For more information, see [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service)

#### DataMiner Cube desktop app: Prevent a tile from being added when an identical tile already exists [ID 41899]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

A number of enhancements have been made to the DataMiner Cube desktop app to prevent an agent/cluster from being added when a tile for that agent/cluster already exists.

#### Alarm Console: Enhanced behavior of correlated alarms in linked alarm tabs [ID 41907]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

Up to now, when a correlated alarm appeared in a linked alarm tab because it matched the linked object, its base alarms would also appear in that alarm tab if they too matched the linked object. The behavior of correlated alarms in linked alarm tab has now been enhanced. See below.

- When the correlated alarm matches the linked object, but the base alarms do not, then only the correlated alarm will be shown.

- When the correlated alarm does not match the filter, but one or more of the base alarms do, then only those matching base alarms will be shown, even when *Correlation tracking* is enabled.

- When the correlated alarm matches the filter, and one or more of the base alarms also match the filter, then only the correlated alarm will be shown.

- When the correlated alarm does not match the filter, and none of the base alarms match the filter, then neither the correlated alarm nor the base alarms will be shown.

#### Alarm Console: Sound played when the alarm banner appears can now be disabled [ID 41982]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

When you enable the *Show in banner* option for a particular alarm tab, a banner will appear at the top of the Cube window when new alarms enter the tab. That banner will show the number of new alarms, the color of the most severe among them, and service impact information.

Up to now, each time the alarm banner appeared or was updated, a sound would be played. A new *Enable the sound for the alarm banner* setting has now been added in the *Alarm Console* section of the *Settings* window. This setting will allow you to indicate whether or not a sound should be played when the alarm banner appears or is updated. By default, a sound will be played.

#### Web apps: GQI DxM version displayed in About box [ID 42003]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

When a DataMiner web app is using the GQI DxM to build and run GQI queries, the version of the GQI DxM will now be displayed in the app's *About* box.

> [!NOTE]
> When the web app is using SLHelper instead of the GQI DxM, the *About* box will not display any GQI version. Instead, it will display "no DxM".

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

#### Visual Overview: AlarmSummary shapes linked to a function would not show the correct alarm color [ID 41916]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

When an *AlarmSummary* shape was linked to a function, the shape would not show the correct alarm color.

#### Swarming: Element selection in 'Element Swarming' window would be cleared when an element was created or deleted [ID 42079]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 -->

When, while a number of elements were selected in the *Element Swarming* window, an element was created or deleted in either the same client or another client, up to now, the element selection in the *Element Swarming* window would incorrectly be cleared.

#### Automation, Correlation & Scheduler apps - 'Send email' action: 'Configure' button would incorrectly not appear after a dashboard was selected [ID 42240]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When, while configuring a *Send email* action, you had attached a dashboard, the *Configure* button would incorrectly not appear.

#### Visual Overview: DataMiner Cube could stop working when Children shapes were being updated [ID 42304]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When *Children* shapes were being updated, in some cases, DataMiner Cube could stop working.
