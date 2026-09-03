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

When, in DataMiner Cube, you add a credential in the Automation script editor, you will now first have to select a credential type.

After you select a type, Cube will only show credentials of that type that you are allowed to use. If you change the selected type afterwards, the selected credential will be cleared and you will have to select a new credential.

You cannot save the script until both a credential type and a credential have been selected.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.7.0/10.6.10 or newer.

### Fixes

*No fixes have been added yet.*
