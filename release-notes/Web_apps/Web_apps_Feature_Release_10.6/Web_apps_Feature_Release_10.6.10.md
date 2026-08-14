---
uid: Web_apps_Feature_Release_10.6.10
---

# DataMiner web apps Feature Release 10.6.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU7].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.10](xref:General_Feature_Release_10.6.10).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.10](xref:Cube_Feature_Release_10.6.10).

## Highlights

*No highlights have been selected yet.*

## New features

*This release does not contain any new features yet.*

## Changes

### Enhancements

#### Dashboards/Low-Code Apps: Discrete filtering now uses OR filters instead of RegexFilter when GQI DxM is enabled [ID 46015]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

For the query filter and table component, the filtering for discrete columns now uses OR filtering in GQI. Previously, the filtering was done by creating a regex that combined the selected display values. The adjusted filtering behavior is more predictable, preventing possible issues in case a value is different from the display value.

This only applies when the GQI DxM is enabled.

### Fixes

#### Dashboards/Low-Code Apps: Element filter selection could fail while search results were loading [ID 46129]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When you selected an element in an element filter in edit mode, but search results were still loading, it could occur that the selection failed.

This issue has now been fixed, ensuring that element filter selection is no longer cleared by overlapping search requests.

#### Dashboard Gateway: Error while initializing themes on Dashboard Gateway setup [ID 46147]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

While initializing the themes functionality, a Dashboard Gateway setup could throw a null error, which was shown in the logging. This issue has been resolved.

#### Dashboards/Low-Code Apps - Query builder: Not possible to add multiple datetime filters [ID 46152]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

In the query builder, it is was not possible to add a filter after another filter on a datetime column that was linked to data.

#### Dashboards/Low-Code Apps: Query filter not applied when both Boolean options were selected [ID 46155]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

In the query filter component, no filtering was applied when both options in a Boolean column (`true` and `false`) were selected. Now, instead an "Is one of" filter is applied with both values, filtering out empty cells. The filter selection is also stored in the URL and restored when the dashboard is reloaded.

This only applies when the GQI DxM is enabled. SLHelper filtering is unaffected.
