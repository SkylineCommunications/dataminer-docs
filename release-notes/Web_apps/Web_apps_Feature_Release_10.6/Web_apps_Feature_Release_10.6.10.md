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

#### GQI DxM: Ad hoc data sources can now expose static columns [ID 46050]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

GQI extensions can now use the `GQIStaticColumns` attribute on an ad hoc data source to indicate that its columns do not depend on any of the input arguments. This allows GQI to expose the columns even when the data source requires arguments during execution, for example, to filter or sort rows.

In addition, extension characteristics are now requested once during worker initialization instead of for every created instance. This reduces repeated capability checks and pipe serialization overhead.

#### Dashboards/Low-Code Apps: List component now uses the new search box for filtering [ID 46156]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

The List component now uses the new search box as its filter input, providing a more consistent experience across components. You can use the input to filter the list and clear the filter when needed.

#### Dashboards/Low-Code Apps: Alarm table now uses the new search box for filtering [ID 46160]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

The Alarm table component now uses the new search box as its filter input, providing a more consistent experience across components. You can use the input to filter the table and clear the filter when needed.

#### Dashboards/Low-Code Apps: Tree component now uses the new search box for filtering [ID 46164]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

The Tree component now uses the new search box as its filter input, providing a more consistent experience across components. You can use the input to filter the tree and clear the filter when needed.

#### Dashboards/Low-Code Apps: Trigger component now uses the new subtle button [ID 46166]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

The Trigger component now uses the new subtle button, providing a more consistent experience across components.

#### Dashboards/Low-Code Apps: Parameter picker now uses new input components [ID 46176]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

The Parameter picker component now uses the new search and dropdown inputs for filtering and grouping data, providing a more consistent experience across components.

#### GQI DxM: Enhanced performance when building queries [ID 46203]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, when GQI retrieved operator capabilities, internally, columns always had to be resolved twice. As, from now on, this is no longer necessary, overall performance will improve when building queries.

Also, a parameter table query problem has been fixed. Up to now, columns that were only needed internally to execute the query would also by default be included in the query result. This has now been changed. The behavior of the *Get parameter table by ID* data source has now been made consistent with that of every other data source.

### Fixes

#### Dashboards/Low-Code Apps: Element filter selection could fail while search results were loading [ID 46129]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When you selected an element in an element filter in edit mode, but search results were still loading, it could occur that the selection failed.

This issue has now been fixed, ensuring that element filter selection is no longer cleared by overlapping search requests.

#### Dashboards: Report configuration would incorrectly not be URL encoded when saved [ID 46136]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Some dashboards could not be used for report generation through the Scheduler when the dashboard name or folder path contained special characters, such as parentheses. In addition, the *Open in dashboards app* button did not work for these dashboards.

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

#### Dashboards: EPM picker component could disappear when updates were triggered quickly [ID 46165]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When updates were triggered very quickly on an EPM picker component, a change detection issue could occur that caused the component to disappear until a mouse event occurred.

#### Dashboards: Dashboard would incorrectly be visible without view rights on the root folder [ID 46200]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, in some cases, users without view rights on the root dashboards folder could incorrectly access dashboards located in subfolders if they had view rights on those subfolders.

#### GQI DxM: Optimized OR filters could be ignored on the right side of a join [ID 46201]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When a join query optimized the right-side query by adding an internal OR filter, the filter could be ignored when the query was reconstructed. As a result, filtering on the right side of the join could be skipped and the query could return additional rows.

The optimized OR filter is now preserved and applied correctly.

#### Web APIs: User settings could not be read on Dashboard Gateway setups [ID 46230]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

On a Dashboard Gateway setup, user settings could incorrectly be read from a local file. Since Dashboard Gateway setups do not provide direct file access, this could cause a *Local file access is required.* error when query actions needed those settings.

The required requests are now forwarded to the connected DMA instead.

#### GQI DxM: SLNet extension worker connections could be closed unreliably [ID 46231]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, SLNet pipe connections in the GQI extension worker could be closed unreliably, which could leave stale client state or delay disconnect handling during pipe shutdown.

From now on, closed client connections will be cleaned up more deterministically, improving the reliability of extension worker shutdown and subsequent queries.

#### Date/time inputs: Manual entry and in-progress edits could behave unreliably [ID 46248]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

In automation script UIs, date and time inputs could behave unexpectedly. In Firefox, when you manually entered values starting with `0` (e.g., `05` or `09`), the cursor could jump to another field too early. Also, if a live update arrived while you were editing a time input, your in-progress changes could be lost or focus could move unexpectedly.

Manual typing now behaves consistently across Firefox and Chromium-based browsers, and in-progress edits are preserved while you are still working in the field.
