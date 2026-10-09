---
uid: Cube_Feature_Release_10.6.12
description: "Release notes for DataMiner Cube Feature Release 10.6.12, with new features, enhancements, and fixes planned for this preview release."
---

# DataMiner Cube Feature Release 10.6.12 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.12](xref:General_Feature_Release_10.6.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.12](xref:Web_apps_Feature_Release_10.6.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Spectrum: Measurement point selections are now synced between clients in shared mode [ID 46513]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a Spectrum component is in shared mode, its measurement point cycle is shared with other users. However, up to now, selecting or deselecting a measurement point would not immediately update the other connected clients.

From now on, changes to measurement point selections will immediately be pushed to the other clients.

> [!NOTE]
> This feature will only work in conjunction with DataMiner server version 10.7.0/10.6.12 or newer.

#### Spectrum: Shared-mode users can now control how configuration changes are applied [ID 46514]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a user changed the configuration of a Spectrum component in shared mode, up to now, the changes were not immediately reflected in other clients. From now on, the user can right-click the *x clients* button and select *Push changes to other users*. Other users will then receive a banner where they can apply or ignore the changes. Closing the Spectrum card also triggers the banner.

The *Spectrum card behavior upon last session preset modification in shared mode* setting, under *Settings* > *Card*, will control how other clients handle pushed changes:

- *Notify* (default) will display the banner.
- *Skip* will prevent notifications and updates.
- *Update automatically* will apply pushed changes without displaying a warning.

#### Spectrum: Automatic standby will no longer be applied in shared mode [ID 46574]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a Spectrum card is open, it automatically enters standby mode after the configured inactivity period. From now on, this will no longer happen when the Spectrum component is in shared mode. In addition, the standby options in the ribbon will now be disabled.

#### Spectrum: Preset section of Spectrum component has been adapted to the new theme [ID 46591]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

The *Preset* section on the right side of a Spectrum component has now been adapted to the new theme.

### Fixes

#### Spectrum: Marker was shown on the first trace instead of the trace where it was added [ID 46290]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you selected several measurement points in a Spectrum component and added a marker to a trace other than the first one, the marker was shown on the first trace when you reopened the card or loaded a preset.

The marker will now be shown on the trace where you added it.

#### Profiles: Instances, parameters, or definitions could be incorrectly marked as modified [ID 46468]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

In some cases, a profile instance, a profile parameter, or a profile definition was marked as modified even though no changes had been made to it. This could happen when the server and client stored the same properties in different orders, causing Cube to detect a change.

Cube now compares profile instances, parameters, and definitions independently of property order, so differences in ordering no longer cause them to be marked as modified.

#### Service & Resource Management: Unavailable resource status could be selected manually [ID 46490]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, when you created or edited a resource in the Resources module in DataMiner Cube, you could select *Unavailable* in the *Status* box. This allowed you to manually set a resource to an invalid status.

The *Status* box will now only offer *Available* and *Maintenance*. If a resource is already set to *Unavailable*, its current status will still be displayed. Once you change it, you will only be able to select *Available* or *Maintenance*.

#### Spectrum: Last Session Preset could not be saved after loading a custom preset in shared mode [ID 46516]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you opened a Spectrum component in shared mode and loaded a custom preset, up to now, it would no longer be possible to save the Last Session Preset. As a result, changes made to the custom preset could not be pushed to the other clients.

#### Spectrum: Preset loading flags would incorrectly affect other sessions [ID 46517]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you loaded a preset in a Spectrum component, changing the preset loading flags would incorrectly affect all sessions instead of only the current session.

From now on, changes to preset loading flags will only be applied to the current session.

#### Spectrum: Banner would incorrectly always be shown to the user who pushed changes in shared mode [ID 46518]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, when you pushed changes to other users from a Spectrum component in shared mode, you would incorrectly always receive a banner indicating that changes were available.

From now on, when you push changes to other users in shared mode, you will only receive a banner when multiple Spectrum components are open in your own session. Other users will always receive a banner.

#### Spectrum: 'Push to other clients' button would incorrectly be enabled when not in shared mode [ID 46519]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a Spectrum component was not in shared mode, up to now, the *Push changes to other users* button would incorrectly be enabled, even though nothing happened when clicking it.

From now on, the button will be disabled when the Spectrum component is not in shared mode.

#### Spectrum: Shared-mode banner could be too small in Visual Overview [ID 46520]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you viewed a Spectrum component in shared mode in Visual Overview, in some cases, the banner indicating that another user had pushed changes could be too small to use.

The banner will now be displayed clearly, even when the component has limited space.

#### Backup module was unavailable in mixed DaaS systems [ID 46528]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, the Backup module was unavailable whenever DaaS was enabled, including systems that also contained non-DaaS agents. As a result, it was not possible to configure or run backups for non-DaaS agents in these mixed environments.

From now on, the Backup module will be available in mixed environments. It will only include non-DaaS agents, and backup settings and operations will be applied only to those agents.

The module will remain unavailable when all agents in the system are DaaS agents.

#### System Center - Agents: Warning messages could be incorrect when adding or removing an Agent [ID 46550]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

On DataMiner 10.6.0 and newer, when you added or removed an Agent in Cube, up to now, incorrect warning messages could be displayed because Cube would incorrectly still check the legacy `NATSForceManualConfig` and `BrokerGateway` soft-launch flags.

#### Spectrum: Display settings would not always be applied when loading a new preset [ID 46555]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, when you created a preset in a Spectrum session in shared mode and then loaded it in another session, in some cases, the display settings would not be applied, even when the option to load them was selected.

From now on, display settings will be applied whenever the option to load them is selected.

#### Spectrum: Average trace visibility would no longer be saved in presets [ID 46585]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Because of an issue, the visibility of the average trace in the Spectrum component would no longer be saved in presets. As a result, reopening a preset would not restore the visibility of the average trace.

From now on, Cube will again save and restore this setting with the preset.

#### Spectrum: Thresholds could be missing when loading a preset [ID 46622]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you loaded a preset containing a threshold in a Spectrum component, in some cases, the threshold could be missing.

The threshold will now be displayed when the preset is loaded.

#### Spectrum: Banner text was unclear after a Last Session Preset change [ID 46668]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When another session changed the Last Session Preset of a Spectrum analyzer in shared mode, the banner in Cube said, "This spectrum element has changes to its currently loaded preset." Because this wording referred to a preset rather than the session that made the change, it could be unclear.

The banner now says, "Another session has made changes to this spectrum analyzer."

#### Data Display: Full-screen button did not work in pop-up windows [ID 46742]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a table was displayed in a pop-up window before the Surveyor had been opened in the current workspace, up to now, the full-screen button would not work.

From now on, the full-screen and exit-full-screen buttons will both work. You will be able to expand and restore tables in pop-up windows without first opening the Surveyor.
