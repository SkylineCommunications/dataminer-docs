---
uid: Web_apps_Feature_Release_10.6.6
---

# DataMiner web apps Feature Release 10.6.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU3].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.6](xref:General_Feature_Release_10.6.6).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.6](xref:Cube_Feature_Release_10.6.6).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Dashboards/Low-Code Apps: Problem when themes were being migrated when the DMA was offline [ID 45020]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When themes were being migrated, in some cases, an exception could be thrown when the DataMiner Agent was offline.

#### GQI DxM unavailable because of missing Newtonsoft.Json assembly [ID 45146]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

After an upgrade from DataMiner web 10.5.0 CU0, 10.5.2, or 10.5.3 to a higher version, the GQI DxM would be unavailable in the DataMiner web apps. Also, the GQI logging would contain a message stating `Could not load file or assembly 'Newtonsoft.Json'`.
