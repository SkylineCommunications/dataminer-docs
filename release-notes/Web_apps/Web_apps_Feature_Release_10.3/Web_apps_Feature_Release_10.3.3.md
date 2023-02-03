---
uid: Web_apps_Feature_Release_10.3.3
---

# DataMiner web apps Feature Release 10.3.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.3](xref:General_Feature_Release_10.3.3).

## Highlights

*No highlights have been selected for this release yet*

## Other new features

#### Dashboards app - GQI: New data sources [ID_34747] [ID_35027] [ID_34965] [ID_35058]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the Generic Query Interface, the following new data sources are now available:

| Data source                   | Contents                                                   |
|-------------------------------|------------------------------------------------------------|
| Get trend data patterns       | All pattern matching tags created in the DataMiner System. |
| Get trend data pattern events | All pattern occurrences detected in the DataMiner System.  |
| Get behavioral change events  | All behavioral anomalies detected in the DataMiner System. |

The *Get trend data pattern events* and *Get behavioral change events* data sources contain time range metadata on each row. Each time range holds the start and end time of the event in question. When a table row is selected, the time range will be exposed as a feed.

#### GQI: 'State' column added to 'Get views' data source [ID_35333]

<!-- MR 10.4.0 - FR 10.3.3 -->

A `State` column has been added to the *Get views* data source. This column shows the alarm state of the view.

#### GQI: Multiple groupBy operations can now be applied after an aggregation operation [ID_35355]

<!-- MR 10.4.0 - FR 10.3.3 -->

After an aggregation operation, you can now apply multiple groupBy operations.

## Changes

### Enhancements

#### Web apps: Enhanced color picker [ID_35276]

<!-- MR 10.4.0 - FR 10.3.3 -->

A number of enhancements have been made to the color picker.

#### Dashboards - Line & area chart component: 'Show average', 'Show minimum' and 'Show maximum' options will now be taken into account when exporting trend data to CSV [ID_35311]

<!-- MR 10.4.0 - FR 10.3.3 -->
<!-- Timestamp format fix added to Fixes -->

When exporting trend data to CSV, from now on, the *Show average*, *Show minimum* and *Show maximum* options will be taken into account.

> [!NOTE]
>
> - When the *Show min/max shading* option is enabled (which it is by default), minimum and maximum values will always be included when you export trend data.
> - As the *Show min/max shading* option and the *Show average* option are both enabled by default, a CSV export of trend data will by default contain all trend data values.

#### Errors received from the web API after sending a GetConnection call will now be logged in SLNet.txt [ID_35313]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when SLNet receives an error from the web API after sending a *GetConnection* call, it will log the request and the response in the *SLNet.txt* log file.

### Fixes

#### GQI: Problem when fetching two queries using an external data source with a custom argument of which the ID was set to "Type" [ID_35242]

<!-- MR 10.3.0 - FR 10.3.3 -->

When two queries using an external data source with a custom argument of which the ID was set to "Type" had to be fetched, only one of the two queries would get fetched when the only difference between them was the value of the custom argument.

#### Dashboards app: Problem when trying to open a shared dashboard [ID_35271]

<!-- MR 10.4.0 - FR 10.3.3 -->

When users tried to open a shared dashboard, in some cases, they would unexpectedly be presented with a login screen due to a permission issue.

Workaround: Recreate the faulty shared dashboard.

#### Dashboards - Line & area chart component: Timestamps could be formatted incorrectly when exporting trend data to CSV [ID_35311]

<!-- MR 10.4.0 - FR 10.3.3 -->
<!-- See Enhancements for rest of 35311 -->

When trend data was exported to a CSV file, up to now, timestamps could be formatted incorrectly.

#### Web apps: Problems with Visual Overview components [ID_35399]

<!-- MR 10.4.0 - FR 10.3.3 -->

A number of issues regarding the Visual Overview component have been fixed.

- In some cases, the Visual Overview component would send an excessive amount of polling requests.
- When a page was selected in the Visual Overview component, in some cases, an incorrect page would be displayed.
- In some cases, the dimensions of pop-up windows would be incorrect.
- When a pop-up window was shown using a *VdxShape* property, in some cases, the default page would be shown instead of the page that was specified.

#### Dashboards app & Low-code apps - Line & area chart component: Problems when visualizing resource availability [ID_35408]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a dashboard or a low-code app, a *Line & area chart* component was used to visualize the capacity usage over time of a resource, it would incorrectly take into account bookings that had been canceled. Also, when two or more bookings ended at the same, it would not show the capacity usage in a correct way, and when there was no booking in the selected time range, it would show an error.

In the latter case, it will now instead show a flat line indicating that the resource is not being used.

#### Dashboards app: Problem with 'Preserve feed selections' option [ID_35438]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you select the *Preserve feed selections* option for a particular dashboard folder, any feed selection you make in a dashboard in that folder is preserved when you navigate to another dashboard in that same folder.

Up to now, in some cases, one folder would incorrectly take over feed selections from another folder.

#### Low-code apps: Problem when creating a new draft version [ID_35446]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a draft version of a low-code app, you opened the version panel and created a new draft, the previous draft version would incorrectly loaded instead of the published version.

#### Dashboards app: Time range feeds would trigger components more often than required [ID_35460]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Time range feeds would trigger components more often than required, causing them to send an excessive number of requests.
