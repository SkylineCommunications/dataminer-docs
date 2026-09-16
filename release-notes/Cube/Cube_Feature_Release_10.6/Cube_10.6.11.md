---
uid: Cube_Feature_Release_10.6.11
---

# DataMiner Cube Feature Release 10.6.11 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU8].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.11](xref:General_Feature_Release_10.6.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.11](xref:Web_apps_Feature_Release_10.6.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Jobs: All references with regard to the Jobs module will now be hidden when connected to a DMA running version 10.5.X or newer [ID 46180]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

The Jobs module has been end-of-life since DataMiner 10.5.0. If Cube is connected to a DataMiner Agent running version 10.5.X or newer, from now on, it will hide all references with regard to this module.

### Automation script editor: Enhanced way of selecting credentials [ID 46251]

<!-- MR 10.7.0 - FR 10.6.11 -->

When, in DataMiner Cube, you add a set of credentials in the automation script editor, you will now first have to select a credentials type.

After you select a type, Cube will only show credentials of that type that you are allowed to use. If you change the selected type afterwards, the selected credentials will be cleared and you will have to select a new set of credentials.

You cannot save the script until both a credentials type and a set of credentials have been selected.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.7.0/10.6.10 or newer.

### Fixes

#### Alarm Console: Enabling the 'Severity duration' column could cause Cube to stop working [ID 46256]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

When you connected to a DataMiner Agent with a large number of active alarms while the *Severity duration* column was enabled on the *Active alarms* tab, in some rare cases, Cube could stop working.

In addition, the severity duration could be calculated incorrectly when an alarm was updated after its severity had remained unchanged for a long time.

#### System Center - Agents: Hostnames could incorrectly be accepted when adding an Agent to a cluster [ID 46334]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

When you manually added an Agent to a cluster in the *Add Agent* dialog, up to now, Cube could accept a hostname instead of requiring an IP address.
