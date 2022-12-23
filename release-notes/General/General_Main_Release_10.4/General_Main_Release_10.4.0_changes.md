---
uid: General_Main_Release_10.4.0_changes
---

# General Main Release 10.4.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### SLAnalytics: Number of 'GetParameterMessages' requests has been optimized [ID_34936]

<!-- MR 10.4.0 - FR 10.3.1 -->

The number of *GetParameterMessages* sent by SLAnalytics in order to check whether a trended table parameter is still active has been optimized.

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

#### SLAnalytics - Proactive cap detection: Enhanced accuracy when generating alarm predictions [ID_35080]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall accuracy has increased when generating alarm predictions.

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

#### SLAnalytics - Behavioral anomaly detection : More accurate change point time ranges [ID_35121]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, behavioral changes of the type "level shift", "trend change" and "variance change" will now have a more accurate time range when the change in behavior is sufficiently clear.

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

### Fixes

#### GQI: Problem when retrieving DCF interfaces [ID_34820]

<!-- MR 10.4.0 - FR 10.3.1 -->

When a GQI query returned all DCF interfaces from all agents in the DataMiner System, the NATS message broker would throw a *MaxPayloadException* when *MaxPayload* exceeded the value configured in `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`.

From now on, when a GQI query has to retrieve DCF interfaces, it will do so by querying one agent at a time.

#### Problem with Resource Manager when ResourceStorageType was not specified in Resource Manager settings [ID_34981]

<!-- MR 10.4.0 - FR 10.3.1 -->

In some cases, Resource Manager could throw a NullReferenceException when *ResourceStorageType* was not specified in the `C:\Skyline DataMiner\ResourceManager\Config.xml` file.

#### GQI: Problem when a column select or a column manipulation operator was applied before an aggregation operator [ID_35009]

<!-- MR 10.4.0 - FR 10.3.1 [CU0] -->

When a column select or a column manipulation operator was applied before an aggregation operator, the column select or column manipulation operator would incorrectly be ignored. As a result, all columns would be visible in the *group by node* or columns created by the column manipulation would not be added to the options of the *group by node*.

#### Dashboards app & Low-code apps - Parameter feed: Problem when more than 10,000 elements had to be retrieved from the server [ID_35186]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, the parameter feed used the element cache of the web client to populate its element list. As this cache can only hold up to 10,000 elements, this prevented the parameter feed from retrieving all elements when the cluster contained more than 10,000 elements.

From now on, when the parameter feed has a protocol or view filter, it will fetch all elements matching the filter page by page, even when the total number of elements exceeds 10,000.

#### Problem when a GQI message was sent asynchronously to SLNet [ID_35232]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a client asynchronously sent an GQI message to SLNet, in some cases, an exception could be thrown.
