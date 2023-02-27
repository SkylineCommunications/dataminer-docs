---
uid: Web_apps_Main_Release_10.4.0_changes
---

# DataMiner web apps Main Release 10.4.0 – Changes – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### Web apps - Interactive Automation scrips: Fields containing invalid values will now be indicated more clearly [ID_34962]

<!-- MR 10.4.0 - FR 10.3.2 -->

When, in an Automation script launched from a web app, an input field contains an invalid value, the border of that field will turn red. This red border will now be wider in order to be more visible.

#### GQI: Enhanced performance of GQI queries [ID_34977]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries has increased, especially when those queries contain join operations.

#### GQI: Enhanced performance of GQI queries using the 'Get parameters for elements where' data source [ID_35005]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries using the *Get parameters for elements where* data source has increased.

#### Dashboards app - Line & area chart: Multiple timespans will now be converted to one single time range [ID_35008]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a line & area chart component is fed a collection of timespans, it will now convert those timespans to one single time range.

For example, when a line & area chart component is fed the following timespans...

- *01/01/2022 9:00:00 > 01/01/2022 10:00:00*
- *01/01/2022 9:30:00 > 01/01/2022 10:30:00*

... it will convert those timespans into the following time range:

- *01/01/2022 9:00:00 > 01/01/2022 10:30:00*

#### GQI: Enhanced performance when using Sort operators in conjunction with alarm, change point, trend pattern and trend pattern occurrence data sources [ID_35031]

<!-- MR 10.4.0 - FR 10.3.3 -->

Because of a number of enhancements, overall query performance has increased when using Sort operators in conjunction with the following data sources:

- Get alarms
- Get behavioral change events
- Get trend data patterns
- Get trend data pattern events

#### Web apps: Button styles used in interactive Automation script components have been aligned with those used in low-code app components [ID_35076]

<!-- MR 10.4.0 - FR 10.3.2 -->

In the web apps, the button styles used in interactive Automation script components have now been fully aligned with those used in low-code app components.

#### Web app: More detailed version information in About box [ID_35090]

<!-- MR 10.4.0 - FR 10.3.2 -->

In the *About* box of a web application, you can now find more detailed version information.

| Old name | New name | Description |
|----------|----------|-------------|
| - | Server version | Server version and build number of the DataMiner Agent |
| Client build | Web version | Build number of the web app |
| Client version | App | Version number of the web app |
| Server API version | API | Version number of the Web Services API |

#### GQI: Enhanced query performance when aggregation operations are followed by a filter [ID_35110]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall query performance has increased, especially in cases where aggregation operations are followed by a filter.

#### Dashboards - GQI components: Enhanced behavior when loading data [ID_35148]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, a loading skeleton would be displayed each time data was being loaded into a GQI component (e.g. a node edge graph). From now on, only when the component was empty will a loading skeleton be displayed. When existing data in the component is being refreshed, a loader bar will now be displayed instead.

#### Web apps: Enhanced performance when retrieving a list of users [ID_35150]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a web app requests a list of users, the Web Services API will now cache the result set it receives from the server. This will increase overall performance, especially in situations where, up to now, the same list of users had to be retrieved frequently.

This user cache will be cleared each time a change occurs that has security implications (e.g. new users added, user permissions updated, etc.).

#### Dashboards app - Line & area chart component: 'Group by' setting will now by default be set to 'All together' [ID_35160]

<!-- MR 10.4.0 - FR 10.3.2 -->

In case a *Line & area chart* component displays trending for multiple parameters, the *Group by* setting allows you to specify how the graphs should be grouped. From now on, this *Group by* setting will by default be set to "All together".

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

#### GQI: data sources 'Get elements' and 'Get services' will now also return alarm states [ID_35464]

<!-- MR 10.4.0 - FR 10.3.3 -->

The GQI data sources *Get elements* and *Get services* will now also return alarm states.

#### GQI: 'State' column in data sources 'Get services' and 'Get views' renamed to 'Alarm state' [ID_35557]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the GQI data sources *Get services* and *Get views*, the *State* column has now been renamed to *Alarm state*.

### Fixes

#### GQI: Problem when retrieving DCF interfaces [ID_34820]

<!-- MR 10.4.0 - FR 10.3.1 -->

When a GQI query returned all DCF interfaces from all agents in the DataMiner System, the NATS message broker would throw a *MaxPayloadException* when *MaxPayload* exceeded the value configured in `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`.

From now on, when a GQI query has to retrieve DCF interfaces, it will do so by querying one agent at a time.

#### GQI: Problem when a column select or a column manipulation operator was applied before an aggregation operator [ID_35009]

<!-- MR 10.4.0 - FR 10.3.1 [CU0] -->

When a column select or a column manipulation operator was applied before an aggregation operator, the column select or column manipulation operator would incorrectly be ignored. As a result, all columns would be visible in the *group by node* or columns created by the column manipulation would not be added to the options of the *group by node*.

#### Dashboards app & Low-Code Apps - Parameter feed: Problem when more than 10,000 elements had to be retrieved from the server [ID_35186]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, the parameter feed used the element cache of the web client to populate its element list. As this cache can only hold up to 10,000 elements, this prevented the parameter feed from retrieving all elements when the cluster contained more than 10,000 elements.

From now on, when the parameter feed has a protocol or view filter, it will fetch all elements matching the filter page by page, even when the total number of elements exceeds 10,000.

#### Dashboards app & Low-code apps: Issues with regard to data highlighting [ID_35250]

<!-- MR 10.4.0 - FR 10.3.2 -->

A number of issues with regard to data highlighting have been fixed.

#### Dashboards app: Problem when trying to open a shared dashboard [ID_35271]

<!-- MR 10.4.0 - FR 10.3.3 -->

When users tried to open a shared dashboard, in some cases, they would unexpectedly be presented with a login screen due to a permission issue.

Workaround: Recreate the faulty shared dashboard.

#### Dashboards - Line & area chart component: Timestamps could be formatted incorrectly when exporting trend data to CSV [ID_35311]

<!-- MR 10.4.0 - FR 10.3.3 -->
<!-- See Enhancements for rest of 35311 -->

When trend data was exported to a CSV file, up to now, timestamps could be formatted incorrectly.

#### Dashboards app & Low-code apps - GQI table component: 'Cannot read properties of undefined (reading 'Guid')' error [ID_35316]

<!-- MR 10.4.0 - FR 10.3.2 [CU0] -->

In some cases, a GQI table component could show a `Cannot read properties of undefined (reading 'Guid')` error.

#### Web apps: Problems with Visual Overview components [ID_35399]

<!-- MR 10.4.0 - FR 10.3.3 -->

A number of issues regarding the Visual Overview component have been fixed.

- In some cases, the Visual Overview component would send an excessive amount of polling requests.
- When a page was selected in the Visual Overview component, in some cases, an incorrect page would be displayed.
- In some cases, the dimensions of pop-up windows would be incorrect.
- When a pop-up window was shown using a *VdxShape* property, in some cases, the default page would be shown instead of the page that was specified.

#### Dashboards app: Visualization picker would incorrectly resize when you hovered over it [ID_35516]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you tried to select a visualization for a newly added component that did not yet have one, the visualization picker would incorrectly resize the first time you hovered over it.
