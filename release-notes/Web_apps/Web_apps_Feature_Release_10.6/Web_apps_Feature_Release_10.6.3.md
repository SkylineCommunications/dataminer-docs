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

#### Dashboards app: New Add button in navigation pane [ID 44432]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

In the navigation pane, a new *Add* button is now available to users with permission to add dashboards.

- Clicking *Add* will create a new dashboard.
- Clicking the down arrow on the right will open a menu with the following commands:

  - Create dashboard
  - Create folder
  - Import dashboard
  - Import from catalog

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

#### DataMiner upgrade: New internal setting to allow or forbid installers to downgrade [ID 44441]

<!-- MR 10.7.0 - FR 10.6.3 -->

Up to now, every installer included in a DataMiner web upgrade package was allowed to downgrade, and every installer in a full DataMiner server upgrade package was forbidden to downgrade.

From now on, when a DataMiner web upgrade package is created, it will be possible to explicitly indicate that certain installers are forbidden to downgrade, and when a full DataMiner server upgrade package is created, it will be possible to explicitly indicate that certain installers are allowed to downgrade.

#### Dashboards app: List of recently opened dashboards will now be sorted chronologically [ID 44452]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

In the sidebar of the Dashboards app, up to now, the list of recently opened dashboards would be sorted alphabetically. From now on, the dashboards in that list will be sorted by the time at which they were opened, from most recent to least recent.

#### Dashboards/Low-Code Apps - GQI components: 'Empty result message' setting can now be cleared [ID 44472]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

In the *Table*, *Column & bar chart*, *Line & area chart*, *Pie & donut chart*, *Grid*, *Timeline*, and *Node edge graph* components, the *Empty result message* setting allows you to specify a custom message that is displayed when a query returns no results.

From now on, it will be possible to clear this setting's value. If you do so, no message will be displayed when a query returns no results, and the component will be empty.

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

#### Dashboards/Low-Code Apps -Timeline component: Scrolling could cause the groups to no longer be aligned with the timeline items [ID 44445]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When you scrolled inside a *Timeline* component in which multiple groupings were applied, in some cases, the different groups would no longer be aligned with the timeline items.

#### Dashboards/Low-Code Apps -Timeline component: Problem after a transition from summer time to winter time or vice versa [ID 44455]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When the DataMiner Agent had a fixed time zone, and the client computer had a time zone with a daylight saving time, up to now, transitioning from summer time to winter time and vice versa could yield unexpected results in a *Timeline* component. For example, timeline items could be too long or too short, be positioned incorrectly, or even be missing.

From now on, all timeline items will be displayed correctly after a transition from summer time to winter time or vice versa.

#### Dashboards/Low-Code Apps - Alarm table component: Problem when an alarm was removed from a group that had been deleted earlier [ID 44463]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When the alarms in an *Alarm table* component are grouped by time, they are grouped under group names such as "Today", "Yesterday", and "Last Week".

Up to now, when a certain group name had been removed (e.g. by means of an Automation script), and an alarm under that group name returned to its normal state, an error would occur when the *Alarm table* component attempted to remove the alarm.
