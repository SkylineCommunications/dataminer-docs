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

#### Security enhancements [ID_37488]

<!-- RN 37488: MR 10.3.0 [CU9] - FR 10.3.12 -->

A number of security enhancements have been made.

### Fixes

#### Dashboards app: Problem with 'Clear all' button [ID_37232]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Clicking the *Clear all* button would incorrectly not clear the selection in certain components. Also, the parameters would not be removed from the dashboard's URL.

#### Dashboards app & Low-Code Apps - Table component: All table rows would incorrectly be exported when a filter was applied [ID_37473]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when you applied a filter to a table and then exported the data to a CSV file, all rows would incorrectly be exported. From now on, only the visible rows (i.e. the rows that match the filter) will be exported.

#### Dashboards app & Low-Code Apps - Table component: Exceptions would cause both an empty result message and an error message to be displayed [ID_37479]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

When GQI threw an exception when a session was opened, both an empty result message and an error message would be displayed on top of each other. From now on, when an exception is thrown, only an error message will be displayed.

#### Dashboards app: URL option 'showAdvancedSettings' was case sensitive [ID_37493]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, the *showAdvancedSettings* URL option would incorrectly be case sensitive. This option is now case insensitive.

#### Low-Code Apps: No longer possible to edit a low-code app of which the query migration had failed [ID_37501]

<!-- MR 10.3.0 [CU9] - FR 10.3.12 -->

Up to now, it would no longer be possible to edit a low-code app of which the query migration had failed.

From now on, when the query migration fails, the original query will be left untouched, allowing you to edit the app and fix any errors.
