---
uid: Web_apps_Feature_Release_10.6.11
---

# DataMiner web apps Feature Release 10.6.11 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU8].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.11](xref:General_Feature_Release_10.6.11).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.11](xref:Cube_Feature_Release_10.6.11).

## Highlights

*No highlights have been selected yet.*

## New features

*This release does not contain any new features yet.*

## Changes

### Enhancements

#### GQI DxM: Write-only parameter table columns are now excluded by default [ID 46033]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Some protocol parameters are write-only (e.g., buttons or action/configuration fields) and do not return readable values. Up to now, these columns could still appear in default output or in query-builder capabilities for parameter-related data sources.

From now on, write-only columns are retained for backward compatibility but excluded from default selections and from new capability choices.

Existing queries can still resolve and run if such columns were already explicitly referenced. If a write-only column is explicitly selected, it remains available for subsequent operators such as *Filter*, *Sort*, *Aggregate*, and *Join*.

### Fixes

*No fixes have been selected yet.*
