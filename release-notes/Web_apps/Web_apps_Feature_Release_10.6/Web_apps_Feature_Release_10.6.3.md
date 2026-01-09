---
uid: Web_apps_Feature_Release_10.6.3
---

# DataMiner web apps Feature Release 10.6.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.5.0 [CU12].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.3](xref:General_Feature_Release_10.6.3).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.3](xref:Cube_Feature_Release_10.6.3).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards/Low-Code Apps: Enhanced component data mechanism [ID 44015]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Many components in dashboards and low-code apps can be configured to be linked to component data, i.e. data that is made available by other components in the dashboard or app. This mechanism has now been reworked in order to enhance overall performance, scalability, reliability and robustness.

#### Dashboards/Low-Code Apps - Column & bar chart component: Minor enhancements [ID 44416]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

A number of minor enhancements have been made to the *Column & bar chart* component.

For example, while data was being loaded, up to now, no loader bar would be displayed when a view was applied in the component. From now on, a loader bar will also be displayed when a view is applied.

Also, API calls will only be performed again when their arguments change, and no abort errors will be shown anymore.

### Fixes

#### Dashboards/Low-Code Apps: Maps component would incorrectly fetch markers with larger bounds than necessary when you zoomed in or out [ID 44381]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

In some cases, a *Maps* component would incorrectly fetch markers with larger bounds than necessary when you zoomed in or out.

As this issue has now been fixed, overall performance has increased when zooming in or out in a *Maps* component.

#### Web apps: Problem when deleting a web app [ID 44411]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, when a web app was deleted, its info file would get deleted first. However, without this file, it cannot be determined whether a user has permission to delete the app. Also, in cases where the delete operation would partially fail, the absence of the info file would make it impossible to retry the delete operation.

From now on, when a web app is deleted, its info file will be deleted last.

#### Dashboards/Low-Code Apps - Line & area chart component: More data points displayed than necessary when 'Trend points' was set to 'Average (fixed interval)' [ID 44422]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When in a *Line & area chart* component, the *Trend points* option was set to "Average (fixed interval)", in some cases, the trend graph would incorrectly display more data points than necessary.
