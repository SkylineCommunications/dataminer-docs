---
uid: Web_apps_Feature_Release_10.3.12
---

# DataMiner web apps Feature Release 10.3.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.12](xref:General_Feature_Release_10.3.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Dashboards app: Problem with 'Clear all' button [ID_37232]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Clicking the *Clear all* button would incorrectly not clear the selection in certain components. Also, the parameters would not be removed from the dashboard's URL.

#### Dashboards app: All table rows would incorrectly be exported when a filter was applied [ID_37473]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you applied a filter to a table and then exported the data to a CSV file, all rows would incorrectly be exported. From now on, only the visible rows (i.e. the rows that match the filter) will be exported.

#### Dashboards app: URL option 'showAdvancedSettings' was case sensitive [ID_37493]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, the *showAdvancedSettings* URL option would incorrectly be case sensitive. This option is now case insensitive.
