---
uid: Cube_Feature_Release_10.6.10
---

# DataMiner Cube Feature Release 10.6.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU7].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.10](xref:General_Feature_Release_10.6.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.10](xref:Web_apps_Feature_Release_10.6.10).

## Highlights

*No highlights have been selected yet.*

## New features

*This release does not contain any new features yet.*

## Changes

*This release does not contain any enhancements yet.*

### Fixes

#### Alarm templates: Absolute proactive thresholds showed percentages instead of delta values [ID 46049]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

In alarm templates, proactive thresholds of type *Absolute* were displayed with a percentage sign in the *Thresholds to take into account* setting (e.g., *Critical High (5000000 %)*).

This has now been corrected. Absolute thresholds are now shown with a delta prefix and no percentage sign (e.g., *Critical High (Δ 5000000)*), consistent with the regular alarm template editor.

#### Upgrades: End time was not always set correctly in the Overview tab [ID 46100]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When you performed a DataMiner upgrade, it could occur that the end time in the *Overview* tab was not always set correctly. This issue has been resolved.

#### Spectrum Analysis: Measurement point cycle could be reset when the same spectrum element was opened in another component [ID 46111]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When you opened a spectrum element in one spectrum analysis component and then opened the same element in another component with measurement points selected, the measurement point cycle in the first component could be reset. This issue has been resolved.
