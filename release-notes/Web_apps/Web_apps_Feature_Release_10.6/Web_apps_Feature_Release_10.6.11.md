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

#### Jobs app: All code has now been removed from the web repository [ID 46170]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

The Jobs module has been end-of-life since DataMiner 10.5.0. All code related to this module has now been removed from the web repository.

#### Dashboards/Low-Code Apps - Query builder: Hidden tree argument items are now excluded by default [ID 46246]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

In the query builder, tree argument items that are marked as hidden by GQI are now excluded by default.

To preserve backward compatibility, existing queries that already selected one of these hidden items can still be loaded and executed.

If you deselect such a hidden item, it remains available in that editing session. After you close and reopen the query builder, the hidden item is no longer offered as a selectable option.

### Fixes

#### Dashboards/Low-Code Apps: Linked dropdown components feeding data to each other could cause a dashboard or app to become unresponsive [ID 46314]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, when two dropdown components were configured to feed data to each other, in some cases, the dashboard or low-code app could become unresponsive.
