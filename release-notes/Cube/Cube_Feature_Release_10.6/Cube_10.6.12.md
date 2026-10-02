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

### Fixes

#### Spectrum: Marker was shown on the first trace instead of the trace where it was added [ID 46290]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you selected several measurement points in a Spectrum component and added a marker to a trace other than the first one, the marker was shown on the first trace when you reopened the card or loaded a preset.

The marker will now be shown on the trace where you added it.

#### Profiles: Instances, parameters, or definitions could be incorrectly marked as modified [ID 46468]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

In some cases, a profile instance, a profile parameter, or a profile definition was marked as modified even though no changes had been made to it. This could happen when the server and client stored the same properties in different orders, causing Cube to detect a change.

Cube now compares profile instances, parameters, and definitions independently of property order, so differences in ordering no longer cause them to be marked as modified.

#### System Center - Agents: Warning messages could be incorrect when adding or removing an Agent [ID 46550]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

On DataMiner 10.6.0 and newer, when you added or removed an Agent in Cube, up to now, incorrect warning messages could be displayed because Cube would incorrectly still check the legacy `NATSForceManualConfig` and `BrokerGateway` soft-launch flags.

#### Spectrum: Average trace visibility would no longer be saved in presets [ID 46585]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Because of an issue, the visibility of the average trace in the Spectrum component would no longer be saved in presets. As a result, reopening a preset would not restore the visibility of the average trace.

From now on, Cube will again save and restore this setting with the preset.

#### Spectrum: Thresholds could be missing when loading a preset [ID 46622]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you loaded a preset containing a threshold in a Spectrum component, in some cases, the threshold could be missing.

The threshold will now be displayed when the preset is loaded.
