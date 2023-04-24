---
uid: Web_apps_Feature_Release_10.3.3
---

# DataMiner web apps Feature Release 10.3.3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.3](xref:General_Feature_Release_10.3.3).

## Highlights

#### Dashboards app - GQI: New data sources [ID_34747] [ID_35027] [ID_34965] [ID_35058]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the Generic Query Interface, the following new data sources are now available:

| Data source                   | Contents                                                   |
|-------------------------------|------------------------------------------------------------|
| Get trend data patterns       | All pattern matching tags created in the DataMiner System. |
| Get trend data pattern events | All pattern occurrences detected in the DataMiner System.  |
| Get behavioral change events  | All behavioral anomalies detected in the DataMiner System. |

The *Get trend data pattern events* and *Get behavioral change events* data sources contain time range metadata on each row. Each time range holds the start and end time of the event in question. When a table row is selected, the time range will be exposed as a feed.

#### Dashboards app & Low-Code Apps - GQI: 'Row by row' option [ID_35057] [ID_35565]

<!-- MR 10.4.0 - FR 10.3.3 -->

When configuring a Join operator, you can now select the *Row by row* option.

- When you do not select the *Row by row* option, the join will execute both the left and the right queries once, and directly combine their results (default behavior).

- When you select the *Row by row* option, the join will execute the left query first, and then execute the right query for each row  with a filter derived from the Join condition.

> [!NOTE]
>
> - The *Row by row* option will only be visible and configurable when you opened the dashboard or app with `showAdvancedSettings=true` added to the URL.
> - Currently, the *Row by row" option is only supported for inner and left joins. If you use it for an outer or right join, an exception will be thrown.

## Other features

#### Monitoring app: Element name added to breadcrumbs of trend card [ID_35270]

<!-- MR 10.4.0 - FR 10.3.3 -->

As of now, the header of a trend card shows a breadcrumb trail with the element name of a parameter as a clickable item. Clicking this element name allows you to quickly navigate back to the element card.

#### GQI: 'State' column added to 'Get views' data source [ID_35333]

<!-- MR 10.4.0 - FR 10.3.3 -->

A `State` column has been added to the *Get views* data source. This column shows the alarm state of the view.

#### GQI: Multiple groupBy operations can now be applied after an aggregation operation [ID_35355]

<!-- MR 10.4.0 - FR 10.3.3 -->

After an aggregation operation, you can now apply multiple groupBy operations.

#### Dashboards app - GQI: New 'Get parameter relations' data source [ID_35443]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the Generic Query Interface, the *Get parameter relations* data source is now available.

It can be used to retrieve the parameter relationships that are stored in a model managed by a DataMiner Extension Module named *ModelHost*.

> [!NOTE]
> This data source will only be available when *ModelHost* is running.

## Changes

### Enhancements

#### GQI: Enhanced performance when using Sort operators in conjunction with alarm, change point, trend pattern and trend pattern occurrence data sources [ID_35031]

<!-- MR 10.4.0 - FR 10.3.3 -->

Because of a number of enhancements, overall query performance has increased when using Sort operators in conjunction with the following data sources:

- Get alarms
- Get behavioral change events
- Get trend data patterns
- Get trend data pattern events

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

#### Dashboards app - EPM parameter selector: Data retrieved from the collector that was displayed as a table with a single row will now be displayed as single parameters [ID_35412]

<!-- MR 10.3.0 - FR 10.3.3 -->

In an EPM parameter selector, in some cases, data retrieved from the collector was displayed as a table with a single row, which often had the system name as primary key.

From now on, data retrieved from the collector that used to be displayed as a table with a single row will now be displayed as single parameters (one for every column).

#### Chart components will now display GQI and configuration errors [ID_35445]

<!-- MR 10.3.0 - FR 10.3.3 -->

From now on, a chart component will display an error when the GQI query that retrieves data for that chart component throws an error, or when the chart component is not configured correctly.

#### GQI: data sources 'Get elements' and 'Get services' will now also return alarm states [ID_35464]

<!-- MR 10.4.0 - FR 10.3.3 -->

The GQI data sources *Get elements* and *Get services* will now also return alarm states.

#### Support for GQI queries from Data Aggregator with ad hoc data sources [ID_35526]

<!-- MR 10.4.0 - FR 10.3.3 -->

GQI now supports queries from [Data Aggregator](xref:Data_Aggregator_DxM) that use ad hoc data sources.

#### Enhanced performance when opening a web app [ID_35549]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Because DataMiner web apps will now be passed to client machines as compressed files, overall performance has increased when opening a web app.

#### GQI: 'State' column in data sources 'Get services' and 'Get views' renamed to 'Alarm state' [ID_35557]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the GQI data sources *Get services* and *Get views*, the *State* column has now been renamed to *Alarm state*.

### Fixes

#### GQI: Problem when fetching two queries using an external data source with a custom argument of which the ID was set to "Type" [ID_35242]

<!-- MR 10.3.0 - FR 10.3.3 -->

When two queries using an external data source with a custom argument of which the ID was set to "Type" had to be fetched, only one of the two queries would get fetched when the only difference between them was the value of the custom argument.

#### Dashboards app: Problem when trying to open a shared dashboard [ID_35271]

<!-- MR 10.3.0 [CU3] - FR 10.3.3 -->

When users tried to open a shared dashboard, in some cases, they would unexpectedly be presented with a login screen because of a permission issue.

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

#### Dashboards app & Low-Code Apps - Line & area chart component: Problems when visualizing resource availability [ID_35408]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a dashboard or a low-code app, a *Line & area chart* component was used to visualize the capacity usage over time of a resource, it would incorrectly take into account bookings that had been canceled. Also, when two or more bookings ended at the same, it would not show the capacity usage in a correct way, and when there was no booking in the selected time range, it would show an error.

In the latter case, it will now instead show a flat line indicating that the resource is not being used.

#### Dashboards app: Problem with line & area chart component when dashboard was shared [ID_35422]

<!-- MR 10.3.0 - FR 10.3.3 -->

When, in a dashboard, a line & area chart component had its *Hide non-trended parameters* option selected, errors could start to appear inside that component when the dashboard was shared.

#### Dashboards app: Problem with 'Preserve feed selections' option [ID_35438]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you select the *Preserve feed selections* option for a particular dashboard folder, any feed selection you make in a dashboard in that folder is preserved when you navigate to another dashboard in that same folder.

Up to now, in some cases, one folder would incorrectly take over feed selections from another folder.

#### Low-Code Apps: Problem when creating a new draft version [ID_35446]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a draft version of a low-code app, you opened the version panel and created a new draft, the previous draft version would incorrectly loaded instead of the published version.

#### Dashboards app: Time range feeds would trigger components more often than required [ID_35460]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Time range feeds would trigger components more often than required, causing them to send an excessive number of requests.

#### Web apps: An invalid value entered into a text box would incorrectly be replaced by the last valid value that was entered [ID_35489]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 -->

When you entered an invalid value into a text box, an error message would be displayed for a very short moment, and the invalid value would incorrectly be replaced by the last valid value that was entered.

#### Low-Code Apps: Panels of which the 'Fit to view' option was selected would incorrectly switch to mobile mode [ID_35542]

<!-- MR 10.3.0 - FR 10.3.3 -->

Panels of which the *Fit to view* option was selected would incorrectly switch to mobile mode when their width got too small. From now on, panels of which the *Fit to view* option is selected will never switch to mobile mode.

#### Web apps: No longer possible to clear a radio button group [ID_35603]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 [CU0] -->

It would incorrectly no longer be possible to clear a radio button group.

#### Web apps: Auto-complete control could clear its content while you were entering a value [ID_35623]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 [CU0] -->

In some cases, an auto-complete control could clear its content while you were entering a value.
